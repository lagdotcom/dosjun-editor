using System.Collections.Generic;
using System.IO;

namespace DosjunEditor
{
    public class Campaign : IHasResource
    {
        public const int Padding = 8;
        public Resource Resource { get; set; }

        public Campaign(Resource r)
        {
            Resource = r;
            Version = new VersionHeader();
        }
        public Campaign() : this(new Resource { Type = ResourceType.Campaign }) { }

        public void Read(BinaryReader br)
        {
            Version.Read(br);

            NumGlobals = br.ReadUInt16();
            NumFlags = br.ReadUInt16();
            StartingScript = br.ReadUInt16();
            NameId = br.ReadUInt16();
            DescId = br.ReadUInt16();
            FontId = br.ReadUInt16();
            MenuBgId = br.ReadUInt16();
            DungeonBgId = br.ReadUInt16();
            CombatBgId = br.ReadUInt16();
            MenuMusicId = br.ReadUInt16();

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
            bw.Write(FontId);
            bw.Write(MenuBgId);
            bw.Write(DungeonBgId);
            bw.Write(CombatBgId);
            bw.Write(MenuMusicId);

            bw.WritePadding(Padding);
        }

        public VersionHeader Version { get; set; }
        public ushort NumGlobals { get; set; }
        public ushort NumFlags { get; set; }
        public ushort StartingScript { get; set; }
        public ushort NameId { get; set; }
        public ushort DescId { get; set; }
        public ushort FontId { get; set; }
        public ushort MenuBgId { get; set; }
        public ushort DungeonBgId { get; set; }
        public ushort CombatBgId { get; set; }
        public ushort MenuMusicId { get; set; }
    }
}
