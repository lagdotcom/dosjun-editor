using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DosjunEditor
{
    public partial class ZoneForm : Form, IResourceEditor
    {
        public const string CrLf = "\r\n";
        public const string Lf = "\n";

        private List<ComboBox> ScriptNameBoxes;

        private bool updatingDisplay;

        public ZoneForm()
        {
            InitializeComponent();

            ScriptNameBoxes = new List<ComboBox>()
            {
                OnEnterBox,
                OnUseBox,
            };
        }

        public Context Context;
        public IHasResource Editing => Zone;
        public Zone Zone;
        public int ZoneId;
        public Tile CurrentTile { get; private set; }

        public event EventHandler Saved;

        private void Context_UnsavedChangesChanged(object sender, EventArgs e)
        {
            if (Context.UnsavedChanges)
            {
                Text = "Zone Editor*";
            }
            else
            {
                Text = "Zone Editor";
            }
        }

        public void SaveAll()
        {
            CheckDescriptionUpdate();

            Context.UnsavedChanges = false;
            Saved?.Invoke(this, null);
        }

        public bool CheckChanged()
        {
            if (Context.UnsavedChanges)
            {
                DialogResult result = MessageBox.Show("Save changes?", "Don't lose your work!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Cancel) return true;
                if (result == DialogResult.Yes) SaveAll();
            }

            return false;
        }

        public void Setup(Context ctx, IHasResource zone)
        {
            Context = ctx;
            ctx.UnsavedChangesChanged += Context_UnsavedChangesChanged;
            ctx.EncountersChanged += Context_EncountersChanged;

            Zone = zone as Zone;

            CeilingTexture.Setup(ctx, Zone);
            FloorTexture.Setup(ctx, Zone);

            LoadScriptNames();
            LoadThings();

            Map.Setup(ctx, Zone);
        }

        private void Context_EncountersChanged(object sender, EventArgs e)
        {
            UpdateETable();
        }
        
        private void LoadScriptNames()
        {
            foreach (ComboBox box in ScriptNameBoxes)
                Globals.Populate(box, Context.Djn.PublicScripts);

            if (CurrentTile != null) Map_TileSelected(CurrentTile);
        }

        private void LoadThings()
        {
            Globals.Populate(ThingBox, Context.Djn.Things);
        }

        private void CheckDescriptionUpdate()
        {
            if (CurrentTile == null)
                return;

            string old = Context.GetString(CurrentTile.DescriptionId);
            string rep = DescriptionBox.Text.Replace(CrLf, Lf);

            if (old != rep)
            {
                Context.UnsavedChanges = true;
                CurrentTile.DescriptionId = Context.GetStringId(rep, CurrentTile.DescriptionId);
            }
        }

        private void UpdateDescription()
        {
            DescriptionBox.Text = Context.GetString(CurrentTile.DescriptionId).Replace(Lf, CrLf);
        }

        private string GetETableText(ushort id)
        {
            if (id == 0) return "(No encounters)";
            return Zone.ETables[id - 1].GetDescription(Context, Zone, CrLf);
        }

        private void UpdateETable()
        {
            ETableIdLabel.Text = CurrentTile.ETableId == 0 ? Globals.EmptyItem : $"#{CurrentTile.ETableId}";
            ETableBox.Text = GetETableText(CurrentTile.ETableId);
        }

        private void Map_TileSelected(Tile t)
        {
            updatingDisplay = true;

            CheckDescriptionUpdate();
            CurrentTile = t;

            NorthWall.Setup(Context, Zone, t.Walls[0]);
            EastWall.Setup(Context, Zone, t.Walls[1]);
            SouthWall.Setup(Context, Zone, t.Walls[2]);
            WestWall.Setup(Context, Zone, t.Walls[3]);

            CeilingTexture.TextureId = t.CeilingTexture;
            FloorTexture.TextureId = t.FloorTexture;

            UpdateDescription();
            UpdateETable();

            OnEnterBox.SelectedItem = Globals.Resolve(Context, t.OnEnterId);
            OnUseBox.SelectedItem = Globals.Resolve(Context, t.OnUseId);
            ThingBox.SelectedItem = Globals.Resolve(Context, t.Thing);
            DangerBox.Value = t.Danger;

            ImpassableFlag.Checked = t.Flags.HasFlag(TileFlags.Impassable);

            updatingDisplay = false;
        }

        private void ZoneForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = CheckChanged();
            }
        }

        private void DataElement_Changed(object sender, EventArgs e)
        {
            if (!updatingDisplay)
            {
                Map.UpdateTile();
                Context.UnsavedChanges = true;
            }
        }

        private void FloorTexture_ValueChanged(object sender, EventArgs e)
        {
            CurrentTile.FloorTexture = FloorTexture.TextureId;
            DataElement_Changed(sender, e);
        }

        private void CeilingTexture_ValueChanged(object sender, EventArgs e)
        {
            CurrentTile.CeilingTexture = CeilingTexture.TextureId;
            DataElement_Changed(sender, e);
        }
        
        private void MenuSave_Click(object sender, EventArgs e)
        {
            SaveAll();
        }

        private void MenuExit_Click(object sender, EventArgs e)
        {
            // this triggers CheckChanged() anyway
            Close();
        }
        
        private ushort GetScriptId(ComboBox box) => (box.SelectedItem as Resource).ID;

        private void OnEnterBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updatingDisplay)
            {
                CurrentTile.OnEnterId = GetScriptId(OnEnterBox);
                Context.UnsavedChanges = true;
            }
        }

        private void OnUseBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updatingDisplay)
            {
                CurrentTile.OnUseId = GetScriptId(OnUseBox);
                Context.UnsavedChanges = true;
            }
        }

        private void Map_KeyUp(object sender, KeyEventArgs e)
        {
            bool handled = true;

            switch (e.KeyCode)
            {
                case Keys.Left:
                    Map.Carve(-1, 0);
                    break;

                case Keys.Up:
                    Map.Carve(0, -1);
                    break;

                case Keys.Right:
                    Map.Carve(1, 0);
                    break;

                case Keys.Down:
                    Map.Carve(0, 1);
                    break;

                case Keys.N:
                    if (e.Shift) NorthWall.CycleTexture();
                    else NorthWall.CycleType();
                    break;

                case Keys.E:
                    if (e.Shift) EastWall.CycleTexture();
                    else EastWall.CycleType();
                    break;

                case Keys.S:
                    if (e.Shift) SouthWall.CycleTexture();
                    else SouthWall.CycleType();
                    break;

                case Keys.W:
                    if (e.Shift) WestWall.CycleTexture();
                    else WestWall.CycleType();
                    break;

                case Keys.C:
                    CeilingTexture.Cycle();
                    break;

                case Keys.F:
                    FloorTexture.Cycle();
                    break;

                case Keys.T:
                    CycleThing();
                    break;

                case Keys.I:
                    ImpassableFlag.Checked = !ImpassableFlag.Checked;
                    break;

                case Keys.Z:
                    int size = Map.TileSize * 2;
                    if (size > 100) size = 16;
                    Map.TileSize = size;
                    break;

                default:
                    handled = false;
                    break;
            }

            e.Handled = handled;
        }

        private void CycleThing()
        {
            int index = ThingBox.SelectedIndex + 1;
            if (index == ThingBox.Items.Count) index = 0;

            ThingBox.SelectedIndex = index;
        }

        private void SelectETableButton_Click(object sender, EventArgs e)
        {
            List<string> items = new List<string>
            {
                GetETableText(0)
            };
            foreach (ETable et in Zone.ETables)
            {
                items.Add(et.GetDescription(Context, Zone));
            }

            PickerDialog dlg = new PickerDialog { Items = items };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CurrentTile.ETableId = (ushort)dlg.SelectedIndex;

                UpdateETable();

                Context.UnsavedChanges = true;
            }
        }

        private void EditETableButton_Click(object sender, EventArgs e)
        {
            if (CurrentTile.ETableId > 0)
            {
                ETableForm form = new ETableForm();
                form.Setup(Context, Zone, Zone.ETables[CurrentTile.ETableId - 1]);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    form.Apply();
                    Context.UnsavedChanges = true;
                    Context.UpdateEncounters();
                }
            }
        }

        private void ImpassableFlag_CheckedChanged(object sender, EventArgs e)
        {
            if (!updatingDisplay)
            {
                if (ImpassableFlag.Checked) CurrentTile.Flags |= TileFlags.Impassable;
                else CurrentTile.Flags &= ~TileFlags.Impassable;

                DataElement_Changed(sender, e);
            }
        }

        private void ThingBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updatingDisplay)
            {
                CurrentTile.Thing = (ThingBox.SelectedItem as Resource).ID;

                DataElement_Changed(sender, e);
            }
        }

        private void MenuEncounters_Click(object sender, EventArgs e)
        {
            EncountersForm form = new EncountersForm();
            form.Setup(Context, Zone);

            form.Show();
        }

        private void MenuETables_Click(object sender, EventArgs e)
        {
            ETablesForm form = new ETablesForm();
            form.Setup(Context, Zone);

            form.Show();
        }

        private void AddETableButton_Click(object sender, EventArgs e)
        {
            ushort newId = Tools.AddETable(Context, Zone);
            if (newId != 0)
            {
                CurrentTile.ETableId = newId;
                UpdateETable();
            }
        }

        private void DangerBox_ValueChanged(object sender, EventArgs e)
        {
            CurrentTile.Danger = (byte)DangerBox.Value;
            DataElement_Changed(sender, e);
        }

        private void MenuZone_Click(object sender, EventArgs e)
        {
            using (ZoneDataForm form = new ZoneDataForm())
            {
                form.Setup(Context, Zone);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    form.Apply();
                    Context.UnsavedChanges = true;
                }
            }
        }
    }
}
