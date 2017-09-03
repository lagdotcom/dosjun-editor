using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DosjunEditor
{
    public class Encounter : IBinaryData
    {
        public Encounter()
        {
            MonsterIds = new ushort[Consts.EncounterSize];
            Minimums = new byte[Consts.EncounterSize];
            Maximums = new byte[Consts.EncounterSize];
        }

        public void Read(BinaryReader br)
        {
            for (var i = 0; i < Consts.EncounterSize; i++) MonsterIds[i] = br.ReadUInt16();
            Minimums = br.ReadBytes(Consts.EncounterSize);
            Maximums = br.ReadBytes(Consts.EncounterSize);
        }

        public void Write(BinaryWriter bw)
        {
            for (var i = 0; i < Consts.EncounterSize; i++) bw.Write(MonsterIds[i]);
            bw.Write(Minimums);
            bw.Write(Maximums);
        }

        public ushort[] MonsterIds { get; private set; }
        public byte[] Minimums { get; private set; }
        public byte[] Maximums { get; private set; }

        private string[] DescriptionStrings(Monsters monsters)
        {
            List<string> items = new List<string>();
            for (var i = 0; i < Consts.EncounterSize; i++)
            {
                if (MonsterIds[i] > 0 && Maximums[i] > 0)
                    items.Add($"{Minimums[i]}-{Maximums[i]}x {monsters[MonsterIds[i]].Name}");
            }

            return items.ToArray();
        }

        public string GetDescription(Monsters monsters, string join = "; ") => string.Join(join, DescriptionStrings(monsters));
    }
}
