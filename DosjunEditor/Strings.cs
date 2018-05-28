using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DosjunEditor
{
    public class Strings : IHasResource
    {
        private Dictionary<string, ushort> strings;

        public Strings(Resource r)
        {
            Resource = r;
            strings = new Dictionary<string, ushort>();
        }
        public Strings() : this(new Resource { Type = ResourceType.Strings }) { }

        public Resource Resource { get; set; }

        public void Read(BinaryReader br)
        {
            ushort count = br.ReadUInt16();

            for (var i = 0; i < count; i++)
            {
                ushort id = br.ReadUInt16();
                string s = br.ReadNS();
                strings[s] = id;
            }
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write((ushort)strings.Count);

            foreach (var pair in strings)
            {
                bw.Write(pair.Value);
                bw.WriteNS(pair.Key);
            }
        }

        public string this[ushort id] => strings.Where(p => p.Value == id).First().Key;

        public ushort Add(string s)
        {
            if (!strings.ContainsKey(s)) strings[s] = (ushort)(strings.Count + 1);
            return strings[s];
        }

        public ushort Set(ushort id, string s)
        {
            string old = this[id];
            strings.Remove(old);

            strings[s] = id;
            return id;
        }

        public IEnumerable<KeyValuePair<string, ushort>> AsEnumerable() => strings.AsEnumerable();
    }
}
