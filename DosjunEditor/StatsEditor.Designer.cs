namespace DosjunEditor
{
    partial class StatsEditor
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
            this.Outside = new System.Windows.Forms.GroupBox();
            this.TableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDown9 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown10 = new System.Windows.Forms.NumericUpDown();
            this.Outside.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown10)).BeginInit();
            this.SuspendLayout();
            // 
            // Outside
            // 
            this.Outside.Controls.Add(this.TableLayout);
            this.Outside.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Outside.Location = new System.Drawing.Point(0, 0);
            this.Outside.Name = "Outside";
            this.Outside.Size = new System.Drawing.Size(258, 400);
            this.Outside.TabIndex = 0;
            this.Outside.TabStop = false;
            this.Outside.Text = "Stats";
            // 
            // TableLayout
            // 
            this.TableLayout.ColumnCount = 2;
            this.TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayout.Location = new System.Drawing.Point(3, 16);
            this.TableLayout.Name = "TableLayout";
            this.TableLayout.RowCount = 16;
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.TableLayout.Size = new System.Drawing.Size(252, 381);
            this.TableLayout.TabIndex = 9;
            // 
            // numericUpDown9
            // 
            this.numericUpDown9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown9.Location = new System.Drawing.Point(3, 323);
            this.numericUpDown9.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.numericUpDown9.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147483648});
            this.numericUpDown9.Name = "numericUpDown9";
            this.numericUpDown9.Size = new System.Drawing.Size(94, 20);
            this.numericUpDown9.TabIndex = 30;
            // 
            // numericUpDown10
            // 
            this.numericUpDown10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown10.Location = new System.Drawing.Point(103, 303);
            this.numericUpDown10.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.numericUpDown10.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147483648});
            this.numericUpDown10.Name = "numericUpDown10";
            this.numericUpDown10.Size = new System.Drawing.Size(146, 20);
            this.numericUpDown10.TabIndex = 31;
            // 
            // StatsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Outside);
            this.Name = "StatsEditor";
            this.Size = new System.Drawing.Size(258, 400);
            this.Outside.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown10)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Outside;
        private System.Windows.Forms.NumericUpDown numericUpDown10;
        private System.Windows.Forms.NumericUpDown numericUpDown9;
        private System.Windows.Forms.TableLayoutPanel TableLayout;
    }
}
