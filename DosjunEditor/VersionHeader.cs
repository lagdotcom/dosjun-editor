using System.IO;

namespace DosjunEditor
{
    public class VersionHeader : IBinaryData
    {
        public void Read(BinaryReader br)
        {
            Magic = new string(br.ReadChars(3));
            Version = br.ReadByte();

            if (Magic != Consts.Magic || Version != Consts.Version)
                throw new InvalidDataException("Version header is wrong");
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(Magic.ToCharArray());
            bw.Write(Version);
        }

        public string Magic { get; set; }
        public byte Version { get; set; }
    }
}
