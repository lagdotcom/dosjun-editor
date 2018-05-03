using System.IO;

namespace DosjunEditor
{
    public class Wall : IBinaryData
    {
        public const int Padding = 1;

        public void Read(BinaryReader br)
        {
            TextureId = br.ReadUInt16();
            Type = (WallType)br.ReadByte();

            br.ReadBytes(Padding);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(TextureId);
            bw.Write((byte)Type);

            bw.WritePadding(Padding);
        }

        public ushort TextureId { get; set; }
        public WallType Type { get; set; }

        public override string ToString() => $"{Type} #{TextureId}";
    }
}
