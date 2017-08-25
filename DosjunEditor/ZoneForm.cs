using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DosjunEditor
{
    public partial class ZoneForm : Form
    {
        private bool changed;

        public ZoneForm()
        {
            InitializeComponent();
        }

        public Campaign Campaign { get; private set; }
        public string ZonePath { get; private set; }
        public string ZoneName { get; private set; }
        public string ZoneFilename => ZonePath + ZoneName + ".ZON";
        public Zone Zone { get; private set; }
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
            string zonOut = ZoneFilename + ".TEST";
            using (Stream file = File.OpenWrite(zonOut)) Zone.Write(new BinaryWriter(file));

            MessageBox.Show($"Wrote: {zonOut}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Changed = false;
        }

        public void Exit()
        {
            if (Changed)
            {
                DialogResult result = MessageBox.Show("Save changes?", "Don't lose your work!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Cancel) return;
                if (result == DialogResult.OK) SaveAll();
            }
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
        }
    }
}
