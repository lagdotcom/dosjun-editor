using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DosjunEditor
{
    public partial class MonsterForm : Form
    {
        public MonsterForm()
        {
            InitializeComponent();

            foreach (string name in Tools.GetEnumNames<AI>())
                AIBox.Items.Add(name);

            foreach (string name in Tools.GetEnumNames<Skill>())
                SkillsList.Items.Add(name);
        }

        public Campaign Campaign { get; private set; }
        public Monster Monster { get; private set; }

        public void Setup(Campaign cmp, Monster mon)
        {
            Campaign = cmp;
            Monster = mon;

            IDBox.Value = mon.Id;

            NameBox.MaxLength = Consts.NameSize;
            NameBox.Text = mon.Name;

            ImageBox.Text = mon.Image;

            RowBox.SelectedIndex = (int)mon.Row;

            AIBox.SelectedIndex = (int)mon.AI;

            XPBox.Value = mon.Experience;

            StatsBoxes.Stats = mon.Stats;

            SkillsList.SelectedIndices.Clear();
            foreach (short sk in mon.Skills)
                SkillsList.SelectedIndices.Add(sk);
        }

        public void Apply()
        {
            Monster.Id = (ushort)IDBox.Value;
            Monster.Name = NameBox.Text;
            Monster.Image = ImageBox.Text.ToUpper();
            Monster.Row = (Row)RowBox.SelectedIndex;
            Monster.AI = (AI)AIBox.SelectedIndex;
            Monster.Experience = (uint)XPBox.Value;
            StatsBoxes.Apply();

            Monster.Skills.Clear();
            foreach (int sk in SkillsList.SelectedIndices)
                Monster.Skills.Add((short)sk);
        }

        private void ImageBox_TextChanged(object sender, EventArgs e)
        {
            ImageShow.Image = Tools.GetPCX($"{Consts.MonsterDirectory}{Path.DirectorySeparatorChar}{ImageBox.Text}.PCX")?.ToBitmap(); 
        }
    }
}
