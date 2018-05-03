using System.Collections.Generic;
using System.IO;

namespace DosjunEditor
{
    public class Zone : IHasResource
    {
        public const int Padding = 2;
        public Resource Resource { get; set; }

        public Zone()
        {
            Resource = new Resource { Type = ResourceType.Zone };

            Version = new VersionHeader();
            Tiles = new TileBag();
            Strings = new List<string>();
            Scripts = new List<CompiledScript>();
            Encounters = new List<Encounter>();
            CodeStrings = new List<string>();
            ETables = new List<ETable>();
            Textures = new List<string>();
        }

        public void Read(BinaryReader br)
        {
            Version.Read(br);
            CampaignName = br.ReadZS(8);
            Width = br.ReadByte();
            Height = br.ReadByte();

            ushort stringCount = br.ReadUInt16();
            ushort scriptCount = br.ReadUInt16();
            ushort encounterCount = br.ReadUInt16();
            ushort codeStringCount = br.ReadUInt16();
            ushort etableCount = br.ReadUInt16();
            ushort textureCount = br.ReadUInt16();
            EnterScript = br.ReadUInt16();
            MoveScript = br.ReadUInt16();

            br.ReadBytes(Padding);

            for (int y = 0; y < Height; y++)
                for (int x = 0; x < Width; x++)
                {
                    Tile t = new Tile();
                    t.Read(br);
                    Tiles.Set(x, y, t);
                }

            for (int i = 0; i < stringCount; i++) Strings.Add(br.ReadNS());
            br.ReadList(Scripts, scriptCount);
            br.ReadList(Encounters, encounterCount);
            for (int i = 0; i < codeStringCount; i++) CodeStrings.Add(br.ReadNS());
            br.ReadList(ETables, etableCount);
            for (int i = 0; i < textureCount; i++) Textures.Add(br.ReadNS());
        }

        public void Write(BinaryWriter bw)
        {
            Width = (byte)Tiles.Width;
            Height = (byte)Tiles.Height;

            Version.Write(bw);
            bw.WriteZS(CampaignName, 8);
            bw.Write(Width);
            bw.Write(Height);
            bw.Write(StringCount);
            bw.Write(ScriptCount);
            bw.Write(EncounterCount);
            bw.Write(CodeStringCount);
            bw.Write(ETableCount);
            bw.Write(TextureCount);
            bw.Write(EnterScript);
            bw.Write(MoveScript);

            bw.WritePadding(Padding);

            for (int y = 0; y < Height; y++)
                for (int x = 0; x < Width; x++)
                    Tiles.At(x, y).Write(bw);

            foreach (string s in Strings) bw.WriteNS(s);
            foreach (CompiledScript sc in Scripts) sc.Write(bw);
            foreach (Encounter en in Encounters) en.Write(bw);
            foreach (string c in CodeStrings) bw.WriteNS(c);
            foreach (ETable et in ETables) et.Write(bw);
            foreach (string tex in Textures) bw.WriteNS(tex);
        }

        public bool UsingEncounterId(int index)
        {
            foreach (ETable et in ETables)
                for (var i = 0; i < et.Possibilities; i++)
                    if (et.EncounterIds[i] == index) return true;

            return false;
        }

        public ushort GetTextureId(string textureName)
        {
            if (!Textures.Contains(textureName))
                Textures.Add(textureName);

            return (ushort)(Textures.IndexOf(textureName) + 1);
        }

        public VersionHeader Version { get; set; }
        public string CampaignName { get; set; }
        public byte Width { get; set; }
        public byte Height { get; set; }
        public ushort EnterScript { get; set; }
        public ushort MoveScript { get; set; }
        public ushort StringCount => (ushort)Strings.Count;
        public ushort ScriptCount => (ushort)Scripts.Count;
        public ushort EncounterCount => (ushort)Encounters.Count;
        public ushort CodeStringCount => (ushort)CodeStrings.Count;
        public ushort ETableCount => (ushort)ETables.Count;
        public ushort TextureCount => (ushort)Textures.Count;

        public TileBag Tiles { get; private set; }
        public List<string> Strings { get; private set; }
        public List<CompiledScript> Scripts { get; private set; }
        public List<Encounter> Encounters { get; private set; }
        public List<string> CodeStrings { get; private set; }
        public List<ETable> ETables { get; private set; }
        public List<string> Textures { get; private set; }
    }
}
