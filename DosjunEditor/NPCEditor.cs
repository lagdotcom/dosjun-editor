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
    public partial class NPCEditor : Form, IResourceEditor
    {
        public NPCEditor()
        {
            InitializeComponent();

            AttitudeBox.Minimum = short.MinValue;
            AttitudeBox.Maximum = short.MaxValue;

            foreach (string name in Tools.GetEnumNames<Pronouns>('/'))
                PronounsBox.Items.Add(name);
        }

        public IHasResource Editing => NPC;
        public NPC NPC { get; private set; }
        public Context Context { get; private set; }

        public event EventHandler Saved;

        public void Setup(Context ctx, IHasResource r)
        {
            Context = ctx;
            NPC = r as NPC;

            Globals.Populate(PortraitBox, Context.Djn.Portraits);

            AttitudeBox.Value = NPC.Attitude;
            NameBox.Text = ctx.GetString(NPC.NameId);
            PortraitBox.SelectedItem = Globals.Resolve(ctx, NPC.PortraitId);
            PronounsBox.SelectedIndex = (int)NPC.Pronouns;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            NPC.Attitude = (short)AttitudeBox.Value;
            NPC.NameId = Context.GetStringId(NameBox.Text, NPC.NameId);
            NPC.PortraitId = (PortraitBox.SelectedItem as Resource).ID;
            NPC.Pronouns = (Pronouns)PronounsBox.SelectedIndex;

            Saved?.Invoke(this, null);
            Context.UnsavedChanges = true;
            Close();
        }
    }
}
