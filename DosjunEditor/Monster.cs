using System.Collections.Generic;
using System.IO;

namespace DosjunEditor
{
    public class Monster : IHasResource
    {
        public const int Padding = 3;
        public Resource Resource { get; set; }

        public Monster()
        {
            Resource = new Resource { Type = ResourceType.Monster };

            Stats = new Stats();
            Skills = new List<short>();
        }

        public void Read(BinaryReader br)
        {
            Name = br.ReadZS(Consts.NameSize);
            Image = br.ReadZS(8);
            Stats.Read(br);
            Row = (Row)br.ReadByte();
            AI = (AI)br.ReadByte();
            Experience = br.ReadUInt32();
            WeaponId = br.ReadUInt16();
            Flags = (MonsterFlags)br.ReadByte();

            br.ReadBytes(Padding);

            if (Flags.HasFlag(MonsterFlags.HasSkills)) Skills = br.ReadIntList();
        }

        public void Write(BinaryWriter bw)
        {
            Flags = 0;
            if (Skills.Count > 0) Flags |= MonsterFlags.HasSkills;

            bw.WriteZS(Name, Consts.NameSize);
            bw.WriteZS(Image, 8);
            Stats.Write(bw);
            bw.Write((byte)Row);
            bw.Write((byte)AI);
            bw.Write(Experience);
            bw.Write(WeaponId);
            bw.Write((byte)Flags);

            bw.WritePadding(Padding);

            if (Flags.HasFlag(MonsterFlags.HasSkills)) bw.WriteIntList(Skills);
        }

        public string Name { get; set; }
        public string Image { get; set; }
        public Stats Stats { get; set; }
        public Row Row { get; set; }
        public AI AI { get; set; }
        public uint Experience { get; set; }
        public ushort WeaponId { get; set; }
        public MonsterFlags Flags { get; set; }
        public List<short> Skills { get; set; }

        public override string ToString() => Name;
    }
}
