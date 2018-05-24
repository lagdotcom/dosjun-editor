using System.Collections;
using System.Windows.Forms;

namespace DosjunEditor
{
    public class ResourceListSorter : IComparer
    {
        public ResourceListSorter()
        {
        }

        public SortColumn Column { get; set; }
        public bool Descending { get; set; }

        public int Compare(object x, object y)
        {
            int comp = Compare(x as ListViewItem, y as ListViewItem);

            return Descending ? -comp : comp;
        }

        protected int Compare(ListViewItem a, ListViewItem b)
        {
            switch (Column)
            {
                case SortColumn.Name:
                    return a.Text.CompareTo(b.Text);

                case SortColumn.Type:
                    return a.SubItems[0].Text.CompareTo(b.SubItems[0].Text);

                case SortColumn.ID:
                    return ((int)a.Tag).CompareTo((int)b.Tag);

                default: return 0;
            }
        }

        public enum SortColumn
        {
            ID,
            Name,
            Type,
        }
    }
}
