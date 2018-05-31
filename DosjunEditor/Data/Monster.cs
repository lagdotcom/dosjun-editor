using System.Collections.Generic;
using System.IO;

namespace DosjunEditor
{
    public class Monster : IHasResource
    {
        public const int Padding = 15;
        public Resource Resource { get; set; }

        public Monster(Resource r)
        {
            Resource = r;

            Stats = new Stats();
            Skills = new List<short>();
            Version = new VersionHeader();
        }
        public Monster() : this(new Resource { Type = ResourceType.Monster }) { }

        public void Read(BinaryReader br)
        {
            Version.Read(br);
            NameId = br.ReadUInt16();
            ImageId = br.ReadUInt16();
            Row = (Row)br.ReadByte();
            AI = (AI)br.ReadByte();
            Experience = br.ReadUInt32();
            WeaponId = br.ReadUInt16();
            Flags = (MonsterFlags)br.ReadByte();

            br.ReadBytes(Padding);
            Stats.Read(br);

            if (Flags.HasFlag(MonsterFlags.HasSkills))
                Skills = br.ReadIntList();
        }

        public void Write(BinaryWriter bw)
        {
            Flags = MonsterFlags.None;
            if (Skills.Count > 0)
                Flags |= MonsterFlags.HasSkills;

            Version.Write(bw);
            bw.Write(NameId);
            bw.Write(ImageId);
            bw.Write((byte)Row);
            bw.Write((byte)AI);
            bw.Write(Experience);
            bw.Write(WeaponId);
            bw.Write((byte)Flags);

            bw.WritePadding(Padding);
            Stats.Write(bw);

            if (Flags.HasFlag(MonsterFlags.HasSkills))
                bw.WriteIntList(Skills);
        }

        public VersionHeader Version { get; set; }
        public ushort NameId { get; set; }
        public ushort ImageId { get; set; }
        public Stats Stats { get; set; }
        public Row Row { get; set; }
        public AI AI { get; set; }
        public uint Experience { get; set; }
        public ushort WeaponId { get; set; }
        public MonsterFlags Flags { get; set; }
        public List<short> Skills { get; set; }
    }
}
