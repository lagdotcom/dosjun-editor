﻿using System.IO;

namespace DosjunEditor
{
    public class VersionHeader : IBinaryData
    {
        public const int Size = 4;

        public VersionHeader()
        {
            Magic = Globals.Magic;
            Version = Globals.Version;
        }

        public void Read(BinaryReader br)
        {
            Magic = new string(br.ReadChars(3));
            Version = br.ReadByte();

            if (Magic != Globals.Magic || Version > Globals.Version)
                throw new InvalidDataException("Version header is wrong");
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(Magic.ToCharArray());
            bw.Write(Version);
        }

        public string Magic { get; set; }
        public byte Version { get; set; }

        public override string ToString() => $"{Magic} v{Version}";
    }
}
