using System;
using System.IO;
using System.Windows.Forms;

namespace DosjunEditor
{
    public partial class ZoneForm : Form
    {
        public const string CrLf = "\r\n";
        public const string Lf = "\n";

        private bool changed;
        private bool addingDescription;

        public ZoneForm()
        {
            InitializeComponent();
        }

        public Campaign Campaign { get; private set; }
        public string ZonePath { get; private set; }
        public string ZoneName { get; private set; }
        public string ZoneFilename => ZonePath + ZoneName + ".ZON";
        public string JunFilename => ZonePath + ZoneName + ".JC";

        public Zone Zone { get; private set; }
        public Tile CurrentTile { get; private set; }
        public Jun.Parser Parser { get; private set; }
        public bool Changed
        {
            get => changed;
            set { SetChanged(value); }
        }

        private void SetChanged(bool flag)
        {
            if (changed != flag)
            {
                changed = flag;

                if (flag)
                {
                    Text = "Zone Editor*";
                }
                else
                {
                    Text = "Zone Editor";
                }
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
            Changed = false;
        }

        public bool CheckChanged()
        {
            if (Changed)
            {
                DialogResult result = MessageBox.Show("Save changes?", "Don't lose your work!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Cancel) return true;
                if (result == DialogResult.Yes) SaveAll();
            }

            return false;
        }

        public void Setup(Campaign campaign, string path, string zoneName)
        {
            Campaign = campaign;
            ZonePath = path;
            ZoneName = zoneName;

            if (string.IsNullOrEmpty(zoneName))
            {
                Zone = new Zone();
                Changed = true;
            }
            else
            {
                Zone = new Zone();
                using (Stream file = File.OpenRead(ZoneFilename)) Zone.Read(new BinaryReader(file));
            }

            Parser = null;
            LoadScriptNames();

            Map.Zone = Zone;
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
                    LoadScriptNames();
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
            OnEnterBox.Items.Add("--");

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
                Changed = true;
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
                DescriptionIdLabel.Text = "-";
            }
        }

        private void Map_TileSelected(Tile t)
        {
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

            OnEnterBox.SelectedIndex = t.OnEnterId;
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
            Map.UpdateTile();
            Changed = true;
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
            Zone.Strings.Add(string.Empty);
            CurrentTile.DescriptionId = (ushort)Zone.Strings.Count;

            addingDescription = true;
            UpdateDescription();
        }

        private void SelectDescriptionButton_Click(object sender, EventArgs e)
        {
            PickerDialog dlg = new PickerDialog { Items = Zone.Strings };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CurrentTile.DescriptionId = (ushort)(dlg.SelectedIndex + 1);

                UpdateDescription();

                Changed = true;
            }
        }

        private void MenuSave_Click(object sender, EventArgs e)
        {
            SaveAll();
        }

        private void MenuExit_Click(object sender, EventArgs e)
        {
            if (!CheckChanged())
            {
                Close();
            }
        }

        private void MenuLoad_Click(object sender, EventArgs e)
        {
            LoadJC();
        }

        private void OnEnterBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentTile.OnEnterId = (ushort)OnEnterBox.SelectedIndex;
        }
    }
}
