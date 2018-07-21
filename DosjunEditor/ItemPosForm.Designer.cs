namespace DosjunEditor
{
    partial class ItemPosForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.XBox = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.YBox = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.ItemBox = new System.Windows.Forms.ComboBox();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.OKBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.XBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 111;
            this.label4.Text = "X";
            // 
            // XBox
            // 
            this.XBox.Location = new System.Drawing.Point(176, 39);
            this.XBox.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.XBox.Name = "XBox";
            this.XBox.Size = new System.Drawing.Size(120, 20);
            this.XBox.TabIndex = 110;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 113;
            this.label1.Text = "Y";
            // 
            // YBox
            // 
            this.YBox.Location = new System.Drawing.Point(176, 65);
            this.YBox.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.YBox.Name = "YBox";
            this.YBox.Size = new System.Drawing.Size(120, 20);
            this.YBox.TabIndex = 112;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 115;
            this.label2.Text = "Item";
            // 
            // ItemBox
            // 
            this.ItemBox.FormattingEnabled = true;
            this.ItemBox.Location = new System.Drawing.Point(76, 12);
            this.ItemBox.Name = "ItemBox";
            this.ItemBox.Size = new System.Drawing.Size(220, 21);
            this.ItemBox.TabIndex = 114;
            // 
            // CancelBtn
            // 
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(221, 159);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 117;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // OKBtn
            // 
            this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKBtn.Location = new System.Drawing.Point(16, 159);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(75, 23);
            this.OKBtn.TabIndex = 116;
            this.OKBtn.Text = "OK";
            this.OKBtn.UseVisualStyleBackColor = true;
            // 
            // ItemPosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 193);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OKBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ItemBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.YBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.XBox);
            this.Name = "ItemPosForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Item Position Editor";
            ((System.ComponentModel.ISupportInitialize)(this.XBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown XBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown YBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ItemBox;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button OKBtn;
    }
}