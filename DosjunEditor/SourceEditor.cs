using FastColoredTextBoxNS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DosjunEditor
{
    public partial class SourceEditor : Form, IResourceEditor
    {
        private Style comment = new TextStyle(Brushes.Green, null, FontStyle.Italic);
        private Style keyword = new TextStyle(Brushes.Blue, null, FontStyle.Bold);
        private string keywordRegex;

        public SourceEditor()
        {
            GetRegex();
            InitializeComponent();
        }

        ~SourceEditor()
        {
            comment.Dispose();
            keyword.Dispose();
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
            keywordRegex = $@"\b({string.Join("|", Jun.Env.Keywords)})\b";
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
            e.ChangedRange.SetStyle(comment, @"#.*$", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(keyword, keywordRegex);

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
            catch (Jun.CodeException ex)
            {
                MessageBox.Show(ex.Message, "Tokenizing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                parser.Parse(tokenizer.Tokens);
            }
            catch (Jun.CodeException ex)
            {
                // delete temporary 
                foreach (CompiledScript scr in parser.TemporaryScripts)
                {
                    Context.Djn.Remove(scr.Resource.ID);
                }

                MessageBox.Show(ex.Message, "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // copy all compiled scripts into the container
            foreach (Jun.Script js in parser.Scripts)
            {
                ushort id = parser.Constants[js.Name];
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
