using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DosjunEditor.Cartographer
{
    public partial class CartographerForm : Form, IResourceEditor
    {
        private Control toolOptions = null;

        public CartographerForm()
        {
            InitializeComponent();
        }

        public Context Context { get; private set; }
        public Zone Zone { get; private set; }
        public IHasResource Editing => Zone;

        public event EventHandler Saved;

        public void Setup(Context ctx, IHasResource r)
        {
            Context = ctx;
            Zone = r as Zone;

            Context.UnsavedChangesChanged += Context_UnsavedChangesChanged;
            Ui.Centre = new Point(Zone.Width / 2, Zone.Height / 2);
            Ui.Context = ctx;
            Ui.Zone = Zone;

            Tools.Add(new WallTypeCycler(Context));
            Tools.Add(new AreaDefiner(Zone, Ui, Context));
        }

        public bool CheckChanged()
        {
            if (Context.UnsavedChanges)
            {
                DialogResult result = MessageBox.Show("Save changes?", "Don't lose your work!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Cancel) return true;
                if (result == DialogResult.Yes) SaveAll();
            }

            return false;
        }

        private void Context_UnsavedChangesChanged(object sender, EventArgs e)
        {
            if (Context.UnsavedChanges)
            {
                Text = "Cartographer*";
            }
            else
            {
                Text = "Cartographer";
            }
        }

        public void SaveAll()
        {
            Context.UnsavedChanges = false;
            Saved?.Invoke(this, null);
        }

        private void Ui_TileHighlighted(object sender, EventArgs e)
        {
            if (Ui.CurrentTile != null)
            {
                CellHighlightLabel.Text = Ui.CurrentTile.ToString();
                AreaHighlightLabel.Text = string.Join(", ", Context.Djn.Wip.Zones[Zone.Resource.ID].Areas.Where(a => a.Contains(Ui.CurrentTile.X, Ui.CurrentTile.Y)).Select(a => a.Name));
            }
            else
            {
                CellHighlightLabel.Text = "-";
                AreaHighlightLabel.Text = "-";
            }

            if (Ui.CurrentWall != null)
            {
                WallHighlightLabel.Text = Ui.CurrentWall.ToString();
            }
            else
            {
                WallHighlightLabel.Text = "-";
            }
        }

        private void Ui_ToolUsed(object sender, EventArgs e)
        {
            if (Ui.CurrentWall == null) Tools.Current.Apply(Ui.CurrentTile);
            else Tools.Current.Apply(Ui.CurrentTile, Ui.CurrentWall);
        }

        private void Tools_ToolChanged(object sender, EventArgs e)
        {
            ITool tool = Tools.Current;

            if (toolOptions != null)
            {
                Controls.Remove(toolOptions);
                toolOptions = null;
            }

            if (tool != null)
            {
                toolOptions = tool.Options;
                if (toolOptions != null)
                {
                    toolOptions.Dock = DockStyle.Right;
                    Controls.Add(toolOptions);
                }
            }
        }

        private void CartographerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = CheckChanged();
            }
        }
    }
}
