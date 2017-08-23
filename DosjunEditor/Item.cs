using System.IO;

namespace DosjunEditor
{
    public class Item : IBinaryData
    {
        public const int Padding = 6;

        public void Read(BinaryReader br)
        {
            Name = br.ReadZS(Consts.NameSize);
            Id = br.ReadUInt16();
            Type = (ItemType)br.ReadByte();
            Flags = (ItemFlags)br.ReadUInt16();
            Value = br.ReadUInt32();
            Special = (ItemSpecial)br.ReadByte();
            SpecialArg1 = br.ReadInt16();
            SpecialArg2 = br.ReadInt16();
            br.ReadBytes(Padding);
            Stats = new Stats();
            Stats.Read(br);
        }

        public void Write(BinaryWriter bw)
        {
            bw.WriteZS(Name, Consts.NameSize);
            bw.Write(Id);
            bw.Write((byte)Type);
            bw.Write((ushort)Flags);
            bw.Write(Value);
            bw.Write((byte)Special);
            bw.Write(SpecialArg1);
            bw.Write(SpecialArg2);
            bw.WritePadding(Padding);
            Stats.Write(bw);
        }

        public string Name { get; set; }
        public ushort Id { get; set; }
        public ItemType Type { get; set; }
        public ItemFlags Flags { get; set; }
        public uint Value { get; set; }
        public ItemSpecial Special { get; set; }
        public short SpecialArg1 { get; set; }
        public short SpecialArg2 { get; set; }
        public Stats Stats { get; set; }

        public override string ToString() => Name;
    }
}
