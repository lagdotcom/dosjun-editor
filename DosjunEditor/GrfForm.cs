﻿using System;
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
    public partial class GrfForm : Form, IResourceEditor
    {
        public GrfForm()
        {
            InitializeComponent();
        }

        public Context Context { get; set; }
        public IHasResource Editing { get; set; }
        public Grf Grf { get; private set; }

        public event EventHandler Saved;

        public void Setup(Context ctx, IHasResource r)
        {
            Context = ctx;
            Editing = r;
            Grf = r as Grf;

            ImageNumber.Maximum = Grf.Images.Count - 1;
            TextureFlag.Checked = Grf.Resource.Flags.HasFlag(ResourceFlags.Texture);
            ShowImage();
        }

        public void ShowImage()
        {
            GrfImage img = Grf.Images[(int)ImageNumber.Value];
            ImageView.Image = img.AsImage(Context.Djn.Palette);
        }

        private void ImageNumber_ValueChanged(object sender, EventArgs e)
        {
            ShowImage();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            ResourceFlags rf = Grf.Resource.Flags;
            Tools.SetFlag(TextureFlag.Checked, ResourceFlags.Texture, ref rf);
            Grf.Resource.Flags = rf;

            Saved?.Invoke(this, null);
        }
    }
}