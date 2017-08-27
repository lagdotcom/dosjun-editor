using System;
using System.Drawing;
using System.Windows.Forms;

namespace DosjunEditor
{
    public partial class ZoneView : UserControl
    {
        private Zone zone;
        private int tileSize = 8;
        private Tile selectedTile;

        public ZoneView()
        {
            InitializeComponent();
        }

        public Zone Zone
        {
            get => zone;
            set
            {
                zone = value;
                if (zone != null) SelectTile(zone.Tiles.At(0, 0));
                Invalidate();
            }
        }

        public int TileSize
        {
            get => tileSize;
            set
            {
                tileSize = value;
                Invalidate();
            }
        }

        public delegate void TileEventHandler(Tile t);
        public event TileEventHandler TileSelected;

        public void UpdateTile()
        {
            int nx = selectedTile.X * tileSize;
            int ny = selectedTile.Y * tileSize;
            Invalidate(new Rectangle(nx, ny, tileSize + 1, tileSize + 1));
        }

        protected void SelectTile(Tile t)
        {
            if (selectedTile != null)
            {
                int ox = selectedTile.X * tileSize;
                int oy = selectedTile.Y * tileSize;
                Invalidate(new Rectangle(ox, oy, tileSize + 1, tileSize + 1));
            }

            int nx = t.X * tileSize;
            int ny = t.Y * tileSize;
            Invalidate(new Rectangle(nx, ny, tileSize + 1, tileSize + 1));

            selectedTile = t;
            TileSelected?.Invoke(t);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (selectedTile != null)
            {
                int ox = selectedTile.X * tileSize;
                int oy = selectedTile.Y * tileSize;
                e.Graphics.DrawRectangle(new Pen(Color.Yellow), ox, oy, tileSize - 1, tileSize - 1);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            e.Graphics.FillRectangle(Brushes.DarkGray, e.ClipRectangle);

            if (zone == null)
            {
                e.Graphics.DrawString("No Zone", Font, Brushes.Red, 10, 10);
                return;
            }

            for (int y = 0; y < zone.Tiles.Height; y++)
            {
                for (int x = 0; x < zone.Tiles.Width; x++)
                {
                    Tile t = zone.Tiles.At(x, y);
                    int ox = x * tileSize;
                    int oy = y * tileSize;
                    int ex = ox + tileSize - 1;
                    int ey = oy + tileSize - 1;

                    e.Graphics.FillRectangle(PaletteBrush(t.Floor), ox, oy, tileSize, tileSize);

                    if (t.Walls[0].Texture > 0)
                        e.Graphics.FillRectangle(PaletteBrush(t.Walls[0].Texture), ox, oy, tileSize, 2);

                    if (t.Walls[1].Texture > 0)
                        e.Graphics.FillRectangle(PaletteBrush(t.Walls[1].Texture), ex - 1, oy, 2, tileSize);

                    if (t.Walls[2].Texture > 0)
                        e.Graphics.FillRectangle(PaletteBrush(t.Walls[2].Texture), ox, ey - 1, tileSize, 2);

                    if (t.Walls[3].Texture > 0)
                        e.Graphics.FillRectangle(PaletteBrush(t.Walls[3].Texture), ox, oy, 2, tileSize);

                    if (t.OnEnterId > 0)
                        e.Graphics.FillRectangle(Brushes.Yellow, ex - 6, ey - 6, 4, 4);
                }
            }
        }

        private void ZoneView_MouseClick(object sender, MouseEventArgs e)
        {
            if (zone == null) return;

            int x = e.X / tileSize;
            int y = e.Y / tileSize;

            if (zone.Tiles.Width > x && zone.Tiles.Height > y)
            {
                SelectTile(zone.Tiles.At(x, y));
            }
        }

        private Brush PaletteBrush(byte index)
        {
            // TODO: cache
            return new SolidBrush(Globals.Palette[index]);
        }

        private Pen PalettePen(byte index)
        {
            // TODO: cache
            return new Pen(Globals.Palette[index]);
        }

        public void Carve(int xmod, int ymod)
        {
            int dx = selectedTile.X + xmod;
            int dy = selectedTile.Y + ymod;

            if (dx < 0 || dy < 0) return;

            SelectTile(zone.Tiles.At(dx, dy));
        }
    }
}
