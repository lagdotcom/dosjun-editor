using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DosjunEditor
{
    public class Monsters : IBinaryData
    {
        public const int Padding = 26;

        public Monsters()
        {
            Data = new List<Monster>();
        }

        public void Read(BinaryReader br)
        {
            Version = new VersionHeader();
            Version.Read(br);

            ushort count = br.ReadUInt16();

            br.ReadBytes(Padding);

            br.ReadList(Data, count);
        }

        public void Write(BinaryWriter bw)
        {
            Version.Write(bw);
            bw.Write(Count);

            bw.WritePadding(Padding);

            foreach (Monster m in Data) m.Write(bw);
        }

        public VersionHeader Version { get; set; }
        public ushort Count => (ushort)Data.Count;
        public List<Monster> Data { get; set; }

        public Monster this[ushort id]
        {
            get
            {
                return Data.First(m => m.Id == id);
            }
        }
    }
}
