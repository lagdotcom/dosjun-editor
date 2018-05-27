using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DosjunEditor
{
    public class PC : IHasResource
    {
        public const int Padding = 17;
        public const int Size = 13 + Padding + VersionHeader.Size + (InventoryItem.Size * Globals.InventorySize) + Stats.Size + ((int)Job.Count * 2);

        public PC(Resource r)
        {
            Resource = r;

            Items = new InventoryItem[Globals.InventorySize];
            JobLevels = new ushort[(int)Job.Count];
            Stats = new Stats();
            Version = new VersionHeader();

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

            br.ReadBytes(Padding);

            Stats.Read(br);

            for (int i = 0; i < (int)Job.Count; i++)
                JobLevels[i] = br.ReadUInt16();

            for (int i = 0; i < Globals.InventorySize; i++)
                Items[i].Read(br);
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

            bw.WritePadding(Padding);

            Stats.Write(bw);

            foreach (ushort level in JobLevels)
                bw.Write(level);

            foreach (InventoryItem item in Items)
                item.Write(bw);
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
    }
}
