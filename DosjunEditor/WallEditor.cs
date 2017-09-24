using System;
using System.Windows.Forms;

namespace DosjunEditor
{
    public partial class WallEditor : UserControl
    {
        private Wall wall;

        public WallEditor()
        {
            wall = new Wall();
            InitializeComponent();

            foreach (string name in Tools.GetNames<WallType>())
                TypeBox.Items.Add(name);
        }

        public Wall Wall
        {
            get => wall;
            set
            {
                Wall w = value;
                if (w == null) w = new Wall();
                wall = w;

                TypeBox.SelectedIndex = (int)wall.Type;
                ColourBox.Colour = wall.Texture;
            }
        }

        public WallType Type
        {
            get => wall.Type;
            set
            {
                wall.Type = value;
                TypeBox.SelectedIndex = (int)value;
            }
        }

        public byte Colour
        {
            get => wall.Texture;
            set
            {
                wall.Texture = value;
                ColourBox.Colour = value;
            }
        }

        public event EventHandler AnyChanged;

        private void TypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            wall.Type = (WallType)TypeBox.SelectedIndex;
            AnyChanged?.Invoke(this, e);
        }

        private void ColourBox_ColourChanged(object sender, EventArgs e)
        {
            wall.Texture = ColourBox.Colour;
            AnyChanged?.Invoke(this, e);
        }
    }
}
