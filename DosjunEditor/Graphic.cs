using System.IO;

namespace DosjunEditor
{
    public class Graphic : IHasResource
    {
        public Resource Resource { get; set; }

        public Graphic()
        {
            Resource = new Resource { Type = ResourceType.Graphic };
        }

        public void Read(BinaryReader br)
        {
            throw new System.NotImplementedException();
        }

        public void Write(BinaryWriter bw)
        {
            throw new System.NotImplementedException();
        }
    }
}
