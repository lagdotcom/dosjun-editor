using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DosjunEditor.Controls
{
    public partial class CartographerUi : UserControl
    {
        const int TileLayer = 1;
        const int WallLayer = 0;

        private StringFormat CentreBoth = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
        private Brush OutOfBoundsBrush = new SolidBrush(Color.DarkCyan);
        private Brush TileHighlightBrush = new SolidBrush(Color.FromArgb(32, 32, 0));

        private Point centre = new Point();
        private Context context;
        private Target currentTarget;
        private int deltaX, deltaY;
        private Dictionary<Rectangle, Target> hotspots = new Dictionary<Rectangle, Target>();
        private Point oldPosition;
        private int tileSize = 32;
        private Zone zone;

        public CartographerUi()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        public Point Centre
        {
            get => centre;
            set { centre = value; Invalidate(); }
        }

        public Context Context
        {
            get => context;
            set { context = value; Invalidate(); }
        }

        public Tile CurrentTile => currentTarget?.Tile;
        public Wall CurrentWall => currentTarget?.Wall;

        public Tile PaintingTile { get; private set; }
        
        public int TileSize
        {
            get => tileSize;
            set { tileSize = value; Invalidate(); }
        }

        public int WallThickness => TileSize / 8;

        public Zone Zone
        {
            get => zone;
            set
            {
                zone = value;
                Invalidate();
            }
        }

        public event EventHandler TileHighlighted;
        public event PaintEventHandler TilePainted;
        public event EventHandler ToolUsed;
        public event PaintEventHandler ZonePainted;

        protected override void OnPaint(PaintEventArgs e)
        {
            Region original = e.Graphics.Clip;

            if (zone == null)
            {
                e.Graphics.FillRectangle(Brushes.DarkRed, ClientRectangle);
                e.Graphics.DrawString("No Zone Selected", Font, Brushes.OrangeRed, ClientRectangle, CentreBoth);
                return;
            }

            e.Graphics.FillRectangle(OutOfBoundsBrush, ClientRectangle);

            int cx = (ClientRectangle.Width - TileSize) / 2;
            int cy = (ClientRectangle.Height - TileSize) / 2;

            hotspots.Clear();

            foreach (Tile t in Zone.Tiles)
            {
                int dx = t.X - Centre.X;
                int dy = t.Y - Centre.Y;

                PaintTile(e.Graphics, t, cx + dx * TileSize, cy + dy * TileSize);
            }

            e.Graphics.Clip = original;
            ZonePainted?.Invoke(this, e);
        }

        protected bool PaintTile(Graphics g, Tile t, int x, int y)
        {
            Rectangle rect = new Rectangle(x, y, TileSize, TileSize);
            if (!ClientRectangle.IntersectsWith(rect))
            {
                return false;
            }

            Point p = new Point(t.X, t.Y);
            bool highlighted = CurrentTile == t;

            g.Clip = new Region(rect);

            // TODO: floor colour
            if (t.FloorTexture > 0)
                g.FillRectangle(highlighted ? TileHighlightBrush : Brushes.Black, rect);

            PaintWall(g, t, t.Walls[0], p, Direction.North, rect.Left, rect.Top);
            PaintWall(g, t, t.Walls[1], p, Direction.East, rect.Right, rect.Top);
            PaintWall(g, t, t.Walls[2], p, Direction.South, rect.Right, rect.Bottom);
            PaintWall(g, t, t.Walls[3], p, Direction.West, rect.Left, rect.Bottom);

            rect.Inflate(-WallThickness, -WallThickness);
            hotspots.Add(rect, new Target { Tile = t, Layer = TileLayer });

            PaintingTile = t;
            TilePainted?.Invoke(this, new PaintEventArgs(g, rect));
            return true;
        }

        protected void PaintWall(Graphics g, Tile t, Wall w, Point p, Direction d, int x1, int y1)
        {
            bool highlighted = CurrentWall == w;
            int xm = 0, ym = 0;
            int width = tileSize, height = tileSize;

            LineDrawer ld = new LineDrawer(g, x1, y1, d)
            {
                Colour = highlighted ? Color.Yellow : Color.White,
                Thickness = WallThickness / 2
            }.Turn(1);

            switch (d)
            {
                case Direction.North:
                    height = WallThickness;
                    break;

                case Direction.South:
                    xm = tileSize;
                    ym = WallThickness;
                    height = WallThickness;
                    break;

                case Direction.West:
                    ym = tileSize;
                    width = WallThickness;
                    break;

                case Direction.East:
                    xm = WallThickness;
                    width = WallThickness;
                    break;
            }
            
            // TODO: wall colour
            int wallSize = tileSize / 3;
            int gapSize = tileSize - wallSize * 2;
            int doorSize = tileSize / 4;
            if (w.TextureId > 0)
            {
                switch (w.Type)
                {
                    case WallType.Normal:
                        ld.Draw(tileSize);
                        break;

                    case WallType.Door:
                        ld.Draw(wallSize)
                            .Turn(1)
                            .Draw(doorSize)
                            .Turn(-1)
                            .Move(gapSize)
                            .Turn(-1)
                            .Draw(doorSize)
                            .Turn(1)
                            .Draw(wallSize);
                        break;

                    case WallType.LockedDoor:
                        ld.Draw(tileSize)
                            .Turn(2)
                            .Move(wallSize)
                            .Turn(-1)
                            .Draw(doorSize)
                            .Turn(1)
                            .Move(gapSize)
                            .Turn(1)
                            .Draw(wallSize);
                        break;
                }
            }

            Rectangle rect = new Rectangle(x1 - xm, y1 - ym, width, height);
            hotspots.Add(rect, new Target { Tile = t, Wall = w, Layer = WallLayer });
        }

        private class Target
        {
            public int Layer { get; set; }
            public Tile Tile { get; set; }
            public Wall Wall { get; set; }
        }

        private void CartographerUi_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                deltaX += e.Location.X - oldPosition.X;
                deltaY += e.Location.Y - oldPosition.Y;

                DragMovement();
            }
            else
            {
                deltaX = 0;
                deltaY = 0;

                UpdateHighlight(e.X, e.Y);
            }

            oldPosition = e.Location;
        }

        private void CartographerUi_MouseClick(object sender, MouseEventArgs e)
        {
            if (currentTarget == null) return;

            if (e.Button == MouseButtons.Left)
            {
                ToolUsed?.Invoke(this, null);

                Context.UnsavedChanges = true;
                Invalidate();
            }
        }

        private void DragMovement()
        {
            Point newCentre = centre;
            bool moved = false;

            int cellsX = deltaX / tileSize;
            if (cellsX != 0)
            {
                deltaX = 0;
                moved = true;
                newCentre.X -= cellsX;
            }

            int cellsY = deltaY / tileSize;
            if (cellsY != 0)
            {
                deltaY = 0;
                moved = true;
                newCentre.Y -= cellsY;
            }

            if (moved) Centre = newCentre;
        }

        private void UpdateHighlight(int x, int y)
        {
            currentTarget = hotspots.Where(p => p.Key.Contains(x, y)).Select(p => p.Value).OrderBy(t => t.Layer).FirstOrDefault();

            TileHighlighted?.Invoke(this, null);
            Invalidate();
        }

        private void CartographerUi_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
