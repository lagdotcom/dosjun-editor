using System;
using System.Windows.Forms;

namespace DosjunEditor
{
    public partial class PalettePicker : UserControl
    {
        public PalettePicker()
        {
            InitializeComponent();
        }

        public byte Colour
        {
            get => (byte)Choice.Value;
            set { Choice.Value = value;  }
        }

        public event EventHandler ColourChanged;

        private void Choice_ValueChanged(object sender, EventArgs e)
        {
            if (Globals.Palette != null)
                Choice.BackColor = Globals.Palette[Colour];

            ColourChanged?.Invoke(this, null);
        }
    }
}
