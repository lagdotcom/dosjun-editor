﻿namespace DosjunEditor
{
    partial class PalettePicker
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
            this.Choice = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.Choice)).BeginInit();
            this.SuspendLayout();
            // 
            // Choice
            // 
            this.Choice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Choice.Location = new System.Drawing.Point(0, 0);
            this.Choice.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Choice.Name = "Choice";
            this.Choice.Size = new System.Drawing.Size(150, 20);
            this.Choice.TabIndex = 0;
            this.Choice.ValueChanged += new System.EventHandler(this.Choice_ValueChanged);
            // 
            // PalettePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Choice);
            this.Name = "PalettePicker";
            this.Size = new System.Drawing.Size(150, 20);
            ((System.ComponentModel.ISupportInitialize)(this.Choice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown Choice;
    }
}
