using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DosjunEditor
{
    public class PC : IHasResource
    {
        public const int Padding = 15;
        public const int Size = 15 + Padding + VersionHeader.Size + (InventoryItem.Size * Globals.InventorySize) + Stats.Size + (Globals.NumJobs * 2);

        public PC(Resource r)
        {
            Resource = r;

            JobLevels = new ushort[Globals.NumJobs];
            Stats = new Stats();
            Version = new VersionHeader();
            Skills = new List<short>();
            Buffs = new List<Buff>();

            Items = new InventoryItem[Globals.InventorySize];
            for (int i = 0; i < Globals.InventorySize; i++)
                Items[i] = new InventoryItem();
        }
        public PC() : this(new Resource { Type = ResourceType.PC }) { }

        public void Read(BinaryReader br)
        {
            Version.Read(br);
            NameId = br.ReadUInt16();
            Job = (Job)br.ReadByte();
            Pronouns = (Pronouns)br.ReadByte();
            PortraitId = br.ReadUInt16();
            br.ReadUInt16();    // Level
            Flags = (PCFlags)br.ReadByte();
            Experience = br.ReadUInt32();
            Attitude = br.ReadInt16();

            br.ReadBytes(Padding);

            Stats.Read(br);

            for (int i = 0; i < Globals.NumJobs; i++)
                JobLevels[i] = br.ReadUInt16();

            for (int i = 0; i < Globals.InventorySize; i++)
                Items[i].Read(br);

            Skills = br.ReadIntList();
            Buffs = br.ReadObjectList<Buff>();
        }

        public void Write(BinaryWriter bw)
        {
            Version.Write(bw);
            bw.Write(NameId);
            bw.Write((byte)Job);
            bw.Write((byte)Pronouns);
            bw.Write(PortraitId);
            bw.Write(Level);
            bw.Write((byte)Flags);
            bw.Write(Experience);
            bw.Write(Attitude);

            bw.WritePadding(Padding);

            Stats.Write(bw);

            foreach (ushort level in JobLevels)
                bw.Write(level);

            foreach (InventoryItem item in Items)
                item.Write(bw);

            bw.WriteIntList(Skills);
            bw.WriteObjectList(Buffs, Buff.Size);
        }

        public Resource Resource { get; set; }

        public VersionHeader Version { get; set; }
        public ushort NameId { get; set; }
        public Job Job { get; set; }
        public Pronouns Pronouns { get; set; }
        public ushort PortraitId { get; set; }
        public ushort Level => (ushort)JobLevels.Sum(l => l);
        public ushort[] JobLevels { get; set; }
        public Stats Stats { get; set; }
        public InventoryItem[] Items { get; set; }
        public PCFlags Flags { get; set; }
        public uint Experience { get; set; }
        public short Attitude { get; set; }
        public List<short> Skills { get; set; }
        public List<Buff> Buffs { get; set; }
        public string Name { get; set; }
    }
}
