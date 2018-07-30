namespace DosjunEditor
{
    partial class ZoneForm
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
            this.MenuZone = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEncounters = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuETables = new System.Windows.Forms.ToolStripMenuItem();
            this.ZoneTabs = new System.Windows.Forms.TabControl();
            this.TexturesTab = new System.Windows.Forms.TabPage();
            this.WestWall = new DosjunEditor.WallEditor();
            this.CeilingTexture = new DosjunEditor.TextureComboBox();
            this.FloorTexture = new DosjunEditor.TextureComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SouthWall = new DosjunEditor.WallEditor();
            this.label2 = new System.Windows.Forms.Label();
            this.EastWall = new DosjunEditor.WallEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.NorthWall = new DosjunEditor.WallEditor();
            this.ContentsTab = new System.Windows.Forms.TabPage();
            this.RemoveItemButton = new System.Windows.Forms.Button();
            this.EditItemButton = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.ItemList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AddItemButton = new System.Windows.Forms.Button();
            this.OnUseBox = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.DangerBox = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.ThingBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.FlagsBox = new System.Windows.Forms.GroupBox();
            this.ImpassableFlag = new System.Windows.Forms.CheckBox();
            this.EditETableButton = new System.Windows.Forms.Button();
            this.AddETableButton = new System.Windows.Forms.Button();
            this.SelectETableButton = new System.Windows.Forms.Button();
            this.ETableBox = new System.Windows.Forms.TextBox();
            this.ETableIdLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.OnEnterBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.DescriptionBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Map = new DosjunEditor.ZoneView();
            this.TopMenu.SuspendLayout();
            this.ZoneTabs.SuspendLayout();
            this.TexturesTab.SuspendLayout();
            this.ContentsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DangerBox)).BeginInit();
            this.FlagsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopMenu
            // 
            this.TopMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.tablesToolStripMenuItem});
            this.TopMenu.Location = new System.Drawing.Point(0, 0);
            this.TopMenu.Name = "TopMenu";
            this.TopMenu.Size = new System.Drawing.Size(1184, 24);
            this.TopMenu.TabIndex = 2;
            this.TopMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuZone,
            this.MenuSave,
            this.MenuExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // MenuZone
            // 
            this.MenuZone.Name = "MenuZone";
            this.MenuZone.Size = new System.Drawing.Size(148, 22);
            this.MenuZone.Text = "&Zone Details...";
            this.MenuZone.Click += new System.EventHandler(this.MenuZone_Click);
            // 
            // MenuSave
            // 
            this.MenuSave.Name = "MenuSave";
            this.MenuSave.Size = new System.Drawing.Size(148, 22);
            this.MenuSave.Text = "&Save";
            this.MenuSave.Click += new System.EventHandler(this.MenuSave_Click);
            // 
            // MenuExit
            // 
            this.MenuExit.Name = "MenuExit";
            this.MenuExit.Size = new System.Drawing.Size(148, 22);
            this.MenuExit.Text = "E&xit";
            this.MenuExit.Click += new System.EventHandler(this.MenuExit_Click);
            // 
            // tablesToolStripMenuItem
            // 
            this.tablesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuEncounters,
            this.MenuETables});
            this.tablesToolStripMenuItem.Name = "tablesToolStripMenuItem";
            this.tablesToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.tablesToolStripMenuItem.Text = "&Tables";
            // 
            // MenuEncounters
            // 
            this.MenuEncounters.Name = "MenuEncounters";
            this.MenuEncounters.Size = new System.Drawing.Size(173, 22);
            this.MenuEncounters.Text = "&Encounters...";
            this.MenuEncounters.Click += new System.EventHandler(this.MenuEncounters_Click);
            // 
            // MenuETables
            // 
            this.MenuETables.Name = "MenuETables";
            this.MenuETables.Size = new System.Drawing.Size(173, 22);
            this.MenuETables.Text = "Encounter &Tables...";
            this.MenuETables.Click += new System.EventHandler(this.MenuETables_Click);
            // 
            // ZoneTabs
            // 
            this.ZoneTabs.Controls.Add(this.TexturesTab);
            this.ZoneTabs.Controls.Add(this.ContentsTab);
            this.ZoneTabs.Dock = System.Windows.Forms.DockStyle.Right;
            this.ZoneTabs.Location = new System.Drawing.Point(916, 24);
            this.ZoneTabs.Name = "ZoneTabs";
            this.ZoneTabs.SelectedIndex = 0;
            this.ZoneTabs.Size = new System.Drawing.Size(268, 737);
            this.ZoneTabs.TabIndex = 3;
            // 
            // TexturesTab
            // 
            this.TexturesTab.Controls.Add(this.WestWall);
            this.TexturesTab.Controls.Add(this.CeilingTexture);
            this.TexturesTab.Controls.Add(this.FloorTexture);
            this.TexturesTab.Controls.Add(this.label6);
            this.TexturesTab.Controls.Add(this.label5);
            this.TexturesTab.Controls.Add(this.label4);
            this.TexturesTab.Controls.Add(this.label3);
            this.TexturesTab.Controls.Add(this.SouthWall);
            this.TexturesTab.Controls.Add(this.label2);
            this.TexturesTab.Controls.Add(this.EastWall);
            this.TexturesTab.Controls.Add(this.label1);
            this.TexturesTab.Controls.Add(this.NorthWall);
            this.TexturesTab.Location = new System.Drawing.Point(4, 22);
            this.TexturesTab.Name = "TexturesTab";
            this.TexturesTab.Padding = new System.Windows.Forms.Padding(3);
            this.TexturesTab.Size = new System.Drawing.Size(260, 711);
            this.TexturesTab.TabIndex = 0;
            this.TexturesTab.Text = "Textures";
            this.TexturesTab.UseVisualStyleBackColor = true;
            // 
            // WestWall
            // 
            this.WestWall.Face = DosjunEditor.WallLocation.West;
            this.WestWall.Location = new System.Drawing.Point(9, 156);
            this.WestWall.Name = "WestWall";
            this.WestWall.Size = new System.Drawing.Size(116, 116);
            this.WestWall.TabIndex = 54;
            this.WestWall.AnyChanged += new System.EventHandler(this.DataElement_Changed);
            // 
            // CeilingTexture
            // 
            this.CeilingTexture.Face = DosjunEditor.WallLocation.Ceiling;
            this.CeilingTexture.Location = new System.Drawing.Point(125, 551);
            this.CeilingTexture.Name = "CeilingTexture";
            this.CeilingTexture.Size = new System.Drawing.Size(126, 116);
            this.CeilingTexture.TabIndex = 53;
            this.CeilingTexture.TextureId = ((ushort)(0));
            this.CeilingTexture.ValueChanged += new System.EventHandler(this.DataElement_Changed);
            // 
            // FloorTexture
            // 
            this.FloorTexture.Face = DosjunEditor.WallLocation.Floor;
            this.FloorTexture.Location = new System.Drawing.Point(125, 418);
            this.FloorTexture.Name = "FloorTexture";
            this.FloorTexture.Size = new System.Drawing.Size(126, 116);
            this.FloorTexture.TabIndex = 52;
            this.FloorTexture.TextureId = ((ushort)(0));
            this.FloorTexture.ValueChanged += new System.EventHandler(this.DataElement_Changed);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 551);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 51;
            this.label6.Text = "Ceiling";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 418);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 50;
            this.label5.Text = "Floor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 49;
            this.label4.Text = "West Wall";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(71, 280);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 48;
            this.label3.Text = "South Wall";
            // 
            // SouthWall
            // 
            this.SouthWall.Face = DosjunEditor.WallLocation.South;
            this.SouthWall.Location = new System.Drawing.Point(74, 296);
            this.SouthWall.Name = "SouthWall";
            this.SouthWall.Size = new System.Drawing.Size(116, 116);
            this.SouthWall.TabIndex = 47;
            this.SouthWall.AnyChanged += new System.EventHandler(this.DataElement_Changed);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(132, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "East Wall";
            // 
            // EastWall
            // 
            this.EastWall.Face = DosjunEditor.WallLocation.East;
            this.EastWall.Location = new System.Drawing.Point(135, 156);
            this.EastWall.Name = "EastWall";
            this.EastWall.Size = new System.Drawing.Size(116, 116);
            this.EastWall.TabIndex = 45;
            this.EastWall.AnyChanged += new System.EventHandler(this.DataElement_Changed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(71, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 43;
            this.label1.Text = "North Wall";
            // 
            // NorthWall
            // 
            this.NorthWall.Face = DosjunEditor.WallLocation.North;
            this.NorthWall.Location = new System.Drawing.Point(74, 21);
            this.NorthWall.Name = "NorthWall";
            this.NorthWall.Size = new System.Drawing.Size(116, 116);
            this.NorthWall.TabIndex = 44;
            this.NorthWall.AnyChanged += new System.EventHandler(this.DataElement_Changed);
            // 
            // ContentsTab
            // 
            this.ContentsTab.Controls.Add(this.RemoveItemButton);
            this.ContentsTab.Controls.Add(this.EditItemButton);
            this.ContentsTab.Controls.Add(this.label13);
            this.ContentsTab.Controls.Add(this.ItemList);
            this.ContentsTab.Controls.Add(this.AddItemButton);
            this.ContentsTab.Controls.Add(this.OnUseBox);
            this.ContentsTab.Controls.Add(this.label12);
            this.ContentsTab.Controls.Add(this.DangerBox);
            this.ContentsTab.Controls.Add(this.label11);
            this.ContentsTab.Controls.Add(this.ThingBox);
            this.ContentsTab.Controls.Add(this.label10);
            this.ContentsTab.Controls.Add(this.FlagsBox);
            this.ContentsTab.Controls.Add(this.EditETableButton);
            this.ContentsTab.Controls.Add(this.AddETableButton);
            this.ContentsTab.Controls.Add(this.SelectETableButton);
            this.ContentsTab.Controls.Add(this.ETableBox);
            this.ContentsTab.Controls.Add(this.ETableIdLabel);
            this.ContentsTab.Controls.Add(this.label9);
            this.ContentsTab.Controls.Add(this.OnEnterBox);
            this.ContentsTab.Controls.Add(this.label8);
            this.ContentsTab.Controls.Add(this.DescriptionBox);
            this.ContentsTab.Controls.Add(this.label7);
            this.ContentsTab.Location = new System.Drawing.Point(4, 22);
            this.ContentsTab.Name = "ContentsTab";
            this.ContentsTab.Padding = new System.Windows.Forms.Padding(3);
            this.ContentsTab.Size = new System.Drawing.Size(260, 711);
            this.ContentsTab.TabIndex = 1;
            this.ContentsTab.Text = "Contents";
            this.ContentsTab.UseVisualStyleBackColor = true;
            // 
            // RemoveItemButton
            // 
            this.RemoveItemButton.Enabled = false;
            this.RemoveItemButton.Location = new System.Drawing.Point(192, 585);
            this.RemoveItemButton.Name = "RemoveItemButton";
            this.RemoveItemButton.Size = new System.Drawing.Size(60, 23);
            this.RemoveItemButton.TabIndex = 57;
            this.RemoveItemButton.Text = "Remove";
            this.RemoveItemButton.UseVisualStyleBackColor = true;
            this.RemoveItemButton.Click += new System.EventHandler(this.RemoveItemButton_Click);
            // 
            // EditItemButton
            // 
            this.EditItemButton.Enabled = false;
            this.EditItemButton.Location = new System.Drawing.Point(100, 585);
            this.EditItemButton.Name = "EditItemButton";
            this.EditItemButton.Size = new System.Drawing.Size(60, 23);
            this.EditItemButton.TabIndex = 56;
            this.EditItemButton.Text = "Edit...";
            this.EditItemButton.UseVisualStyleBackColor = true;
            this.EditItemButton.Click += new System.EventHandler(this.EditItemButton_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 455);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 13);
            this.label13.TabIndex = 55;
            this.label13.Text = "Items";
            // 
            // ItemList
            // 
            this.ItemList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.ItemList.Location = new System.Drawing.Point(6, 471);
            this.ItemList.Name = "ItemList";
            this.ItemList.Size = new System.Drawing.Size(246, 108);
            this.ItemList.TabIndex = 54;
            this.ItemList.UseCompatibleStateImageBehavior = false;
            this.ItemList.View = System.Windows.Forms.View.Details;
            this.ItemList.SelectedIndexChanged += new System.EventHandler(this.ItemList_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Item";
            this.columnHeader1.Width = 182;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "X";
            this.columnHeader2.Width = 30;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Y";
            this.columnHeader3.Width = 30;
            // 
            // AddItemButton
            // 
            this.AddItemButton.Location = new System.Drawing.Point(6, 585);
            this.AddItemButton.Name = "AddItemButton";
            this.AddItemButton.Size = new System.Drawing.Size(60, 23);
            this.AddItemButton.TabIndex = 53;
            this.AddItemButton.Text = "Add...";
            this.AddItemButton.UseVisualStyleBackColor = true;
            this.AddItemButton.Click += new System.EventHandler(this.AddItemButton_Click);
            // 
            // OnUseBox
            // 
            this.OnUseBox.FormattingEnabled = true;
            this.OnUseBox.Location = new System.Drawing.Point(126, 322);
            this.OnUseBox.Name = "OnUseBox";
            this.OnUseBox.Size = new System.Drawing.Size(126, 21);
            this.OnUseBox.TabIndex = 51;
            this.OnUseBox.SelectedIndexChanged += new System.EventHandler(this.OnUseBox_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 325);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 50;
            this.label12.Text = "On Use";
            // 
            // DangerBox
            // 
            this.DangerBox.Location = new System.Drawing.Point(126, 427);
            this.DangerBox.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.DangerBox.Name = "DangerBox";
            this.DangerBox.Size = new System.Drawing.Size(126, 20);
            this.DangerBox.TabIndex = 49;
            this.DangerBox.ValueChanged += new System.EventHandler(this.DangerBox_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 429);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 13);
            this.label11.TabIndex = 48;
            this.label11.Text = "Danger Value";
            // 
            // ThingBox
            // 
            this.ThingBox.FormattingEnabled = true;
            this.ThingBox.Location = new System.Drawing.Point(126, 399);
            this.ThingBox.Name = "ThingBox";
            this.ThingBox.Size = new System.Drawing.Size(126, 21);
            this.ThingBox.TabIndex = 47;
            this.ThingBox.SelectedIndexChanged += new System.EventHandler(this.ThingBox_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 403);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 13);
            this.label10.TabIndex = 46;
            this.label10.Text = "Thing";
            // 
            // FlagsBox
            // 
            this.FlagsBox.Controls.Add(this.ImpassableFlag);
            this.FlagsBox.Location = new System.Drawing.Point(6, 349);
            this.FlagsBox.Name = "FlagsBox";
            this.FlagsBox.Size = new System.Drawing.Size(246, 44);
            this.FlagsBox.TabIndex = 45;
            this.FlagsBox.TabStop = false;
            this.FlagsBox.Text = "Flags";
            // 
            // ImpassableFlag
            // 
            this.ImpassableFlag.AutoSize = true;
            this.ImpassableFlag.Location = new System.Drawing.Point(6, 19);
            this.ImpassableFlag.Name = "ImpassableFlag";
            this.ImpassableFlag.Size = new System.Drawing.Size(79, 17);
            this.ImpassableFlag.TabIndex = 0;
            this.ImpassableFlag.Text = "Impassable";
            this.ImpassableFlag.UseVisualStyleBackColor = true;
            this.ImpassableFlag.CheckedChanged += new System.EventHandler(this.ImpassableFlag_CheckedChanged);
            // 
            // EditETableButton
            // 
            this.EditETableButton.Location = new System.Drawing.Point(100, 265);
            this.EditETableButton.Name = "EditETableButton";
            this.EditETableButton.Size = new System.Drawing.Size(60, 23);
            this.EditETableButton.TabIndex = 44;
            this.EditETableButton.Text = "Edit...";
            this.EditETableButton.UseVisualStyleBackColor = true;
            this.EditETableButton.Click += new System.EventHandler(this.EditETableButton_Click);
            // 
            // AddETableButton
            // 
            this.AddETableButton.Location = new System.Drawing.Point(192, 265);
            this.AddETableButton.Name = "AddETableButton";
            this.AddETableButton.Size = new System.Drawing.Size(60, 23);
            this.AddETableButton.TabIndex = 43;
            this.AddETableButton.Text = "Add...";
            this.AddETableButton.UseVisualStyleBackColor = true;
            this.AddETableButton.Click += new System.EventHandler(this.AddETableButton_Click);
            // 
            // SelectETableButton
            // 
            this.SelectETableButton.Location = new System.Drawing.Point(6, 265);
            this.SelectETableButton.Name = "SelectETableButton";
            this.SelectETableButton.Size = new System.Drawing.Size(60, 23);
            this.SelectETableButton.TabIndex = 42;
            this.SelectETableButton.Text = "Select...";
            this.SelectETableButton.UseVisualStyleBackColor = true;
            this.SelectETableButton.Click += new System.EventHandler(this.SelectETableButton_Click);
            // 
            // ETableBox
            // 
            this.ETableBox.Location = new System.Drawing.Point(6, 164);
            this.ETableBox.Multiline = true;
            this.ETableBox.Name = "ETableBox";
            this.ETableBox.ReadOnly = true;
            this.ETableBox.Size = new System.Drawing.Size(246, 95);
            this.ETableBox.TabIndex = 41;
            // 
            // ETableIdLabel
            // 
            this.ETableIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ETableIdLabel.Location = new System.Drawing.Point(192, 148);
            this.ETableIdLabel.Name = "ETableIdLabel";
            this.ETableIdLabel.Size = new System.Drawing.Size(60, 13);
            this.ETableIdLabel.TabIndex = 40;
            this.ETableIdLabel.Text = "#";
            this.ETableIdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 148);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 13);
            this.label9.TabIndex = 39;
            this.label9.Text = "Encounter Table";
            // 
            // OnEnterBox
            // 
            this.OnEnterBox.FormattingEnabled = true;
            this.OnEnterBox.Location = new System.Drawing.Point(126, 294);
            this.OnEnterBox.Name = "OnEnterBox";
            this.OnEnterBox.Size = new System.Drawing.Size(126, 21);
            this.OnEnterBox.TabIndex = 38;
            this.OnEnterBox.SelectedIndexChanged += new System.EventHandler(this.OnEnterBox_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 297);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 37;
            this.label8.Text = "On Enter";
            // 
            // DescriptionBox
            // 
            this.DescriptionBox.Location = new System.Drawing.Point(6, 21);
            this.DescriptionBox.Multiline = true;
            this.DescriptionBox.Name = "DescriptionBox";
            this.DescriptionBox.Size = new System.Drawing.Size(246, 95);
            this.DescriptionBox.TabIndex = 36;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 35;
            this.label7.Text = "Description";
            // 
            // Map
            // 
            this.Map.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Map.Location = new System.Drawing.Point(0, 24);
            this.Map.Name = "Map";
            this.Map.Size = new System.Drawing.Size(1184, 737);
            this.Map.TabIndex = 0;
            this.Map.TileSize = 16;
            this.Map.TileSelected += new DosjunEditor.ZoneView.TileEventHandler(this.Map_TileSelected);
            this.Map.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Map_KeyUp);
            // 
            // ZoneForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.ZoneTabs);
            this.Controls.Add(this.Map);
            this.Controls.Add(this.TopMenu);
            this.MainMenuStrip = this.TopMenu;
            this.Name = "ZoneForm";
            this.Text = "Zone Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ZoneForm_FormClosing);
            this.TopMenu.ResumeLayout(false);
            this.TopMenu.PerformLayout();
            this.ZoneTabs.ResumeLayout(false);
            this.TexturesTab.ResumeLayout(false);
            this.TexturesTab.PerformLayout();
            this.ContentsTab.ResumeLayout(false);
            this.ContentsTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DangerBox)).EndInit();
            this.FlagsBox.ResumeLayout(false);
            this.FlagsBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ZoneView Map;
        private System.Windows.Forms.MenuStrip TopMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuSave;
        private System.Windows.Forms.ToolStripMenuItem MenuExit;
        private System.Windows.Forms.ToolStripMenuItem tablesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuEncounters;
        private System.Windows.Forms.ToolStripMenuItem MenuETables;
        private System.Windows.Forms.ToolStripMenuItem MenuZone;
        private System.Windows.Forms.TabControl ZoneTabs;
        private System.Windows.Forms.TabPage TexturesTab;
        private WallEditor WestWall;
        private TextureComboBox CeilingTexture;
        private TextureComboBox FloorTexture;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private WallEditor SouthWall;
        private System.Windows.Forms.Label label2;
        private WallEditor EastWall;
        private System.Windows.Forms.Label label1;
        private WallEditor NorthWall;
        private System.Windows.Forms.TabPage ContentsTab;
        private System.Windows.Forms.ComboBox OnUseBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown DangerBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox ThingBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox FlagsBox;
        private System.Windows.Forms.CheckBox ImpassableFlag;
        private System.Windows.Forms.Button EditETableButton;
        private System.Windows.Forms.Button AddETableButton;
        private System.Windows.Forms.Button SelectETableButton;
        private System.Windows.Forms.TextBox ETableBox;
        private System.Windows.Forms.Label ETableIdLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox OnEnterBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox DescriptionBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button RemoveItemButton;
        private System.Windows.Forms.Button EditItemButton;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ListView ItemList;
        private System.Windows.Forms.Button AddItemButton;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}