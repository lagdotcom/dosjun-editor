using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            e.Graphics.FillRectangle(Brushes.Black, e.ClipRectangle);

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

                    e.Graphics.FillRectangle(PaletteBrush(t.Floor), ox + 2, oy + 2, tileSize - 4, tileSize - 4);

                    e.Graphics.DrawLine(PalettePen(t.Walls[0].Texture), ox + 2, oy + 1, ex - 2, oy + 1);
                    e.Graphics.DrawLine(PalettePen(t.Walls[1].Texture), ex - 1, oy + 2, ex - 1, ey - 2);
                    e.Graphics.DrawLine(PalettePen(t.Walls[2].Texture), ox + 2, ey - 1, ex - 2, ey - 1);
                    e.Graphics.DrawLine(PalettePen(t.Walls[3].Texture), ox + 1, oy + 2, ox + 1, ey - 2);
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
                if (selectedTile != null)
                {
                    int ox = selectedTile.X * tileSize;
                    int oy = selectedTile.Y * tileSize;
                    Invalidate(new Rectangle(ox, oy, tileSize + 1, tileSize + 1));
                }

                SelectTile(zone.Tiles.At(x, y));

                int nx = selectedTile.X * tileSize;
                int ny = selectedTile.Y * tileSize;
                Invalidate(new Rectangle(nx, ny, tileSize + 1, tileSize + 1));
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
    }
}
