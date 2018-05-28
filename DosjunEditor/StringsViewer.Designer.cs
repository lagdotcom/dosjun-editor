namespace DosjunEditor
{
    partial class StringsViewer
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
            this.StringList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // StringList
            // 
            this.StringList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.StringList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StringList.Location = new System.Drawing.Point(0, 0);
            this.StringList.Name = "StringList";
            this.StringList.Size = new System.Drawing.Size(800, 450);
            this.StringList.TabIndex = 0;
            this.StringList.UseCompatibleStateImageBehavior = false;
            this.StringList.View = System.Windows.Forms.View.Details;
            this.StringList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.StringList_ColumnClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            this.columnHeader2.Width = 600;
            // 
            // StringsViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.StringList);
            this.Name = "StringsViewer";
            this.Text = "Strings Viewer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView StringList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}