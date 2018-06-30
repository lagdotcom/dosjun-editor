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
            this.OKBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.RowBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.AIBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ImageShow = new DosjunEditor.InterpolatedBox();
            this.XPBox = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.SkillsBox = new System.Windows.Forms.GroupBox();
            this.ImageBox = new System.Windows.Forms.ComboBox();
            this.StatsBoxes = new DosjunEditor.StatsEditor();
            this.SkillsList = new DosjunEditor.SkillsEditor();
            ((System.ComponentModel.ISupportInitialize)(this.ImageShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XPBox)).BeginInit();
            this.SkillsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // OKBtn
            // 
            this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKBtn.Location = new System.Drawing.Point(15, 390);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(75, 23);
            this.OKBtn.TabIndex = 100;
            this.OKBtn.Text = "OK";
            this.OKBtn.UseVisualStyleBackColor = true;
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(220, 390);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 101;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(75, 8);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(220, 20);
            this.NameBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 37);
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
            this.RowBox.Location = new System.Drawing.Point(75, 194);
            this.RowBox.Name = "RowBox";
            this.RowBox.Size = new System.Drawing.Size(220, 21);
            this.RowBox.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Row";
            // 
            // AIBox
            // 
            this.AIBox.FormattingEnabled = true;
            this.AIBox.Location = new System.Drawing.Point(75, 221);
            this.AIBox.Name = "AIBox";
            this.AIBox.Size = new System.Drawing.Size(220, 21);
            this.AIBox.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 224);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "AI";
            // 
            // ImageShow
            // 
            this.ImageShow.Interpolation = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            this.ImageShow.Location = new System.Drawing.Point(167, 60);
            this.ImageShow.Name = "ImageShow";
            this.ImageShow.Size = new System.Drawing.Size(128, 128);
            this.ImageShow.TabIndex = 102;
            this.ImageShow.TabStop = false;
            // 
            // XPBox
            // 
            this.XPBox.Location = new System.Drawing.Point(75, 248);
            this.XPBox.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.XPBox.Name = "XPBox";
            this.XPBox.Size = new System.Drawing.Size(220, 20);
            this.XPBox.TabIndex = 104;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 250);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 103;
            this.label6.Text = "Experience";
            // 
            // SkillsBox
            // 
            this.SkillsBox.Controls.Add(this.SkillsList);
            this.SkillsBox.Location = new System.Drawing.Point(565, 8);
            this.SkillsBox.Name = "SkillsBox";
            this.SkillsBox.Size = new System.Drawing.Size(200, 405);
            this.SkillsBox.TabIndex = 105;
            this.SkillsBox.TabStop = false;
            this.SkillsBox.Text = "Skills";
            // 
            // ImageBox
            // 
            this.ImageBox.FormattingEnabled = true;
            this.ImageBox.Location = new System.Drawing.Point(75, 33);
            this.ImageBox.Name = "ImageBox";
            this.ImageBox.Size = new System.Drawing.Size(220, 21);
            this.ImageBox.TabIndex = 106;
            this.ImageBox.SelectedIndexChanged += new System.EventHandler(this.ImageBox_SelectedIndexChanged);
            // 
            // StatsBoxes
            // 
            this.StatsBoxes.Location = new System.Drawing.Point(301, 8);
            this.StatsBoxes.Name = "StatsBoxes";
            this.StatsBoxes.Size = new System.Drawing.Size(258, 405);
            this.StatsBoxes.Stats = null;
            this.StatsBoxes.TabIndex = 6;
            // 
            // SkillsList
            // 
            this.SkillsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SkillsList.Location = new System.Drawing.Point(3, 16);
            this.SkillsList.Name = "SkillsList";
            this.SkillsList.Size = new System.Drawing.Size(194, 386);
            this.SkillsList.TabIndex = 0;
            // 
            // MonsterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 425);
            this.Controls.Add(this.ImageBox);
            this.Controls.Add(this.SkillsBox);
            this.Controls.Add(this.XPBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ImageShow);
            this.Controls.Add(this.StatsBoxes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.AIBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.RowBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OKBtn);
            this.Name = "MonsterForm";
            this.Text = "Monster Editor";
            ((System.ComponentModel.ISupportInitialize)(this.ImageShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XPBox)).EndInit();
            this.SkillsBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox RowBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox AIBox;
        private System.Windows.Forms.Label label5;
        private StatsEditor StatsBoxes;
        private InterpolatedBox ImageShow;
        private System.Windows.Forms.NumericUpDown XPBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox SkillsBox;
        private System.Windows.Forms.ComboBox ImageBox;
        private SkillsEditor SkillsList;
    }
}