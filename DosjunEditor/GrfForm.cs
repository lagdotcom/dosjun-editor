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
            UpdateChar();
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
                int index = (int)ImageNumber.Value + 1;

                Grf.Images.Insert(index, gi);
                UpdateImageCount();
                ImageNumber.Value = index;
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

        private void UpdateChar()
        {
            bool vis = SubtypeBox.SelectedIndex == (int)ResourceSubtype.Font;
            FontChar.Visible = vis;
            FontCharLbl.Visible = vis;

            if (vis)
                FontChar.Text = Tools.AsChar((char)ImageNumber.Value);
        }

        private void SubtypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateChar();
        }
    }
}
