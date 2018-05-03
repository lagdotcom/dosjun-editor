using System.Collections.Generic;
using System.IO;

namespace DosjunEditor
{
    public class Campaign : IHasResource
    {
        public const int Padding = 18;
        public Resource Resource { get; set; }

        public Campaign()
        {
            Resource = new Resource { Type = ResourceType.Campaign };
            Version = new VersionHeader();
        }

        public void Read(BinaryReader br)
        {
            Version.Read(br);

            NumGlobals = br.ReadUInt16();
            NumFlags = br.ReadUInt16();
            StartingScript = br.ReadUInt16();
            NameId = br.ReadUInt16();
            DescId = br.ReadUInt16();

            br.ReadBytes(Padding);
        }

        public void Write(BinaryWriter bw)
        {
            Version.Write(bw);
            bw.Write(NumGlobals);
            bw.Write(NumFlags);
            bw.Write(StartingScript);
            bw.Write(NameId);
            bw.Write(DescId);

            bw.WritePadding(Padding);
        }

        public VersionHeader Version { get; set; }
        public ushort NumGlobals { get; set; }
        public ushort NumFlags { get; set; }
        public ushort StartingScript { get; set; }
        public ushort NameId { get; set; }
        public ushort DescId { get; set; }
    }
}
