using System;
using System.Collections.Generic;
using System.Drawing;
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
    }
}