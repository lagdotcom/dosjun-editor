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
        private ushort textureId;

        private static Dictionary<WallLocation, Rectangle> slices = new Dictionary<WallLocation, Rectangle>
        {
            { WallLocation.North, new Rectangle(32, 64, 64, 64) },
            { WallLocation.East, new Rectangle(32, 64, 64, 64) },
            { WallLocation.South, new Rectangle(32, 64, 64, 64) },
            { WallLocation.West, new Rectangle(32, 64, 64, 64) },
            { WallLocation.Ceiling, new Rectangle(1, 0, 126, 32) },
            { WallLocation.Floor, new Rectangle(1, 160, 126, 32) }
        };

        private bool updatingDisplay;

        public TextureComboBox()
        {
            InitializeComponent();
        }

        public Context Context { get; private set; }
        public Zone Zone { get; private set; }
        public WallLocation Face { get; set; }

        public event EventHandler ValueChanged;

        public int Count => Box.Items.Count;

        public ushort TextureId
        {
            get
            {
                return textureId;
            }

            set
            {
                updatingDisplay = true;

                textureId = value;
                Box.SelectedItem = Globals.Resolve(Context, value);

                updatingDisplay = false;
            }
        }

        public void Setup(Context ctx, Zone zone)
        {
            Context = ctx;
            Zone = zone;

            Globals.Populate(Box, Context.Djn.Textures);
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
                textureId = (Box.SelectedItem as Graphic).Resource.ID;
                ValueChanged?.Invoke(this, e);
            }

            UpdatePicture();
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
