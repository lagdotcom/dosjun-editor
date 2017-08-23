using System.Collections.Generic;
using System.IO;

namespace DosjunEditor
{
    public class Items : IBinaryData
    {
        public const int Padding = 26;

        public void Read(BinaryReader br)
        {
            Version = new VersionHeader();
            Version.Read(br);

            ushort count = br.ReadUInt16();

            br.ReadBytes(Padding);

            Data = new List<Item>();
            for (var i = 0; i < count; i++)
            {
                Item it = new Item();
                it.Read(br);
                Data.Add(it);
            }
        }

        public void Write(BinaryWriter bw)
        {
            Version.Write(bw);
            bw.Write(Count);

            bw.WritePadding(Padding);

            foreach (Item it in Data)
                it.Write(bw);
        }

        public VersionHeader Version { get; set; }
        public ushort Count => (ushort)Data.Count;
        public List<Item> Data { get; set; }
    }
}