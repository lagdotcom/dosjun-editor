using DosjunEditor.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DosjunEditor.Cartographer
{
    class AreaDefiner : ITool
    {
        private AreaDefinerOptions options;
        private Brush brush;

        public AreaDefiner(Zone z, CartographerUi ui, Context ctx)
        {
            Context = ctx;
            Ui = ui;
            options = new AreaDefinerOptions();
            options.Setup(z, ctx);
            options.AreaChanged += Options_AreaChanged;

            brush = new SolidBrush(Color.FromArgb(128, 255, 255, 0));
        }

        private void Options_AreaChanged(object sender, EventArgs e)
        {
            Ui.Invalidate();
        }

        public Context Context { get; private set; }
        public Wip.ZoneArea CurrentArea => options.CurrentArea;
        public Control Options => options;
        public CartographerUi Ui { get; private set; }

        public string Name => "Area Definer";

        public void Activate()
        {
            Ui.TilePainted += Ui_TilePainted;
            Ui.Invalidate();
        }

        public void Deactivate()
        {
            Ui.TilePainted -= Ui_TilePainted;
            Ui.Invalidate();
        }

        private void Ui_TilePainted(object sender, PaintEventArgs e)
        {
            if (CurrentArea != null)
            {
                if (CurrentArea.Contains(Ui.PaintingTile.X, Ui.PaintingTile.Y))
                {
                    e.Graphics.FillRegion(brush, e.Graphics.Clip);
                }
            }
        }

        public void Apply(Tile tile)
        {
            if (CurrentArea != null)
            {
                if (!CurrentArea.Contains(tile.X, tile.Y))
                {
                    CurrentArea.Add(tile.X, tile.Y);
                    Context.UnsavedChanges = true;
                }
                else
                {
                    CurrentArea.Remove(tile.X, tile.Y);
                    Context.UnsavedChanges = true;
                }
            }
        }

        public void Apply(Tile tile, Wall wall)
        {
            Apply(tile);
        }
    }
}
