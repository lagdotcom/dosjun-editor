using System.IO;

namespace DosjunEditor
{
    public class CompiledScript : IHasResource
    {
        public Resource Resource { get; set; }

        public CompiledScript()
        {
            Resource = new Resource { Type = ResourceType.Script };
            Bytecode = new byte[0];
        }

        public void Read(BinaryReader br)
        {
            Bytecode = br.ReadBytes((int)Resource.Size);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(Bytecode);
        }

        public byte[] Bytecode { get; set; }

        public override string ToString() => $"script, {Bytecode.Length} bytes";
    }
}
