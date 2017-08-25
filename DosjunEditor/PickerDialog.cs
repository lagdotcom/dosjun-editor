using System.Collections;
using System.Windows.Forms;

namespace DosjunEditor
{
    public partial class PickerDialog : Form
    {
        private IList items;

        public PickerDialog()
        {
            InitializeComponent();
        }

        public IList Items
        {
            get => items;
            set
            {
                items = value;
                LoadItems();
            }
        }

        public int SelectedIndex => Options.SelectedIndex;
        public object SelectedValue => Options.SelectedValue;

        private void LoadItems()
        {
            Options.Items.Clear();
            if (items == null) return;

            foreach (object o in items) Options.Items.Add(o);
        }
    }
}
