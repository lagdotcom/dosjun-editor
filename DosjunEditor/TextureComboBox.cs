﻿using ImageMagick;
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
        
        private bool updatingDisplay;

        public TextureComboBox()
        {
            InitializeComponent();
        }

        public Context Context { get; private set; }
        public Zone Zone { get; private set; }

        // TODO: ?
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
                textureId = (Box.SelectedItem as Resource).ID;
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

            Resource img = Box.SelectedItem as Resource;
            Picture.Image = (Context.Djn[img.ID] as Grf).Images[0].AsImage(Context.Djn.Palette);
        }
    }
}
