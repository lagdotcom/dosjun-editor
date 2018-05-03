namespace DosjunEditor
{
    partial class WallEditor
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
            this.label1 = new System.Windows.Forms.Label();
            this.TypeBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TextureBox = new DosjunEditor.TextureComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Type";
            // 
            // TypeBox
            // 
            this.TypeBox.FormattingEnabled = true;
            this.TypeBox.Location = new System.Drawing.Point(76, 0);
            this.TypeBox.Name = "TypeBox";
            this.TypeBox.Size = new System.Drawing.Size(121, 21);
            this.TypeBox.TabIndex = 1;
            this.TypeBox.SelectedIndexChanged += new System.EventHandler(this.TypeBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Texture";
            // 
            // TextureBox
            // 
            this.TextureBox.Face = DosjunEditor.WallLocation.North;
            this.TextureBox.Location = new System.Drawing.Point(76, 27);
            this.TextureBox.Name = "TextureBox";
            this.TextureBox.Size = new System.Drawing.Size(121, 142);
            this.TextureBox.TabIndex = 5;
            this.TextureBox.TextureId = ((byte)(0));
            this.TextureBox.ValueChanged += new System.EventHandler(this.TextureBox_ValueChanged);
            // 
            // WallEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TextureBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TypeBox);
            this.Controls.Add(this.label1);
            this.Name = "WallEditor";
            this.Size = new System.Drawing.Size(198, 169);
            this.Resize += new System.EventHandler(this.WallEditor_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox TypeBox;
        private System.Windows.Forms.Label label2;
        private TextureComboBox TextureBox;
    }
}
