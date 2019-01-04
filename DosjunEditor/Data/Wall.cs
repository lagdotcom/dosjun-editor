using System.IO;

namespace DosjunEditor
{
    public class Wall : IBinaryData
    {
        public const int Padding = 1;

        public Wall(Direction dir)
        {
            Direction = dir;
        }

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

        public Direction Direction { get; private set; }
        public ushort TextureId { get; set; }
        public WallType Type { get; set; }

        public override string ToString() => $"{Direction}: {Type} #{TextureId}";
    }
}
