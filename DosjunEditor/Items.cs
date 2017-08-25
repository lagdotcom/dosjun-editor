﻿using System.Collections.Generic;
using System.IO;

namespace DosjunEditor
{
    public class Items : IBinaryData
    {
        public const int Padding = 26;

        public Items()
        {
            Data = new List<Item>();
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

            foreach (Item it in Data) it.Write(bw);
        }

        public VersionHeader Version { get; set; }
        public ushort Count => (ushort)Data.Count;
        public List<Item> Data { get; set; }
    }
}