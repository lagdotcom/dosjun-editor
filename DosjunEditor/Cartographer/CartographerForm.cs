using System;
using System.Drawing;
using System.Windows.Forms;

namespace DosjunEditor.Cartographer
{
    public partial class CartographerForm : Form, IResourceEditor
    {
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
            CellHighlightLabel.Text = Ui.CurrentTile?.ToString();
            WallHighlightLabel.Text = Ui.CurrentWall?.ToString();
        }

        private void Ui_ToolUsed(object sender, EventArgs e)
        {
            if (Ui.CurrentWall == null) Tools.Current.Apply(Ui.CurrentTile);
            else Tools.Current.Apply(Ui.CurrentTile, Ui.CurrentWall);
        }
    }
}
