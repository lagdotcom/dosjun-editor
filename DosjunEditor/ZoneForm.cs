using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace DosjunEditor
{
    public partial class ZoneForm : Form
    {
        public const string CrLf = "\r\n";
        public const string Lf = "\n";

        private bool addingDescription;
        private bool updatingDisplay;

        public ZoneForm()
        {
            InitializeComponent();

            foreach (string name in Tools.GetNames<Thing>())
                ThingBox.Items.Add(name);
        }

        public ZoneContext Context { get; private set; }

        public Campaign Campaign => Context.Campaign;
        public Monsters Monsters => Context.Monsters;
        public string ZonePath { get; private set; }
        public string ZoneName { get; private set; }
        public string ZoneFilename => ZonePath + ZoneName + ".ZON";
        public string JunFilename => ZonePath + ZoneName + ".JC";

        public Zone Zone => Context.Zone;
        public Tile CurrentTile { get; private set; }
        public Jun.Parser Parser { get; private set; }

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

            if (Parser != null)
            {
                Zone.CodeStrings.Clear();
                Zone.Scripts.Clear();

                Zone.CodeStrings.AddRange(Parser.Strings);
                foreach (Jun.Script sc in Parser.Scripts)
                    Zone.Scripts.Add(new CompiledScript { Bytecode = sc.Code.ToArray() });
            }

            using (Stream file = File.OpenWrite(ZoneFilename)) Zone.Write(new BinaryWriter(file));

            MessageBox.Show($"Wrote: {ZoneFilename}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Context.UnsavedChanges = false;
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

        public void Setup(Campaign campaign, string path, Monsters monsters, string zoneName)
        {
            Context = new ZoneContext
            {
                Campaign = campaign,
                Monsters = monsters,
            };
            Context.UnsavedChangesChanged += Context_UnsavedChangesChanged;
            Context.EncountersChanged += Context_EncountersChanged;

            ZonePath = path;
            ZoneName = zoneName;

            if (string.IsNullOrEmpty(zoneName))
            {
                Context.Zone = new Zone();
                Context.UnsavedChanges = true;
            }
            else
            {
                Context.Zone = new Zone();
                using (Stream file = File.OpenRead(ZoneFilename)) Zone.Read(new BinaryReader(file));
            }

            Parser = null;
            LoadScriptNames();

            Map.Zone = Zone;
        }

        private void Context_EncountersChanged(object sender, EventArgs e)
        {
            UpdateETable();
        }

        private void LoadJC()
        {
            Parser = null;

            if (File.Exists(JunFilename))
            {
                try
                {
                    Jun.Tokenizer jt = new Jun.Tokenizer();
                    jt.Tokenize(JunFilename);

                    Jun.Parser jp = new Jun.Parser();
                    jp.Parse(jt.Tokens);

                    Parser = jp;
                    updatingDisplay = true;
                    LoadScriptNames();
                    updatingDisplay = false;
                    MessageBox.Show($"Loaded {jp.Scripts.Count} scripts", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "JC Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No .JC to load.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LoadScriptNames()
        {
            int oldSelection = OnEnterBox.SelectedIndex;
            OnEnterBox.Items.Clear();
            OnEnterBox.Items.Add(Consts.EmptyItem);

            if (Parser == null)
            {
                for (var i = 0; i < Zone.ScriptCount; i++)
                    OnEnterBox.Items.Add($"Script #{i + 1}");
            }
            else
            {
                foreach (Jun.Script sc in Parser.Scripts)
                    OnEnterBox.Items.Add(sc.Name);
            }

            OnEnterBox.SelectedIndex = oldSelection;
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
            if (id == 0) return "(No encounters)";
            return Zone.ETables[id - 1].GetDescription(Zone, Monsters, CrLf);
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

            NorthWall.Wall = t.Walls[0];
            EastWall.Wall = t.Walls[1];
            SouthWall.Wall = t.Walls[2];
            WestWall.Wall = t.Walls[3];

            CeilingColour.Colour = t.Ceiling;
            FloorColour.Colour = t.Floor;

            addingDescription = false;
            UpdateDescription();
            UpdateETable();

            OnEnterBox.SelectedIndex = t.OnEnterId;
            ThingBox.SelectedIndex = (int)t.Thing;

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

        private void FloorColour_ColourChanged(object sender, EventArgs e)
        {
            CurrentTile.Floor = FloorColour.Colour;
            DataElement_Changed(sender, e);
        }

        private void CeilingColour_ColourChanged(object sender, EventArgs e)
        {
            CurrentTile.Ceiling = CeilingColour.Colour;
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

        private void MenuLoad_Click(object sender, EventArgs e)
        {
            LoadJC();
        }

        private void OnEnterBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updatingDisplay)
            {
                CurrentTile.OnEnterId = (ushort)OnEnterBox.SelectedIndex;
                Context.UnsavedChanges = true;
            }
        }

        private void Map_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
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
            }
        }

        private void SelectETableButton_Click(object sender, EventArgs e)
        {
            List<string> items = new List<string>
            {
                GetETableText(0)
            };
            foreach (ETable et in Zone.ETables)
            {
                items.Add(et.GetDescription(Zone, Monsters));
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
                form.Setup(Context, Zone.ETables[CurrentTile.ETableId - 1]);

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

                Context.UnsavedChanges = true;
            }
        }

        private void ThingBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updatingDisplay)
            {
                CurrentTile.Thing = (Thing)ThingBox.SelectedIndex;
                Context.UnsavedChanges = true;
            }
        }

        private void MenuEncounters_Click(object sender, EventArgs e)
        {
            EncountersForm form = new EncountersForm();
            form.Setup(Context);

            form.Show();
        }

        private void MenuETables_Click(object sender, EventArgs e)
        {
            ETablesForm form = new ETablesForm();
            form.Setup(Context);

            form.Show();
        }

        private void AddETableButton_Click(object sender, EventArgs e)
        {
            ushort newId = Tools.AddETable(Context);
            if (newId != 0)
            {
                CurrentTile.ETableId = newId;
                UpdateETable();
            }
        }
    }
}
