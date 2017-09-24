using System;
using System.Windows.Forms;

namespace DosjunEditor
{
    public partial class EncounterForm : Form
    {
        private Row[] rows;

        public EncounterForm()
        {
            InitializeComponent();
        }
        
        public Encounter Encounter { get; private set; }
        public Monsters Monsters { get; private set; }
        public Zone Zone { get; private set; }

        public void Setup(ZoneContext context, Encounter encounter)
        {
            Zone = context.Zone;
            Monsters = context.Monsters;
            Encounter = encounter;

            rows = new Row[Consts.EncounterSize];
            for (var i = 0; i < Consts.EncounterSize; i++)
                rows[i] = new Row(i, this);
        }

        public void Apply()
        {
            for (var i = 0; i < Consts.EncounterSize; i++)
            {
                Encounter.Minimums[i] = rows[i].Minimum;
                Encounter.Maximums[i] = rows[i].Maximum;
                Encounter.MonsterIds[i] = rows[i].MonsterId;
            }
        }

        private class Row
        {
            private bool updating;

            public Row(int index, EncounterForm parent)
            {
                Parent = parent;

                Minimum = Parent.Encounter.Minimums[index];
                Maximum = Parent.Encounter.Maximums[index];
                MonsterId = Parent.Encounter.MonsterIds[index];

                MinimumBox = new NumericUpDown()
                {
                    Minimum = 0,
                    Maximum = 255,
                    Dock = DockStyle.Fill,
                    Value = Minimum
                };
                MinimumBox.ValueChanged += MinimumBox_ValueChanged;

                MaximumBox = new NumericUpDown()
                {
                    Minimum = 0,
                    Maximum = 255,
                    Dock = DockStyle.Fill,
                    Value = Maximum
                };
                MaximumBox.ValueChanged += MaximumBox_ValueChanged;

                MonsterBox = new ComboBox()
                {
                    Dock = DockStyle.Fill
                };
                MonsterBox.SelectedIndexChanged += MonsterBox_SelectedIndexChanged;
                RefreshMonsterList();

                Parent.MonsterTable.Controls.Add(MinimumBox, 0, index);
                Parent.MonsterTable.Controls.Add(MaximumBox, 1, index);
                Parent.MonsterTable.Controls.Add(MonsterBox, 2, index);
            }

            private void MinimumBox_ValueChanged(object sender, EventArgs e)
            {
                Minimum = (byte)MinimumBox.Value;
            }

            private void MaximumBox_ValueChanged(object sender, EventArgs e)
            {
                Maximum = (byte)MaximumBox.Value;
            }

            private void MonsterBox_SelectedIndexChanged(object sender, EventArgs e)
            {
                int index;

                if (!updating)
                {
                    index = MonsterBox.SelectedIndex;

                    if (index == 0) MonsterId = 0;
                    else MonsterId = Parent.Monsters.Data[index - 1].Id;
                }
            }

            public EncounterForm Parent { get; private set; }
            public byte Minimum { get; private set; }
            public byte Maximum { get; private set; }
            public ushort MonsterId { get; private set; }
            public NumericUpDown MinimumBox { get; private set; }
            public NumericUpDown MaximumBox { get; private set; }
            public ComboBox MonsterBox { get; private set; }

            public void RefreshMonsterList()
            {
                updating = true;
                MonsterBox.Items.Clear();
                MonsterBox.Items.Add(Consts.EmptyItem);
                foreach (Monster mon in Parent.Monsters.Data)
                    MonsterBox.Items.Add(mon.Name);
                MonsterBox.SelectedIndex = MonsterId;
                updating = false;
            }
        }
    }
}
