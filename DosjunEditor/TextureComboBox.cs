using ImageMagick;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DosjunEditor
{
    public partial class TextureComboBox : UserControl
    {
        public const string NoTexture = "(None)";

        private static Dictionary<WallLocation, Rectangle> slices = new Dictionary<WallLocation, Rectangle>
        {
            { WallLocation.North, new Rectangle(32, 64, 64, 64) },
            { WallLocation.East, new Rectangle(32, 64, 64, 64) },
            { WallLocation.South, new Rectangle(32, 64, 64, 64) },
            { WallLocation.West, new Rectangle(32, 64, 64, 64) },
            { WallLocation.Ceiling, new Rectangle(1, 0, 126, 32) },
            { WallLocation.Floor, new Rectangle(1, 160, 126, 32) }
        };

        private string texture;
        private bool updatingDisplay;

        public TextureComboBox()
        {
            InitializeComponent();

            Box.Items.Clear();
            Box.Items.Add(NoTexture);
            foreach (string texture in Tools.GetTextures())
                Box.Items.Add(texture);

            texture = null;
        }

        public Zone Zone { get; set; }
        public WallLocation Face { get; set; }

        public event EventHandler ValueChanged;

        public int Count => Box.Items.Count;

        public string Texture
        {
            get => texture;
            set
            {
                texture = value;

                updatingDisplay = true;
                Box.SelectedItem = value;
                updatingDisplay = false;
            }
        }

        public byte TextureId
        {
            get
            {
                if (texture == null) return 0;
                return (byte)Zone.GetTextureId(texture);
            }

            set
            {
                updatingDisplay = true;
                Box.SelectedIndex = ConvertTextureId(value);
                updatingDisplay = false;
            }
        }

        public void Cycle()
        {
            int index = Box.SelectedIndex + 1;
            if (index == Count) index = 0;

            Box.SelectedIndex = index;
        }

        private void Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updatingDisplay)
            {
                texture = Box.SelectedIndex == 0 ? null : (string)Box.SelectedItem;
                ValueChanged?.Invoke(this, e);
            }

            UpdatePicture();
        }

        private int ConvertTextureId(byte textureId)
        {
            if (textureId == 0 || textureId > Zone.TextureCount) return 0;
            return Box.Items.IndexOf(Zone.Textures[textureId - 1]);
        }

        private void UpdatePicture()
        {
            if (Box.SelectedIndex == 0)
            {
                Picture.Image = null;
                return;
            }

            Rectangle slice = slices[Face];
            MagickImage texture = Tools.GetPCX($"{Consts.WallDirectory}{Path.DirectorySeparatorChar}{Box.SelectedItem}1.PCX");

            if (texture != null)
            {
                texture.Crop(slice.X, slice.Y, slice.Width, slice.Height);
                Picture.Image = texture.ToBitmap();
            }
            else
                Picture.Image = null;
        }
    }
}
