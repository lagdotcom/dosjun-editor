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
        private int x, y, width;
        private int lastX, lastY;
        private bool zeroMode;
        private List<byte> strip;

        public Palette Palette { get; set; }
        public byte Lookup(byte r, byte g, byte b) => Palette.Closest(r, g, b);

        public GrfImage Convert(Image image)
        {
            if (image.Width > ushort.MaxValue || image.Height > ushort.MaxValue)
                throw new ArgumentOutOfRangeException("i", "Image size is too large");

            width = image.Width;
            GrfImage dst = new GrfImage
            {
                Width = (ushort)width,
                Height = (ushort)image.Height,
            };

            Bitmap bmp = new Bitmap(image);
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);

            // get BMP data as byte[]
            int bpp = 3;
            BitmapData data = bmp.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            int dataSize = Math.Abs(data.Stride) * bmp.Height;
            int strideAdjustment = data.Stride - (bmp.Width * bpp);
            byte[] bytes = new byte[dataSize];
            Marshal.Copy(data.Scan0, bytes, 0, dataSize);
            bmp.UnlockBits(data);

            Reset();

            for (int i = 0; i < dataSize; i += bpp)
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
                if (x == width)
                {
                    x = 0;
                    y++;
                    i += strideAdjustment;
                }
            }

            EndStrip();
            WriteEnd();

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
                MoveCursor(lastX, lastY, x, y);
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
                    WriteStrip(bytes.Take(MaxStrip));
                    bytes = bytes.Skip(MaxStrip);
                }

                WriteStrip(strip);
                strip.Clear();
            }
        }

        private void MoveCursor(int lastX, int lastY, int x, int y)
        {
            int xdiff = x - lastX;
            int ydiff = y - lastY;

            while (xdiff > byte.MaxValue)
            {
                WriteSkip(byte.MaxValue, 0);
                xdiff -= byte.MaxValue;
            }

            while (xdiff < -byte.MaxValue)
            {
                WriteJump(byte.MaxValue, 0);
                xdiff += byte.MaxValue;
            }

            if (xdiff >= 0)
            {
                WriteSkip((byte)xdiff, (byte)ydiff);
            }

            if (xdiff < 0)
            {
                WriteJump((byte)-xdiff, (byte)ydiff);
            }
        }

        // Direct Writes

        private void WriteEnd()
        {
            raw.Add(GrfImage.End);
        }

        private void WriteStrip(IEnumerable<byte> strip)
        {
            int count = strip.Count();
            raw.Add((byte)(count + GrfImage.Data));
            raw.AddRange(strip);
        }

        private void WriteSkip(byte xm, byte ym)
        {
            raw.Add(GrfImage.Skip);
            raw.Add(xm);
            raw.Add(ym);
        }

        private void WriteJump(byte xm, byte ym)
        {
            raw.Add(GrfImage.Jump);
            raw.Add(xm);
            raw.Add(ym);
        }
    }
}
