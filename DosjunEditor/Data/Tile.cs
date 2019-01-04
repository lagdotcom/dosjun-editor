using System.IO;

namespace DosjunEditor
{
    public class Tile : IBinaryData
    {
        public const int Padding = 15;

        public Tile()
        {
            Walls = new Wall[Globals.NumWalls];
            for (var i = 0; i < 4; i++)
                Walls[i] = new Wall((Direction)i);
        }

        public void Read(BinaryReader br)
        {
            br.ReadArray(Walls);
            FloorTexture = br.ReadUInt16();
            CeilingTexture = br.ReadUInt16();
            DescriptionId = br.ReadUInt16();
            OnEnterId = br.ReadUInt16();
            ETableId = br.ReadUInt16();
            Flags = (TileFlags)br.ReadUInt16();
            Thing = br.ReadUInt16();
            OnUseId = br.ReadUInt16();
            Danger = br.ReadByte();
            Effect = (TileEffect)br.ReadByte();

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
            bw.Write(Thing);
            bw.Write(OnUseId);
            bw.Write(Danger);
            bw.Write((byte)Effect);

            bw.WritePadding(Padding);
        }

        public int X { get; set; }
        public int Y { get; set; }

        public Wall[] Walls { get; private set; }
        public ushort FloorTexture { get; set; }
        public ushort CeilingTexture { get; set; }
        public ushort DescriptionId { get; set; }
        public ushort OnEnterId { get; set; }
        public ushort ETableId { get; set; }
        public TileFlags Flags { get; set; }
        public ushort Thing { get; set; }
        public ushort OnUseId { get; set; }
        public byte Danger { get; set; }
        public TileEffect Effect { get; set; }

        public override string ToString() => $"{X},{Y}";
    }
}
