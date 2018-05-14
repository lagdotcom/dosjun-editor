using System.Collections.Generic;
using System.IO;

namespace DosjunEditor
{
    public class Zone : IHasResource
    {
        public const int Padding = 14;
        public Resource Resource { get; set; }

        public Zone(Resource r)
        {
            Resource = r;

            Version = new VersionHeader();
            Tiles = new TileBag();
            Encounters = new List<Encounter>();
            ETables = new List<ETable>();
        }
        public Zone() : this(new Resource { Type = ResourceType.Zone }) { }

        public void Read(BinaryReader br)
        {
            Version.Read(br);
            Width = br.ReadByte();
            Height = br.ReadByte();
            Floor = br.ReadByte();
            br.ReadByte();

            ushort encounterCount = br.ReadUInt16();
            ushort etableCount = br.ReadUInt16();
            EnterScript = br.ReadUInt16();
            MoveScript = br.ReadUInt16();
            NameId = br.ReadUInt16();

            br.ReadBytes(Padding);

            for (int y = 0; y < Height; y++)
                for (int x = 0; x < Width; x++)
                {
                    Tile t = new Tile();
                    t.Read(br);
                    Tiles.Set(x, y, t);
                }

            br.ReadList(Encounters, encounterCount);
            br.ReadList(ETables, etableCount);
        }

        public void Write(BinaryWriter bw)
        {
            Width = (byte)Tiles.Width;
            Height = (byte)Tiles.Height;

            Version.Write(bw);
            bw.Write(Width);
            bw.Write(Height);
            bw.Write(Floor);
            bw.Write((byte)0);
            bw.Write(EncounterCount);
            bw.Write(ETableCount);
            bw.Write(EnterScript);
            bw.Write(MoveScript);
            bw.Write(NameId);

            bw.WritePadding(Padding);

            for (int y = 0; y < Height; y++)
                for (int x = 0; x < Width; x++)
                    Tiles.At(x, y).Write(bw);

            foreach (Encounter en in Encounters) en.Write(bw);
            foreach (ETable et in ETables) et.Write(bw);
        }

        public bool UsingEncounterId(int index)
        {
            foreach (ETable et in ETables)
                for (var i = 0; i < et.Possibilities; i++)
                    if (et.EncounterIds[i] == index) return true;

            return false;
        }

        public VersionHeader Version { get; set; }
        public byte Width { get; set; }
        public byte Height { get; set; }
        public byte Floor { get; set; }
        public ushort EnterScript { get; set; }
        public ushort MoveScript { get; set; }
        public ushort EncounterCount => (ushort)Encounters.Count;
        public ushort ETableCount => (ushort)ETables.Count;
        public ushort NameId { get; set; }

        public TileBag Tiles { get; private set; }
        public List<Encounter> Encounters { get; private set; }
        public List<ETable> ETables { get; private set; }
    }
}
