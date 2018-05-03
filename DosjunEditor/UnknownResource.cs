using System.IO;

namespace DosjunEditor
{
    internal class UnknownResource : IHasResource
    {
        public Resource Resource { get; set; }
        public byte[] Raw { get; set; }

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
