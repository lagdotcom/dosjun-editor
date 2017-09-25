using ImageMagick;
using System;
using System.IO;
using System.Windows.Forms;

namespace DosjunEditor
{
    public partial class MonsterForm : Form
    {
        public MonsterForm()
        {
            InitializeComponent();

            foreach (string name in Tools.GetNames<AI>())
                AIBox.Items.Add(name);
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

            StatsBoxes.Stats = mon.Stats;
        }

        public void Apply()
        {
            Monster.Id = (ushort)IDBox.Value;
            Monster.Name = NameBox.Text;
            Monster.Image = ImageBox.Text.ToUpper();
            Monster.Row = (Row)RowBox.SelectedIndex;
            Monster.AI = (AI)AIBox.SelectedIndex;
            StatsBoxes.Apply();
        }

        private void ImageBox_TextChanged(object sender, System.EventArgs e)
        {
            string path = $"{Consts.MonsterDirectory}{Path.DirectorySeparatorChar}{ImageBox.Text}.PCX";
            if (File.Exists(path))
            {
                using (MagickImage img = new MagickImage(path))
                    ImageShow.Image = img.ToBitmap();
            }
            else
            {
                ImageShow.Image = null;
            }
        }
    }
}
