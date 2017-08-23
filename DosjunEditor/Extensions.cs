using System.IO;

namespace DosjunEditor
{
    static class Extensions
    {
        public static void WriteNS(this BinaryWriter bw, string data)
        {
            ushort len = (ushort)data.Length;
            bw.Write(len);
            bw.Write(data.ToCharArray());
            bw.Write('\0');
        }

        public static void WriteZS(this BinaryWriter bw, string data, int size)
        {
            bw.Write(data.ToCharArray());
            for (var i = data.Length; i < size; i++)
                bw.Write('\0');
        }

        public static void WritePadding(this BinaryWriter bw, int bytes)
        {
            byte[] data = new byte[bytes];
            bw.Write(data);
        }

        public static string ReadNS(this BinaryReader br)
        {
            ushort len = br.ReadUInt16();
            string data = new string(br.ReadChars(len));
            br.ReadChar();
            return data;
        }

        public static string ReadZS(this BinaryReader br, int size)
        {
            string data = new string(br.ReadChars(size));
            return data.TrimEnd('\0');
        }
    }
}
