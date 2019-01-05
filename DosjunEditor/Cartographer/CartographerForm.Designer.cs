namespace DosjunEditor.Cartographer
{
    partial class CartographerForm
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
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.CellHighlightLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.WallHighlightLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.AreaHighlightLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.ZoomIn = new System.Windows.Forms.Button();
            this.ZoomOut = new System.Windows.Forms.Button();
            this.Ui = new DosjunEditor.Controls.CartographerUi();
            this.Tools = new DosjunEditor.Controls.ToolPalette();
            this.StatusBar.SuspendLayout();
            this.TopPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusBar
            // 
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CellHighlightLabel,
            this.WallHighlightLabel,
            this.AreaHighlightLabel});
            this.StatusBar.Location = new System.Drawing.Point(0, 428);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(800, 22);
            this.StatusBar.TabIndex = 1;
            this.StatusBar.Text = "statusStrip1";
            // 
            // CellHighlightLabel
            // 
            this.CellHighlightLabel.Name = "CellHighlightLabel";
            this.CellHighlightLabel.Size = new System.Drawing.Size(12, 17);
            this.CellHighlightLabel.Text = "-";
            // 
            // WallHighlightLabel
            // 
            this.WallHighlightLabel.Name = "WallHighlightLabel";
            this.WallHighlightLabel.Size = new System.Drawing.Size(12, 17);
            this.WallHighlightLabel.Text = "-";
            // 
            // AreaHighlightLabel
            // 
            this.AreaHighlightLabel.Name = "AreaHighlightLabel";
            this.AreaHighlightLabel.Size = new System.Drawing.Size(12, 17);
            this.AreaHighlightLabel.Text = "-";
            // 
            // TopPanel
            // 
            this.TopPanel.Controls.Add(this.Tools);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(800, 40);
            this.TopPanel.TabIndex = 2;
            // 
            // ZoomIn
            // 
            this.ZoomIn.Location = new System.Drawing.Point(12, 46);
            this.ZoomIn.Name = "ZoomIn";
            this.ZoomIn.Size = new System.Drawing.Size(23, 23);
            this.ZoomIn.TabIndex = 4;
            this.ZoomIn.TabStop = false;
            this.ZoomIn.Text = "+";
            this.ZoomIn.UseVisualStyleBackColor = true;
            this.ZoomIn.Click += new System.EventHandler(this.ZoomIn_Click);
            // 
            // ZoomOut
            // 
            this.ZoomOut.Location = new System.Drawing.Point(12, 75);
            this.ZoomOut.Name = "ZoomOut";
            this.ZoomOut.Size = new System.Drawing.Size(23, 23);
            this.ZoomOut.TabIndex = 5;
            this.ZoomOut.TabStop = false;
            this.ZoomOut.Text = "-";
            this.ZoomOut.UseVisualStyleBackColor = true;
            this.ZoomOut.Click += new System.EventHandler(this.ZoomOut_Click);
            // 
            // Ui
            // 
            this.Ui.Centre = new System.Drawing.Point(0, 0);
            this.Ui.Context = null;
            this.Ui.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Ui.Location = new System.Drawing.Point(0, 40);
            this.Ui.Name = "Ui";
            this.Ui.Size = new System.Drawing.Size(800, 388);
            this.Ui.TabIndex = 3;
            this.Ui.TileSize = 32;
            this.Ui.Zone = null;
            this.Ui.TileHighlighted += new System.EventHandler(this.Ui_TileHighlighted);
            this.Ui.ToolUsed += new System.EventHandler(this.Ui_ToolUsed);
            // 
            // Tools
            // 
            this.Tools.Current = null;
            this.Tools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tools.Location = new System.Drawing.Point(0, 0);
            this.Tools.Name = "Tools";
            this.Tools.Size = new System.Drawing.Size(800, 40);
            this.Tools.TabIndex = 0;
            this.Tools.ToolChanged += new System.EventHandler(this.Tools_ToolChanged);
            // 
            // CartographerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ZoomOut);
            this.Controls.Add(this.ZoomIn);
            this.Controls.Add(this.Ui);
            this.Controls.Add(this.TopPanel);
            this.Controls.Add(this.StatusBar);
            this.Name = "CartographerForm";
            this.Text = "Cartographer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CartographerForm_FormClosing);
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.TopPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ToolStripStatusLabel CellHighlightLabel;
        private System.Windows.Forms.Panel TopPanel;
        private Controls.ToolPalette Tools;
        private System.Windows.Forms.ToolStripStatusLabel WallHighlightLabel;
        private System.Windows.Forms.ToolStripStatusLabel AreaHighlightLabel;
        private Controls.CartographerUi Ui;
        private System.Windows.Forms.Button ZoomIn;
        private System.Windows.Forms.Button ZoomOut;
    }
}