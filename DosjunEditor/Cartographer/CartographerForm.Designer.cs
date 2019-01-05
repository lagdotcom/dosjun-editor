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
            this.TopPanel = new System.Windows.Forms.Panel();
            this.Tools = new DosjunEditor.Controls.ToolPalette();
            this.Ui = new DosjunEditor.Controls.CartographerUi();
            this.AreaHighlightLabel = new System.Windows.Forms.ToolStripStatusLabel();
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
            // TopPanel
            // 
            this.TopPanel.Controls.Add(this.Tools);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(800, 40);
            this.TopPanel.TabIndex = 2;
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
            // Ui
            // 
            this.Ui.Centre = new System.Drawing.Point(0, 0);
            this.Ui.Context = null;
            this.Ui.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Ui.Location = new System.Drawing.Point(0, 0);
            this.Ui.Name = "Ui";
            this.Ui.Size = new System.Drawing.Size(800, 450);
            this.Ui.TabIndex = 0;
            this.Ui.TileSize = 32;
            this.Ui.Zone = null;
            this.Ui.TileHighlighted += new System.EventHandler(this.Ui_TileHighlighted);
            this.Ui.ToolUsed += new System.EventHandler(this.Ui_ToolUsed);
            // 
            // AreaHighlightLabel
            // 
            this.AreaHighlightLabel.Name = "AreaHighlightLabel";
            this.AreaHighlightLabel.Size = new System.Drawing.Size(12, 17);
            this.AreaHighlightLabel.Text = "-";
            // 
            // CartographerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TopPanel);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.Ui);
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

        private Controls.CartographerUi Ui;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ToolStripStatusLabel CellHighlightLabel;
        private System.Windows.Forms.Panel TopPanel;
        private Controls.ToolPalette Tools;
        private System.Windows.Forms.ToolStripStatusLabel WallHighlightLabel;
        private System.Windows.Forms.ToolStripStatusLabel AreaHighlightLabel;
    }
}