using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DosjunEditor
{
    public class Wip : IHasResource
    {
        const int Padding = 26;
        public Resource Resource { get; set; }

        public Wip(Resource r)
        {
            Resource = r;
            Version = new VersionHeader();
            Zones = new Dictionary<ushort, ZoneData>();
        }
        public Wip() : this(new Resource { Type = ResourceType.Wip, OnlyDesign = true }) { }

        public void Read(BinaryReader br)
        {
            Version.Read(br);

            ushort numZones = br.ReadUInt16();

            br.ReadBytes(Padding);

            Zones.Clear();
            for (int i = 0; i < numZones; i++)
            {
                ushort id = br.ReadUInt16();
                ZoneData zd = new ZoneData();
                zd.Read(br);

                Zones[id] = zd;
            }
        }

        public void Write(BinaryWriter bw)
        {
            Version.Write(bw);

            bw.Write((ushort)Zones.Count);

            bw.WritePadding(Padding);

            foreach (KeyValuePair<ushort, ZoneData> p in Zones)
            {
                bw.Write(p.Key);
                p.Value.Write(bw);
            }
        }

        public VersionHeader Version { get; set; }
        public Dictionary<ushort, ZoneData> Zones { get; set; }

        public class ZoneData : IBinaryData
        {
            const int Padding = 14;

            public ZoneData()
            {
                Areas = new List<ZoneArea>();
            }

            public void Read(BinaryReader br)
            {
                ushort numAreas = br.ReadUInt16();
                br.ReadBytes(Padding);

                Areas = br.ReadMany<ZoneArea>(numAreas);
            }

            public void Write(BinaryWriter bw)
            {
                bw.Write((ushort)Areas.Count);
                bw.WritePadding(Padding);

                bw.WriteMany(Areas);
            }

            public List<ZoneArea> Areas { get; private set; }
        }

        public class ZoneArea : IBinaryData
        {
            const int Padding = 14;

            public ZoneArea()
            {
                Points = new List<ZonePoint>();
            }

            public void Read(BinaryReader br)
            {
                ushort numPoints = br.ReadUInt16();
                br.ReadBytes(Padding);

                Name = br.ReadNS();
                Points = br.ReadMany<ZonePoint>(numPoints);
            }

            public void Write(BinaryWriter bw)
            {
                bw.Write((ushort)Points.Count);
                bw.WritePadding(Padding);

                bw.WriteNS(Name);
                bw.WriteMany(Points);
            }

            public string Name { get; set; }
            public List<ZonePoint> Points { get; private set; }

            public override string ToString() => Name;

            public bool Contains(int x, int y) => Points.Any(p => p.X == x && p.Y == y);
            public void Add(int x, int y) => Points.Add(new ZonePoint { X = x, Y = y });

            public void Remove(int x, int y)
            {
                ZonePoint zp = Points.Find(p => p.X == x && p.Y == y);
                if (zp != null) Points.Remove(zp);
            }
        }

        public class ZonePoint : IBinaryData
        {
            public void Read(BinaryReader br)
            {
                X = br.ReadInt32();
                Y = br.ReadInt32();
            }

            public void Write(BinaryWriter bw)
            {
                bw.Write(X);
                bw.Write(Y);
            }

            public int X { get; set; }
            public int Y { get; set; }
        }
    }
}
