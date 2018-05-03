using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DosjunEditor
{
    public partial class MonsterForm : Form, IResourceEditor
    {
        public MonsterForm()
        {
            InitializeComponent();

            foreach (string name in Tools.GetEnumNames<AI>())
                AIBox.Items.Add(name);

            foreach (string name in Tools.GetEnumNames<Skill>())
                SkillsList.Items.Add(name);
        }

        public Context Context { get; private set; }
        public Monster Monster { get; private set; }
        public IHasResource Editing => Monster;

        public event EventHandler Saved;

        public void Setup(Context ctx, IHasResource r)
        {
            Context = ctx;
            Monster = r as Monster;

            NameBox.MaxLength = Consts.NameSize;
            NameBox.Text = Monster.Name;

            ImageBox.Text = Monster.Image;

            RowBox.SelectedIndex = (int)Monster.Row;

            AIBox.SelectedIndex = (int)Monster.AI;

            XPBox.Value = Monster.Experience;

            StatsBoxes.Stats = Monster.Stats;

            SkillsList.SelectedIndices.Clear();
            foreach (short sk in Monster.Skills)
                SkillsList.SelectedIndices.Add(sk);
        }

        public void Apply()
        {
            Monster.Name = NameBox.Text;
            Monster.Image = ImageBox.Text.ToUpper();
            Monster.Row = (Row)RowBox.SelectedIndex;
            Monster.AI = (AI)AIBox.SelectedIndex;
            Monster.Experience = (uint)XPBox.Value;
            StatsBoxes.Apply();

            Monster.Skills.Clear();
            foreach (int sk in SkillsList.SelectedIndices)
                Monster.Skills.Add((short)sk);

            Saved?.Invoke(this, null);
        }

        private void ImageBox_TextChanged(object sender, EventArgs e)
        {
            ImageShow.Image = Tools.GetPCX($"{Consts.MonsterDirectory}{Path.DirectorySeparatorChar}{ImageBox.Text}.PCX")?.ToBitmap(); 
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            Apply();
            Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
