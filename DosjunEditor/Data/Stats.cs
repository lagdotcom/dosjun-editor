using System.IO;

namespace DosjunEditor
{
    public class Stats : IBinaryData
    {
        public const int Size = 32;

        public Stats()
        {
            Values = new short[Globals.NumStats];
        }

        public void Read(BinaryReader br)
        {
            for (int i = 0; i < Globals.NumStats; i++)
                Values[i] = br.ReadInt16();
        }

        public void Write(BinaryWriter bw)
        {
            for (int i = 0; i < Globals.NumStats; i++)
                bw.Write(Values[i]);
        }

        public short[] Values { get; }

        public short this[Stat st]
        {
            get
            {
                return Values[(int)st];
            }

            set
            {
                Values[(int)st] = value;
            }
        }
    }
}