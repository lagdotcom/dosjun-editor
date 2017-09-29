using System.IO;

namespace DosjunEditor
{
    public class Wall : IBinaryData
    {
        public const int Padding = 2;

        public void Read(BinaryReader br)
        {
            TextureId = br.ReadByte();
            Type = (WallType)br.ReadByte();

            br.ReadBytes(Padding);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(TextureId);
            bw.Write((byte)Type);

            bw.WritePadding(Padding);
        }

        public byte TextureId { get; set; }
        public WallType Type { get; set; }

        public override string ToString() => $"{Type} #{TextureId}";
    }
}
