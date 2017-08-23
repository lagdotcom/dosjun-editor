using System.Collections.Generic;
using System.IO;

namespace DosjunEditor
{
    public class Campaign : IBinaryData
    {
        public const int Padding = 23;

        public void Read(BinaryReader br)
        {
            Version = new VersionHeader();
            Version.Read(br);

            StartZone = br.ReadSByte();
            StartX = br.ReadByte();
            StartY = br.ReadByte();
            StartFacing = (Direction)br.ReadByte();
            byte count = br.ReadByte();

            br.ReadBytes(Padding);

            Zones = new List<string>();
            for (var i = 0; i < count; i++)
                Zones.Add(br.ReadNS());
        }

        public void Write(BinaryWriter bw)
        {
            Version.Write(bw);
            bw.Write(StartZone);
            bw.Write(StartX);
            bw.Write(StartY);
            bw.Write((byte)StartFacing);
            bw.Write(ZoneCount);

            bw.WritePadding(Padding);

            foreach (string zone in Zones)
                bw.WriteNS(zone);
        }

        public VersionHeader Version { get; set; }
        public sbyte StartZone { get; set; }
        public byte StartX { get; set; }
        public byte StartY { get; set; }
        public Direction StartFacing { get; set; }
        public byte ZoneCount => (byte)Zones.Count;
        public List<string> Zones { get; set; }
    }
}
