using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;

namespace DosjunEditor
{
    public class ImgConverter
    {
        public const int MaxStrip = byte.MaxValue - GrfImage.Data;

        private List<byte> raw;
        private int x, y;
        private int lastX, lastY;
        private bool zeroMode;
        private List<byte> strip;

        public GrfImage Convert(Image image)
        {
            if (image.Width > ushort.MaxValue || image.Height > ushort.MaxValue)
                throw new ArgumentOutOfRangeException("i", "Image size is too large");

            GrfImage dst = new GrfImage
            {
                Width = (ushort)image.Width,
                Height = (ushort)image.Height,
            };

            Bitmap bmp = new Bitmap(image);
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData data = bmp.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            int dataSize = Math.Abs(data.Stride) * bmp.Height;
            byte[] bytes = new byte[dataSize];
            Marshal.Copy(data.Scan0, bytes, 0, dataSize);

            Reset();

            for (int i = 0; i < dataSize; i += 3)
            {
                // BGR format
                byte r = bytes[i + 2];
                byte g = bytes[i + 1];
                byte b = bytes[i];

                byte index = Lookup(r, g, b);

                if (index == 0)
                {
                    EndStrip();
                    AddZero();
                }
                else
                {
                    EndZeroes();
                    strip.Add(index);
                }

                x++;
                if (x == bmp.Width)
                {
                    x = 0;
                    y++;
                }
            }

            EndStrip();
            WriteEnd();

            bmp.UnlockBits(data);
            dst.Raw = raw.ToArray();
            return dst;
        }

        // Helpers

        private void Reset()
        {
            x = 0;
            y = 0;
            lastX = 0;
            lastY = 0;
            zeroMode = false;
            strip = new List<byte>();
            raw = new List<byte>();
        }

        private void EndZeroes()
        {
            if (zeroMode)
            {
                WriteSkip(lastX, lastY, x, y);
                zeroMode = false;
            }
        }

        private void AddZero()
        {
            if (!zeroMode)
            {
                zeroMode = true;
                lastX = x;
                lastY = y;
            }
        }

        private void EndStrip()
        {
            if (strip.Count > 0)
            {
                IEnumerable<byte> bytes = strip.AsEnumerable();

                while (strip.Count > MaxStrip)
                {
                    raw.Add(byte.MaxValue);
                    raw.AddRange(bytes.Take(MaxStrip));

                    bytes = bytes.Skip(MaxStrip);
                }

                raw.Add((byte)(bytes.Count() + GrfImage.Data));
                raw.AddRange(bytes);

                strip.Clear();
            }
        }

        // Direct Writes

        private void WriteEnd()
        {
            raw.Add(GrfImage.End);
        }

        private void WriteSkip(int lastX, int lastY, int x, int y)
        {
            int xdiff = x - lastX;
            int ydiff = y - lastY;

            while (xdiff > byte.MaxValue)
            {
                raw.Add(GrfImage.Skip);
                raw.Add(byte.MaxValue);
                raw.Add(0);
                xdiff -= byte.MaxValue;
            }

            while (xdiff < -byte.MaxValue)
            {
                raw.Add(GrfImage.Jump);
                raw.Add(byte.MaxValue);
                raw.Add(0);
                xdiff += byte.MaxValue;
            }

            if (xdiff > 0)
            {
                raw.Add(GrfImage.Skip);
                raw.Add((byte)xdiff);
                raw.Add((byte)ydiff);
            }

            if (xdiff < 0)
            {
                raw.Add(GrfImage.Jump);
                raw.Add((byte)-xdiff);
                raw.Add((byte)ydiff);
            }
        }

        public byte Lookup(byte r, byte g, byte b) => Palette.Closest(r, g, b);

        public Palette Palette { get; set; }
    }
}
