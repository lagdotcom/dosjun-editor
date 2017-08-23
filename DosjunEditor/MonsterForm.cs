using System.Windows.Forms;

namespace DosjunEditor
{
    public partial class MonsterForm : Form
    {
        public MonsterForm()
        {
            InitializeComponent();
        }

        public Campaign Campaign { get; set; }
        public Monster Monster { get; set; }

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
        }
    }
}
