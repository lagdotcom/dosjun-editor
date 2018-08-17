using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DosjunEditor
{
    public partial class DropTableEditor : Form, IResourceEditor
    {
        public DropTableEditor()
        {
            InitializeComponent();

            Rows = new List<Row>();
            CountBox.Maximum = ushort.MaxValue;
        }

        private List<Row> Rows { get; }

        public Context Context { get; private set; }
        public DropTable DropTable { get; private set; }
        public IHasResource Editing => DropTable;

        public event EventHandler Saved;

        public void Setup(Context ctx, IHasResource r)
        {
            Context = ctx;
            DropTable = r as DropTable;

            SetRowCount(DropTable.Drops.Count);
        }

        private void SetRowCount(int count)
        {
            if (count <= 0) count = 1;
            CountBox.Value = count;
            Drops.RowCount = count;

            while (count > Rows.Count)
            {
                Drops.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
                Rows.Add(new Row(this, Rows.Count));
            }

            while (count < Rows.Count)
            {
                Row row = Rows[count];
                row.Dispose();
                Rows.Remove(row);
            }
        }

        private void GetDroppables(ComboBox box)
        {
            IEnumerable<IHasResource> droppables = Context.Djn.Droppable;
            if (DropTable.Resource.ID != 0) droppables = droppables.Where(r => r.Resource.ID != DropTable.Resource.ID);

            Globals.Populate(box, droppables);
        }

        private class Row : IDisposable
        {
            public Row(DropTableEditor parent, int index)
            {
                Parent = parent;
                Index = index;

                Reference = new ComboBox { Dock = DockStyle.Fill };
                Chance = new NumericUpDown { Dock = DockStyle.Fill, Maximum = 100, Minimum = 1 };

                Parent.GetDroppables(Reference);

                if (index < parent.DropTable.Drops.Count)
                {
                    Drop drop = parent.DropTable.Drops[index];
                    Chance.Value = drop.Chance;
                    Reference.SelectedItem = Globals.Resolve(parent.Context, drop.Reference);
                }
                else
                {
                    Reference.SelectedIndex = 0;
                }

                parent.Drops.Controls.Add(Reference, 0, index);
                parent.Drops.Controls.Add(Chance, 1, index);
            }

            public DropTableEditor Parent { get; }
            public int Index { get; }
            public ComboBox Reference { get; }
            public NumericUpDown Chance { get; }

            public void Dispose()
            {
                Reference.Dispose();
                Chance.Dispose();
            }
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            DropTable.Drops.Clear();
            foreach (Row r in Rows)
            {
                Resource res = r.Reference.SelectedItem as Resource;
                DropTable.Drops.Add(new Drop
                {
                    Reference = res.ID,
                    Chance = (byte)r.Chance.Value,
                    Flags = res.Type == ResourceType.DropTable ? DropFlags.Table : 0,
                });
            }

            Saved?.Invoke(this, e);
            Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CountBox_ValueChanged(object sender, EventArgs e)
        {
            SetRowCount((int)CountBox.Value);
        }
    }
}
