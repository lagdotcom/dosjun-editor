using System.IO;

namespace DosjunEditor
{
    public class ScriptSource : IHasResource
    {
        public Resource Resource { get; set; }
        public string Source { get; set; }

        public ScriptSource(Resource r)
        {
            Resource = r;
            Source = string.Empty;
        }
        public ScriptSource() : this(new Resource { Type = ResourceType.Source, OnlyDesign = true }) { }

        public void Read(BinaryReader br)
        {
            Resource.OnlyDesign = true;

            Source = br.ReadZS((int)Resource.Size);
        }

        public void Write(BinaryWriter bw)
        {
            bw.WriteZS(Source, Source.Length + 1);
        }
    }
}
