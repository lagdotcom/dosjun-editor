﻿using System.IO;

namespace DosjunEditor
{
    public class Tile : IBinaryData
    {
        public const int Padding = 8;

        public Tile()
        {
            Walls = new Wall[4];
        }

        public void Read(BinaryReader br)
        {
            Walls = br.ReadArray<Wall>(4);
            Floor = br.ReadByte();
            Ceiling = br.ReadByte();
            DescriptionId = br.ReadUInt16();
            OnEnterId = br.ReadUInt16();
            ETableId = br.ReadUInt16();

            br.ReadBytes(Padding);
        }

        public void Write(BinaryWriter bw)
        {
            foreach (Wall w in Walls) w.Write(bw);
            bw.Write(Floor);
            bw.Write(Ceiling);
            bw.Write(DescriptionId);
            bw.Write(OnEnterId);
            bw.Write(ETableId);

            bw.WritePadding(Padding);
        }

        public int X { get; set; }
        public int Y { get; set; }

        public Wall[] Walls { get; private set; }
        public byte Floor { get; set; }
        public byte Ceiling { get; set; }
        public ushort DescriptionId { get; set; }
        public ushort OnEnterId { get; set; }
        public ushort ETableId { get; set; }
    }
}