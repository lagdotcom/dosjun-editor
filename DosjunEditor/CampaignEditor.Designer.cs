namespace DosjunEditor
{
    partial class CampaignEditor
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
            this.NumGlobals = new System.Windows.Forms.NumericUpDown();
            this.OKBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.NumFlags = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.StartScript = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CampaignName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CampaignDesc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.FontBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.MenuBg = new System.Windows.Forms.ComboBox();
            this.DungeonBg = new System.Windows.Forms.ComboBox();
            this.CombatBg = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.MenuMusic = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.NumGlobals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumFlags)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of Script Globals";
            // 
            // NumGlobals
            // 
            this.NumGlobals.Location = new System.Drawing.Point(154, 12);
            this.NumGlobals.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumGlobals.Name = "NumGlobals";
            this.NumGlobals.Size = new System.Drawing.Size(75, 20);
            this.NumGlobals.TabIndex = 1;
            // 
            // OKBtn
            // 
            this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKBtn.Location = new System.Drawing.Point(15, 496);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(75, 23);
            this.OKBtn.TabIndex = 6;
            this.OKBtn.Text = "OK";
            this.OKBtn.UseVisualStyleBackColor = true;
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(342, 496);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 7;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // NumFlags
            // 
            this.NumFlags.Location = new System.Drawing.Point(154, 38);
            this.NumFlags.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumFlags.Name = "NumFlags";
            this.NumFlags.Size = new System.Drawing.Size(75, 20);
            this.NumFlags.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Number of Script Flags";
            // 
            // StartScript
            // 
            this.StartScript.FormattingEnabled = true;
            this.StartScript.Location = new System.Drawing.Point(154, 64);
            this.StartScript.Name = "StartScript";
            this.StartScript.Size = new System.Drawing.Size(263, 21);
            this.StartScript.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Starting Script";
            // 
            // CampaignName
            // 
            this.CampaignName.Location = new System.Drawing.Point(154, 91);
            this.CampaignName.Name = "CampaignName";
            this.CampaignName.Size = new System.Drawing.Size(263, 20);
            this.CampaignName.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Name";
            // 
            // CampaignDesc
            // 
            this.CampaignDesc.Location = new System.Drawing.Point(154, 117);
            this.CampaignDesc.Multiline = true;
            this.CampaignDesc.Name = "CampaignDesc";
            this.CampaignDesc.Size = new System.Drawing.Size(263, 81);
            this.CampaignDesc.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Description";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 207);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Main Font";
            // 
            // FontBox
            // 
            this.FontBox.FormattingEnabled = true;
            this.FontBox.Location = new System.Drawing.Point(154, 204);
            this.FontBox.Name = "FontBox";
            this.FontBox.Size = new System.Drawing.Size(263, 21);
            this.FontBox.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 234);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Main Menu Background";
            // 
            // MenuBg
            // 
            this.MenuBg.FormattingEnabled = true;
            this.MenuBg.Location = new System.Drawing.Point(154, 231);
            this.MenuBg.Name = "MenuBg";
            this.MenuBg.Size = new System.Drawing.Size(263, 21);
            this.MenuBg.TabIndex = 14;
            // 
            // DungeonBg
            // 
            this.DungeonBg.FormattingEnabled = true;
            this.DungeonBg.Location = new System.Drawing.Point(154, 258);
            this.DungeonBg.Name = "DungeonBg";
            this.DungeonBg.Size = new System.Drawing.Size(263, 21);
            this.DungeonBg.TabIndex = 16;
            // 
            // CombatBg
            // 
            this.CombatBg.FormattingEnabled = true;
            this.CombatBg.Location = new System.Drawing.Point(154, 285);
            this.CombatBg.Name = "CombatBg";
            this.CombatBg.Size = new System.Drawing.Size(263, 21);
            this.CombatBg.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 261);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Dungeon Background";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 288);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Combat Background";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 315);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Main Menu Music";
            // 
            // MenuMusic
            // 
            this.MenuMusic.FormattingEnabled = true;
            this.MenuMusic.Location = new System.Drawing.Point(154, 312);
            this.MenuMusic.Name = "MenuMusic";
            this.MenuMusic.Size = new System.Drawing.Size(263, 21);
            this.MenuMusic.TabIndex = 20;
            // 
            // CampaignEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(432, 531);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.MenuMusic);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CombatBg);
            this.Controls.Add(this.DungeonBg);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.MenuBg);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.FontBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CampaignDesc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CampaignName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.StartScript);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NumFlags);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OKBtn);
            this.Controls.Add(this.NumGlobals);
            this.Controls.Add(this.label1);
            this.Name = "CampaignEditor";
            this.Text = "Campaign Editor";
            ((System.ComponentModel.ISupportInitialize)(this.NumGlobals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumFlags)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NumGlobals;
        private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.NumericUpDown NumFlags;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox StartScript;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox CampaignName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox CampaignDesc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox FontBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox MenuBg;
        private System.Windows.Forms.ComboBox DungeonBg;
        private System.Windows.Forms.ComboBox CombatBg;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox MenuMusic;
    }
}