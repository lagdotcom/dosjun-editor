using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace DosjunEditor
{
    public partial class SkillsEditor : UserControl, IComparer
    {
        int sortColumn = 0;
        bool descending = false;

        public SkillsEditor()
        {
            InitializeComponent();

            foreach (Skill sk in Enum.GetValues(typeof(Skill)))
                Add(sk);

            View.ListViewItemSorter = this;
        }

        public IEnumerable<short> Values
        {
            get => from ListViewItem item in View.CheckedItems
                   select (short)item.Tag;
            set
            {
                for (short i = 0; i < View.Items.Count; i++)
                {
                    ListViewItem item = View.Items[i];
                    item.Checked = value.Contains((short)item.Tag);
                }
            }
        }

        public int Compare(object x, object y)
        {
            ListViewItem a = x as ListViewItem;
            ListViewItem b = y as ListViewItem;

            int cmp = a.SubItems[sortColumn].Text.CompareTo(b.SubItems[sortColumn].Text);
            if (descending) cmp = -cmp;

            return cmp;
        }

        private void Add(Skill sk)
        {
            View.Items.Add(new ListViewItem(new string[]{
                Tools.FormatEnumName(sk.ToString(), '?'),
                Globals.SkillSource.ContainsKey(sk) ? Globals.SkillSource[sk] : "?",
            })
            { Tag = sk });
        }

        private void View_ColumnClick(object sender, ColumnClickEventArgs e)
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

            View.Sort();
        }

        private void SkillsEditor_Resize(object sender, EventArgs e)
        {
            View.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
    }
}
