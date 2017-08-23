using System.IO;

namespace DosjunEditor
{
    public class Stats : IBinaryData
    {
        public const int Count = (int)Stat._Count;

        public void Read(BinaryReader br)
        {
            Data = new short[Count];
            for (var i = 0; i < Count; i++) Data[i] = br.ReadInt16();
        }

        public void Write(BinaryWriter bw)
        {
            foreach (short st in Data) bw.Write(st);
        }

        public short[] Data { get; private set; }

        public short MaxHP => Data[(int)Stat.MaxHP];
        public short MaxMP => Data[(int)Stat.MaxMP];
        public short MinDamage => Data[(int)Stat.MinDamage];
        public short MaxDamage => Data[(int)Stat.MaxDamage];
        public short Armour => Data[(int)Stat.Armour];
        public short Strength => Data[(int)Stat.Strength];
        public short Dexterity => Data[(int)Stat.Dexterity];
        public short Intelligence => Data[(int)Stat.Intelligence];
        public short HP => Data[(int)Stat.HP];
        public short MP => Data[(int)Stat.MP];
    }
}