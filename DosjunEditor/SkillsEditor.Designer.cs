namespace DosjunEditor
{
    partial class SkillsEditor
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
            this.View = new System.Windows.Forms.ListView();
            this.columnSkill = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnLearned = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // View
            // 
            this.View.CheckBoxes = true;
            this.View.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnSkill,
            this.columnLearned});
            this.View.Dock = System.Windows.Forms.DockStyle.Fill;
            this.View.Location = new System.Drawing.Point(0, 0);
            this.View.Name = "View";
            this.View.Size = new System.Drawing.Size(150, 150);
            this.View.TabIndex = 0;
            this.View.UseCompatibleStateImageBehavior = false;
            this.View.View = System.Windows.Forms.View.Details;
            this.View.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.View_ColumnClick);
            // 
            // columnSkill
            // 
            this.columnSkill.Text = "Skill";
            this.columnSkill.Width = 76;
            // 
            // columnLearned
            // 
            this.columnLearned.Text = "Learned";
            this.columnLearned.Width = 70;
            // 
            // SkillsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.View);
            this.Name = "SkillsEditor";
            this.Resize += new System.EventHandler(this.SkillsEditor_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView View;
        private System.Windows.Forms.ColumnHeader columnSkill;
        private System.Windows.Forms.ColumnHeader columnLearned;
    }
}
