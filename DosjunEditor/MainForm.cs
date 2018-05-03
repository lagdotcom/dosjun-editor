using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;

namespace DosjunEditor
{
    public partial class MainForm : Form
    {
        private bool changed;

        public MainForm()
        {
            InitializeComponent();
        }

        public string DjnFilename { get; set; }
        public string Root => Path.GetFileNameWithoutExtension(DjnFilename);
        public string DjnPath => Path.GetDirectoryName(DjnFilename) + Path.DirectorySeparatorChar;

        public Djn Djn { get; set; }
        public Context Context { get; set; }
        public bool Changed
        {
            get => changed;
            set { SetChanged(value); }
        }

        public void SaveAll()
        {
            using (Stream file = new FileStream(DjnFilename, FileMode.Truncate))
                Djn.Write(new BinaryWriter(file));

            MessageBox.Show($"Wrote: {DjnFilename}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Changed = false;
        }

        public void Exit()
        {
            if (!EnsureSaved()) return;

            Application.Exit();
        }

        private bool EnsureSaved()
        {
            if (Changed)
            {
                DialogResult result = MessageBox.Show("Save changes?", "Don't lose your work!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Cancel) return false;
                if (result == DialogResult.Yes) SaveAll();
            }

            return true;
        }

        private void MenuExit_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void MenuOpen_Click(object sender, EventArgs e)
        {
            if (OpenDialog.ShowDialog() == DialogResult.OK)
            {
                DjnFilename = OpenDialog.FileName;
                Djn = new Djn();
                using (Stream file = File.OpenRead(DjnFilename))
                    Djn.Read(new BinaryReader(file));
                
                CampaignLoaded();
            }
        }

        private void CampaignLoaded()
        {
            MenuSave.Enabled = true;
            NewBtn.Enabled = true;

            //ResetFilters();
            ShowItems();

            Changed = false;
            Context = new Context { Djn = Djn };
            Context.UnsavedChangesChanged += Context_UnsavedChangesChanged;
            Djn.ResourceChanged += Djn_ResourceChanged;
        }

        private void Djn_ResourceChanged(object sender, IHasResource e)
        {
            ShowItems();
        }

        private void ShowItems()
        {
            Resources.BeginUpdate();
            Resources.Items.Clear();

            foreach (var resource in Djn.Resources)
            {
                ListViewItem lvi = new ListViewItem
                {
                    Text = resource.Value.Resource.ToString(),
                    Tag = resource.Key,
                };
                lvi.SubItems.Add(resource.Value.Resource.Type.ToString());

                Resources.Items.Add(lvi);
            }

            Resources.EndUpdate();
        }

        private void Context_UnsavedChangesChanged(object sender, EventArgs e)
        {
            Changed = Context.UnsavedChanges;
        }

        private void UpdateList(ListBox list, IEnumerable data)
        {
            list.Items.Clear();
            foreach (object datum in data)
                list.Items.Add(datum);
        }

        private void MenuSave_Click(object sender, EventArgs e)
        {
            SaveAll();
        }
        
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.ApplicationExitCall)
            {
                e.Cancel = true;
                Exit();
            }
        }

        private void SetChanged(bool flag)
        {
            if (changed != flag)
            {
                changed = flag;

                if (flag)
                {
                    Text = "Campaign Editor*";
                }
                else
                {
                    Text = "Campaign Editor";
                }
            }
        }
        
        private void MenuNew_Click(object sender, EventArgs e)
        {
            if (EnsureSaved())
            {
                if (SaveDialog.ShowDialog() == DialogResult.OK)
                {
                    DjnFilename = SaveDialog.FileName;

                    Djn = new Djn { Flags = DjnFlags.Design };

                    Djn.Add(new Campaign());
                    Djn.Campaign.Resource.Name = Root;

                    Djn.Add(new Strings());
                    Djn.Strings.Resource.Name = "STRINGS";

                    CampaignLoaded();
                    SetChanged(true);
                }
            }
        }

        private void NewZoneButton_Click(object sender, EventArgs e)
        {
            ZoneForm form = new ZoneForm();

            form.Setup(Context, null, 0);
            form.ZoneSaved += ZoneForm_NewZoneSaved;
            form.ShowDialog();
            form.Dispose();
        }

        private void ZoneForm_NewZoneSaved(object sender, EventArgs e)
        {
            ZoneForm form = sender as ZoneForm;

            form.ZoneId = Djn.Add(form.Zone);
            form.ZoneSaved -= ZoneForm_NewZoneSaved;
        }

        private void DjnItems_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem lvi = Resources.GetItemAt(e.X, e.Y);

            if (lvi != null)
            {
                IHasResource r = Djn[(int)lvi.Tag];

                switch (r.Resource.Type)
                {
                    case ResourceType.Campaign:
                        Spawn<CampaignEditor>(r);
                        return;

                    case ResourceType.Source:
                        Spawn<SourceEditor>(r);
                        return;

                    default:
                        MessageBox.Show($"Cannot edit {r.Resource.Type}... yet.", "Not Implemented", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }
            }
        }

        private IResourceEditor Spawn<T>(IHasResource r) where T: IResourceEditor, new()
        {
            T form = new T();
            form.Setup(Context, r);
            form.Show();
            return form;
        }

        private void NewBtn_Click(object sender, EventArgs e)
        {
            NewContext.Show(MousePosition);
        }

        private void SubEditor_Saved(object sender, EventArgs e)
        {
            IResourceEditor editor = sender as IResourceEditor;
            editor.Saved -= SubEditor_Saved;

            if (editor.Editing.Resource.ID == 0)
            {
                Djn.Add(editor.Editing);
                SetChanged(true);
            }
        }

        private string GetString(string caption)
        {
            StringDialog dlg = new StringDialog { Text = caption };
            return (dlg.ShowDialog(this) == DialogResult.OK) ? dlg.String : null;
        }

        private void Resources_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            bool single = Resources.SelectedItems.Count == 1;

            RenameBtn.Enabled = single;
            DeleteBtn.Enabled = single;
        }

        private void NewSource_Click(object sender, EventArgs e)
        {
            ScriptSource src = new ScriptSource();
            src.Resource.Name = GetString("New Source file name");
            Spawn<SourceEditor>(src).Saved += SubEditor_Saved;
        }

        private void RenameBtn_Click(object sender, EventArgs e)
        {
            if (Resources.SelectedItems.Count != 1)
                return;

            int id = (int)Resources.SelectedItems[0].Tag;

            StringDialog dlg = new StringDialog { String = Djn[id].Resource.Name, Text = "Rename Resource" };
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                Djn.Rename(id, dlg.String);
                Context.UnsavedChanges = true;
            }
        }
        
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Resources.SelectedItems.Count != 1)
                return;

            int id = (int)Resources.SelectedItems[0].Tag;
            if (MessageBox.Show("There's no checks about this breaking anything yet!", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Djn.Remove(id);
                Context.UnsavedChanges = true;
            }
        }
    }
}
