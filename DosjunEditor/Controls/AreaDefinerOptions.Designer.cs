namespace DosjunEditor.Controls
{
    partial class AreaDefinerOptions
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AddArea = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.AreaList = new System.Windows.Forms.ComboBox();
            this.RenameButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddArea
            // 
            this.AddArea.Location = new System.Drawing.Point(3, 3);
            this.AddArea.Name = "AddArea";
            this.AddArea.Size = new System.Drawing.Size(75, 23);
            this.AddArea.TabIndex = 0;
            this.AddArea.Text = "Add...";
            this.AddArea.UseVisualStyleBackColor = true;
            this.AddArea.Click += new System.EventHandler(this.AddArea_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Enabled = false;
            this.DeleteButton.Location = new System.Drawing.Point(3, 59);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton.TabIndex = 1;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // AreaList
            // 
            this.AreaList.FormattingEnabled = true;
            this.AreaList.Location = new System.Drawing.Point(3, 32);
            this.AreaList.Name = "AreaList";
            this.AreaList.Size = new System.Drawing.Size(194, 21);
            this.AreaList.TabIndex = 2;
            this.AreaList.SelectedIndexChanged += new System.EventHandler(this.AreaList_SelectedIndexChanged);
            // 
            // RenameButton
            // 
            this.RenameButton.Enabled = false;
            this.RenameButton.Location = new System.Drawing.Point(3, 88);
            this.RenameButton.Name = "RenameButton";
            this.RenameButton.Size = new System.Drawing.Size(75, 23);
            this.RenameButton.TabIndex = 3;
            this.RenameButton.Text = "Rename...";
            this.RenameButton.UseVisualStyleBackColor = true;
            this.RenameButton.Click += new System.EventHandler(this.RenameButton_Click);
            // 
            // AreaDefinerOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RenameButton);
            this.Controls.Add(this.AreaList);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.AddArea);
            this.Name = "AreaDefinerOptions";
            this.Size = new System.Drawing.Size(200, 400);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddArea;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.ComboBox AreaList;
        private System.Windows.Forms.Button RenameButton;
    }
}
