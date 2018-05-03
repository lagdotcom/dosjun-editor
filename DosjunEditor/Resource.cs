using System.IO;

namespace DosjunEditor
{
    public class Resource : IBinaryData
    {
        public const int Padding = 4;

        public void Read(BinaryReader br, bool design)
        {
            ID = br.ReadUInt16();
            Offset = br.ReadUInt32();
            Size = br.ReadUInt32();
            Type = (ResourceType)br.ReadByte();
            Flags = (ResourceFlags)br.ReadByte();
            br.ReadBytes(Padding);

            if (design)
                Name = br.ReadNS();
        }

        public void Write(BinaryWriter bw, bool design)
        {
            bw.Write(ID);
            bw.Write(Offset);
            bw.Write(Size);
            bw.Write((byte)Type);
            bw.Write((byte)Flags);
            bw.WritePadding(Padding);

            if (design)
                bw.WriteNS(Name);
        }

        public void Read(BinaryReader br)
        {
            Read(br, false);
        }

        public void Write(BinaryWriter bw)
        {
            Write(bw, false);
        }

        public ushort ID { get; set; }
        public ResourceType Type { get; set; }
        public ResourceFlags Flags { get; set; }
        public bool OnlyDesign { get; set; }
        public string Name { get; set; }
        public uint Offset { get; set; }
        public uint Size { get; set; }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(Name))
                return $"{Type} #{ID:X}";

            return Name;
        }
    }
}
