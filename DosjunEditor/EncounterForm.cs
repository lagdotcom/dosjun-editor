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
        
        public Context Context { get; private set; }
        public Encounter Encounter { get; private set; }
        public Zone Zone { get; private set; }

        public void Setup(Context ctx, Zone zone, Encounter encounter)
        {
            Context = ctx;
            Zone = zone;
            Encounter = encounter;

            MinLevel.Value = Encounter.MinLevel;
            MaxLevel.Value = Encounter.MaxLevel;

            rows = new Row[Globals.EncounterSize];
            for (var i = 0; i < Globals.EncounterSize; i++)
                rows[i] = new Row(i, this);
        }

        public void Apply()
        {
            Encounter.MinLevel = (ushort)MinLevel.Value;
            Encounter.MaxLevel = (ushort)MaxLevel.Value;

            for (var i = 0; i < Globals.EncounterSize; i++)
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
                if (!updating)
                    MonsterId = (MonsterBox.SelectedItem as Resource).ID;
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

                Globals.Populate(MonsterBox, Parent.Context.Djn.Monsters);
                MonsterBox.SelectedItem = Globals.Resolve(Parent.Context, MonsterId);

                updating = false;
            }
        }
    }
}
