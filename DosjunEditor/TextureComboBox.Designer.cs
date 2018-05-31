namespace DosjunEditor
{
    partial class TextureComboBox
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Box = new System.Windows.Forms.ComboBox();
            this.Picture = new DosjunEditor.InterpolatedBox();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
            this.SuspendLayout();
            // 
            // Box
            // 
            this.Box.Dock = System.Windows.Forms.DockStyle.Top;
            this.Box.FormattingEnabled = true;
            this.Box.Location = new System.Drawing.Point(0, 0);
            this.Box.Name = "Box";
            this.Box.Size = new System.Drawing.Size(150, 21);
            this.Box.TabIndex = 0;
            this.Box.SelectedIndexChanged += new System.EventHandler(this.Box_SelectedIndexChanged);
            // 
            // Picture
            // 
            this.Picture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Picture.Interpolation = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            this.Picture.Location = new System.Drawing.Point(0, 21);
            this.Picture.Name = "Picture";
            this.Picture.Size = new System.Drawing.Size(150, 150);
            this.Picture.TabIndex = 8;
            this.Picture.TabStop = false;
            // 
            // TextureComboBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Picture);
            this.Controls.Add(this.Box);
            this.Name = "TextureComboBox";
            this.Size = new System.Drawing.Size(150, 171);
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox Box;
        private InterpolatedBox Picture;
    }
}
