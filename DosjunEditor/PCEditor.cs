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
    public partial class PCEditor : Form, IResourceEditor
    {
        public PCEditor()
        {
            InitializeComponent();
            XPBox.Maximum = uint.MaxValue;

            foreach (string name in Tools.GetEnumNames<Job>())
                JobBox.Items.Add(name);

            foreach (string name in Tools.GetEnumNames<Pronouns>('/'))
                PronounsBox.Items.Add(name);
        }

        public Context Context { get; private set; }
        public PC PC { get; private set; }
        public IHasResource Editing => PC;
        public event EventHandler Saved;

        public void Setup(Context ctx, IHasResource r)
        {
            Context = ctx;
            PC = r as PC;

            JobBox.SelectedIndex = (int)PC.Job;
            NameBox.Text = ctx.GetString(PC.NameId);
            PronounsBox.SelectedIndex = (int)PC.Pronouns;
            StatBoxes.Stats = PC.Stats;
            XPBox.Value = PC.Experience;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            PC.Experience = (uint)XPBox.Value;
            PC.Job = (Job)JobBox.SelectedIndex;
            PC.NameId = Context.GetStringId(NameBox.Text, PC.NameId);
            PC.Pronouns = (Pronouns)PronounsBox.SelectedIndex;
            StatBoxes.Apply();

            Saved?.Invoke(this, null);
            Context.UnsavedChanges = true;
            Close();
        }
    }
}
