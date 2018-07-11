using System.IO;

namespace DosjunEditor
{
    public class Buff : IBinaryData
    {
        public const int Size = 8;

        public void Read(BinaryReader br)
        {
            Type = (BuffType)br.ReadUInt16();
            Duration = br.ReadInt16();
            Argument1 = br.ReadInt16();
            Argument2 = br.ReadInt16();
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write((ushort)Type);
            bw.Write(Duration);
            bw.Write(Argument1);
            bw.Write(Argument2);
        }

        public BuffType Type { get; set; }
        public short Duration { get; set; }
        public short Argument1 { get; set; }
        public short Argument2 { get; set; }
    }
}
