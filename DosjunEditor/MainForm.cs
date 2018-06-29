using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;

namespace DosjunEditor
{
    public partial class MainForm : Form
    {
        private bool changed;
        private ResourceListSorter sorter;

        public MainForm()
        {
            InitializeComponent();

            sorter = new ResourceListSorter { Column = ResourceListSorter.SortColumn.ID };
            Resources.ListViewItemSorter = sorter;
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
            using (Stream file = new FileStream(DjnFilename, FileMode.Create))
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
            ImportBtn.Enabled = true;
            MenuSave.Enabled = true;
            NewBtn.Enabled = true;
            DumpBtn.Enabled = true;

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

            foreach (var pair in Djn.Resources)
                Resources.Items.Add(AsItem(pair.Value.Resource));

            Resources.EndUpdate();
        }

        private ListViewItem AsItem(Resource r)
        {
            ListViewItem lvi = new ListViewItem
            {
                Text = r.ToString(),
                Tag = (int)r.ID,
            };
            lvi.SubItems.Add(r.Type == ResourceType.Graphic
                ? $"{r.Type} ({r.Subtype})"
                : r.Type.ToString());
            lvi.SubItems.Add(r.ID.ToString());

            return lvi;
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
                    Text = "DOSJUN Editor*";
                }
                else
                {
                    Text = "DOSJUN Editor";
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

                    case ResourceType.Graphic:
                        Spawn<GrfForm>(r);
                        return;

                    case ResourceType.Item:
                        Spawn<ItemForm>(r);
                        return;

                    case ResourceType.Monster:
                        Spawn<MonsterForm>(r);
                        return;

                    case ResourceType.NPC:
                        Spawn<NPCEditor>(r);
                        return;

                    case ResourceType.PC:
                        Spawn<PCEditor>(r);
                        return;

                    case ResourceType.Script:
                        Spawn<CompiledDumpForm>(r);
                        return;

                    case ResourceType.Source:
                        Spawn<SourceEditor>(r);
                        return;

                    case ResourceType.Strings:
                        Spawn<StringsViewer>(r);
                        return;

                    case ResourceType.Zone:
                        Spawn<ZoneForm>(r);
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
            form.Saved += SubEditor_Saved;
            return form;
        }

        private void SubEditor_Saved(object sender, EventArgs e)
        {
            SetChanged(true);
        }

        private void NewBtn_Click(object sender, EventArgs e)
        {
            NewContext.Show(MousePosition);
        }

        private void SubEditor_NewSaved(object sender, EventArgs e)
        {
            IResourceEditor editor = sender as IResourceEditor;
            editor.Saved -= SubEditor_NewSaved;

            if (editor.Editing.Resource.ID == 0)
                Djn.Add(editor.Editing);
        }

        private string GetString(string caption, string old = null)
        {
            StringDialog dlg = new StringDialog { Text = caption };
            dlg.String = old;
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
            src.Resource.Name = GetString("New Source name");
            Spawn<SourceEditor>(src).Saved += SubEditor_NewSaved;
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

        private void NewResource<R, E>() where E : IResourceEditor, new() where R : IHasResource, new()
        {
            IHasResource r = new R();
            r.Resource.Name = GetString($"New {typeof(R).Name} name");
            Spawn<E>(r).Saved += SubEditor_NewSaved;
        }

        private void NewZone_Click(object sender, EventArgs e)
        {
            NewResource<Zone, ZoneForm>();
        }

        private void NewMonster_Click(object sender, EventArgs e)
        {
            NewResource<Monster, MonsterForm>();
        }

        private void NewItem_Click(object sender, EventArgs e)
        {
            NewResource<Item, ItemForm>();
        }

        private void NewPC_Click(object sender, EventArgs e)
        {
            NewResource<PC, PCEditor>();
        }

        private void NewGraphic_Click(object sender, EventArgs e)
        {
            NewResource<Grf, GrfForm>();
        }

        private void NewNPC_Click(object sender, EventArgs e)
        {
            NewResource<NPC, NPCEditor>();
        }

        private void ImportBtn_Click(object sender, EventArgs e)
        {
            if (ImportDialog.ShowDialog() == DialogResult.OK)
            {
                IHasResource r = Import(ImportDialog.FileName);
                Djn.Add(r);
                Context.UnsavedChanges = true;
                SetChanged(true);
            }
        }

        private void DumpBtn_Click(object sender, EventArgs e)
        {
            if (DumpDialog.ShowDialog() == DialogResult.OK)
            {
                string manifestFilename = $"{DumpDialog.SelectedPath}\\manifest.txt";

                using (StreamWriter sw = new StreamWriter(manifestFilename))
                {
                    foreach (IHasResource r in Djn.Resources.Values)
                    {
                        string resourceFilename = Globals.ToFilename(r);

                        using (BinaryWriter bw = new BinaryWriter(File.OpenWrite($"{DumpDialog.SelectedPath}\\{resourceFilename}")))
                        {
                            r.Write(bw);
                        }

                        sw.WriteLine($"{resourceFilename}\nID: {r.Resource.ID}\nFlags: {r.Resource.Flags}\nSubtype: {r.Resource.Subtype}\n");
                    }
                }

                MessageBox.Show("All files dumped.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private IHasResource Import(string fileName)
        {
            Resource res = new Resource {
                Size = (uint)new FileInfo(fileName).Length,
                Type = Globals.Detect(fileName),
            };
            res.Name = GetString($"Imported {res.Type} name", Path.GetFileNameWithoutExtension(fileName));

            Stream f = File.OpenRead(fileName);
            BinaryReader br = new BinaryReader(f);

            switch (res.Type)
            {
                case ResourceType.Graphic: return Import<Grf>(res, br);
                case ResourceType.Item: return Import<Item>(res, br);
                case ResourceType.Monster: return Import<Monster>(res, br);
                case ResourceType.Palette: return Import<Palette>(res, br);
                case ResourceType.NPC: return Import<NPC>(res, br);
                case ResourceType.PC: return Import<PC>(res, br);
                case ResourceType.Script: return Import<CompiledScript>(res, br);
                case ResourceType.Source: return Import<ScriptSource>(res, br);
                case ResourceType.Strings: return Import<Strings>(res, br);
                case ResourceType.Zone: return Import<Zone>(res, br);
                default: return Import<UnknownResource>(res, br);
            }
        }

        private T Import<T>(Resource res, BinaryReader br) where T: IHasResource, new()
        {
            T r = new T();
            r.Resource = res;
            r.Read(br);
            return r;
        }

        private void Resources_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ResourceListSorter.SortColumn sort = AsColumn(e.Column);

            if (sorter.Column == sort)
            {
                sorter.Descending = !sorter.Descending;
            }
            else
            {
                sorter.Column = sort;
                sorter.Descending = false;
            }

            Resources.Sort();
        }

        private ResourceListSorter.SortColumn AsColumn(int i)
        {
            switch (i)
            {
                case 0: return ResourceListSorter.SortColumn.Name;
                case 1: return ResourceListSorter.SortColumn.Type;
                default: return ResourceListSorter.SortColumn.ID;
            }
        }
    }
}
