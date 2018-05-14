namespace DosjunEditor
{
    partial class GrfForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ImageNumber = new System.Windows.Forms.NumericUpDown();
            this.ImageView = new System.Windows.Forms.PictureBox();
            this.TextureFlag = new System.Windows.Forms.CheckBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SaveBtn);
            this.panel1.Controls.Add(this.TextureFlag);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ImageNumber);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(266, 450);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Image Number";
            // 
            // ImageNumber
            // 
            this.ImageNumber.Location = new System.Drawing.Point(140, 41);
            this.ImageNumber.Name = "ImageNumber";
            this.ImageNumber.Size = new System.Drawing.Size(120, 20);
            this.ImageNumber.TabIndex = 2;
            this.ImageNumber.ValueChanged += new System.EventHandler(this.ImageNumber_ValueChanged);
            // 
            // ImageView
            // 
            this.ImageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImageView.Location = new System.Drawing.Point(266, 0);
            this.ImageView.Name = "ImageView";
            this.ImageView.Size = new System.Drawing.Size(534, 450);
            this.ImageView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImageView.TabIndex = 4;
            this.ImageView.TabStop = false;
            // 
            // TextureFlag
            // 
            this.TextureFlag.AutoSize = true;
            this.TextureFlag.Location = new System.Drawing.Point(15, 12);
            this.TextureFlag.Name = "TextureFlag";
            this.TextureFlag.Size = new System.Drawing.Size(68, 17);
            this.TextureFlag.TabIndex = 4;
            this.TextureFlag.Text = "Texture?";
            this.TextureFlag.UseVisualStyleBackColor = true;
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(8, 415);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveBtn.TabIndex = 5;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // GrfForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ImageView);
            this.Controls.Add(this.panel1);
            this.Name = "GrfForm";
            this.Text = "Graphic Viewer";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown ImageNumber;
        private System.Windows.Forms.PictureBox ImageView;
        private System.Windows.Forms.CheckBox TextureFlag;
        private System.Windows.Forms.Button SaveBtn;
    }
}