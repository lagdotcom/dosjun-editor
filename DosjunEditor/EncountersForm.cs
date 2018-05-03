using System;
using System.Windows.Forms;

namespace DosjunEditor
{
    public partial class EncountersForm : Form
    {
        public EncountersForm()
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

            UpdateEncounterList();
        }

        private void UpdateEncounterList()
        {
            Options.Items.Clear();
            foreach (Encounter encounter in Zone.Encounters)
                Options.Items.Add(encounter.GetDescription(Context));
        }

        private void Context_EncountersChanged(object sender, EventArgs e)
        {
            UpdateEncounterList();
        }

        private void Edit()
        {
            if (Options.SelectedIndex == -1) return;

            Encounter encounter = Zone.Encounters[Options.SelectedIndex];
            using (EncounterForm child = new EncounterForm())
            {
                child.Setup(Context, Zone, encounter);

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

            int index = Options.SelectedIndex;
            if (Zone.UsingEncounterId(index))
            {
                MessageBox.Show("Cannot remove encounter; still in use.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (ETable etable in Zone.ETables)
                etable.DeleteEncounterId((ushort)index);
            Zone.Encounters.RemoveAt(index);

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
            Encounter encounter = new Encounter();
            using (EncounterForm child = new EncounterForm())
            {
                child.Setup(Context, Zone, encounter);

                if (child.ShowDialog() == DialogResult.OK)
                {
                    child.Apply();
                    Zone.Encounters.Add(encounter);

                    Context.UnsavedChanges = true;
                    Context.UpdateEncounters();
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Delete();
        }
    }
}
