using System.IO;

namespace DosjunEditor
{
    public class Tile : IBinaryData
    {
        public const int Padding = 4;

        public Tile()
        {
            Walls = new Wall[4];
            for (var i = 0; i < 4; i++)
                Walls[i] = new Wall();
        }

        public void Read(BinaryReader br)
        {
            Walls = br.ReadArray<Wall>(4);
            FloorTexture = br.ReadByte();
            CeilingTexture = br.ReadByte();
            DescriptionId = br.ReadUInt16();
            OnEnterId = br.ReadUInt16();
            ETableId = br.ReadUInt16();
            Flags = (TileFlags)br.ReadUInt16();
            Thing = (Thing)br.ReadByte();
            Danger = br.ReadByte();

            br.ReadBytes(Padding);
        }

        public void Write(BinaryWriter bw)
        {
            foreach (Wall w in Walls) w.Write(bw);
            bw.Write(FloorTexture);
            bw.Write(CeilingTexture);
            bw.Write(DescriptionId);
            bw.Write(OnEnterId);
            bw.Write(ETableId);
            bw.Write((ushort)Flags);
            bw.Write((byte)Thing);
            bw.Write(Danger);

            bw.WritePadding(Padding);
        }

        public int X { get; set; }
        public int Y { get; set; }

        public Wall[] Walls { get; private set; }
        public byte FloorTexture { get; set; }
        public byte CeilingTexture { get; set; }
        public ushort DescriptionId { get; set; }
        public ushort OnEnterId { get; set; }
        public ushort ETableId { get; set; }
        public TileFlags Flags { get; set; }
        public Thing Thing { get; set; }
        public byte Danger { get; set; }
    }
}
