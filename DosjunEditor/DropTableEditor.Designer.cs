namespace DosjunEditor
{
    partial class DropTableEditor
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
            this.CancelBtn = new System.Windows.Forms.Button();
            this.OKBtn = new System.Windows.Forms.Button();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.CountBox = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.DropsPanel = new System.Windows.Forms.Panel();
            this.Drops = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonPanel.SuspendLayout();
            this.TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CountBox)).BeginInit();
            this.DropsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Controls.Add(this.CancelBtn);
            this.ButtonPanel.Controls.Add(this.OKBtn);
            this.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonPanel.Location = new System.Drawing.Point(0, 416);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Padding = new System.Windows.Forms.Padding(5);
            this.ButtonPanel.Size = new System.Drawing.Size(800, 34);
            this.ButtonPanel.TabIndex = 0;
            // 
            // CancelBtn
            // 
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.CancelBtn.Location = new System.Drawing.Point(720, 5);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 24);
            this.CancelBtn.TabIndex = 2;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // OKBtn
            // 
            this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKBtn.Dock = System.Windows.Forms.DockStyle.Left;
            this.OKBtn.Location = new System.Drawing.Point(5, 5);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(75, 24);
            this.OKBtn.TabIndex = 1;
            this.OKBtn.Text = "OK";
            this.OKBtn.UseVisualStyleBackColor = true;
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // TopPanel
            // 
            this.TopPanel.Controls.Add(this.CountBox);
            this.TopPanel.Controls.Add(this.label1);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Padding = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.TopPanel.Size = new System.Drawing.Size(800, 34);
            this.TopPanel.TabIndex = 1;
            // 
            // CountBox
            // 
            this.CountBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.CountBox.Location = new System.Drawing.Point(80, 7);
            this.CountBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CountBox.Name = "CountBox";
            this.CountBox.Size = new System.Drawing.Size(120, 20);
            this.CountBox.TabIndex = 1;
            this.CountBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CountBox.ValueChanged += new System.EventHandler(this.CountBox_ValueChanged);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(5, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Possibilities";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DropsPanel
            // 
            this.DropsPanel.AutoScroll = true;
            this.DropsPanel.Controls.Add(this.Drops);
            this.DropsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DropsPanel.Location = new System.Drawing.Point(0, 34);
            this.DropsPanel.Name = "DropsPanel";
            this.DropsPanel.Size = new System.Drawing.Size(800, 382);
            this.DropsPanel.TabIndex = 2;
            // 
            // Drops
            // 
            this.Drops.AutoSize = true;
            this.Drops.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Drops.ColumnCount = 2;
            this.Drops.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.Drops.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.Drops.Dock = System.Windows.Forms.DockStyle.Top;
            this.Drops.Location = new System.Drawing.Point(0, 0);
            this.Drops.Name = "Drops";
            this.Drops.RowCount = 1;
            this.Drops.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.Drops.Size = new System.Drawing.Size(800, 30);
            this.Drops.TabIndex = 3;
            // 
            // DropTableEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DropsPanel);
            this.Controls.Add(this.TopPanel);
            this.Controls.Add(this.ButtonPanel);
            this.Name = "DropTableEditor";
            this.Text = "Drop Table Editor";
            this.ButtonPanel.ResumeLayout(false);
            this.TopPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CountBox)).EndInit();
            this.DropsPanel.ResumeLayout(false);
            this.DropsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ButtonPanel;
        private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.NumericUpDown CountBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel DropsPanel;
        private System.Windows.Forms.TableLayoutPanel Drops;
    }
}