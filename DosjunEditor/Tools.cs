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

        public static IEnumerable<string> GetTextures()
        {
            if (!Directory.Exists(Consts.WallDirectory)) yield break;

            foreach (string filename in Directory.EnumerateFiles(Consts.WallDirectory, "*.PCX"))
            {
                if (filename.ToUpper().EndsWith("1.PCX"))
                {
                    yield return Path.GetFileName(filename.Substring(0, filename.Length - 5));
                }
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
    }
}
