using System;
using System.IO;

namespace DosjunEditor
{
    public class Script : IBinaryData
    {
        public Script()
        {
            Bytecode = new byte[0];
        }

        public void Read(BinaryReader br)
        {
            ushort length = br.ReadUInt16();
            Bytecode = br.ReadBytes(length);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write((ushort)Bytecode.Length);
            bw.Write(Bytecode);
        }

        public byte[] Bytecode { get; private set; }
    }
}