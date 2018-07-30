namespace DosjunEditor
{
    partial class EncounterForm
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
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.MonsterTable = new System.Windows.Forms.TableLayoutPanel();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.MinLevel = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MaxLevel = new System.Windows.Forms.NumericUpDown();
            this.ButtonPanel.SuspendLayout();
            this.TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MinLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Controls.Add(this.button2);
            this.ButtonPanel.Controls.Add(this.button1);
            this.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonPanel.Location = new System.Drawing.Point(0, 277);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(284, 34);
            this.ButtonPanel.TabIndex = 10;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(197, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 103;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(12, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 102;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // MonsterTable
            // 
            this.MonsterTable.ColumnCount = 3;
            this.MonsterTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.MonsterTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.MonsterTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.MonsterTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MonsterTable.Location = new System.Drawing.Point(0, 34);
            this.MonsterTable.Name = "MonsterTable";
            this.MonsterTable.RowCount = 6;
            this.MonsterTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.MonsterTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.MonsterTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.MonsterTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.MonsterTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.MonsterTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.MonsterTable.Size = new System.Drawing.Size(284, 243);
            this.MonsterTable.TabIndex = 11;
            // 
            // TopPanel
            // 
            this.TopPanel.Controls.Add(this.label2);
            this.TopPanel.Controls.Add(this.MaxLevel);
            this.TopPanel.Controls.Add(this.label1);
            this.TopPanel.Controls.Add(this.MinLevel);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(284, 34);
            this.TopPanel.TabIndex = 12;
            // 
            // MinLevel
            // 
            this.MinLevel.Location = new System.Drawing.Point(56, 8);
            this.MinLevel.Name = "MinLevel";
            this.MinLevel.Size = new System.Drawing.Size(60, 20);
            this.MinLevel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Min Lvl";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Max Lvl";
            // 
            // MaxLevel
            // 
            this.MaxLevel.Location = new System.Drawing.Point(212, 8);
            this.MaxLevel.Name = "MaxLevel";
            this.MaxLevel.Size = new System.Drawing.Size(60, 20);
            this.MaxLevel.TabIndex = 2;
            // 
            // EncounterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 311);
            this.Controls.Add(this.MonsterTable);
            this.Controls.Add(this.ButtonPanel);
            this.Controls.Add(this.TopPanel);
            this.Name = "EncounterForm";
            this.Text = "Encounter Editor";
            this.ButtonPanel.ResumeLayout(false);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MinLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxLevel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel ButtonPanel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel MonsterTable;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown MaxLevel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown MinLevel;
    }
}