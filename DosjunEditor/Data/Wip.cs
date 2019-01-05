using System.IO;

namespace DosjunEditor
{
    public class Wip : IHasResource
    {
        const int Padding = 28;
        public Resource Resource { get; set; }

        public Wip(Resource r)
        {
            Resource = r;
            Version = new VersionHeader();
        }
        public Wip() : this(new Resource { Type = ResourceType.Wip, OnlyDesign = true }) { }

        public void Read(BinaryReader br)
        {
            Version.Read(br);

            br.ReadBytes(Padding);
        }

        public void Write(BinaryWriter bw)
        {
            Version.Write(bw);

            bw.WritePadding(Padding);
        }

        public VersionHeader Version { get; set; }
    }
}
