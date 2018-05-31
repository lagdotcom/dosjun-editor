using System.IO;

namespace DosjunEditor
{
    public class Buff : IBinaryData
    {
        public const int Size = 4;

        public void Read(BinaryReader br)
        {
            Type = (BuffType)br.ReadUInt16();
            Argument = br.ReadInt16();
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write((ushort)Type);
            bw.Write(Argument);
        }

        public BuffType Type { get; set; }
        public short Argument { get; set; }
    }
}
