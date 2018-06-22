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
    public partial class GrfForm : Form, IResourceEditor
    {
        readonly string[] textureImageNames = new string[]
        {
            "000W",
            "000C",
            "000R",
            "000F",
            "000L",

            "0L1W",
            "0L1C",
            "0L1F",

            "0R1W",
            "0R1C",
            "0R1F",

            "100W",
            "100C",
            "100R",
            "100F",
            "100L",

            "1L1W",
            "1L1C",
            "1L1F",

            "1R1W",
            "1R1C",
            "1R1F",

            "200W",
            "200C",
            "200R",
            "200F",
            "200L",

            "2L1W",
            "2L1C",
            "2L1F",
            "2L1L",

            "2R1W",
            "2R1C",
            "2R1R",
            "2R1F",

            "2L2W",
            "2L2C",
            "2L2F",

            "2R2W",
            "2R2C",
            "2R2F",
        };

        public GrfForm()
        {
            InitializeComponent();

            foreach (string name in Tools.GetEnumNames<ResourceSubtype>())
                SubtypeBox.Items.Add(name);
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

            // TODO: this doesn't copy the original resource so it will overwrite even if you don't hit save

            SubtypeBox.SelectedIndex = (int)r.Resource.Subtype;
            UpdateImageCount();
            ShowImage();
        }

        public void ShowImage()
        {
            if (Grf.Images.Count == 0)
            {
                ImageView.Image = null;
                return;
            }

            GrfImage img = Grf.Images[(int)ImageNumber.Value];
            ImageView.Image = img.AsImage(Context.Djn.Palette);
            UpdateImageName();
        }

        private void ImageNumber_ValueChanged(object sender, EventArgs e)
        {
            ShowImage();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            Grf.Resource.Subtype = (ResourceSubtype)SubtypeBox.SelectedIndex;

            Saved?.Invoke(this, null);
            Context.Djn.Rename(Grf.Resource.ID, Grf.Resource.Name); // this is kinda hacky
            Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ImportBtn_Click(object sender, EventArgs e)
        {
            int newIndex = (int)ImageNumber.Value + 1;
            string name = GetImageName(newIndex);

            Picker.Title = string.IsNullOrEmpty(name) ? "Import an image" : $"Import the {name} image";
            if (Picker.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(Picker.FileName);
                ImgConverter cnv = new ImgConverter { Palette = Context.Djn.Palette };
                GrfImage gi = cnv.Convert(img);

                Grf.Images.Insert(newIndex, gi);
                UpdateImageCount();
                ImageNumber.Value = newIndex;
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            Grf.Images.RemoveAt((int)ImageNumber.Value);
            UpdateImageCount();
        }

        private void UpdateImageCount()
        {
            ImageNumber.Minimum = 0;
            ImageNumber.Maximum = Grf.Images.Count - 1;
            DeleteBtn.Enabled = Grf.Images.Count > 0;
        }

        private void UpdateImageName()
        {
            string name = GetImageName((int)ImageNumber.Value);

            if (string.IsNullOrEmpty(name))
            {
                ImageName.Visible = false;
                ImageNameLbl.Visible = false;
            }
            else
            {
                ImageName.Visible = true;
                ImageNameLbl.Visible = true;
                ImageName.Text = name;
            }
        }

        private string GetImageName(int index)
        {
            switch ((ResourceSubtype)SubtypeBox.SelectedIndex)
            {
                case ResourceSubtype.Font:
                    return Tools.AsChar((char)index);

                case ResourceSubtype.Texture:
                    return (index >= 0 && index < textureImageNames.Length) ? textureImageNames[index] : "(unknown)";
            }

            return null;
        }

        private void SubtypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateImageName();
        }
    }
}
