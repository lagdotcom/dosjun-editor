using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DosjunEditor
{
    public class Globals
    {
        // Generic Header Magic
        public const string Magic = "JUN";

        // Generic Header Version
        public const byte Version = 1;

        // Max items in PC inventory
        public const int InventorySize = 10;

        // Max level in each job
        public const int MaxJobLevel = 10;

        // Number of defined jobs in core
        public const int NumJobs = 10;

        // Number of defined stats in core
        public const int NumStats = 16;

        // Number of walls in each tile
        public const int NumWalls = 4;

        // Max length of PC names
        public const int NameSize = 24;

        // Number of monster types in one encounter
        public const int EncounterSize = 6;

        // Number of encounters in one etable
        public const int ETableSize = 6;

        // Used for empty items in combo boxes
        public const string EmptyItem = "-";

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
            if (id == 0 || !ctx.Djn.Contains(id))
                return NoResource;

            return ctx.Djn[id].Resource;
        }

        public static ResourceType Detect(string fileName)
        {
            string ext = Path.GetExtension(fileName).ToUpper();

            switch (ext)
            {
                case ".CMP": return ResourceType.Campaign;
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

        public static int GetBase(Stats parent, Stat st)
        {
            switch (st)
            {
                case Stat.Toughness:
                    return parent[Stat.Strength] / 3;

                case Stat.MinDamage:
                    return parent[Stat.Strength] / 5;

                case Stat.MaxDamage:
                    return parent[Stat.Strength] / 4;

                default: return 0;
            }
        }
    }
}
