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

            NumGlobals.Maximum = Jun.Env.MaxGlobals;
            NumFlags.Maximum = Jun.Env.MaxFlags;
        }

        public Context Context { get; private set; }
        public Campaign Campaign { get; private set; }
        public IHasResource Editing => Campaign;

        public event EventHandler Saved;

        public void Setup(Context ctx, IHasResource r)
        {
            Context = ctx;
            Campaign = r as Campaign;

            Globals.Populate(StartScript, ctx.Djn.PublicScripts);
            Globals.Populate(FontBox, ctx.Djn.Fonts);
            Globals.Populate(MenuBg, ctx.Djn.Screens);
            Globals.Populate(DungeonBg, ctx.Djn.Screens);
            Globals.Populate(CombatBg, ctx.Djn.Screens);
            Globals.Populate(MenuMusic, ctx.Djn.Music);

            NumGlobals.Value = Campaign.NumGlobals;
            NumFlags.Value = Campaign.NumFlags;
            StartScript.SelectedItem = Globals.Resolve(ctx, Campaign.StartingScript);
            CampaignName.Text = ctx.GetString(Campaign.NameId);
            CampaignDesc.Text = ctx.GetString(Campaign.DescId);
            FontBox.SelectedItem = Globals.Resolve(ctx, Campaign.FontId);
            MenuBg.SelectedItem = Globals.Resolve(ctx, Campaign.MenuBgId);
            DungeonBg.SelectedItem = Globals.Resolve(ctx, Campaign.DungeonBgId);
            CombatBg.SelectedItem = Globals.Resolve(ctx, Campaign.CombatBgId);
            MenuMusic.SelectedItem = Globals.Resolve(ctx, Campaign.MenuMusicId);
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
            Campaign.FontId = (FontBox.SelectedItem as Resource).ID;
            Campaign.MenuBgId = (MenuBg.SelectedItem as Resource).ID;
            Campaign.DungeonBgId = (DungeonBg.SelectedItem as Resource).ID;
            Campaign.CombatBgId = (CombatBg.SelectedItem as Resource).ID;
            Campaign.MenuMusicId = (MenuMusic.SelectedItem as Resource).ID;

            Saved?.Invoke(this, null);
            Context.UnsavedChanges = true;
            Close();
        }
    }
}
