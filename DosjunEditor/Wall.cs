using System.IO;

namespace DosjunEditor
{
    public class Wall : IBinaryData
    {
        public const int Padding = 2;

        public void Read(BinaryReader br)
        {
            Texture = br.ReadByte();
            Type = (WallType)br.ReadByte();

            br.ReadBytes(Padding);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(Texture);
            bw.Write((byte)Type);

            bw.WritePadding(Padding);
        }

        public byte Texture { get; set; }
        public WallType Type { get; set; }

        public override string ToString() => $"{Type} #{Texture}";
    }
}
