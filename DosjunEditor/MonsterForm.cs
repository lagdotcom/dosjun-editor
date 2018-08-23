using System;
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
        }

        public Context Context { get; private set; }
        public Monster Monster { get; private set; }
        public IHasResource Editing => Monster;

        public event EventHandler Saved;

        public void Setup(Context ctx, IHasResource r)
        {
            Context = ctx;
            Monster = r as Monster;

            Globals.Populate(ImageBox, Context.Djn.GrfSubtype(ResourceSubtype.Monster));
            Globals.Populate(DropsBox, Context.Djn.Type<DropTable>());

            NameBox.Text = Context.GetString(Monster.NameId);
            ImageBox.SelectedItem = Globals.Resolve(Context, Monster.ImageId);
            RowBox.SelectedIndex = (int)Monster.Row;
            AIBox.SelectedIndex = (int)Monster.AI;
            XPBox.Value = Monster.Experience;
            DropsBox.SelectedItem = Globals.Resolve(Context, Monster.DropsId);
            StatsBoxes.Stats = Monster.Stats;

            SkillsList.Values = Monster.Skills;

            StatsBoxes.UpdateFields();
        }

        public void Apply()
        {
            Monster.NameId = Context.GetStringId(NameBox.Text, Monster.NameId);
            Monster.ImageId = (ImageBox.SelectedItem as Resource).ID;
            Monster.Row = (Row)RowBox.SelectedIndex;
            Monster.AI = (AI)AIBox.SelectedIndex;
            Monster.Experience = (uint)XPBox.Value;
            Monster.DropsId = (DropsBox.SelectedItem as Resource).ID;
            StatsBoxes.Apply();

            Monster.Skills = SkillsList.Values.ToList();

            Saved?.Invoke(this, null);
        }

        private void ImageBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Resource r = ImageBox.SelectedItem as Resource;
            ImageShow.Image = r.ID == 0 ? null : (Context.Djn[r.ID] as Grf).Images[0].AsImage(Context.Djn.Palette);
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
