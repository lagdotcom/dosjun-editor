using System.IO;

namespace DosjunEditor
{
    public class Music : IHasResource
    {
        public Resource Resource { get; set; }

        public Music(Resource r)
        {
            Resource = r;
            Raw = new byte[0];
        }
        public Music() : this(new Resource { Type = ResourceType.Music }) { }

        public void Read(BinaryReader br)
        {
            Raw = br.ReadBytes((int)Resource.Size);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(Raw);
        }

        public byte[] Raw { get; set; }

        public override string ToString() => $"music/sng, {Raw.Length} bytes";
    }
}
