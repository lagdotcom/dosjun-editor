using System;
using System.Windows.Forms;

namespace DosjunEditor
{
    public partial class ETablesForm : Form
    {
        public ETablesForm()
        {
            InitializeComponent();
        }

        public Context Context { get; private set; }
        public Zone Zone { get; private set; }

        public void Setup(Context ctx, Zone zone)
        {
            Context = ctx;
            Context.EncountersChanged += Context_EncountersChanged;
            Zone = zone;

            UpdateETableList();
        }

        private void UpdateETableList()
        {
            Options.Items.Clear();
            foreach (ETable et in Zone.ETables)
                Options.Items.Add(et.GetDescription(Context, Zone));
        }

        private void Context_EncountersChanged(object sender, EventArgs e)
        {
            UpdateETableList();
        }

        private void Edit()
        {
            if (Options.SelectedIndex == -1) return;

            ETable et = Zone.ETables[Options.SelectedIndex];
            using (ETableForm child = new ETableForm())
            {
                child.Setup(Context, Zone, et);

                if (child.ShowDialog() == DialogResult.OK)
                {
                    child.Apply();
                    Context.UnsavedChanges = true;
                    Context.UpdateEncounters();
                }
            }
        }

        private void Delete()
        {
            if (Options.SelectedIndex == -1) return;

            int index = Options.SelectedIndex + 1;

            foreach (Tile t in Zone.Tiles)
                if (t.ETableId == index)
                    t.ETableId = 0;
            Zone.ETables.RemoveAt(index);

            Context.UnsavedChanges = true;
            Context.UpdateEncounters();
        }

        private void Options_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Edit();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Tools.AddETable(Context, Zone);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Delete();
        }
    }
}
