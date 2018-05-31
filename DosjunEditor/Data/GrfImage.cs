using System;
using System.Drawing;
using System.IO;

namespace DosjunEditor
{
    public class GrfImage : IBinaryData
    {
        public const int Padding = 2;

        public const byte Skip = 0;
        public const byte Jump = 1;
        public const byte End = 2;

        public const byte Data = 2;

        public GrfImage()
        {
            Raw = new byte[0];
        }

        public ushort Width { get; set; }
        public ushort Height { get; set; }
        public byte[] Raw { get; set; }

        public void Read(BinaryReader br)
        {
            Width = br.ReadUInt16();
            Height = br.ReadUInt16();
            ushort datasize = br.ReadUInt16();
            br.ReadBytes(Padding);

            Raw = br.ReadBytes(datasize);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(Width);
            bw.Write(Height);
            bw.Write((ushort)Raw.Length);
            bw.WritePadding(Padding);

            bw.Write(Raw);
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
                while (d < Raw.Length)
                {
                    switch (Raw[d])
                    {
                        case Skip:
                            x += Raw[d + 1];
                            y += Raw[d + 2];
                            d += 3;
                            break;

                        case Jump:
                            x -= Raw[d + 1];
                            y += Raw[d + 2];
                            d += 3;
                            break;

                        case End:
                            return bmp;

                        default:
                            int length = Raw[d++] - Data;
                            for (int i = 0; i < length; i++)
                            {
                                byte index = Raw[d++];
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
            } catch (Exception)
            {
                return bmp;
            }

            return bmp;
        }
    }
}
