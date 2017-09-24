namespace DosjunEditor
{
    partial class MonsterForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.IDBox = new System.Windows.Forms.NumericUpDown();
            this.ImageBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.RowBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.AIBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.StatsBoxes = new DosjunEditor.StatsEditor();
            this.ImageShow = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.IDBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageShow)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(12, 278);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 100;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(176, 278);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 101;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(75, 38);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(155, 20);
            this.NameBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Name";
            // 
            // IDBox
            // 
            this.IDBox.Location = new System.Drawing.Point(75, 12);
            this.IDBox.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.IDBox.Name = "IDBox";
            this.IDBox.Size = new System.Drawing.Size(155, 20);
            this.IDBox.TabIndex = 1;
            // 
            // ImageBox
            // 
            this.ImageBox.Location = new System.Drawing.Point(75, 64);
            this.ImageBox.MaxLength = 8;
            this.ImageBox.Name = "ImageBox";
            this.ImageBox.Size = new System.Drawing.Size(155, 20);
            this.ImageBox.TabIndex = 3;
            this.ImageBox.TextChanged += new System.EventHandler(this.ImageBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Image";
            // 
            // RowBox
            // 
            this.RowBox.FormattingEnabled = true;
            this.RowBox.Items.AddRange(new object[] {
            "Front",
            "Back"});
            this.RowBox.Location = new System.Drawing.Point(74, 224);
            this.RowBox.Name = "RowBox";
            this.RowBox.Size = new System.Drawing.Size(156, 21);
            this.RowBox.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 227);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Row";
            // 
            // AIBox
            // 
            this.AIBox.FormattingEnabled = true;
            this.AIBox.Location = new System.Drawing.Point(74, 251);
            this.AIBox.Name = "AIBox";
            this.AIBox.Size = new System.Drawing.Size(156, 21);
            this.AIBox.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 254);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "AI";
            // 
            // StatsBoxes
            // 
            this.StatsBoxes.Location = new System.Drawing.Point(257, 3);
            this.StatsBoxes.Name = "StatsBoxes";
            this.StatsBoxes.Size = new System.Drawing.Size(258, 259);
            this.StatsBoxes.Stats = null;
            this.StatsBoxes.TabIndex = 6;
            // 
            // ImageShow
            // 
            this.ImageShow.Location = new System.Drawing.Point(102, 90);
            this.ImageShow.Name = "ImageShow";
            this.ImageShow.Size = new System.Drawing.Size(128, 128);
            this.ImageShow.TabIndex = 102;
            this.ImageShow.TabStop = false;
            // 
            // MonsterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 311);
            this.Controls.Add(this.ImageShow);
            this.Controls.Add(this.StatsBoxes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.AIBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.RowBox);
            this.Controls.Add(this.ImageBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.IDBox);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "MonsterForm";
            this.Text = "Monster Editor";
            ((System.ComponentModel.ISupportInitialize)(this.IDBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown IDBox;
        private System.Windows.Forms.TextBox ImageBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox RowBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox AIBox;
        private System.Windows.Forms.Label label5;
        private StatsEditor StatsBoxes;
        private System.Windows.Forms.PictureBox ImageShow;
    }
}