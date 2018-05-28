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
        private List<NumericUpDown> jobLevels;
        private List<InventoryEdit> items;

        public PCEditor()
        {
            InitializeComponent();
            XPBox.Maximum = uint.MaxValue;

            AttitudeBox.Minimum = short.MinValue;
            AttitudeBox.Maximum = short.MaxValue;

            foreach (string name in Tools.GetEnumNames<Job>())
                JobBox.Items.Add(name);

            foreach (string name in Tools.GetEnumNames<Pronouns>('/'))
                PronounsBox.Items.Add(name);

            jobLevels = new List<NumericUpDown>();
            JobLayout.RowCount = 0;
            JobLayout.RowStyles.Clear();
            foreach (string job in Tools.GetEnumNames<Job>())
            {
                Label lbl = new Label {
                    Dock = DockStyle.Fill,
                    Text = job,
                    TextAlign = ContentAlignment.MiddleLeft,
                };
                NumericUpDown lvl = new NumericUpDown {
                    Dock = DockStyle.Fill,
                    Maximum = Globals.MaxJobLevel,
                };

                JobLayout.Controls.Add(lbl, 0, jobLevels.Count);
                JobLayout.Controls.Add(lvl, 1, jobLevels.Count);

                jobLevels.Add(lvl);
            }

            items = new List<InventoryEdit>();
            for (int i = 0; i < Globals.InventorySize; i++)
            {
                InventoryEdit ie = new InventoryEdit
                {
                    Dock = DockStyle.Top,
                };

                InventoryBox.Controls.Add(ie);
                items.Add(ie);
            }
        }

        public Context Context { get; private set; }
        public PC PC { get; private set; }
        public IHasResource Editing => PC;
        public event EventHandler Saved;

        public void Setup(Context ctx, IHasResource r)
        {
            Context = ctx;
            PC = r as PC;

            Globals.Populate(PortraitBox, Context.Djn.Portraits);

            AttitudeBox.Value = PC.Attitude;
            BackRowBox.Checked = PC.Flags.HasFlag(PCFlags.BackRow);
            JobBox.SelectedIndex = (int)PC.Job;
            NameBox.Text = ctx.GetString(PC.NameId);
            PartyBox.Checked = PC.Flags.HasFlag(PCFlags.InParty);
            PortraitBox.SelectedItem = Globals.Resolve(ctx, PC.PortraitId);
            PronounsBox.SelectedIndex = (int)PC.Pronouns;
            StatBoxes.Stats = PC.Stats;
            XPBox.Value = PC.Experience;

            for (int i = 0; i < Globals.NumJobs; i++)
                jobLevels[i].Value = PC.JobLevels[i];

            for (int i = 0; i < Globals.InventorySize; i++)
            {
                items[i].Context = ctx;
                items[i].Item = PC.Items[i];
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            PCFlags flags = PCFlags.None;

            if (BackRowBox.Checked) flags |= PCFlags.BackRow;
            if (PartyBox.Checked) flags |= PCFlags.InParty;

            PC.Attitude = (short)AttitudeBox.Value;
            PC.Experience = (uint)XPBox.Value;
            PC.Flags = flags;
            PC.Job = (Job)JobBox.SelectedIndex;
            PC.NameId = Context.GetStringId(NameBox.Text, PC.NameId);
            PC.PortraitId = (PortraitBox.SelectedItem as Resource).ID;
            PC.Pronouns = (Pronouns)PronounsBox.SelectedIndex;
            StatBoxes.Apply();

            for (int i = 0; i < Globals.NumJobs; i++)
                PC.JobLevels[i] = (ushort)jobLevels[i].Value;

            for (int i = 0; i < Globals.InventorySize; i++)
                items[i].Apply();

            Saved?.Invoke(this, null);
            Context.UnsavedChanges = true;
            Close();
        }
    }
}
