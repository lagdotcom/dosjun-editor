using System;
using System.Collections;
using System.Windows.Forms;

namespace DosjunEditor
{
    public partial class StringsViewer : Form, IResourceEditor, IComparer
    {
        private int sortColumn = 0;
        private bool descending = false;

        public StringsViewer()
        {
            InitializeComponent();

            StringList.ListViewItemSorter = this;
        }

        public IHasResource Editing => Strings;
        public Strings Strings { get; private set; }
        public event EventHandler Saved;
        public Context Context { get; private set; }

        public void Setup(Context ctx, IHasResource r)
        {
            Context = ctx;
            Strings = r as Strings;

            StringList.Items.Clear();
            foreach (var pair in Strings.AsEnumerable())
                StringList.Items.Add(AsItem(pair.Key, pair.Value));
        }

        private ListViewItem AsItem(string s, ushort id)
        {
            ListViewItem lvi = new ListViewItem
            {
                Text = id.ToString(),
            };
            lvi.SubItems.Add(s);

            return lvi;
        }

        public int Compare(object x, object y)
        {
            int val = Compare(x as ListViewItem, y as ListViewItem);
            return descending ? -val : val;
        }

        private int Compare(ListViewItem a, ListViewItem b)
        {
            return a.SubItems[sortColumn].Text.CompareTo(b.SubItems[sortColumn].Text);
        }

        private void StringList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (sortColumn == e.Column)
            {
                descending = !descending;
            }
            else
            {
                sortColumn = e.Column;
                descending = false;
            }

            StringList.Sort();
        }
    }
}
