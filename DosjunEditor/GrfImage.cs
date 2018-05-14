using System;
using System.Drawing;
using System.IO;

namespace DosjunEditor
{
    public class GrfImage : IBinaryData
    {
        public const int Padding = 2;

        private const byte Skip = 0;
        private const byte Jump = 1;
        private const byte End = 2;

        private const byte Data = 2;

        private byte[] raw;

        public GrfImage()
        {
            raw = new byte[0];
        }

        public ushort Width { get; set; }
        public ushort Height { get; set; }

        public void Read(BinaryReader br)
        {
            Width = br.ReadUInt16();
            Height = br.ReadUInt16();
            ushort datasize = br.ReadUInt16();
            br.ReadBytes(Padding);

            raw = br.ReadBytes(datasize);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(Width);
            bw.Write(Height);
            bw.Write((ushort)raw.Length);
            bw.WritePadding(Padding);

            bw.Write(raw);
        }

        public Image AsImage(Palette pal)
        {
            Bitmap bmp = new Bitmap(Width, Height);
            int x = 0,
                y = 0,
                d = 0;

            Graphics g = Graphics.FromImage(bmp);
            g.FillRectangle(new SolidBrush(pal[0]), 0, 0, Width, Height);

            try
            {
                while (d < raw.Length)
                {
                    switch (raw[d])
                    {
                        case Skip:
                            x += raw[d + 1];
                            y += raw[d + 2];
                            d += 3;
                            break;

                        case Jump:
                            x -= raw[d + 1];
                            y += raw[d + 2];
                            d += 3;
                            break;

                        case End:
                            return bmp;

                        default:
                            int length = raw[d++] - Data;
                            for (int i = 0; i < length; i++)
                            {
                                byte index = raw[d++];
                                bmp.SetPixel(x, y, pal[index]);
                                x++;

                                if (x >= Width)
                                {
                                    x = 0;
                                    y++;
                                }
                            }
                            break;
                    }
                }
            } catch (Exception e)
            {
                return bmp;
            }

            return bmp;
        }
    }
}
