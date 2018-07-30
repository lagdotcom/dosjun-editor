using System;
using System.Windows.Forms;

namespace DosjunEditor
{
    public partial class ETableForm : Form
    {
        private Row[] rows;
        private int maximum;
        private byte count;

        public ETableForm()
        {
            InitializeComponent();
        }

        private void SetMaximum(int max)
        {
            maximum = max;

            PossibilitiesBox.Maximum = maximum;
            rows = new Row[maximum];
            for (var i = 0; i < maximum; i++)
            {
                rows[i] = new Row(i, this);
            }
        }

        public Context Context { get; private set; }
        public ETable ETable { get; private set; }
        public Zone Zone { get; private set; }

        public void Setup(Context ctx, Zone zone, ETable etable)
        {
            Context = ctx;
            Zone = zone;
            ETable = etable;

            SetMaximum(Globals.ETableSize);
            ShowPossibilities(ETable.Possibilities);
        }

        public void Apply()
        {
            ETable.Possibilities = count;
            for (var i = 0; i < maximum; i++)
            {
                if (i < count)
                {
                    ETable.Percentages[i] = rows[i].Percentage;
                    ETable.EncounterIds[i] = rows[i].EncounterId;
                }
                else
                {
                    ETable.Percentages[i] = 0;
                    ETable.EncounterIds[i] = 0;
                }
            }
        }

        private void ShowPossibilities(byte poss)
        {
            count = poss;
            PossibilitiesBox.Value = poss;
            for (var i = 0; i < maximum; i++)
            {
                rows[i].Show(i < poss);
            }
        }

        private class Row
        {
            private bool updating;

            public Row(int index, ETableForm parent)
            {
                Parent = parent;

                Percentage = ClampPercentage(Parent.ETable.Percentages[index]);
                EncounterId = ClampIndex(Parent.ETable.EncounterIds[index]);

                PercentageBox = new NumericUpDown()
                {
                    Minimum = 1,
                    Maximum = 100,
                    Dock = DockStyle.Fill,
                    Value = Percentage
                };
                PercentageBox.ValueChanged += PercentageBox_ValueChanged;

                EncounterBox = new ComboBox()
                {
                    Dock = DockStyle.Fill
                };
                EncounterBox.SelectedIndexChanged += EncounterBox_SelectedIndexChanged;
                RefreshEncounterList();

                Parent.EncounterTable.Controls.Add(PercentageBox, 0, index);
                Parent.EncounterTable.Controls.Add(EncounterBox, 1, index);
            }

            private void PercentageBox_ValueChanged(object sender, EventArgs e)
            {
                Percentage = (byte)PercentageBox.Value;
            }

            private void EncounterBox_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (!updating)
                    EncounterId = (ushort)EncounterBox.SelectedIndex;
            }

            public ETableForm Parent { get; private set; }
            public byte Percentage { get; private set; }
            public ushort EncounterId { get; private set; }
            public NumericUpDown PercentageBox { get; private set; }
            public ComboBox EncounterBox { get; private set; }

            public void Show(bool shown = true)
            {
                PercentageBox.Visible = shown;
                EncounterBox.Visible = shown;
            }

            public void RefreshEncounterList()
            {
                updating = true;

                EncounterBox.Items.Clear();
                foreach (Encounter en in Parent.Zone.Encounters)
                    EncounterBox.Items.Add(en.GetDescription(Parent.Context));
                EncounterBox.SelectedIndex = EncounterId;

                updating = false;
            }

            private byte ClampPercentage(byte perc)
            {
                if (perc < 1) return 1;
                if (perc > 100) return 100;
                return perc;
            }

            private ushort ClampIndex(ushort index)
            {
                if (index >= Parent.Zone.EncounterCount) return (ushort)(Parent.Zone.EncounterCount - 1);
                return index;
            }
        }

        private void PossibilitiesBox_ValueChanged(object sender, EventArgs e)
        {
            ShowPossibilities((byte)PossibilitiesBox.Value);
        }
    }
}
