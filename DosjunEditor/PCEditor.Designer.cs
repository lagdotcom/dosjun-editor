namespace DosjunEditor
{
    partial class PCEditor
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
            this.StatBoxes = new DosjunEditor.StatsEditor();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.OKBtn = new System.Windows.Forms.Button();
            this.JobBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PronounsBox = new System.Windows.Forms.ComboBox();
            this.XPBox = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.PortraitBox = new System.Windows.Forms.ComboBox();
            this.BackRowBox = new System.Windows.Forms.CheckBox();
            this.PartyBox = new System.Windows.Forms.CheckBox();
            this.JobGroup = new System.Windows.Forms.GroupBox();
            this.JobLayout = new System.Windows.Forms.TableLayoutPanel();
            this.InventoryBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.XPBox)).BeginInit();
            this.JobGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatBoxes
            // 
            this.StatBoxes.Location = new System.Drawing.Point(301, 8);
            this.StatBoxes.Name = "StatBoxes";
            this.StatBoxes.Size = new System.Drawing.Size(258, 405);
            this.StatBoxes.Stats = null;
            this.StatBoxes.TabIndex = 0;
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(75, 8);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(220, 20);
            this.NameBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Name";
            // 
            // CancelBtn
            // 
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(220, 390);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 103;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // OKBtn
            // 
            this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKBtn.Location = new System.Drawing.Point(15, 390);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(75, 23);
            this.OKBtn.TabIndex = 102;
            this.OKBtn.Text = "OK";
            this.OKBtn.UseVisualStyleBackColor = true;
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // JobBox
            // 
            this.JobBox.FormattingEnabled = true;
            this.JobBox.Location = new System.Drawing.Point(75, 34);
            this.JobBox.Name = "JobBox";
            this.JobBox.Size = new System.Drawing.Size(220, 21);
            this.JobBox.TabIndex = 104;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 105;
            this.label1.Text = "Job";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 107;
            this.label3.Text = "Pronouns";
            // 
            // PronounsBox
            // 
            this.PronounsBox.FormattingEnabled = true;
            this.PronounsBox.Location = new System.Drawing.Point(75, 61);
            this.PronounsBox.Name = "PronounsBox";
            this.PronounsBox.Size = new System.Drawing.Size(220, 21);
            this.PronounsBox.TabIndex = 106;
            // 
            // XPBox
            // 
            this.XPBox.Location = new System.Drawing.Point(175, 88);
            this.XPBox.Name = "XPBox";
            this.XPBox.Size = new System.Drawing.Size(120, 20);
            this.XPBox.TabIndex = 108;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 109;
            this.label4.Text = "Experience";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 111;
            this.label5.Text = "Portrait";
            // 
            // PortraitBox
            // 
            this.PortraitBox.FormattingEnabled = true;
            this.PortraitBox.Location = new System.Drawing.Point(75, 114);
            this.PortraitBox.Name = "PortraitBox";
            this.PortraitBox.Size = new System.Drawing.Size(220, 21);
            this.PortraitBox.TabIndex = 110;
            // 
            // BackRowBox
            // 
            this.BackRowBox.AutoSize = true;
            this.BackRowBox.Location = new System.Drawing.Point(207, 141);
            this.BackRowBox.Name = "BackRowBox";
            this.BackRowBox.Size = new System.Drawing.Size(88, 17);
            this.BackRowBox.TabIndex = 112;
            this.BackRowBox.Text = "In Back Row";
            this.BackRowBox.UseVisualStyleBackColor = true;
            // 
            // PartyBox
            // 
            this.PartyBox.AutoSize = true;
            this.PartyBox.Location = new System.Drawing.Point(207, 164);
            this.PartyBox.Name = "PartyBox";
            this.PartyBox.Size = new System.Drawing.Size(62, 17);
            this.PartyBox.TabIndex = 113;
            this.PartyBox.Text = "In Party";
            this.PartyBox.UseVisualStyleBackColor = true;
            // 
            // JobGroup
            // 
            this.JobGroup.Controls.Add(this.JobLayout);
            this.JobGroup.Location = new System.Drawing.Point(15, 187);
            this.JobGroup.Name = "JobGroup";
            this.JobGroup.Size = new System.Drawing.Size(280, 175);
            this.JobGroup.TabIndex = 114;
            this.JobGroup.TabStop = false;
            this.JobGroup.Text = "Job Levels";
            // 
            // JobLayout
            // 
            this.JobLayout.ColumnCount = 2;
            this.JobLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.JobLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.JobLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JobLayout.Location = new System.Drawing.Point(3, 16);
            this.JobLayout.Name = "JobLayout";
            this.JobLayout.RowCount = 1;
            this.JobLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.JobLayout.Size = new System.Drawing.Size(274, 156);
            this.JobLayout.TabIndex = 0;
            // 
            // InventoryBox
            // 
            this.InventoryBox.Location = new System.Drawing.Point(565, 8);
            this.InventoryBox.Name = "InventoryBox";
            this.InventoryBox.Size = new System.Drawing.Size(280, 300);
            this.InventoryBox.TabIndex = 115;
            this.InventoryBox.TabStop = false;
            this.InventoryBox.Text = "Inventory";
            // 
            // PCEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 426);
            this.Controls.Add(this.InventoryBox);
            this.Controls.Add(this.JobGroup);
            this.Controls.Add(this.PartyBox);
            this.Controls.Add(this.BackRowBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PortraitBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.XPBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PronounsBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.JobBox);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OKBtn);
            this.Controls.Add(this.NameBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.StatBoxes);
            this.Name = "PCEditor";
            this.Text = "PC Editor";
            ((System.ComponentModel.ISupportInitialize)(this.XPBox)).EndInit();
            this.JobGroup.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private StatsEditor StatBoxes;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.ComboBox JobBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox PronounsBox;
        private System.Windows.Forms.NumericUpDown XPBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox PortraitBox;
        private System.Windows.Forms.CheckBox BackRowBox;
        private System.Windows.Forms.CheckBox PartyBox;
        private System.Windows.Forms.GroupBox JobGroup;
        private System.Windows.Forms.TableLayoutPanel JobLayout;
        private System.Windows.Forms.GroupBox InventoryBox;
    }
}