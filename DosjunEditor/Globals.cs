using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DosjunEditor
{
    internal class Globals
    {
        public const int InventorySize = 10;
        public const int MaxJobLevel = 10;
        public const int NumJobs = 6;

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
                case ".ITM": return ResourceType.Item;
                case ".MON": return ResourceType.Monster;
                case ".SNG": return ResourceType.Music;
                case ".NPC": return ResourceType.NPC;
                case ".PAL": return ResourceType.Palette;
                case ".PC": return ResourceType.PC;
                case ".JCC": return ResourceType.Script;
                case ".WAV": return ResourceType.Sound;
                case ".JC": return ResourceType.Source;
                case ".STR": return ResourceType.Strings;
                case ".ZON": return ResourceType.Zone;

                default: return ResourceType.Unknown;
            }
        }

        public static string ToFilename(IHasResource r)
        {
            switch (r.Resource.Type)
            {
                case ResourceType.Campaign: return r.Resource.Name + ".CMP";
                case ResourceType.Font: return r.Resource.Name + ".FNT";
                case ResourceType.Graphic: return r.Resource.Name + ".GRF";
                case ResourceType.Item: return r.Resource.Name + ".ITM";
                case ResourceType.Monster: return r.Resource.Name + ".MON";
                case ResourceType.Music: return r.Resource.Name + ".SNG";
                case ResourceType.NPC: return r.Resource.Name + ".NPC";
                case ResourceType.Palette: return r.Resource.Name + ".PAL";
                case ResourceType.PC: return r.Resource.Name + ".PC";
                case ResourceType.Script: return r.Resource.Name + ".JCC";
                case ResourceType.Sound: return r.Resource.Name + ".WAV";
                case ResourceType.Source: return r.Resource.Name + ".JC";
                case ResourceType.Strings: return r.Resource.Name + ".STR";
                case ResourceType.Zone: return r.Resource.Name + ".ZON";

                default: return r.Resource.Name;
            }
        }
    }
}
