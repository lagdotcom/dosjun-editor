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
            HitBonus = br.ReadInt16();
            DodgeBonus = br.ReadInt16();
            Unused1 = br.ReadInt16();
            Unused2 = br.ReadInt16();
            Unused3 = br.ReadInt16();
            Unused4 = br.ReadInt16();
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
            bw.Write(HitBonus);
            bw.Write(DodgeBonus);
            bw.Write(Unused1);
            bw.Write(Unused2);
            bw.Write(Unused3);
            bw.Write(Unused4);
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
        public short HitBonus { get; set; }
        public short DodgeBonus { get; set; }
        public short Unused1 { get; set; }
        public short Unused2 { get; set; }
        public short Unused3 { get; set; }
        public short Unused4 { get; set; }
    }
}