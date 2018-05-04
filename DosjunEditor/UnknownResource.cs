using System.IO;

namespace DosjunEditor
{
    internal class UnknownResource : IHasResource
    {
        public Resource Resource { get; set; }
        public byte[] Raw { get; set; }

        public UnknownResource(Resource res)
        {
            Resource = res;
            Raw = new byte[0];
        }
        public UnknownResource() : this(new Resource { Type = ResourceType.Unknown }) { }

        public void Read(BinaryReader br)
        {
            Raw = br.ReadBytes((int)Resource.Size);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(Raw);
        }
    }
}
