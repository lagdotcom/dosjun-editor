using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DosjunEditor
{
    public partial class ZoneForm : Form
    {
        public const string CrLf = "\r\n";
        public const string Lf = "\n";

        private List<ComboBox> ScriptNameBoxes;

        private bool addingDescription;
        private bool updatingDisplay;

        public ZoneForm()
        {
            InitializeComponent();

            foreach (string name in Tools.GetEnumNames<Thing>())
                ThingBox.Items.Add(name);

            ScriptNameBoxes = new List<ComboBox>()
            {
                OnEnterBox,
                OnUseBox,
            };
        }

        public Context Context;
        public Zone Zone;
        public int ZoneId;
        public Tile CurrentTile { get; private set; }
        public Jun.Parser Parser { get; private set; }

        public event EventHandler ZoneSaved;

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
            CheckAddingDescription();

            Context.UnsavedChanges = false;
            ZoneSaved?.Invoke(this, null);
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

        public void Setup(Context context, Zone zone, int id)
        {
            Context = context;
            Context.UnsavedChangesChanged += Context_UnsavedChangesChanged;
            Context.EncountersChanged += Context_EncountersChanged;

            if (zone == null)
            {
                Zone = new Zone();
                Context.UnsavedChanges = true;
            }
            else
            {
                Zone = zone;
            }

            CeilingTexture.Zone = Zone;
            FloorTexture.Zone = Zone;

            Parser = null;
            LoadScriptNames();

            Map.Zone = Zone;
        }

        private void Context_EncountersChanged(object sender, EventArgs e)
        {
            UpdateETable();
        }
        
        private void LoadScriptNames()
        {
            throw new NotImplementedException();

            List<String> scriptNames = new List<string> { Consts.EmptyItem };

            if (Parser == null)
            {
                for (var i = 0; i < Zone.ScriptCount; i++)
                    scriptNames.Add($"Script #{i + 1}");
            }
            else
            {
                foreach (Jun.Script sc in Parser.Scripts) //.Where(sc => sc.Public))
                    scriptNames.Add(sc.Name);
            }

            //Context.ScriptNames = scriptNames.ToArray();

            foreach (ComboBox box in ScriptNameBoxes)
            {
                box.Items.Clear();
                //box.Items.AddRange(Context.ScriptNames);
            }

            if (CurrentTile != null) Map_TileSelected(CurrentTile);
        }

        private void CheckAddingDescription()
        {
            if (addingDescription)
            {
                Context.UnsavedChanges = true;
                Zone.Strings[CurrentTile.DescriptionId - 1] = DescriptionBox.Text.Replace(CrLf, Lf);

                DescriptionBox.ReadOnly = true;
            }
        }

        private void UpdateDescription()
        {
            DescriptionBox.ReadOnly = !addingDescription;
            if (CurrentTile.DescriptionId > 0)
            {
                DescriptionBox.Text = Zone.Strings[CurrentTile.DescriptionId - 1].Replace(Lf, CrLf);
                DescriptionIdLabel.Text = $"#{CurrentTile.DescriptionId}";
            }
            else
            {
                DescriptionBox.Text = string.Empty;
                DescriptionIdLabel.Text = Consts.EmptyItem;
            }
        }

        private string GetETableText(ushort id)
        {
            throw new NotImplementedException();

            //if (id == 0) return "(No encounters)";
            //return Zone.ETables[id - 1].GetDescription(Zone, Monsters, CrLf);
        }

        private void UpdateETable()
        {
            ETableIdLabel.Text = CurrentTile.ETableId == 0 ? Consts.EmptyItem : $"#{CurrentTile.ETableId}";
            ETableBox.Text = GetETableText(CurrentTile.ETableId);
        }

        private void Map_TileSelected(Tile t)
        {
            updatingDisplay = true;

            CheckAddingDescription();
            CurrentTile = t;

            NorthWall.Setup(Zone, t.Walls[0]);
            EastWall.Setup(Zone, t.Walls[1]);
            SouthWall.Setup(Zone, t.Walls[2]);
            WestWall.Setup(Zone, t.Walls[3]);

            CeilingTexture.TextureId = t.CeilingTexture;
            FloorTexture.TextureId = t.FloorTexture;

            addingDescription = false;
            UpdateDescription();
            UpdateETable();

            OnEnterBox.SelectedIndex = t.OnEnterId;
            OnUseBox.SelectedIndex = t.OnUseId;
            ThingBox.SelectedIndex = (int)t.Thing;
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

        private void AddDescriptionButton_Click(object sender, EventArgs e)
        {
            if (!addingDescription)
            {
                Zone.Strings.Add(string.Empty);
                CurrentTile.DescriptionId = (ushort)Zone.Strings.Count;

                addingDescription = true;
                UpdateDescription();
            }
        }

        private void SelectDescriptionButton_Click(object sender, EventArgs e)
        {
            PickerDialog dlg = new PickerDialog { Items = Zone.Strings };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CurrentTile.DescriptionId = (ushort)(dlg.SelectedIndex + 1);
                Context.UnsavedChanges = true;

                UpdateDescription();
            }
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
        
        private ushort GetScriptId(ComboBox box)
        {
            // no need to account for States - they show up in the list here!
            if (Parser == null) return (ushort)box.SelectedIndex;

            string item = (string)box.SelectedItem;
            if (item == Consts.EmptyItem) return 0;

            return (ushort)(Parser.Scripts.FindIndex(sc => sc.Name == item) + 1);
        }

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
            throw new NotImplementedException();

            List<string> items = new List<string>
            {
                GetETableText(0)
            };
            foreach (ETable et in Zone.ETables)
            {
                //items.Add(et.GetDescription(Zone, Context.Djn.Monsters));
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
            throw new NotImplementedException();

            if (CurrentTile.ETableId > 0)
            {
                ETableForm form = new ETableForm();
                //form.Setup(Context, Zone.ETables[CurrentTile.ETableId - 1]);

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
                CurrentTile.Thing = (Thing)ThingBox.SelectedIndex;

                DataElement_Changed(sender, e);
            }
        }

        private void MenuEncounters_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();

            EncountersForm form = new EncountersForm();
            //form.Setup(Context);

            form.Show();
        }

        private void MenuETables_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();

            ETablesForm form = new ETablesForm();
            //form.Setup(Context);

            form.Show();
        }

        private void AddETableButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();

            /*ushort newId = Tools.AddETable(Context);
            if (newId != 0)
            {
                CurrentTile.ETableId = newId;
                UpdateETable();
            }*/
        }

        private void DangerBox_ValueChanged(object sender, EventArgs e)
        {
            CurrentTile.Danger = (byte)DangerBox.Value;
            DataElement_Changed(sender, e);
        }

        private void MenuZone_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();

            using (ZoneDataForm form = new ZoneDataForm())
            {
                //form.Setup(Context);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    form.Apply();
                    Context.UnsavedChanges = true;
                }
            }
        }
    }
}
