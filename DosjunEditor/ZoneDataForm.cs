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

            LocalBox.Maximum = Jun.Env.MaxLocals;
        }

        public Context Context { get; private set; }
        public Zone Zone { get; private set; }

        public void Setup(Context ctx, Zone zone)
        {
            Context = ctx;
            Zone = zone;

            NameBox.Text = ctx.GetString(Zone.NameId);
            WidthBox.Text = Zone.Width.ToString();
            HeightBox.Text = Zone.Height.ToString();
            FloorBox.Value = Zone.Floor;
            LocalBox.Value = Zone.LocalCount;

            Globals.Populate(EnterBox, Context.Djn.PublicScripts);
            EnterBox.SelectedItem = Globals.Resolve(Context, Zone.EnterScript);

            Globals.Populate(MoveBox, Context.Djn.PublicScripts);
            MoveBox.SelectedItem = Globals.Resolve(Context, Zone.MoveScript);
        }

        public void Apply()
        {
            Zone.NameId = Context.GetStringId(NameBox.Text, Zone.NameId);
            Zone.Floor = (byte)FloorBox.Value;
            Zone.LocalCount = (ushort)LocalBox.Value;
            Zone.EnterScript = (EnterBox.SelectedItem as Resource).ID;
            Zone.MoveScript = (MoveBox.SelectedItem as Resource).ID;
        }
    }
}
