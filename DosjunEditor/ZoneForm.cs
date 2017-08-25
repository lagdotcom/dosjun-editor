using System;
using System.IO;
using System.Windows.Forms;

namespace DosjunEditor
{
    public partial class ZoneForm : Form
    {
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
        public Zone Zone { get; private set; }
        public Tile CurrentTile { get; private set; }
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

            string zonOut = ZoneFilename + ".TEST";
            using (Stream file = File.OpenWrite(zonOut)) Zone.Write(new BinaryWriter(file));

            MessageBox.Show($"Wrote: {zonOut}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            Map.Zone = Zone;
        }

        private void CheckAddingDescription()
        {
            if (addingDescription)
            {
                Changed = true;
                Zone.Strings[CurrentTile.DescriptionId - 1] = DescriptionBox.Text;
            }
        }

        private void UpdateDescription()
        {
            DescriptionBox.ReadOnly = !addingDescription;
            if (CurrentTile.DescriptionId > 0)
            {
                DescriptionBox.Text = Zone.Strings[CurrentTile.DescriptionId - 1];
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
            PickerDialog dlg = new PickerDialog();
            dlg.Items = Zone.Strings;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                CurrentTile.DescriptionId = (ushort)(dlg.SelectedIndex + 1);

                UpdateDescription();

                Changed = true;
            }
        }
    }
}
