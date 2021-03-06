﻿namespace DosjunEditor
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
            this.StatsBoxes = new DosjunEditor.StatsEditor();
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
            this.label6 = new System.Windows.Forms.Label();
            this.AttitudeBox = new System.Windows.Forms.NumericUpDown();
            this.SkillsBox = new System.Windows.Forms.GroupBox();
            this.SkillsList = new DosjunEditor.SkillsEditor();
            ((System.ComponentModel.ISupportInitialize)(this.XPBox)).BeginInit();
            this.JobGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AttitudeBox)).BeginInit();
            this.SkillsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatsBoxes
            // 
            this.StatsBoxes.Location = new System.Drawing.Point(301, 8);
            this.StatsBoxes.Name = "StatsBoxes";
            this.StatsBoxes.Size = new System.Drawing.Size(258, 405);
            this.StatsBoxes.Stats = null;
            this.StatsBoxes.TabIndex = 0;
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
            this.CancelBtn.Location = new System.Drawing.Point(217, 526);
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
            this.OKBtn.Location = new System.Drawing.Point(12, 526);
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
            this.BackRowBox.Location = new System.Drawing.Point(15, 167);
            this.BackRowBox.Name = "BackRowBox";
            this.BackRowBox.Size = new System.Drawing.Size(88, 17);
            this.BackRowBox.TabIndex = 112;
            this.BackRowBox.Text = "In Back Row";
            this.BackRowBox.UseVisualStyleBackColor = true;
            // 
            // PartyBox
            // 
            this.PartyBox.AutoSize = true;
            this.PartyBox.Location = new System.Drawing.Point(233, 167);
            this.PartyBox.Name = "PartyBox";
            this.PartyBox.Size = new System.Drawing.Size(62, 17);
            this.PartyBox.TabIndex = 113;
            this.PartyBox.Text = "In Party";
            this.PartyBox.UseVisualStyleBackColor = true;
            // 
            // JobGroup
            // 
            this.JobGroup.Controls.Add(this.JobLayout);
            this.JobGroup.Location = new System.Drawing.Point(15, 238);
            this.JobGroup.Name = "JobGroup";
            this.JobGroup.Size = new System.Drawing.Size(280, 282);
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
            this.JobLayout.Size = new System.Drawing.Size(274, 263);
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 117;
            this.label6.Text = "Attitude";
            // 
            // AttitudeBox
            // 
            this.AttitudeBox.Location = new System.Drawing.Point(175, 141);
            this.AttitudeBox.Name = "AttitudeBox";
            this.AttitudeBox.Size = new System.Drawing.Size(120, 20);
            this.AttitudeBox.TabIndex = 116;
            // 
            // SkillsBox
            // 
            this.SkillsBox.Controls.Add(this.SkillsList);
            this.SkillsBox.Location = new System.Drawing.Point(851, 8);
            this.SkillsBox.Name = "SkillsBox";
            this.SkillsBox.Size = new System.Drawing.Size(200, 405);
            this.SkillsBox.TabIndex = 118;
            this.SkillsBox.TabStop = false;
            this.SkillsBox.Text = "Skills";
            // 
            // SkillsList
            // 
            this.SkillsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SkillsList.Location = new System.Drawing.Point(3, 16);
            this.SkillsList.Name = "SkillsList";
            this.SkillsList.Size = new System.Drawing.Size(194, 386);
            this.SkillsList.TabIndex = 0;
            // 
            // PCEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 561);
            this.Controls.Add(this.SkillsBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.AttitudeBox);
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
            this.Controls.Add(this.StatsBoxes);
            this.Name = "PCEditor";
            this.Text = "PC Editor";
            ((System.ComponentModel.ISupportInitialize)(this.XPBox)).EndInit();
            this.JobGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AttitudeBox)).EndInit();
            this.SkillsBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private StatsEditor StatsBoxes;
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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown AttitudeBox;
        private System.Windows.Forms.GroupBox SkillsBox;
        private SkillsEditor SkillsList;
    }
}