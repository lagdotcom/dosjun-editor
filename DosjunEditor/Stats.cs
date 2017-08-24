using System.IO;

namespace DosjunEditor
{
    public class Stats : IBinaryData
    {
        public void Read(BinaryReader br)
        {
            MaxHP = br.ReadInt16();
            MaxMP = br.ReadInt16();
            MinDamage = br.ReadInt16();
            MaxDamage = br.ReadInt16();
            Armour = br.ReadInt16();
            Strength = br.ReadInt16();
            Dexterity = br.ReadInt16();
            Intelligence = br.ReadInt16();
            HP = br.ReadInt16();
            MP = br.ReadInt16();
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(MaxHP);
            bw.Write(MaxMP);
            bw.Write(MinDamage);
            bw.Write(MaxDamage);
            bw.Write(Armour);
            bw.Write(Strength);
            bw.Write(Dexterity);
            bw.Write(Intelligence);
            bw.Write(HP);
            bw.Write(MP);
        }

        public short MaxHP { get; set; }
        public short MaxMP { get; set; }
        public short MinDamage { get; set; }
        public short MaxDamage { get; set; }
        public short Armour { get; set; }
        public short Strength { get; set; }
        public short Dexterity { get; set; }
        public short Intelligence { get; set; }
        public short HP { get; set; }
        public short MP { get; set; }
    }
}