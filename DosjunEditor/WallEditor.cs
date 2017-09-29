using System;
using System.Windows.Forms;

namespace DosjunEditor
{
    public partial class WallEditor : UserControl
    {
        private bool updatingDisplay;
        private Wall wall;

        public WallEditor()
        {
            wall = new Wall();
            InitializeComponent();

            foreach (string name in Tools.GetEnumNames<WallType>())
                TypeBox.Items.Add(name);
        }

        public WallType Type
        {
            get => wall.Type;
        }

        public byte Texture
        {
            get => wall.TextureId;
        }

        public event EventHandler AnyChanged;

        public void Setup(Zone z, Wall w)
        {
            wall = w;

            updatingDisplay = true;
            TypeBox.SelectedIndex = (int)wall.Type;
            TextureBox.Zone = z;
            TextureBox.TextureId = wall.TextureId;
            updatingDisplay = false;
        }
        
        private void TypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updatingDisplay)
            {
                wall.Type = (WallType)TypeBox.SelectedIndex;
                AnyChanged?.Invoke(this, e);
            }
        }

        private void TextureBox_ValueChanged(object sender, EventArgs e)
        {
            wall.TextureId = TextureBox.TextureId;
            AnyChanged?.Invoke(this, e);
        }
    }
}
