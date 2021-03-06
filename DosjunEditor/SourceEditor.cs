﻿using DosjunEditor.Jun.Ex;
using FastColoredTextBoxNS;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DosjunEditor
{
    public partial class SourceEditor : Form, IResourceEditor
    {
        private Style comment = new TextStyle(Brushes.Green, null, FontStyle.Italic);
        private Style keyword = new TextStyle(Brushes.Blue, null, FontStyle.Bold);
        private Style reference = new TextStyle(Brushes.Red, null, FontStyle.Regular);
        private Style constant = new TextStyle(Brushes.Purple, null, FontStyle.Regular);
        private Style @internal = new TextStyle(Brushes.Orange, null, FontStyle.Regular);
        private string keywordRegex;
        private string constantRegex;
        private string internalRegex;

        public SourceEditor()
        {
            GetRegex();
            InitializeComponent();
        }

        public new void Dispose()
        {
            comment.Dispose();
            keyword.Dispose();
            reference.Dispose();
            constant.Dispose();
            @internal.Dispose();
        }

        public Context Context { get; private set; }
        public ScriptSource Source { get; private set; }
        public IHasResource Editing => Source;

        public event EventHandler Saved;

        public void Setup(Context ctx, IHasResource r)
        {
            Context = ctx;
            Source = r as ScriptSource;

            CodeSource.Text = Source.Source;
        }

        private void GetRegex()
        {
            keywordRegex = $@"\b({string.Join("|", Jun.Env.Commands.Keys)})\b";
            constantRegex = $@"\b({string.Join("|", Jun.Env.Constants.Keys)})\b";
            internalRegex = $@"\b({string.Join("|", Jun.Env.Internals.Keys)})\b";
        }

        private void Save()
        {
            Source.Source = CodeSource.Text;

            Context.UnsavedChanges = true;
            Saved?.Invoke(this, null);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void CodeSource_TextChanged(object sender, TextChangedEventArgs e)
        {
            e.ChangedRange.ClearStyle(comment);
            e.ChangedRange.ClearStyle(keyword);
            e.ChangedRange.ClearStyle(reference);
            e.ChangedRange.ClearStyle(constant);
            e.ChangedRange.ClearStyle(@internal);
            e.ChangedRange.SetStyle(comment, @"#.*$", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(keyword, keywordRegex);
            e.ChangedRange.SetStyle(reference, @"\$\w+\b");
            e.ChangedRange.SetStyle(constant, constantRegex);
            e.ChangedRange.SetStyle(@internal, internalRegex);

            //e.ChangedRange.ClearFoldingMarkers();
            //e.ChangedRange.SetFoldingMarkers(@"Script\b", @"EndScript\b");
            //e.ChangedRange.SetFoldingMarkers(@"State\b", @"EndState\b");
        }

        private void Compile_Click(object sender, EventArgs e)
        {
            Save();

            Jun.Tokenizer tokenizer = new Jun.Tokenizer(Context);
            Jun.Parser parser = new Jun.Parser(Context);

            try
            {
                tokenizer.Tokenize(Source.Source.Split('\n'));
            }
            catch (JunException ex)
            {
                MessageBox.Show(ex.Message, "Tokenizing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CodeSource.Focus();
                CodeSource.Selection = new Range(CodeSource, tokenizer.Column - 1, tokenizer.Line - 1, tokenizer.Column, tokenizer.Line - 1);
                return;
            }

            try
            {
                parser.Parse(tokenizer.Tokens);
            }
            catch (JunException ex)
            {
                // delete temporary 
                foreach (CompiledScript scr in parser.TemporaryScripts)
                {
                    Context.Djn.Remove(scr.Resource.ID);
                }

                MessageBox.Show(ex.Message, "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CodeSource.Focus();
                CodeSource.Selection.Start = new Place(0, parser.LineNumber);
                CodeSource.SelectNext(@"\w+");
                return;
            }

            // copy all compiled scripts into the container
            foreach (Jun.Script js in parser.Scripts)
            {
                short id = parser.Constants[js.Name];
                CompiledScript scr = Context.Djn[id] as CompiledScript;

                scr.Resource.Flags = js.Public ? ResourceFlags.None : ResourceFlags.Private;
                scr.Resource.OnlyDesign = false;
                scr.Bytecode = js.Code.ToArray();
            }

            Context.UnsavedChanges = true;
            MessageBox.Show("Compiled!");
        }
    }
}
