using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DosjunEditor
{
    internal class Globals
    {
        public static Color[] Palette { get; internal set; }
        private static Resource NoResource = new Resource { ID = 0, Name = "(None)" };

        public static void Populate(ComboBox box, IEnumerable<IHasResource> resources)
        {
            box.Items.Clear();
            box.Items.Add(NoResource);

            foreach (IHasResource res in resources)
                box.Items.Add(res.Resource);
        }

        public static Resource Resolve(Context ctx, ushort id)
        {
            if (id == 0) return NoResource;
            return ctx.Djn[id].Resource;
        }

        public static ResourceType Detect(string fileName)
        {
            string ext = Path.GetExtension(fileName).ToUpper();

            switch (ext)
            {
                case ".CMP": return ResourceType.Campaign;
                case ".FNT": return ResourceType.Font;
                case ".GRF": return ResourceType.Graphic;
                case ".SNG": return ResourceType.Music;
                case ".PAL": return ResourceType.Palette;
                case ".JC": return ResourceType.Source;
                case ".ZON": return ResourceType.Zone;
                default: return ResourceType.Unknown;
            }
        }
    }
}
