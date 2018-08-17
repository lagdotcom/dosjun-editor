using System.Collections.Generic;
using System.IO;

namespace DosjunEditor
{
    public class DropTable : IHasResource
    {
        public const int Padding = 14;

        public Resource Resource { get; set; }

        public DropTable(Resource r)
        {
            Resource = r;

            Drops = new List<Drop>();
        }
        public DropTable() : this(new Resource { Type = ResourceType.DropTable }) { }

        public void Read(BinaryReader br)
        {
            ushort count = br.ReadUInt16();
            br.ReadBytes(Padding);

            Drops = br.ReadMany<Drop>(count);
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write((ushort)Drops.Count);
            bw.WritePadding(Padding);

            bw.WriteMany(Drops);
        }

        public List<Drop> Drops { get; private set; }
    }
}
