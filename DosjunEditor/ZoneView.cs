﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DosjunEditor
{
    public partial class ZoneView : UserControl
    {
        private int tileSize = 8;
        private Tile selectedTile;
        private Color selectedTileColour = Color.FromArgb(127, Color.Yellow);

        public ZoneView()
        {
            InitializeComponent();
        }

        public Context Context { get; private set; }
        public Zone Zone { get; private set; }

        public int TileSize
        {
            get => tileSize;
            set
            {
                tileSize = value;
                Invalidate();
            }
        }

        private float Quarter => (float)TileSize / 4;
        private float Eighth => (float)TileSize / 8;

        public delegate void TileEventHandler(Tile t);
        public event TileEventHandler TileSelected;

        public void Setup(Context ctx, Zone zone)
        {
            Context = ctx;
            Zone = zone;

            SelectTile(zone.Tiles.At(0, 0));
            Invalidate();
        }

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
                e.Graphics.FillRectangle(new SolidBrush(selectedTileColour), ox, oy, tileSize, tileSize);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            e.Graphics.FillRectangle(Brushes.Black, e.ClipRectangle);

            if (Zone == null)
            {
                e.Graphics.DrawString("No Zone", Font, Brushes.Red, 10, 10);
                return;
            }

            int q = tileSize / 4;
            int ei = q / 2;
            for (int y = 0; y < Zone.Tiles.Height; y++)
            {
                for (int x = 0; x < Zone.Tiles.Width; x++)
                {
                    Tile t = Zone.Tiles.At(x, y);
                    int ox = x * tileSize;
                    int oy = y * tileSize;
                    int ex = ox + tileSize - 1;
                    int ey = oy + tileSize - 1;

                    if (t.Flags.HasFlag(TileFlags.Impassable))
                    {
                        e.Graphics.DrawLine(Pens.DarkRed, ox, oy, ex, ey);
                        e.Graphics.DrawLine(Pens.DarkRed, ex, oy, ox, ey);
                    }

                    DrawSide(e.Graphics, t.Walls[0], Direction.North, ox, oy);
                    DrawSide(e.Graphics, t.Walls[1], Direction.East, ox, oy);
                    DrawSide(e.Graphics, t.Walls[2], Direction.South, ox, oy);
                    DrawSide(e.Graphics, t.Walls[3], Direction.West, ox, oy);

                    if (t.OnEnterId > 0)
                        e.Graphics.FillRectangle(Brushes.Yellow, ox + ei, oy + ei, q, q);

                    if (t.OnUseId > 0)
                        e.Graphics.FillRectangle(Brushes.Red, ox + ei, ey - q - ei, q, q);

                    if (t.Thing > 0)
                        e.Graphics.FillRectangle(Brushes.Green, ex - q - ei, ey - q - ei, q, q);

                    if (Zone.Items.Any(p => p.X == x && p.Y == y))
                        e.Graphics.FillRectangle(Brushes.Cyan, ex - q - ei, oy + ei, q, q);
                }
            }
        }

        private void DrawSide(Graphics g, Wall w, Direction dir, int ox, int oy)
        {
            if (w.TextureId == 0) return;

            Brush b = WallBrush(w.TextureId);
            int ex = ox + tileSize - 1;
            int ey = oy + tileSize - 1;

            switch (w.Type)
            {
                case WallType.Normal:
                    switch (dir)
                    {
                        case Direction.North:
                            g.FillRectangle(b, ox, oy, tileSize, 2);
                            break;

                        case Direction.East:
                            g.FillRectangle(b, ex - 1, oy, 2, tileSize);
                            break;

                        case Direction.South:
                            g.FillRectangle(b, ox, ey - 1, tileSize, 2);
                            break;

                        case Direction.West:
                            g.FillRectangle(b, ox, oy, 2, tileSize);
                            break;
                    }

                    break;

                case WallType.Door:
                    switch (dir)
                    {
                        case Direction.North:
                            g.FillRectangle(b, ox, oy, Quarter, 2);
                            g.FillRectangle(b, ox + Quarter, oy, 2, Quarter);
                            g.FillRectangle(b, ex - Quarter, oy, Quarter + 1, 2);
                            g.FillRectangle(b, ex - Quarter - 1, oy, 2, Quarter);
                            break;

                        case Direction.East:
                            g.FillRectangle(b, ex - 1, oy, 2, Quarter);
                            g.FillRectangle(b, ex - Quarter + 1, oy + Quarter, Quarter, 2);
                            g.FillRectangle(b, ex - 1, ey - Quarter, 2, Quarter + 1);
                            g.FillRectangle(b, ex - Quarter + 1, ey - Quarter - 1, Quarter, 2);
                            break;

                        case Direction.South:
                            g.FillRectangle(b, ox, ey - 1, Quarter, 2);
                            g.FillRectangle(b, ox + Quarter, ey - Quarter + 1, 2, Quarter);
                            g.FillRectangle(b, ex - Quarter, ey - 1, Quarter + 1, 2);
                            g.FillRectangle(b, ex - Quarter - 1, ey - Quarter + 1, 2, Quarter);
                            break;

                        case Direction.West:
                            g.FillRectangle(b, ox, oy, 2, Quarter);
                            g.FillRectangle(b, ox, oy + Quarter, Quarter, 2);
                            g.FillRectangle(b, ox, ey - Quarter, 2, Quarter + 1);
                            g.FillRectangle(b, ox, ey - Quarter - 1, Quarter, 2);
                            break;
                    }

                    break;

                case WallType.LockedDoor:
                    switch (dir)
                    {
                        case Direction.North:
                            g.FillRectangle(b, ox, oy, tileSize, 2);
                            g.FillRectangle(b, ox + Quarter, oy, 2, Quarter);
                            g.FillRectangle(b, ex - Quarter - 1, oy, 2, Quarter);
                            break;

                        case Direction.East:
                            g.FillRectangle(b, ex - 1, oy, 2, tileSize);
                            g.FillRectangle(b, ex - Quarter + 1, oy + Quarter, Quarter, 2);
                            g.FillRectangle(b, ex - Quarter + 1, ey - Quarter - 1, Quarter, 2);
                            break;

                        case Direction.South:
                            g.FillRectangle(b, ox, ey - 1, tileSize, 2);
                            g.FillRectangle(b, ox + Quarter, ey - Quarter + 1, 2, Quarter);
                            g.FillRectangle(b, ex - Quarter - 1, ey - Quarter + 1, 2, Quarter);
                            break;

                        case Direction.West:
                            g.FillRectangle(b, ox, oy, 2, tileSize);
                            g.FillRectangle(b, ox, oy + Quarter, Quarter, 2);
                            g.FillRectangle(b, ox, ey - Quarter - 1, Quarter, 2);
                            break;
                    }

                    break;
            }
        }

        private void ZoneView_MouseClick(object sender, MouseEventArgs e)
        {
            if (Zone == null) return;

            int x = e.X / tileSize;
            int y = e.Y / tileSize;

            if (Zone.Tiles.Width > x && Zone.Tiles.Height > y)
            {
                SelectTile(Zone.Tiles.At(x, y));
            }
        }

        private Brush WallBrush(ushort index)
        {
            // TODO
            return new SolidBrush(Color.Gray);
        }

        public void Carve(int xmod, int ymod)
        {
            int dx = selectedTile.X + xmod;
            int dy = selectedTile.Y + ymod;

            if (dx < 0 || dy < 0) return;

            SelectTile(Zone.Tiles.At(dx, dy));
        }
    }
}
