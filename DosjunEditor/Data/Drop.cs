using System.IO;

namespace DosjunEditor
{
    public class Drop : IBinaryData
    {
        public void Read(BinaryReader br)
        {
            Reference = br.ReadUInt16();
            Chance = br.ReadByte();
            Flags = (DropFlags)br.ReadByte();
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(Reference);
            bw.Write(Chance);
            bw.Write((byte)Flags);
        }

        public ushort Reference { get; set; }
        public byte Chance { get; set; }
        public DropFlags Flags { get; set; }

        public override string ToString() => $"{Chance}% for #{Reference} ({Flags})";
    }
}
