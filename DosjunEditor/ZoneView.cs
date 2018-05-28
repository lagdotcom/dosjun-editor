using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DosjunEditor
{
    public partial class ZoneView : UserControl
    {
        private int tileSize = 8;
        private Tile selectedTile;
        private Color selectedTileColour = Color.FromArgb(127, Color.Yellow);
        private Dictionary<string, Color> textureColours;

        public ZoneView()
        {
            InitializeComponent();

            textureColours = new Dictionary<string, Color>
            {
                { "WWASH", Color.White },
                { "WSTONE", Color.Blue },
            };
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
                        e.Graphics.FillRectangle(Brushes.Yellow, ex - 6, ey - 6, 4, 4);

                    if (t.OnUseId > 0)
                        e.Graphics.FillRectangle(Brushes.Red, ex - 6, ey - 10, 4, 4);

                    if (t.Thing > 0)
                        DrawThing(e.Graphics, t.Thing, ox, oy, ex, ey);
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

        private void DrawThing(Graphics g, Thing id, int ox, int oy, int ex, int ey)
        {
            float mx = ox + (ex - ox) / 2f;
            float my = oy + (ey - oy) / 2f;

            switch (id)
            {
                case Thing.Shiny:
                    // small yellow diamond
                    g.DrawLine(Pens.Yellow, mx - Eighth, my, mx, my - Eighth);
                    g.DrawLine(Pens.Yellow, mx, my - Eighth, mx + Eighth, my);
                    g.DrawLine(Pens.Yellow, mx + Eighth, my, mx, my + Eighth);
                    g.DrawLine(Pens.Yellow, mx, my + Eighth, mx - Eighth, my);
                    break;

                case Thing.Barrel:
                    // cylinder
                    g.DrawEllipse(Pens.Brown, ox + Eighth, oy + Eighth, Quarter * 3 - 1, Quarter);
                    g.DrawEllipse(Pens.Brown, ox + Eighth, ey - Eighth - Quarter, Quarter * 3 - 1, Quarter);
                    g.DrawLine(Pens.Brown, ox + Eighth, oy + Quarter, ox + Eighth, ey - Quarter);
                    g.DrawLine(Pens.Brown, ex - Eighth, oy + Quarter, ex - Eighth, ey - Quarter);
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
