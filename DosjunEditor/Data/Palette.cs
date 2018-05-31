using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DosjunEditor
{
    public class Palette : IHasResource
    {
        public const int Size = 256;

        private Color[] colours;
        private Dictionary<Color, byte> cache;

        public Palette(Resource r)
        {
            Resource = r;
            colours = new Color[256];

            cache = new Dictionary<Color, byte>();
        }
        public Palette() : this(new Resource { Type = ResourceType.Palette }) { }

        public Resource Resource { get; set; }

        public Color this[int i] => colours[i];

        public void Read(BinaryReader br)
        {
            for (int i = 0; i < Size; i++)
            {
                byte[] colour = br.ReadBytes(3);
                colours[i] = Color.FromArgb(colour[0] * 4, colour[1] * 4, colour[2] * 4);
            }
        }

        public void Write(BinaryWriter bw)
        {
            foreach (Color c in colours)
            {
                bw.Write((byte)(c.R / 4));
                bw.Write((byte)(c.G / 4));
                bw.Write((byte)(c.B / 4));
            }
        }

        public byte Closest(byte r, byte g, byte b)
        {
            Color find = Color.FromArgb(r, g, b);
            if (!cache.ContainsKey(find))
            {
                Color best = colours.OrderBy(check => EuclideanDistance(find, check)).First();
                cache[find] = (byte)Array.IndexOf(colours, best);
            }

            return cache[find];
        }

        public static double EuclideanDistance(Color a, Color b)
        {
            return Math.Sqrt(
                (a.R - b.R) * (a.R - b.R) +
                (a.G - b.G) * (a.G - b.G) +
                (a.B - b.B) * (a.B - b.B)
            );
        }
    }
}
