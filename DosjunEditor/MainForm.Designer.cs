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
            this.TopMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ItemBox = new System.Windows.Forms.GroupBox();
            this.ItemList = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.NewItemButton = new System.Windows.Forms.Button();
            this.MonsterBox = new System.Windows.Forms.GroupBox();
            this.MonsterList = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.NewMonsterButton = new System.Windows.Forms.Button();
            this.ZoneBox = new System.Windows.Forms.GroupBox();
            this.ZoneList = new System.Windows.Forms.ListBox();
            this.ZoneButtons = new System.Windows.Forms.Panel();
            this.NewZoneButton = new System.Windows.Forms.Button();
            this.AddZoneButton = new System.Windows.Forms.Button();
            this.TopMenu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.ItemBox.SuspendLayout();
            this.panel2.SuspendLayout();
            this.MonsterBox.SuspendLayout();
            this.panel1.SuspendLayout();
            this.ZoneBox.SuspendLayout();
            this.ZoneButtons.SuspendLayout();
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
            this.MenuOpen,
            this.MenuSave,
            this.MenuExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
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
            this.OpenDialog.Filter = "Campaign Files|*.cmp";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.ItemBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.MonsterBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ZoneBox, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(947, 530);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // ItemBox
            // 
            this.ItemBox.Controls.Add(this.ItemList);
            this.ItemBox.Controls.Add(this.panel2);
            this.ItemBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemBox.Location = new System.Drawing.Point(633, 3);
            this.ItemBox.Name = "ItemBox";
            this.ItemBox.Size = new System.Drawing.Size(311, 524);
            this.ItemBox.TabIndex = 7;
            this.ItemBox.TabStop = false;
            this.ItemBox.Text = "Items";
            // 
            // ItemList
            // 
            this.ItemList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemList.FormattingEnabled = true;
            this.ItemList.Location = new System.Drawing.Point(3, 46);
            this.ItemList.Name = "ItemList";
            this.ItemList.Size = new System.Drawing.Size(305, 475);
            this.ItemList.TabIndex = 6;
            this.ItemList.DoubleClick += new System.EventHandler(this.ItemList_DoubleClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.NewItemButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(305, 30);
            this.panel2.TabIndex = 5;
            // 
            // NewItemButton
            // 
            this.NewItemButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.NewItemButton.Enabled = false;
            this.NewItemButton.Location = new System.Drawing.Point(0, 0);
            this.NewItemButton.Name = "NewItemButton";
            this.NewItemButton.Size = new System.Drawing.Size(75, 30);
            this.NewItemButton.TabIndex = 1;
            this.NewItemButton.Text = "&New...";
            this.NewItemButton.UseVisualStyleBackColor = true;
            this.NewItemButton.Click += new System.EventHandler(this.NewItemButton_Click);
            // 
            // MonsterBox
            // 
            this.MonsterBox.Controls.Add(this.MonsterList);
            this.MonsterBox.Controls.Add(this.panel1);
            this.MonsterBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MonsterBox.Location = new System.Drawing.Point(318, 3);
            this.MonsterBox.Name = "MonsterBox";
            this.MonsterBox.Size = new System.Drawing.Size(309, 524);
            this.MonsterBox.TabIndex = 6;
            this.MonsterBox.TabStop = false;
            this.MonsterBox.Text = "Monsters";
            // 
            // MonsterList
            // 
            this.MonsterList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MonsterList.FormattingEnabled = true;
            this.MonsterList.Location = new System.Drawing.Point(3, 46);
            this.MonsterList.Name = "MonsterList";
            this.MonsterList.Size = new System.Drawing.Size(303, 475);
            this.MonsterList.TabIndex = 6;
            this.MonsterList.DoubleClick += new System.EventHandler(this.MonsterList_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.NewMonsterButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(303, 30);
            this.panel1.TabIndex = 5;
            // 
            // NewMonsterButton
            // 
            this.NewMonsterButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.NewMonsterButton.Enabled = false;
            this.NewMonsterButton.Location = new System.Drawing.Point(0, 0);
            this.NewMonsterButton.Name = "NewMonsterButton";
            this.NewMonsterButton.Size = new System.Drawing.Size(75, 30);
            this.NewMonsterButton.TabIndex = 1;
            this.NewMonsterButton.Text = "&New...";
            this.NewMonsterButton.UseVisualStyleBackColor = true;
            this.NewMonsterButton.Click += new System.EventHandler(this.NewMonsterButton_Click);
            // 
            // ZoneBox
            // 
            this.ZoneBox.Controls.Add(this.ZoneList);
            this.ZoneBox.Controls.Add(this.ZoneButtons);
            this.ZoneBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ZoneBox.Location = new System.Drawing.Point(3, 3);
            this.ZoneBox.Name = "ZoneBox";
            this.ZoneBox.Size = new System.Drawing.Size(309, 524);
            this.ZoneBox.TabIndex = 5;
            this.ZoneBox.TabStop = false;
            this.ZoneBox.Text = "Zones";
            // 
            // ZoneList
            // 
            this.ZoneList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ZoneList.FormattingEnabled = true;
            this.ZoneList.Location = new System.Drawing.Point(3, 46);
            this.ZoneList.Name = "ZoneList";
            this.ZoneList.Size = new System.Drawing.Size(303, 475);
            this.ZoneList.TabIndex = 5;
            this.ZoneList.DoubleClick += new System.EventHandler(this.ZoneList_DoubleClick);
            // 
            // ZoneButtons
            // 
            this.ZoneButtons.Controls.Add(this.NewZoneButton);
            this.ZoneButtons.Controls.Add(this.AddZoneButton);
            this.ZoneButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.ZoneButtons.Location = new System.Drawing.Point(3, 16);
            this.ZoneButtons.Name = "ZoneButtons";
            this.ZoneButtons.Size = new System.Drawing.Size(303, 30);
            this.ZoneButtons.TabIndex = 4;
            // 
            // NewZoneButton
            // 
            this.NewZoneButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.NewZoneButton.Enabled = false;
            this.NewZoneButton.Location = new System.Drawing.Point(75, 0);
            this.NewZoneButton.Name = "NewZoneButton";
            this.NewZoneButton.Size = new System.Drawing.Size(75, 30);
            this.NewZoneButton.TabIndex = 1;
            this.NewZoneButton.Text = "&New...";
            this.NewZoneButton.UseVisualStyleBackColor = true;
            // 
            // AddZoneButton
            // 
            this.AddZoneButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.AddZoneButton.Enabled = false;
            this.AddZoneButton.Location = new System.Drawing.Point(0, 0);
            this.AddZoneButton.Name = "AddZoneButton";
            this.AddZoneButton.Size = new System.Drawing.Size(75, 30);
            this.AddZoneButton.TabIndex = 0;
            this.AddZoneButton.Text = "&Add...";
            this.AddZoneButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 554);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.TopMenu);
            this.MainMenuStrip = this.TopMenu;
            this.Name = "MainForm";
            this.Text = "Campaign Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.TopMenu.ResumeLayout(false);
            this.TopMenu.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ItemBox.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.MonsterBox.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ZoneBox.ResumeLayout(false);
            this.ZoneButtons.ResumeLayout(false);
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox ItemBox;
        private System.Windows.Forms.ListBox ItemList;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button NewItemButton;
        private System.Windows.Forms.GroupBox MonsterBox;
        private System.Windows.Forms.ListBox MonsterList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button NewMonsterButton;
        private System.Windows.Forms.GroupBox ZoneBox;
        private System.Windows.Forms.ListBox ZoneList;
        private System.Windows.Forms.Panel ZoneButtons;
        private System.Windows.Forms.Button NewZoneButton;
        private System.Windows.Forms.Button AddZoneButton;
    }
}

