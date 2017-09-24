using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DosjunEditor
{
    public static class Tools
    {
        public static IEnumerable<string> GetNames<T>()
        {
            foreach (string name in Enum.GetNames(typeof(T)))
                yield return FormatEnumName(name);
        }

        public static ushort AddETable(ZoneContext context)
        {
            ETable et = new ETable();
            using (ETableForm child = new ETableForm())
            {
                child.Setup(context, et);

                if (child.ShowDialog() == DialogResult.OK)
                {
                    child.Apply();
                    context.Zone.ETables.Add(et);

                    context.UnsavedChanges = true;
                    context.UpdateEncounters();

                    return context.Zone.ETableCount;
                }
                else return 0;
            }
        }

        private static string FormatEnumName(string name)
        {
            string formatted = name.Replace("_", " ");

            return formatted;
        }
    }
}
