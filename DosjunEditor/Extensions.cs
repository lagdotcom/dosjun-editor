using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DosjunEditor
{
    static class Extensions
    {
        private const ushort LIST_TYPE_INT = 1;
        private const ushort LIST_TYPE_OBJECT = 2;

        public static void WriteNS(this BinaryWriter bw, string data)
        {
            if (data == null)
            {
                bw.Write((ushort)0);
                return;
            }

            ushort len = (ushort)data.Length;
            bw.Write(len);
            bw.Write(data.ToCharArray());
            bw.Write('\0');
        }

        public static void WriteZS(this BinaryWriter bw, string data, int size)
        {
            if (data == null)
            {
                for (var i = 0; i < size; i++)
                    bw.Write('\0');

                return;
            }

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
            if (len == 0) return null;

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

        public static List<T> ReadMany<T>(this BinaryReader br, int count) where T : IBinaryData, new()
        {
            List<T> list = new List<T>();

            for (int i = 0; i < count; i++)
            {
                T item = new T();
                item.Read(br);
                list.Add(item);
            }

            return list;
        }

        public static void WriteMany<T>(this BinaryWriter bw, List<T> list) where T : IBinaryData
        {
            for (int i = 0; i < list.Count; i++)
                list[i].Write(bw);
        }

        public static List<short> ReadIntList(this BinaryReader br)
        {
            List<short> list = new List<short>();
            ushort type, osize, size;

            type = br.ReadUInt16();
            osize = br.ReadUInt16();
            size = br.ReadUInt16();
            br.ReadUInt16(); // Capacity

            if (type != LIST_TYPE_INT) throw new IOException("Not an int list");
            if (osize != 0) throw new IOException("ints should have size 0");

            for (int i = 0; i < size; i++)
                list.Add(br.ReadInt16());

            return list;
        }

        public static List<T> ReadObjectList<T>(this BinaryReader br) where T : IBinaryData, new()
        {
            List<T> list = new List<T>();
            ushort type, osize, size;

            type = br.ReadUInt16();
            osize = br.ReadUInt16();
            size = br.ReadUInt16();
            br.ReadUInt16(); // Capacity

            if (type != LIST_TYPE_OBJECT) throw new IOException("Not an object list");
            if (osize == 0) throw new IOException("objects should have nonzero size");

            for (int i = 0; i < size; i++)
            {
                T obj = new T();
                obj.Read(br);
                list.Add(obj);
            }

            return list;
        }

        public static void WriteObjectList<T>(this BinaryWriter bw, List<T> list, ushort osize) where T: IBinaryData
        {
            bw.Write(LIST_TYPE_OBJECT);
            bw.Write(osize);
            bw.Write(list.Count);
            bw.Write(list.Count); // Capacity

            foreach (T obj in list)
                obj.Write(bw);
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

        public static IEnumerable<object> GetTags(this ListView.SelectedListViewItemCollection items)
        {
            List<object> tags = new List<object>();

            foreach (ListViewItem lvi in items)
                tags.Add(lvi.Tag);

            return tags.AsEnumerable();
        }
    }
}
