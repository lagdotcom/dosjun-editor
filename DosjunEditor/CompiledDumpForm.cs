using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DosjunEditor
{
    public partial class CompiledDumpForm : Form, IResourceEditor
    {
        public CompiledDumpForm()
        {
            InitializeComponent();
        }

        public IHasResource Editing => Script;
        public CompiledScript Script { get; private set; }
        public event EventHandler Saved;
        public Context Context { get; private set; }

        public void Setup(Context ctx, IHasResource r)
        {
            Context = ctx;
            Script = r as CompiledScript;

            Jun.Script scr = new Jun.Script
            {
                Code = Script.Bytecode.ToList(),
                Name = r.Resource.Name,
                Type = r.Resource.Flags.HasFlag(ResourceFlags.Private) ? Jun.ScriptType.State : Jun.ScriptType.Script,
            };

            DumpBox.Text = Jun.Visualizer.Show(new Jun.Script[] { scr })
                .Replace("\n", "\r\n");
            DumpBox.Select(0, 0);
        }
    }
}
