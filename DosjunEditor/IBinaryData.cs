using System.IO;

namespace DosjunEditor
{
    public interface IBinaryData
    {
        void Read(BinaryReader br);
        void Write(BinaryWriter bw);
    }
}
