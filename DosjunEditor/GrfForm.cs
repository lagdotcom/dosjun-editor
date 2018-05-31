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

            ImageNumber.Maximum = Grf.Images.Count - 1;
            SubtypeBox.SelectedIndex = (int)r.Resource.Subtype;
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
            if (Picker.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(Picker.FileName);
                ImgConverter cnv = new ImgConverter { Palette = Context.Djn.Palette };
                GrfImage gi = cnv.Convert(img);

                Grf.Images.Add(gi);
                ImageNumber.Maximum = Grf.Images.Count - 1;
                ImageNumber.Value = ImageNumber.Maximum;
            }
        }
    }
}
