using System.IO;

namespace DosjunEditor
{
    public class CompiledScript : IBinaryData
    {
        public CompiledScript()
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

        public byte[] Bytecode { get; set; }

        public override string ToString() => $"script, {Bytecode.Length} bytes";
    }
}
