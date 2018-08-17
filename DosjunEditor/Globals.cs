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

        public static Dictionary<Skill, string> SkillSource = new Dictionary<Skill, string>
        {
            { Skill.Concentrate, "Fighter" },
            { Skill._F1b, "Fighter" },
            { Skill.Inspire, "Fighter 2" },
            { Skill.Cleave, "Fighter 2" },
            { Skill._F3a, "Fighter 3" },
            { Skill._F3b, "Fighter 3" },
            { Skill._F4a, "Fighter 4" },
            { Skill._F4b, "Fighter 4" },
            { Skill._F5a, "Fighter 5" },
            { Skill._F5b, "Fighter 5" },
            { Skill._F6a, "Fighter 6" },
            { Skill._F6b, "Fighter 6" },
            { Skill._F7a, "Fighter 7" },
            { Skill._F7b, "Fighter 7" },
            { Skill._F8a, "Fighter 8" },
            { Skill._F8b, "Fighter 8" },
            { Skill._F9a, "Fighter 9" },
            { Skill._F9b, "Fighter 9" },
            { Skill._FXa, "Fighter Max" },
            { Skill._FXb, "Fighter Max" },

            { Skill._C1a, "Cleric" },
            { Skill._C1b, "Cleric" },
            { Skill._C2a, "Cleric 2" },
            { Skill._C2b, "Cleric 2" },
            { Skill._C3a, "Cleric 3" },
            { Skill._C3b, "Cleric 3" },
            { Skill._C4a, "Cleric 4" },
            { Skill._C4b, "Cleric 4" },
            { Skill._C5a, "Cleric 5" },
            { Skill._C5b, "Cleric 5" },
            { Skill._C6a, "Cleric 6" },
            { Skill._C6b, "Cleric 6" },
            { Skill._C7a, "Cleric 7" },
            { Skill._C7b, "Cleric 7" },
            { Skill._C8a, "Cleric 8" },
            { Skill._C8b, "Cleric 8" },
            { Skill._C9a, "Cleric 9" },
            { Skill._C9b, "Cleric 9" },
            { Skill._CXa, "Cleric Max" },
            { Skill._CXb, "Cleric Max" },

            { Skill._M1a, "Mage" },
            { Skill._M1b, "Mage" },
            { Skill._M2a, "Mage 2" },
            { Skill._M2b, "Mage 2" },
            { Skill._M3a, "Mage 3" },
            { Skill._M3b, "Mage 3" },
            { Skill._M4a, "Mage 4" },
            { Skill._M4b, "Mage 4" },
            { Skill._M5a, "Mage 5" },
            { Skill._M5b, "Mage 5" },
            { Skill._M6a, "Mage 6" },
            { Skill._M6b, "Mage 6" },
            { Skill._M7a, "Mage 7" },
            { Skill._M7b, "Mage 7" },
            { Skill._M8a, "Mage 8" },
            { Skill._M8b, "Mage 8" },
            { Skill._M9a, "Mage 9" },
            { Skill._M9b, "Mage 9" },
            { Skill._MXa, "Mage Max" },
            { Skill._MXb, "Mage Max" },

            { Skill.Sing, "Bard" },
            { Skill._B1b, "Bard" },
            { Skill._B2a, "Bard 2" },
            { Skill._B2b, "Bard 2" },
            { Skill._B3a, "Bard 3" },
            { Skill._B3b, "Bard 3" },
            { Skill.Reverberation, "Bard 4" },
            { Skill._B4b, "Bard 4" },
            { Skill._B5a, "Bard 5" },
            { Skill._B5b, "Bard 5" },
            { Skill._B6a, "Bard 6" },
            { Skill._B6b, "Bard 6" },
            { Skill._B7a, "Bard 7" },
            { Skill._B7b, "Bard 7" },
            { Skill._B8a, "Bard 8" },
            { Skill._B8b, "Bard 8" },
            { Skill._B9a, "Bard 9" },
            { Skill._B9b, "Bard 9" },
            { Skill._BXa, "Bard Max" },
            { Skill._BXb, "Bard Max" },

            { Skill.Hide, "Rogue" },
            { Skill._Ro1b, "Rogue" },
            { Skill.Bludgeon, "Rogue 2" },
            { Skill.Venom, "Rogue 2" },
            { Skill._Ro3a, "Rogue 3" },
            { Skill._Ro3b, "Rogue 3" },
            { Skill._Ro4a, "Rogue 4" },
            { Skill._Ro4b, "Rogue 4" },
            { Skill._Ro5a, "Rogue 5" },
            { Skill._Ro5b, "Rogue 5" },
            { Skill._Ro6a, "Rogue 6" },
            { Skill._Ro6b, "Rogue 6" },
            { Skill._Ro7a, "Rogue 7" },
            { Skill._Ro7b, "Rogue 7" },
            { Skill._Ro8a, "Rogue 8" },
            { Skill._Ro8b, "Rogue 8" },
            { Skill._Ro9a, "Rogue 9" },
            { Skill._Ro9b, "Rogue 9" },
            { Skill._RoXa, "Rogue Max" },
            { Skill._RoXb, "Rogue Max" },

            { Skill._Ra1a, "Ranger" },
            { Skill._Ra1b, "Ranger" },
            { Skill._Ra2a, "Ranger 2" },
            { Skill._Ra2b, "Ranger 2" },
            { Skill._Ra3a, "Ranger 3" },
            { Skill._Ra3b, "Ranger 3" },
            { Skill._Ra4a, "Ranger 4" },
            { Skill._Ra4b, "Ranger 4" },
            { Skill._Ra5a, "Ranger 5" },
            { Skill._Ra5b, "Ranger 5" },
            { Skill._Ra6a, "Ranger 6" },
            { Skill._Ra6b, "Ranger 6" },
            { Skill._Ra7a, "Ranger 7" },
            { Skill._Ra7b, "Ranger 7" },
            { Skill._Ra8a, "Ranger 8" },
            { Skill._Ra8b, "Ranger 8" },
            { Skill._Ra9a, "Ranger 9" },
            { Skill._Ra9b, "Ranger 9" },
            { Skill._RaXa, "Ranger Max" },
            { Skill._RaXb, "Ranger Max" },
        };

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
                case ".DRP": return ResourceType.DropTable;
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
                case ResourceType.DropTable: return r.Resource.Name + ".DRP";
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
