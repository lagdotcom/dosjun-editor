using System.Collections.Generic;
using System.IO;

namespace DosjunEditor
{
    public class Encounter : IBinaryData
    {
        public Encounter()
        {
            MonsterIds = new ushort[Globals.EncounterSize];
            Minimums = new byte[Globals.EncounterSize];
            Maximums = new byte[Globals.EncounterSize];
        }

        public void Read(BinaryReader br)
        {
            for (var i = 0; i < Globals.EncounterSize; i++) MonsterIds[i] = br.ReadUInt16();
            Minimums = br.ReadBytes(Globals.EncounterSize);
            Maximums = br.ReadBytes(Globals.EncounterSize);
        }

        public void Write(BinaryWriter bw)
        {
            for (var i = 0; i < Globals.EncounterSize; i++) bw.Write(MonsterIds[i]);
            bw.Write(Minimums);
            bw.Write(Maximums);
        }

        public ushort[] MonsterIds { get; private set; }
        public byte[] Minimums { get; private set; }
        public byte[] Maximums { get; private set; }

        private string[] DescriptionStrings(Context ctx)
        {
            List<string> items = new List<string>();
            for (var i = 0; i < Globals.EncounterSize; i++)
            {
                if (MonsterIds[i] > 0 && Maximums[i] > 0)
                {
                    Monster m = ctx.Djn[MonsterIds[i]] as Monster;
                    string name = ctx.GetString(m.NameId);

                    if (Minimums[i] == Maximums[i])
                        items.Add($"{Minimums[i]}x {name}");
                    else
                        items.Add($"{Minimums[i]}-{Maximums[i]}x {name}");
                }
            }

            return items.ToArray();
        }

        public string GetDescription(Context ctx, string join = "; ") => string.Join(join, DescriptionStrings(ctx));
    }
}
