using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DosjunEditor
{
    public partial class StringDialog : Form
    {
        public StringDialog()
        {
            InitializeComponent();
        }

        public string String { get; set; }
        
        private void OKBtn_Click(object sender, EventArgs e)
        {
            String = EntryBox.Text;
        }

        private void StringDialog_Shown(object sender, EventArgs e)
        {
            EntryBox.Text = String;
            EntryBox.Focus();
            EntryBox.SelectAll();
        }
    }
}
