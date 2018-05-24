namespace DosjunEditor
{
    partial class MainForm
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
            this.TopMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.ButtonsPanel = new System.Windows.Forms.Panel();
            this.DumpBtn = new System.Windows.Forms.Button();
            this.ImportBtn = new System.Windows.Forms.Button();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.RenameBtn = new System.Windows.Forms.Button();
            this.NewBtn = new System.Windows.Forms.Button();
            this.Resources = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NewContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NewItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewMonster = new System.Windows.Forms.ToolStripMenuItem();
            this.NewSource = new System.Windows.Forms.ToolStripMenuItem();
            this.NewZone = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportDialog = new System.Windows.Forms.OpenFileDialog();
            this.DumpDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TopMenu.SuspendLayout();
            this.ButtonsPanel.SuspendLayout();
            this.NewContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopMenu
            // 
            this.TopMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.TopMenu.Location = new System.Drawing.Point(0, 0);
            this.TopMenu.Name = "TopMenu";
            this.TopMenu.Size = new System.Drawing.Size(947, 24);
            this.TopMenu.TabIndex = 0;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuNew,
            this.MenuOpen,
            this.MenuSave,
            this.MenuExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // MenuNew
            // 
            this.MenuNew.Name = "MenuNew";
            this.MenuNew.Size = new System.Drawing.Size(112, 22);
            this.MenuNew.Text = "&New...";
            this.MenuNew.Click += new System.EventHandler(this.MenuNew_Click);
            // 
            // MenuOpen
            // 
            this.MenuOpen.Name = "MenuOpen";
            this.MenuOpen.Size = new System.Drawing.Size(112, 22);
            this.MenuOpen.Text = "&Open...";
            this.MenuOpen.Click += new System.EventHandler(this.MenuOpen_Click);
            // 
            // MenuSave
            // 
            this.MenuSave.Enabled = false;
            this.MenuSave.Name = "MenuSave";
            this.MenuSave.Size = new System.Drawing.Size(112, 22);
            this.MenuSave.Text = "&Save";
            this.MenuSave.Click += new System.EventHandler(this.MenuSave_Click);
            // 
            // MenuExit
            // 
            this.MenuExit.Name = "MenuExit";
            this.MenuExit.Size = new System.Drawing.Size(112, 22);
            this.MenuExit.Text = "E&xit";
            this.MenuExit.Click += new System.EventHandler(this.MenuExit_Click);
            // 
            // OpenDialog
            // 
            this.OpenDialog.Filter = "DOSJUN Files|*.DJN";
            // 
            // SaveDialog
            // 
            this.SaveDialog.Filter = "DOSJUN Files|*.DJN";
            // 
            // ButtonsPanel
            // 
            this.ButtonsPanel.Controls.Add(this.DumpBtn);
            this.ButtonsPanel.Controls.Add(this.ImportBtn);
            this.ButtonsPanel.Controls.Add(this.DeleteBtn);
            this.ButtonsPanel.Controls.Add(this.RenameBtn);
            this.ButtonsPanel.Controls.Add(this.NewBtn);
            this.ButtonsPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ButtonsPanel.Location = new System.Drawing.Point(0, 24);
            this.ButtonsPanel.Name = "ButtonsPanel";
            this.ButtonsPanel.Size = new System.Drawing.Size(200, 530);
            this.ButtonsPanel.TabIndex = 1;
            // 
            // DumpBtn
            // 
            this.DumpBtn.Enabled = false;
            this.DumpBtn.Location = new System.Drawing.Point(12, 119);
            this.DumpBtn.Name = "DumpBtn";
            this.DumpBtn.Size = new System.Drawing.Size(182, 23);
            this.DumpBtn.TabIndex = 4;
            this.DumpBtn.Text = "Dump Resources...";
            this.DumpBtn.UseVisualStyleBackColor = true;
            this.DumpBtn.Click += new System.EventHandler(this.DumpBtn_Click);
            // 
            // ImportBtn
            // 
            this.ImportBtn.Enabled = false;
            this.ImportBtn.Location = new System.Drawing.Point(12, 90);
            this.ImportBtn.Name = "ImportBtn";
            this.ImportBtn.Size = new System.Drawing.Size(182, 23);
            this.ImportBtn.TabIndex = 3;
            this.ImportBtn.Text = "Import Resource...";
            this.ImportBtn.UseVisualStyleBackColor = true;
            this.ImportBtn.Click += new System.EventHandler(this.ImportBtn_Click);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Enabled = false;
            this.DeleteBtn.Location = new System.Drawing.Point(12, 61);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(182, 23);
            this.DeleteBtn.TabIndex = 2;
            this.DeleteBtn.Text = "Delete Resource...";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // RenameBtn
            // 
            this.RenameBtn.Enabled = false;
            this.RenameBtn.Location = new System.Drawing.Point(12, 32);
            this.RenameBtn.Name = "RenameBtn";
            this.RenameBtn.Size = new System.Drawing.Size(182, 23);
            this.RenameBtn.TabIndex = 1;
            this.RenameBtn.Text = "Rename Resource...";
            this.RenameBtn.UseVisualStyleBackColor = true;
            this.RenameBtn.Click += new System.EventHandler(this.RenameBtn_Click);
            // 
            // NewBtn
            // 
            this.NewBtn.Enabled = false;
            this.NewBtn.Location = new System.Drawing.Point(12, 3);
            this.NewBtn.Name = "NewBtn";
            this.NewBtn.Size = new System.Drawing.Size(182, 23);
            this.NewBtn.TabIndex = 0;
            this.NewBtn.Text = "New Resource...";
            this.NewBtn.UseVisualStyleBackColor = true;
            this.NewBtn.Click += new System.EventHandler(this.NewBtn_Click);
            // 
            // Resources
            // 
            this.Resources.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.Resources.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Resources.Location = new System.Drawing.Point(200, 24);
            this.Resources.Name = "Resources";
            this.Resources.Size = new System.Drawing.Size(747, 530);
            this.Resources.TabIndex = 2;
            this.Resources.UseCompatibleStateImageBehavior = false;
            this.Resources.View = System.Windows.Forms.View.Details;
            this.Resources.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.Resources_ColumnClick);
            this.Resources.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.Resources_ItemSelectionChanged);
            this.Resources.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DjnItems_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 400;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Type";
            this.columnHeader2.Width = 150;
            // 
            // NewContext
            // 
            this.NewContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewItem,
            this.NewMonster,
            this.NewSource,
            this.NewZone});
            this.NewContext.Name = "NewContext";
            this.NewContext.Size = new System.Drawing.Size(128, 92);
            // 
            // NewItem
            // 
            this.NewItem.Name = "NewItem";
            this.NewItem.Size = new System.Drawing.Size(127, 22);
            this.NewItem.Text = "&Item...";
            this.NewItem.Click += new System.EventHandler(this.NewItem_Click);
            // 
            // NewMonster
            // 
            this.NewMonster.Name = "NewMonster";
            this.NewMonster.Size = new System.Drawing.Size(127, 22);
            this.NewMonster.Text = "&Monster...";
            this.NewMonster.Click += new System.EventHandler(this.NewMonster_Click);
            // 
            // NewSource
            // 
            this.NewSource.Name = "NewSource";
            this.NewSource.Size = new System.Drawing.Size(127, 22);
            this.NewSource.Text = "&Source...";
            this.NewSource.Click += new System.EventHandler(this.NewSource_Click);
            // 
            // NewZone
            // 
            this.NewZone.Name = "NewZone";
            this.NewZone.Size = new System.Drawing.Size(127, 22);
            this.NewZone.Text = "&Zone...";
            this.NewZone.Click += new System.EventHandler(this.NewZone_Click);
            // 
            // ImportDialog
            // 
            this.ImportDialog.Filter = "Fonts|*.FNT|Graphics|*.GRF|Music|*.SNG|Palettes|*.PAL";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ID";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 554);
            this.Controls.Add(this.Resources);
            this.Controls.Add(this.ButtonsPanel);
            this.Controls.Add(this.TopMenu);
            this.MainMenuStrip = this.TopMenu;
            this.Name = "MainForm";
            this.Text = "DOSJUN Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.TopMenu.ResumeLayout(false);
            this.TopMenu.PerformLayout();
            this.ButtonsPanel.ResumeLayout(false);
            this.NewContext.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip TopMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuOpen;
        private System.Windows.Forms.ToolStripMenuItem MenuExit;
        private System.Windows.Forms.OpenFileDialog OpenDialog;
        private System.Windows.Forms.ToolStripMenuItem MenuSave;
        private System.Windows.Forms.ToolStripMenuItem MenuNew;
        private System.Windows.Forms.SaveFileDialog SaveDialog;
        private System.Windows.Forms.Panel ButtonsPanel;
        private System.Windows.Forms.ListView Resources;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button NewBtn;
        private System.Windows.Forms.ContextMenuStrip NewContext;
        private System.Windows.Forms.ToolStripMenuItem NewSource;
        private System.Windows.Forms.Button RenameBtn;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.ToolStripMenuItem NewZone;
        private System.Windows.Forms.ToolStripMenuItem NewMonster;
        private System.Windows.Forms.ToolStripMenuItem NewItem;
        private System.Windows.Forms.Button ImportBtn;
        private System.Windows.Forms.OpenFileDialog ImportDialog;
        private System.Windows.Forms.Button DumpBtn;
        private System.Windows.Forms.FolderBrowserDialog DumpDialog;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}

