using System.Drawing;
using System.IO;

namespace DosjunEditor
{
    public class JascPal
    {
        public const string Magic = "JASC-PAL";

        public JascPal()
        {
            Data = new Color[0];
        }

        public void Load(string filename)
        {
            using (Stream file = File.OpenRead(filename))
            {
                StreamReader sr = new StreamReader(file);
                if (sr.ReadLine() != Magic) throw new InvalidDataException("Not a JASC-PAL");
                sr.ReadLine(); // hex thing

                int count = int.Parse(sr.ReadLine());
                Data = new Color[count];
                for (var i = 0; i < count; i++)
                {
                    string[] bits = sr.ReadLine().Split(' ');
                    Data[i] = Color.FromArgb(int.Parse(bits[0]), int.Parse(bits[1]), int.Parse(bits[2]));
                }
            }
        }

        public Color[] Data { get; private set; }

        public Color this[int key]
        {
            get => Data[key];
        }
    }
}
