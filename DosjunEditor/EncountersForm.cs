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

        public ZoneContext Context { get; private set; }

        public void Setup(ZoneContext context)
        {
            Context = context;
            Context.EncountersChanged += Context_EncountersChanged;

            UpdateEncounterList();
        }

        private void UpdateEncounterList()
        {
            Options.Items.Clear();
            foreach (Encounter encounter in Context.Zone.Encounters)
                Options.Items.Add(encounter.GetDescription(Context.Monsters));
        }

        private void Context_EncountersChanged(object sender, EventArgs e)
        {
            UpdateEncounterList();
        }

        private void Edit()
        {
            if (Options.SelectedIndex == -1) return;

            Encounter encounter = Context.Zone.Encounters[Options.SelectedIndex];
            using (EncounterForm child = new EncounterForm())
            {
                child.Setup(Context, encounter);

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
            if (Context.Zone.UsingEncounterId(index))
            {
                MessageBox.Show("Cannot remove encounter; still in use.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (ETable etable in Context.Zone.ETables)
                etable.DeleteEncounterId((ushort)index);
            Context.Zone.Encounters.RemoveAt(index);

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
                child.Setup(Context, encounter);

                if (child.ShowDialog() == DialogResult.OK)
                {
                    child.Apply();
                    Context.Zone.Encounters.Add(encounter);

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
