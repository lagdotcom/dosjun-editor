using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DosjunEditor
{
    class LineDrawer
    {
        private bool first = true;

        public LineDrawer(Graphics g)
        {
            Colour = Color.White;
            G = g;
            Thickness = 1;
        }

        public LineDrawer(Graphics g, Point p, Direction facing)
            : this(g)
        {
            Pos = p;
            Facing = facing;
        }

        public LineDrawer(Graphics g, int x1, int y1, Direction facing)
            : this(g, new Point(x1, y1), facing) { }

        public Color Colour { get; set; }
        public Direction Facing { get; private set; }
        public Graphics G { get; private set; }
        public Point Pos { get; private set; }
        public Rectangle Rect { get; private set; }
        public int Thickness { get; set; }

        public Brush Brush => new SolidBrush(Colour);
        public Pen Pen => new Pen(Colour);

        public LineDrawer Turn(int amount = 1)
        {
            while (amount < 0)
            {
                Facing = TurnLeft(Facing);
                amount++;
            }

            while (amount > 0)
            {
                Facing = TurnRight(Facing);
                amount--;
            }

            return this;
        }

        public LineDrawer Draw(int distance)
        {
            Point start = Pos;
            Move(distance);

            Rectangle rect = MakeRectangle(start, Pos);
            switch (Facing)
            {
                case Direction.North:
                case Direction.South:
                    rect.Inflate(Thickness, 0);
                    break;

                case Direction.West:
                case Direction.East:
                    rect.Inflate(0, Thickness);
                    break;
            }

            G.FillRectangle(Brush, rect);

            if (first)
            {
                Rect = rect;
                first = false;
            }
            else
                Rect = Rectangle.Union(Rect, rect);

            return this;
        }

        public LineDrawer Move(int distance)
        {
            Pos = new Point(Pos.X + DX(Facing, distance), Pos.Y + DY(Facing, distance));

            return this;
        }

        private static Rectangle MakeRectangle(Point a, Point b) => Rectangle.FromLTRB(
            a.X < b.X ? a.X : b.X,
            a.Y < b.Y ? a.Y : b.Y,
            a.X > b.X ? a.X : b.X,
            a.Y > b.Y ? a.Y : b.Y
        );

        private static int DX(Direction dir, int distance)
        {
            switch (dir)
            {
                case Direction.West: return -distance;
                case Direction.East: return distance;
                default: return 0;
            }
        }

        private static int DY(Direction dir, int distance)
        {
            switch (dir)
            {
                case Direction.North: return -distance;
                case Direction.South: return distance;
                default: return 0;
            }
        }

        private static Direction TurnLeft(Direction dir)
        {
            switch (dir)
            {
                case Direction.South: return Direction.East;
                case Direction.West: return Direction.South;
                case Direction.North: return Direction.West;
                default: return Direction.North;
            }
        }

        private static Direction TurnRight(Direction dir)
        {
            switch (dir)
            {
                case Direction.North: return Direction.East;
                case Direction.East: return Direction.South;
                case Direction.South: return Direction.West;
                default: return Direction.North;
            }
        }
    }
}
