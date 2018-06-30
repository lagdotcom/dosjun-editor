using System.IO;

namespace DosjunEditor
{
    public class ItemPos : IBinaryData
    {
        public void Read(BinaryReader br)
        {
            ItemId = br.ReadUInt16();
            X = br.ReadByte();
            Y = br.ReadByte();
            TileX = br.ReadByte();
            TileY = br.ReadByte();
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(ItemId);
            bw.Write(X);
            bw.Write(Y);
            bw.Write(TileX);
            bw.Write(TileY);
        }

        public ushort ItemId { get; set; }
        public byte X { get; set; }
        public byte Y { get; set; }
        public byte TileX { get; set; }
        public byte TileY { get; set; }
    }
}
