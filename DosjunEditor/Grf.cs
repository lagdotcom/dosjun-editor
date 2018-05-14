using System.Collections.Generic;
using System.IO;

namespace DosjunEditor
{
    public class Grf : IHasResource
    {
        public const int Padding = 26;

        public Resource Resource { get; set; }

        public Grf(Resource r)
        {
            Resource = r;

            Images = new List<GrfImage>();
            Version = new VersionHeader();
        }
        public Grf() : this(new Resource { Type = ResourceType.Graphic }) { }

        public VersionHeader Version { get; set; }
        public List<GrfImage> Images { get; private set; }

        public void Read(BinaryReader br)
        {
            Version.Read(br);
            ushort count = br.ReadUInt16();
            br.ReadBytes(Padding);

            for (int i = 0; i < count; i++)
            {
                GrfImage img = new GrfImage();
                img.Read(br);
                Images.Add(img);
            }
        }

        public void Write(BinaryWriter bw)
        {
            Version.Write(bw);
            bw.Write((ushort)Images.Count);
            bw.WritePadding(Padding);

            foreach (GrfImage img in Images)
                img.Write(bw);
        }
    }
}
