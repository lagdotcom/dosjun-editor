using System.IO;

namespace DosjunEditor
{
    public class Monster : IBinaryData
    {
        public const int Padding = 8;

        public void Read(BinaryReader br)
        {
            Name = br.ReadZS(Consts.NameSize);
            Image = br.ReadZS(8);
            Id = br.ReadUInt16();
            Stats = new Stats();
            Stats.Read(br);
            Row = (Row)br.ReadByte();
            AI = (AI)br.ReadByte();

            br.ReadBytes(Padding);
        }

        public void Write(BinaryWriter bw)
        {
            bw.WriteZS(Name, Consts.NameSize);
            bw.WriteZS(Image, 8);
            bw.Write(Id);
            Stats.Write(bw);
            bw.Write((byte)Row);
            bw.Write((byte)AI);

            bw.WritePadding(Padding);
        }

        public string Name { get; set; }
        public string Image { get; set; }
        public ushort Id { get; set; }
        public Stats Stats { get; set; }
        public Row Row { get; set; }
        public AI AI { get; set; }

        public override string ToString() => Name;
    }
}