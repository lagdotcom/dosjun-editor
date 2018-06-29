namespace DosjunEditor
{
    partial class ItemForm
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
            this.StatsBoxes = new DosjunEditor.StatsEditor();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.OKBtn = new System.Windows.Forms.Button();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TypeBox = new System.Windows.Forms.ComboBox();
            this.FlagsBox = new System.Windows.Forms.GroupBox();
            this.DexterityFlag = new System.Windows.Forms.CheckBox();
            this.LongFlag = new System.Windows.Forms.CheckBox();
            this.MediumFlag = new System.Windows.Forms.CheckBox();
            this.StackedFlag = new System.Windows.Forms.CheckBox();
            this.HeavyFlag = new System.Windows.Forms.CheckBox();
            this.LightFlag = new System.Windows.Forms.CheckBox();
            this.ValueBox = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.SpecialBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SArg1Label = new System.Windows.Forms.Label();
            this.SArg1Box = new System.Windows.Forms.NumericUpDown();
            this.SArg2Box = new System.Windows.Forms.NumericUpDown();
            this.SArg2Label = new System.Windows.Forms.Label();
            this.ImageBox = new System.Windows.Forms.ComboBox();
            this.ImageShow = new DosjunEditor.InterpolatedBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FlagsBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ValueBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SArg1Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SArg2Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageShow)).BeginInit();
            this.SuspendLayout();
            // 
            // StatsBoxes
            // 
            this.StatsBoxes.Location = new System.Drawing.Point(257, 3);
            this.StatsBoxes.Name = "StatsBoxes";
            this.StatsBoxes.Size = new System.Drawing.Size(258, 403);
            this.StatsBoxes.Stats = null;
            this.StatsBoxes.TabIndex = 8;
            // 
            // CancelBtn
            // 
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(176, 383);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 101;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // OKBtn
            // 
            this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKBtn.Location = new System.Drawing.Point(15, 383);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(75, 23);
            this.OKBtn.TabIndex = 100;
            this.OKBtn.Text = "OK";
            this.OKBtn.UseVisualStyleBackColor = true;
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(75, 19);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(155, 20);
            this.NameBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Type";
            // 
            // TypeBox
            // 
            this.TypeBox.FormattingEnabled = true;
            this.TypeBox.Location = new System.Drawing.Point(75, 45);
            this.TypeBox.Name = "TypeBox";
            this.TypeBox.Size = new System.Drawing.Size(156, 21);
            this.TypeBox.TabIndex = 3;
            // 
            // FlagsBox
            // 
            this.FlagsBox.Controls.Add(this.DexterityFlag);
            this.FlagsBox.Controls.Add(this.LongFlag);
            this.FlagsBox.Controls.Add(this.MediumFlag);
            this.FlagsBox.Controls.Add(this.StackedFlag);
            this.FlagsBox.Controls.Add(this.HeavyFlag);
            this.FlagsBox.Controls.Add(this.LightFlag);
            this.FlagsBox.Location = new System.Drawing.Point(521, 3);
            this.FlagsBox.Name = "FlagsBox";
            this.FlagsBox.Size = new System.Drawing.Size(258, 259);
            this.FlagsBox.TabIndex = 23;
            this.FlagsBox.TabStop = false;
            this.FlagsBox.Text = "Flags";
            // 
            // DexterityFlag
            // 
            this.DexterityFlag.AutoSize = true;
            this.DexterityFlag.Location = new System.Drawing.Point(6, 134);
            this.DexterityFlag.Name = "DexterityFlag";
            this.DexterityFlag.Size = new System.Drawing.Size(143, 17);
            this.DexterityFlag.TabIndex = 14;
            this.DexterityFlag.Text = "Dexterity-based Weapon";
            this.DexterityFlag.UseVisualStyleBackColor = true;
            // 
            // LongFlag
            // 
            this.LongFlag.AutoSize = true;
            this.LongFlag.Location = new System.Drawing.Point(6, 111);
            this.LongFlag.Name = "LongFlag";
            this.LongFlag.Size = new System.Drawing.Size(85, 17);
            this.LongFlag.TabIndex = 13;
            this.LongFlag.Text = "Long Range";
            this.LongFlag.UseVisualStyleBackColor = true;
            // 
            // MediumFlag
            // 
            this.MediumFlag.AutoSize = true;
            this.MediumFlag.Location = new System.Drawing.Point(6, 88);
            this.MediumFlag.Name = "MediumFlag";
            this.MediumFlag.Size = new System.Drawing.Size(98, 17);
            this.MediumFlag.TabIndex = 12;
            this.MediumFlag.Text = "Medium Range";
            this.MediumFlag.UseVisualStyleBackColor = true;
            // 
            // StackedFlag
            // 
            this.StackedFlag.AutoSize = true;
            this.StackedFlag.Location = new System.Drawing.Point(6, 65);
            this.StackedFlag.Name = "StackedFlag";
            this.StackedFlag.Size = new System.Drawing.Size(66, 17);
            this.StackedFlag.TabIndex = 11;
            this.StackedFlag.Text = "Stacked";
            this.StackedFlag.UseVisualStyleBackColor = true;
            // 
            // HeavyFlag
            // 
            this.HeavyFlag.AutoSize = true;
            this.HeavyFlag.Location = new System.Drawing.Point(6, 42);
            this.HeavyFlag.Name = "HeavyFlag";
            this.HeavyFlag.Size = new System.Drawing.Size(88, 17);
            this.HeavyFlag.TabIndex = 10;
            this.HeavyFlag.Text = "Heavyweight";
            this.HeavyFlag.UseVisualStyleBackColor = true;
            // 
            // LightFlag
            // 
            this.LightFlag.AutoSize = true;
            this.LightFlag.Location = new System.Drawing.Point(6, 19);
            this.LightFlag.Name = "LightFlag";
            this.LightFlag.Size = new System.Drawing.Size(80, 17);
            this.LightFlag.TabIndex = 9;
            this.LightFlag.Text = "Lightweight";
            this.LightFlag.UseVisualStyleBackColor = true;
            // 
            // ValueBox
            // 
            this.ValueBox.Location = new System.Drawing.Point(75, 72);
            this.ValueBox.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.ValueBox.Name = "ValueBox";
            this.ValueBox.Size = new System.Drawing.Size(155, 20);
            this.ValueBox.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Value";
            // 
            // SpecialBox
            // 
            this.SpecialBox.FormattingEnabled = true;
            this.SpecialBox.Location = new System.Drawing.Point(75, 96);
            this.SpecialBox.Name = "SpecialBox";
            this.SpecialBox.Size = new System.Drawing.Size(156, 21);
            this.SpecialBox.TabIndex = 5;
            this.SpecialBox.SelectedIndexChanged += new System.EventHandler(this.SpecialBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Special";
            // 
            // SArg1Label
            // 
            this.SArg1Label.AutoSize = true;
            this.SArg1Label.Location = new System.Drawing.Point(72, 125);
            this.SArg1Label.Name = "SArg1Label";
            this.SArg1Label.Size = new System.Drawing.Size(29, 13);
            this.SArg1Label.TabIndex = 28;
            this.SArg1Label.Text = "Arg1";
            // 
            // SArg1Box
            // 
            this.SArg1Box.Location = new System.Drawing.Point(120, 123);
            this.SArg1Box.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.SArg1Box.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147483648});
            this.SArg1Box.Name = "SArg1Box";
            this.SArg1Box.Size = new System.Drawing.Size(110, 20);
            this.SArg1Box.TabIndex = 6;
            // 
            // SArg2Box
            // 
            this.SArg2Box.Location = new System.Drawing.Point(120, 149);
            this.SArg2Box.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.SArg2Box.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147483648});
            this.SArg2Box.Name = "SArg2Box";
            this.SArg2Box.Size = new System.Drawing.Size(110, 20);
            this.SArg2Box.TabIndex = 7;
            // 
            // SArg2Label
            // 
            this.SArg2Label.AutoSize = true;
            this.SArg2Label.Location = new System.Drawing.Point(72, 151);
            this.SArg2Label.Name = "SArg2Label";
            this.SArg2Label.Size = new System.Drawing.Size(29, 13);
            this.SArg2Label.TabIndex = 30;
            this.SArg2Label.Text = "Arg2";
            // 
            // ImageBox
            // 
            this.ImageBox.FormattingEnabled = true;
            this.ImageBox.Location = new System.Drawing.Point(75, 175);
            this.ImageBox.Name = "ImageBox";
            this.ImageBox.Size = new System.Drawing.Size(156, 21);
            this.ImageBox.TabIndex = 109;
            this.ImageBox.SelectedIndexChanged += new System.EventHandler(this.ImageBox_SelectedIndexChanged);
            // 
            // ImageShow
            // 
            this.ImageShow.Interpolation = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            this.ImageShow.Location = new System.Drawing.Point(103, 202);
            this.ImageShow.Name = "ImageShow";
            this.ImageShow.Size = new System.Drawing.Size(128, 128);
            this.ImageShow.TabIndex = 108;
            this.ImageShow.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 107;
            this.label1.Text = "Image";
            // 
            // ItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 411);
            this.Controls.Add(this.ImageBox);
            this.Controls.Add(this.ImageShow);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SArg2Box);
            this.Controls.Add(this.SArg2Label);
            this.Controls.Add(this.SArg1Box);
            this.Controls.Add(this.SArg1Label);
            this.Controls.Add(this.SpecialBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ValueBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.FlagsBox);
            this.Controls.Add(this.TypeBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.StatsBoxes);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OKBtn);
            this.Name = "ItemForm";
            this.Text = "Item Editor";
            this.FlagsBox.ResumeLayout(false);
            this.FlagsBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ValueBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SArg1Box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SArg2Box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private StatsEditor StatsBoxes;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox TypeBox;
        private System.Windows.Forms.GroupBox FlagsBox;
        private System.Windows.Forms.CheckBox DexterityFlag;
        private System.Windows.Forms.CheckBox LongFlag;
        private System.Windows.Forms.CheckBox MediumFlag;
        private System.Windows.Forms.CheckBox StackedFlag;
        private System.Windows.Forms.CheckBox HeavyFlag;
        private System.Windows.Forms.CheckBox LightFlag;
        private System.Windows.Forms.NumericUpDown ValueBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox SpecialBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label SArg1Label;
        private System.Windows.Forms.NumericUpDown SArg1Box;
        private System.Windows.Forms.NumericUpDown SArg2Box;
        private System.Windows.Forms.Label SArg2Label;
        private System.Windows.Forms.ComboBox ImageBox;
        private InterpolatedBox ImageShow;
        private System.Windows.Forms.Label label1;
    }
}