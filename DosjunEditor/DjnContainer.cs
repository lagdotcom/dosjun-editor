using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DosjunEditor
{
    public class Djn : IBinaryData
    {
        public Djn()
        {
            Resources = new Dictionary<int, IHasResource>();
            Version = new VersionHeader();
        }

        public VersionHeader Version { get; set; }
        public DjnFlags Flags { get; set; }
        public Dictionary<int, IHasResource> Resources { get; set; }

        public int NextResourceId => Enumerable.Range(1, ushort.MaxValue - 1).Except(Resources.Keys.AsQueryable()).FirstOrDefault();

        public Campaign Campaign => Resources.Values.OfType<Campaign>().FirstOrDefault();
        public IEnumerable<Monster> Monsters => Resources.Values.OfType<Monster>();
        public Palette Palette => Resources.Values.OfType<Palette>().FirstOrDefault();
        public IEnumerable<CompiledScript> PublicScripts => Scripts.Where(s => !s.Resource.Flags.HasFlag(ResourceFlags.Private));
        public Strings Strings => Resources.Values.OfType<Strings>().FirstOrDefault();
        public IEnumerable<CompiledScript> Scripts => Resources.Values.OfType<CompiledScript>();
        public IEnumerable<Grf> Textures => Resources.Values.OfType<Grf>().Where(s => s.Resource.Flags.HasFlag(ResourceFlags.Texture));

        public event EventHandler<IHasResource> ResourceChanged;

        public ushort Add(IHasResource res)
        {
            int id = NextResourceId;
            if (NextResourceId == 0 || NextResourceId > ushort.MaxValue)
                throw new IndexOutOfRangeException($"Too many resources.");

            res.Resource.ID = (ushort)id;
            Resources[id] = res;

            ResourceChanged?.Invoke(this, res);
            return (ushort)id;
        }

        public void Read(BinaryReader br)
        {
            Version.Read(br);
            uint count = br.ReadUInt32();
            uint diroff = br.ReadUInt32();
            Flags = (DjnFlags)br.ReadUInt16();

            Resources.Clear();
            br.BaseStream.Seek(diroff, SeekOrigin.Begin);
            for (int i = 0; i < count; i++)
            {
                Resource r = new Resource();

                r.Read(br, Flags.HasFlag(DjnFlags.Design));
                IHasResource res = Construct(r);

                long off = br.BaseStream.Position;
                br.BaseStream.Seek(r.Offset, SeekOrigin.Begin);
                res.Read(br);
                br.BaseStream.Seek(off, SeekOrigin.Begin);

                Resources[r.ID] = res;
            }
        }

        public void Write(BinaryWriter bw)
        {
            Version.Write(bw);
            bw.Write((uint)Resources.Count);
            bw.Write((uint)0);
            bw.Write((ushort)Flags);

            bw.Seek(32, SeekOrigin.Begin);
            foreach (var pair in Resources)
            {
                Resource r = pair.Value.Resource;

                r.ID = (ushort)pair.Key;
                r.Offset = (uint)bw.BaseStream.Position;
                pair.Value.Write(bw);
                r.Size = (uint)(bw.BaseStream.Position - r.Offset);
            }

            long diroff = bw.BaseStream.Position;
            bw.Seek(8, SeekOrigin.Begin);
            bw.Write((uint)diroff);

            bw.BaseStream.Seek(diroff, SeekOrigin.Begin);
            foreach (var pair in Resources)
            {
                Resource r = pair.Value.Resource;

                // Sorry
                if (!Flags.HasFlag(DjnFlags.Design) && r.OnlyDesign)
                    continue;

                r.Write(bw, Flags.HasFlag(DjnFlags.Design));
            }
        }

        public bool Remove(int id)
        {
            if (!Resources.ContainsKey(id)) return false;

            Resources.Remove(id);
            ResourceChanged?.Invoke(this, null);
            return true;
        }

        public T FindByName<T>(string value) where T: IHasResource
        {
            IHasResource r = Resources.Values.OfType<T>().Where(p => p.Resource.Name == value).FirstOrDefault();

            if (r != null) return (T)r;
            return default(T);
        }

        public IHasResource Construct(Resource r)
        {
            switch (r.Type)
            {
                case ResourceType.Campaign:
                    return new Campaign(r);

                case ResourceType.Font:
                    return new Font(r);

                case ResourceType.Graphic:
                    return new Grf(r);

                case ResourceType.Item:
                    return new Item(r);

                case ResourceType.Monster:
                    return new Monster(r);

                case ResourceType.Palette:
                    return new Palette(r);

                case ResourceType.Script:
                    return new CompiledScript(r);

                case ResourceType.Strings:
                    return new Strings(r);

                case ResourceType.Source:
                    return new ScriptSource(r);

                case ResourceType.Zone:
                    return new Zone(r);

                default:
                    return new UnknownResource(r);
            }
        }

        public IHasResource this[int id]
        {
            get
            {
                if (!Resources.ContainsKey(id))
                {
                    MessageBox.Show($"Missing resource: #{id:X}", "Uh-oh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                return Resources[id];
            }
        }

        public void Rename(int id, string name)
        {
            IHasResource res = this[id];

            res.Resource.Name = name;
            ResourceChanged?.Invoke(this, res);
        }
    }
}
