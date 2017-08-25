using System;
using System.Collections.Generic;
using System.Drawing;

namespace DosjunEditor
{
    public class TileBag
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
            if (!tiles.ContainsKey(p)) tiles[p] = new Tile();

            return tiles[p];
        }

        public void Set(int x, int y, Tile t)
        {
            if (x >= Width) Width = x + 1;
            if (y >= Height) Height = y + 1;
            tiles[new Point(x, y)] = t;
        }
    }
}
