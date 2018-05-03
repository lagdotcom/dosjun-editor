namespace DosjunEditor
{
    partial class SourceEditor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SourceEditor));
            this.ButtonsPanel = new System.Windows.Forms.Panel();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CodeSource = new FastColoredTextBoxNS.FastColoredTextBox();
            this.Compile = new System.Windows.Forms.Button();
            this.ButtonsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CodeSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonsPanel
            // 
            this.ButtonsPanel.Controls.Add(this.Compile);
            this.ButtonsPanel.Controls.Add(this.SaveButton);
            this.ButtonsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonsPanel.Location = new System.Drawing.Point(0, 0);
            this.ButtonsPanel.Name = "ButtonsPanel";
            this.ButtonsPanel.Size = new System.Drawing.Size(800, 48);
            this.ButtonsPanel.TabIndex = 0;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(713, 12);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 0;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CodeSource
            // 
            this.CodeSource.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.CodeSource.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.CodeSource.BackBrush = null;
            this.CodeSource.CharHeight = 14;
            this.CodeSource.CharWidth = 8;
            this.CodeSource.CommentPrefix = "#";
            this.CodeSource.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.CodeSource.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.CodeSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CodeSource.IsReplaceMode = false;
            this.CodeSource.Location = new System.Drawing.Point(0, 48);
            this.CodeSource.Name = "CodeSource";
            this.CodeSource.Paddings = new System.Windows.Forms.Padding(0);
            this.CodeSource.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.CodeSource.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("CodeSource.ServiceColors")));
            this.CodeSource.Size = new System.Drawing.Size(800, 402);
            this.CodeSource.TabIndex = 0;
            this.CodeSource.Zoom = 100;
            this.CodeSource.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.CodeSource_TextChanged);
            // 
            // Compile
            // 
            this.Compile.Location = new System.Drawing.Point(12, 12);
            this.Compile.Name = "Compile";
            this.Compile.Size = new System.Drawing.Size(75, 23);
            this.Compile.TabIndex = 1;
            this.Compile.Text = "Compile";
            this.Compile.UseVisualStyleBackColor = true;
            this.Compile.Click += new System.EventHandler(this.Compile_Click);
            // 
            // SourceEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CodeSource);
            this.Controls.Add(this.ButtonsPanel);
            this.Name = "SourceEditor";
            this.Text = "Source Editor";
            this.ButtonsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CodeSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ButtonsPanel;
        private System.Windows.Forms.Button SaveButton;
        private FastColoredTextBoxNS.FastColoredTextBox CodeSource;
        private System.Windows.Forms.Button Compile;
    }
}