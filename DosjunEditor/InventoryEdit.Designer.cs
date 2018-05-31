namespace DosjunEditor
{
    partial class InventoryEdit
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
            this.ItemBox = new System.Windows.Forms.ComboBox();
            this.SlotBox = new System.Windows.Forms.ComboBox();
            this.QtyBox = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.QtyBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ItemBox
            // 
            this.ItemBox.FormattingEnabled = true;
            this.ItemBox.Location = new System.Drawing.Point(0, 0);
            this.ItemBox.Name = "ItemBox";
            this.ItemBox.Size = new System.Drawing.Size(200, 21);
            this.ItemBox.TabIndex = 0;
            this.ItemBox.SelectedIndexChanged += new System.EventHandler(this.ItemBox_SelectedIndexChanged);
            // 
            // SlotBox
            // 
            this.SlotBox.FormattingEnabled = true;
            this.SlotBox.Location = new System.Drawing.Point(261, 0);
            this.SlotBox.Name = "SlotBox";
            this.SlotBox.Size = new System.Drawing.Size(94, 21);
            this.SlotBox.TabIndex = 1;
            // 
            // QtyBox
            // 
            this.QtyBox.Location = new System.Drawing.Point(206, 0);
            this.QtyBox.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.QtyBox.Name = "QtyBox";
            this.QtyBox.Size = new System.Drawing.Size(49, 20);
            this.QtyBox.TabIndex = 2;
            // 
            // InventoryEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.QtyBox);
            this.Controls.Add(this.SlotBox);
            this.Controls.Add(this.ItemBox);
            this.Name = "InventoryEdit";
            this.Size = new System.Drawing.Size(355, 27);
            this.Resize += new System.EventHandler(this.InventoryEdit_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.QtyBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox ItemBox;
        private System.Windows.Forms.ComboBox SlotBox;
        private System.Windows.Forms.NumericUpDown QtyBox;
    }
}
