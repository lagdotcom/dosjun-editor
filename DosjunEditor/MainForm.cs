using System;
using System.IO;
using System.Windows.Forms;

namespace DosjunEditor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public string CampaignFilename { get; set; }
        public string Root => Path.GetFileNameWithoutExtension(CampaignFilename);
        public string CampaignPath => Path.GetDirectoryName(CampaignFilename) + Path.DirectorySeparatorChar;
        public string MonstersFilename => CampaignPath + Root + ".MON";
        public string ItemsFilename => CampaignPath + Root + ".ITM";

        public Campaign Campaign { get; set; }
        public Monsters Monsters { get; set; }
        public Items Items { get; set; }

        private void MenuExit_Click(object sender, EventArgs e)
        {
            /* TODO */
            Application.Exit();
        }

        private void MenuOpen_Click(object sender, EventArgs e)
        {
            if (OpenDialog.ShowDialog() == DialogResult.OK)
            {
                CampaignFilename = OpenDialog.FileName;

                Campaign = new Campaign();
                Monsters = new Monsters();
                Items = new Items();

                using (Stream file = File.OpenRead(CampaignFilename)) Campaign.Read(new BinaryReader(file));
                using (Stream file = File.OpenRead(MonstersFilename)) Monsters.Read(new BinaryReader(file));
                using (Stream file = File.OpenRead(ItemsFilename)) Items.Read(new BinaryReader(file));
                CampaignLoaded();
            }
        }

        private void CampaignLoaded()
        {
            MenuSave.Enabled = true;
            AddZoneButton.Enabled = true;
            NewZoneButton.Enabled = true;
            NewMonsterButton.Enabled = true;
            NewItemButton.Enabled = true;

            ZoneList.Items.Clear();
            foreach (string zone in Campaign.Zones)
                ZoneList.Items.Add(zone);

            MonsterList.Items.Clear();
            foreach (Monster m in Monsters.Data)
                MonsterList.Items.Add(m);

            ItemList.Items.Clear();
            foreach (Item it in Items.Data)
                ItemList.Items.Add(it);
        }

        private void MenuSave_Click(object sender, EventArgs e)
        {
            string cmpOut = CampaignFilename + ".TEST";
            string monOut = MonstersFilename + ".TEST";
            string itmOut = ItemsFilename + ".TEST";
            using (Stream file = File.OpenWrite(cmpOut)) Campaign.Write(new BinaryWriter(file));
            using (Stream file = File.OpenWrite(monOut)) Monsters.Write(new BinaryWriter(file));
            using (Stream file = File.OpenWrite(itmOut)) Items.Write(new BinaryWriter(file));

            MessageBox.Show($"Wrote: {cmpOut}, {monOut}, {itmOut}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MonsterList_DoubleClick(object sender, EventArgs e)
        {
            object target = MonsterList.SelectedItem;
            if (target != null)
            {
                MonsterForm form = new MonsterForm();
                form.Setup(Campaign, target as Monster);
                form.ShowDialog();
            }
        }
    }
}
