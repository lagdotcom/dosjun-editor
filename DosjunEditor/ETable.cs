using System.Collections.Generic;
using System.IO;

namespace DosjunEditor
{
    public class ETable : IBinaryData
    {
        public ETable()
        {
            EncounterIds = new ushort[Consts.ETableSize];
            Percentages = new byte[Consts.ETableSize];

            Possibilities = 1;
            Percentages[0] = 100;
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

        private string[] DescriptionStrings(Context ctx, Zone zone)
        {
            List<string> items = new List<string>();
            for (var i = 0; i < Possibilities; i++)
                items.Add($"{Percentages[i]}%: {zone.Encounters[EncounterIds[i]].GetDescription(ctx)}");

            return items.ToArray();
        }

        public string GetDescription(Context ctx, Zone zone, string join = ", ") => string.Join(join, DescriptionStrings(ctx, zone));

        public void DeleteEncounterId(ushort index)
        {
            for (var i = 0; i < Possibilities; i++)
            {
                if (EncounterIds[i] > index)
                    EncounterIds[i]--;
            }
        }
    }
}
