using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DosjunEditor
{
    public partial class TextureComboBox : UserControl
    {
        public const string NoTexture = "(None)";
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

        public event EventHandler ValueChanged;

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

        private void Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!updatingDisplay)
            {
                texture = Box.SelectedIndex == 0 ? null : (string)Box.SelectedItem;
                ValueChanged?.Invoke(this, e);
            }
        }

        private int ConvertTextureId(byte textureId)
        {
            if (textureId == 0 || textureId > Zone.TextureCount) return 0;
            return Box.Items.IndexOf(Zone.Textures[textureId - 1]);
        }
    }
}
