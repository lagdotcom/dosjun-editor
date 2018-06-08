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
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.ImportBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.SubtypeBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ImageNumber = new System.Windows.Forms.NumericUpDown();
            this.Picker = new System.Windows.Forms.OpenFileDialog();
            this.FontCharLbl = new System.Windows.Forms.Label();
            this.FontChar = new System.Windows.Forms.TextBox();
            this.ImageView = new DosjunEditor.InterpolatedBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.FontChar);
            this.panel1.Controls.Add(this.FontCharLbl);
            this.panel1.Controls.Add(this.DeleteBtn);
            this.panel1.Controls.Add(this.ImportBtn);
            this.panel1.Controls.Add(this.CancelBtn);
            this.panel1.Controls.Add(this.SubtypeBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.SaveBtn);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ImageNumber);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(266, 450);
            this.panel1.TabIndex = 3;
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Location = new System.Drawing.Point(185, 181);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(75, 23);
            this.DeleteBtn.TabIndex = 11;
            this.DeleteBtn.Text = "Delete";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // ImportBtn
            // 
            this.ImportBtn.Location = new System.Drawing.Point(185, 152);
            this.ImportBtn.Name = "ImportBtn";
            this.ImportBtn.Size = new System.Drawing.Size(75, 23);
            this.ImportBtn.TabIndex = 10;
            this.ImportBtn.Text = "Import...";
            this.ImportBtn.UseVisualStyleBackColor = true;
            this.ImportBtn.Click += new System.EventHandler(this.ImportBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(185, 415);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 8;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // SubtypeBox
            // 
            this.SubtypeBox.FormattingEnabled = true;
            this.SubtypeBox.Location = new System.Drawing.Point(139, 12);
            this.SubtypeBox.Name = "SubtypeBox";
            this.SubtypeBox.Size = new System.Drawing.Size(121, 21);
            this.SubtypeBox.TabIndex = 7;
            this.SubtypeBox.SelectedIndexChanged += new System.EventHandler(this.SubtypeBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Subtype";
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
            // Picker
            // 
            this.Picker.Filter = "Image files|*.png";
            // 
            // FontCharLbl
            // 
            this.FontCharLbl.AutoSize = true;
            this.FontCharLbl.Location = new System.Drawing.Point(12, 70);
            this.FontCharLbl.Name = "FontCharLbl";
            this.FontCharLbl.Size = new System.Drawing.Size(77, 13);
            this.FontCharLbl.TabIndex = 12;
            this.FontCharLbl.Text = "Font Character";
            // 
            // FontChar
            // 
            this.FontChar.Location = new System.Drawing.Point(140, 67);
            this.FontChar.Name = "FontChar";
            this.FontChar.ReadOnly = true;
            this.FontChar.Size = new System.Drawing.Size(40, 20);
            this.FontChar.TabIndex = 13;
            this.FontChar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ImageView
            // 
            this.ImageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImageView.Interpolation = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            this.ImageView.Location = new System.Drawing.Point(266, 0);
            this.ImageView.Name = "ImageView";
            this.ImageView.Size = new System.Drawing.Size(534, 450);
            this.ImageView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImageView.TabIndex = 4;
            this.ImageView.TabStop = false;
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
        private InterpolatedBox ImageView;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.ComboBox SubtypeBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button ImportBtn;
        private System.Windows.Forms.OpenFileDialog Picker;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.TextBox FontChar;
        private System.Windows.Forms.Label FontCharLbl;
    }
}