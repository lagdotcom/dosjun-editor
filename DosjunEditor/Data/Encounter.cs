using System.Collections.Generic;
using System.IO;

namespace DosjunEditor
{
    public class Encounter : IBinaryData
    {
        public const int Padding = 4;
        public const int Size = Globals.EncounterSize * 4 + Padding;

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
            MinLevel = br.ReadUInt16();
            MaxLevel = br.ReadUInt16();

            br.ReadBytes(Padding);
        }

        public void Write(BinaryWriter bw)
        {
            for (var i = 0; i < Globals.EncounterSize; i++) bw.Write(MonsterIds[i]);
            bw.Write(Minimums);
            bw.Write(Maximums);
            bw.Write(MinLevel);
            bw.Write(MaxLevel);

            bw.WritePadding(Padding);
        }

        public ushort[] MonsterIds { get; private set; }
        public byte[] Minimums { get; private set; }
        public byte[] Maximums { get; private set; }
        public ushort MinLevel { get; set; }
        public ushort MaxLevel { get; set; }

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

        private string LevelBoundsString()
        {
            if (MinLevel == 0 && MaxLevel == 0) return string.Empty;

            string min = MinLevel == 0 ? string.Empty : MinLevel.ToString();
            string max = MaxLevel == 0 ? string.Empty : MaxLevel.ToString();

            return $"({min}-{max}) ";
        }

        public string GetDescription(Context ctx, string join = "; ") => $"{LevelBoundsString()}{string.Join(join, DescriptionStrings(ctx))}";
    }
}
