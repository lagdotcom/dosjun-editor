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
    public partial class CampaignEditor : Form, IResourceEditor
    {
        public CampaignEditor()
        {
            InitializeComponent();
        }

        public Context Context { get; private set; }
        public Campaign Campaign { get; private set; }
        public IHasResource Editing => Campaign;

        public event EventHandler Saved;

        public void Setup(Context ctx, IHasResource r)
        {
            Context = ctx;
            Campaign = r as Campaign;

            Globals.Populate(StartScript, ctx.Djn.Scripts);

            NumGlobals.Value = Campaign.NumGlobals;
            NumFlags.Value = Campaign.NumFlags;
            StartScript.SelectedItem = Globals.Resolve(ctx, Campaign.StartingScript);
            CampaignName.Text = ctx.GetString(Campaign.NameId);
            CampaignDesc.Text = ctx.GetString(Campaign.DescId);
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            Campaign.NumGlobals = (ushort)NumGlobals.Value;
            Campaign.NumFlags = (ushort)NumFlags.Value;
            Campaign.StartingScript = (StartScript.SelectedItem as Resource).ID;
            Campaign.NameId = Context.GetStringId(CampaignName.Text, Campaign.NameId);
            Campaign.DescId = Context.GetStringId(CampaignDesc.Text, Campaign.DescId);

            Saved?.Invoke(this, null);
            Context.UnsavedChanges = true;
            Close();
        }
    }
}
