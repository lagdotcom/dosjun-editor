using System;
using System.IO;

namespace DosjunEditor
{
    public class ETable : IBinaryData
    {
        public ETable()
        {
            Possibilities = 0;
            EncounterIds = new ushort[Consts.ETableSize];
            Percentages = new byte[Consts.ETableSize];
        }

        public void Read(BinaryReader br)
        {
            Possibilities = br.ReadByte();
            for (var i = 0; i < Consts.ETableSize; i++) EncounterIds[i] = br.ReadUInt16();
            Percentages = br.ReadBytes(Consts.ETableSize);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(Possibilities);
            for (var i = 0; i < Consts.ETableSize; i++) bw.Write(EncounterIds[i]);
            bw.Write(Percentages);
        }

        public byte Possibilities { get; set; }
        public ushort[] EncounterIds { get; set; }
        public byte[] Percentages { get; set; }
    }
}
