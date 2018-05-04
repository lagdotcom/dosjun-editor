using System.IO;

namespace DosjunEditor
{
    public class Font : IHasResource
    {
        public const int Padding = 14;
        public const int Chars = 256;

        public Resource Resource { get; set; }

        public Font(Resource r)
        {
            Resource = r;
            Version = new VersionHeader();
            CharacterWidths = new byte[Chars];
        }
        public Font() : this(new Resource { Type = ResourceType.Font }) { }

        public VersionHeader Version { get; set; }
        public string FileName { get; set; }
        public byte Width { get; set; }
        public byte Height { get; set; }
        public byte[] CharacterWidths { get; set; }

        public void Read(BinaryReader br)
        {
            Version.Read(br);
            FileName = br.ReadZS(12);
            Width = br.ReadByte();
            Height = br.ReadByte();
            br.ReadBytes(Padding);

            CharacterWidths = br.ReadBytes(Chars);
        }

        public void Write(BinaryWriter bw)
        {
            Version.Write(bw);
            bw.WriteZS(FileName, 12);
            bw.Write(Width);
            bw.Write(Height);
            bw.WritePadding(Padding);

            bw.Write(CharacterWidths);
        }
    }
}
