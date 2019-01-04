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
            wall = new Wall(Direction.Invalid);
            InitializeComponent();

            foreach (string name in Tools.GetEnumNames<WallType>())
                TypeBox.Items.Add(name);
        }

        public WallType Type
        {
            get => wall.Type;
        }

        public ushort Texture
        {
            get => wall.TextureId;
        }

        public WallLocation Face
        {
            get => TextureBox.Face;
            set
            {
                TextureBox.Face = value;
            }
        }

        public event EventHandler AnyChanged;

        public void Setup(Context ctx, Zone zone, Wall wall)
        {
            this.wall = wall;

            updatingDisplay = true;
            TypeBox.SelectedIndex = (int)this.wall.Type;
            TextureBox.Setup(ctx, zone);
            TextureBox.TextureId = this.wall.TextureId;
            updatingDisplay = false;
        }

        public void CycleType()
        {
            int index = TypeBox.SelectedIndex + 1;
            if (index == (int)WallType.Invalid) index = 0;

            TypeBox.SelectedIndex = index;
        }

        public void CycleTexture()
        {
            TextureBox.Cycle();
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

        private void WallEditor_Resize(object sender, EventArgs e)
        {
            TypeBox.Left = Width * 40 / 100;
            TextureBox.Left = TypeBox.Left;

            TypeBox.Width = Width - TypeBox.Left;
            TextureBox.Width = TypeBox.Width;
            TextureBox.Height = Height - TextureBox.Top;
        }
    }
}
