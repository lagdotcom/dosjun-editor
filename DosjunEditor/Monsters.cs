using System.Collections.Generic;
using System.IO;

namespace DosjunEditor
{
    public class Monsters : IBinaryData
    {
        public const int Padding = 26;

        public void Read(BinaryReader br)
        {
            Version = new VersionHeader();
            Version.Read(br);

            ushort count = br.ReadUInt16();

            br.ReadBytes(Padding);

            Data = new List<Monster>();
            for (var i = 0; i < count; i++)
            {
                Monster m = new Monster();
                m.Read(br);
                Data.Add(m);
            }
        }

        public void Write(BinaryWriter bw)
        {
            Version.Write(bw);
            bw.Write(Count);

            bw.WritePadding(Padding);

            foreach (Monster m in Data)
                m.Write(bw);
        }

        public VersionHeader Version { get; set; }
        public ushort Count => (ushort)Data.Count;
        public List<Monster> Data { get; set; }
    }
}
