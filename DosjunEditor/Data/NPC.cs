using System.IO;

namespace DosjunEditor
{
    public class NPC : IHasResource
    {
        public const int Padding = 21;
        public const int Size = 11 + Padding;

        public NPC(Resource r)
        {
            Resource = r;

            Version = new VersionHeader();
        }
        public NPC() : this(new Resource { Type = ResourceType.NPC }) { }

        public void Read(BinaryReader br)
        {
            Version.Read(br);
            NameId = br.ReadUInt16();
            Pronouns = (Pronouns)br.ReadByte();
            PortraitId = br.ReadUInt16();
            Attitude = br.ReadInt16();

            br.ReadBytes(Padding);
        }

        public void Write(BinaryWriter bw)
        {
            Version.Write(bw);
            bw.Write(NameId);
            bw.Write((byte)Pronouns);
            bw.Write(PortraitId);
            bw.Write(Attitude);

            bw.WritePadding(Padding);
        }

        public Resource Resource { get; set; }

        public VersionHeader Version { get; set; }
        public ushort NameId { get; set; }
        public Pronouns Pronouns { get; set; }
        public ushort PortraitId { get; set; }
        public short Attitude { get; set; }
    }
}
