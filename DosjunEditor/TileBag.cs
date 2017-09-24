using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace DosjunEditor
{
    public class TileBag : IEnumerable<Tile>
    {
        private Dictionary<Point, Tile> tiles;

        public TileBag()
        {
            tiles = new Dictionary<Point, Tile>();
        }

        public int Width { get; private set; }
        public int Height { get; private set; }

        public Tile At(int x, int y)
        {
            Point p = new Point(x, y);
            if (!tiles.ContainsKey(p))
                Set(x, y, new Tile { X = x, Y = y });

            return tiles[p];
        }

        public IEnumerator<Tile> GetEnumerator() => new TileBagEnumerator(this);
        IEnumerator IEnumerable.GetEnumerator() => new TileBagEnumerator(this);

        public void Set(int x, int y, Tile t)
        {
            if (x >= Width) Width = x + 1;
            if (y >= Height) Height = y + 1;

            t.X = x;
            t.Y = y;
            tiles[new Point(x, y)] = t;
        }

        private class TileBagEnumerator : IEnumerator<Tile>
        {
            private TileBag bag;
            private int x, y;

            public TileBagEnumerator(TileBag parent)
            {
                bag = parent;
                Reset();
            }

            public Tile Current { get; private set; }
            object IEnumerator.Current => Current;

            public void Dispose() { }

            public bool MoveNext()
            {
                if (x == bag.Width)
                { 
                    if (y == bag.Height) return false;

                    x = 0;
                    y++;
                }
                else
                {
                    x++;
                }

                Current = bag.At(x, y);
                return true;
            }

            public void Reset()
            {
                x = 0;
                y = 0;
            }
        }
    }
}
