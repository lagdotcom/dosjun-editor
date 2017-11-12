using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DosjunEditor
{
    public partial class ZoneDataForm : Form
    {
        public ZoneDataForm()
        {
            InitializeComponent();
        }

        public Zone Zone { get; private set; }

        public void Setup(ZoneContext context)
        {
            Zone = context.Zone;

            CampaignBox.Text = Zone.CampaignName;
            WidthBox.Text = Zone.Width.ToString();
            HeightBox.Text = Zone.Height.ToString();

            EnterBox.Items.Clear();
            EnterBox.Items.AddRange(context.ScriptNames);
            EnterBox.SelectedIndex = Zone.EnterScript;

            MoveBox.Items.Clear();
            MoveBox.Items.AddRange(context.ScriptNames);
            MoveBox.SelectedIndex = Zone.MoveScript;
        }

        public void Apply()
        {
            Zone.EnterScript = (ushort)EnterBox.SelectedIndex;
            Zone.MoveScript = (ushort)MoveBox.SelectedIndex;
        }
    }
}
