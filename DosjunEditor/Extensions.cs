using System.Collections.Generic;
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

        public static T[] ReadArray<T>(this BinaryReader br, int count) where T : IBinaryData, new()
        {
            T[] array = new T[count];

            for (int i = 0; i < count; i++)
            {
                T item = new T();
                item.Read(br);
                array[i] = item;
            }

            return array;
        }

        public static void ReadList<T>(this BinaryReader br, List<T> list, int count) where T : IBinaryData, new()
        {
            for (int i = 0; i < count; i++)
            {
                T item = new T();
                item.Read(br);
                list.Add(item);
            }
        }

        public static List<short> ReadIntList(this BinaryReader br)
        {
            List<short> list = new List<short>();
            ushort type, osize, size, capacity;

            type = br.ReadUInt16();
            osize = br.ReadUInt16();
            size = br.ReadUInt16();
            capacity = br.ReadUInt16();

            if (type != 1) throw new IOException("Not an int list");
            if (osize != 0) throw new IOException("ints should have size 0");

            for (int i = 0; i < size; i++)
                list.Add(br.ReadInt16());

            return list;
        }

        public static void WriteIntList(this BinaryWriter bw, List<short> list)
        {
            ushort size = (ushort)list.Count;

            bw.Write((ushort)1);
            bw.Write((ushort)0);
            bw.Write(size);
            bw.Write(size);

            foreach (short item in list)
                bw.Write(item);
        }
    }
}
