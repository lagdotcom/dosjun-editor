using ImageMagick;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DosjunEditor
{
    public static class Tools
    {
        public static IEnumerable<string> GetEnumNames<T>(char replacement = ' ')
        {
            foreach (string name in Enum.GetNames(typeof(T)))
                yield return FormatEnumName(name, replacement);
        }

        public static ushort AddETable(Context context, Zone zone)
        {
            ETable et = new ETable();
            using (ETableForm child = new ETableForm())
            {
                child.Setup(context, zone, et);

                if (child.ShowDialog() == DialogResult.OK)
                {
                    child.Apply();
                    zone.ETables.Add(et);

                    context.UnsavedChanges = true;
                    context.UpdateEncounters();

                    return zone.ETableCount;
                }
                else return 0;
            }
        }
        
        public static void SetFlag(bool present, ResourceFlags flag, ref ResourceFlags flags)
        {
            if (present)
                flags = flags | flag;
            else
                flags = flags ^ flag;
        }

        public static MagickImage GetPCX(string filename)
        {
            if (File.Exists(filename))
            {
                return new MagickImage(filename);
            }

            return null;
        }

        private static string FormatEnumName(string name, char replacement = ' ')
        {
            string formatted = name.Replace('_', replacement);

            return formatted;
        }

        public static string AsChar(char value)
        {
            switch (value)
            {
                case '\0': return "NUL";
                case '\n': return "LF";
                case '\r': return "CR";
                case '\t': return "TAB";
                case '\b': return "BS";
                case '\a': return "BEL";
                case '\f': return "FF";
                case '\v': return "VT";

                default: return $"{Convert.ToChar(value)}";
            }
        }
    }
}
