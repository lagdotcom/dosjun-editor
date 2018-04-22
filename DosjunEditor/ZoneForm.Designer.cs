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
            this.SidePanel = new System.Windows.Forms.GroupBox();
            this.DangerBox = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.WestWall = new DosjunEditor.WallEditor();
            this.CeilingTexture = new DosjunEditor.TextureComboBox();
            this.FloorTexture = new DosjunEditor.TextureComboBox();
            this.ThingBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.FlagsBox = new System.Windows.Forms.GroupBox();
            this.EditETableButton = new System.Windows.Forms.Button();
            this.AddETableButton = new System.Windows.Forms.Button();
            this.SelectETableButton = new System.Windows.Forms.Button();
            this.ETableBox = new System.Windows.Forms.TextBox();
            this.ETableIdLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.OnEnterBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.AddDescriptionButton = new System.Windows.Forms.Button();
            this.SelectDescriptionButton = new System.Windows.Forms.Button();
            this.DescriptionIdLabel = new System.Windows.Forms.Label();
            this.DescriptionBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SouthWall = new DosjunEditor.WallEditor();
            this.label2 = new System.Windows.Forms.Label();
            this.EastWall = new DosjunEditor.WallEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.NorthWall = new DosjunEditor.WallEditor();
            this.Map = new DosjunEditor.ZoneView();
            this.TopMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuZone = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEncounters = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuETables = new System.Windows.Forms.ToolStripMenuItem();
            this.OnUseBox = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.ImpassableFlag = new System.Windows.Forms.CheckBox();
            this.SidePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DangerBox)).BeginInit();
            this.FlagsBox.SuspendLayout();
            this.TopMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // SidePanel
            // 
            this.SidePanel.Controls.Add(this.OnUseBox);
            this.SidePanel.Controls.Add(this.label12);
            this.SidePanel.Controls.Add(this.DangerBox);
            this.SidePanel.Controls.Add(this.label11);
            this.SidePanel.Controls.Add(this.WestWall);
            this.SidePanel.Controls.Add(this.CeilingTexture);
            this.SidePanel.Controls.Add(this.FloorTexture);
            this.SidePanel.Controls.Add(this.ThingBox);
            this.SidePanel.Controls.Add(this.label10);
            this.SidePanel.Controls.Add(this.FlagsBox);
            this.SidePanel.Controls.Add(this.EditETableButton);
            this.SidePanel.Controls.Add(this.AddETableButton);
            this.SidePanel.Controls.Add(this.SelectETableButton);
            this.SidePanel.Controls.Add(this.ETableBox);
            this.SidePanel.Controls.Add(this.ETableIdLabel);
            this.SidePanel.Controls.Add(this.label9);
            this.SidePanel.Controls.Add(this.OnEnterBox);
            this.SidePanel.Controls.Add(this.label8);
            this.SidePanel.Controls.Add(this.AddDescriptionButton);
            this.SidePanel.Controls.Add(this.SelectDescriptionButton);
            this.SidePanel.Controls.Add(this.DescriptionIdLabel);
            this.SidePanel.Controls.Add(this.DescriptionBox);
            this.SidePanel.Controls.Add(this.label7);
            this.SidePanel.Controls.Add(this.label6);
            this.SidePanel.Controls.Add(this.label5);
            this.SidePanel.Controls.Add(this.label4);
            this.SidePanel.Controls.Add(this.label3);
            this.SidePanel.Controls.Add(this.SouthWall);
            this.SidePanel.Controls.Add(this.label2);
            this.SidePanel.Controls.Add(this.EastWall);
            this.SidePanel.Controls.Add(this.label1);
            this.SidePanel.Controls.Add(this.NorthWall);
            this.SidePanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.SidePanel.Location = new System.Drawing.Point(934, 24);
            this.SidePanel.Name = "SidePanel";
            this.SidePanel.Size = new System.Drawing.Size(250, 937);
            this.SidePanel.TabIndex = 0;
            this.SidePanel.TabStop = false;
            this.SidePanel.Text = "Tile Details";
            // 
            // DangerBox
            // 
            this.DangerBox.Location = new System.Drawing.Point(112, 865);
            this.DangerBox.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.DangerBox.Name = "DangerBox";
            this.DangerBox.Size = new System.Drawing.Size(126, 20);
            this.DangerBox.TabIndex = 32;
            this.DangerBox.ValueChanged += new System.EventHandler(this.DangerBox_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 867);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "Danger Value";
            // 
            // WestWall
            // 
            this.WestWall.Face = DosjunEditor.WallLocation.West;
            this.WestWall.Location = new System.Drawing.Point(6, 131);
            this.WestWall.Name = "WestWall";
            this.WestWall.Size = new System.Drawing.Size(116, 80);
            this.WestWall.TabIndex = 30;
            this.WestWall.AnyChanged += new System.EventHandler(this.DataElement_Changed);
            // 
            // CeilingTexture
            // 
            this.CeilingTexture.Face = DosjunEditor.WallLocation.Ceiling;
            this.CeilingTexture.Location = new System.Drawing.Point(112, 387);
            this.CeilingTexture.Name = "CeilingTexture";
            this.CeilingTexture.Size = new System.Drawing.Size(126, 53);
            this.CeilingTexture.TabIndex = 29;
            this.CeilingTexture.Texture = null;
            this.CeilingTexture.TextureId = ((byte)(0));
            this.CeilingTexture.Zone = null;
            this.CeilingTexture.ValueChanged += new System.EventHandler(this.CeilingTexture_ValueChanged);
            // 
            // FloorTexture
            // 
            this.FloorTexture.Face = DosjunEditor.WallLocation.Floor;
            this.FloorTexture.Location = new System.Drawing.Point(112, 328);
            this.FloorTexture.Name = "FloorTexture";
            this.FloorTexture.Size = new System.Drawing.Size(126, 53);
            this.FloorTexture.TabIndex = 28;
            this.FloorTexture.Texture = null;
            this.FloorTexture.TextureId = ((byte)(0));
            this.FloorTexture.Zone = null;
            this.FloorTexture.ValueChanged += new System.EventHandler(this.FloorTexture_ValueChanged);
            // 
            // ThingBox
            // 
            this.ThingBox.FormattingEnabled = true;
            this.ThingBox.Location = new System.Drawing.Point(112, 838);
            this.ThingBox.Name = "ThingBox";
            this.ThingBox.Size = new System.Drawing.Size(126, 21);
            this.ThingBox.TabIndex = 27;
            this.ThingBox.SelectedIndexChanged += new System.EventHandler(this.ThingBox_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 841);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Thing";
            // 
            // FlagsBox
            // 
            this.FlagsBox.Controls.Add(this.ImpassableFlag);
            this.FlagsBox.Location = new System.Drawing.Point(6, 787);
            this.FlagsBox.Name = "FlagsBox";
            this.FlagsBox.Size = new System.Drawing.Size(232, 44);
            this.FlagsBox.TabIndex = 25;
            this.FlagsBox.TabStop = false;
            this.FlagsBox.Text = "Flags";
            // 
            // EditETableButton
            // 
            this.EditETableButton.Location = new System.Drawing.Point(91, 703);
            this.EditETableButton.Name = "EditETableButton";
            this.EditETableButton.Size = new System.Drawing.Size(59, 23);
            this.EditETableButton.TabIndex = 24;
            this.EditETableButton.Text = "Edit...";
            this.EditETableButton.UseVisualStyleBackColor = true;
            this.EditETableButton.Click += new System.EventHandler(this.EditETableButton_Click);
            // 
            // AddETableButton
            // 
            this.AddETableButton.Location = new System.Drawing.Point(178, 703);
            this.AddETableButton.Name = "AddETableButton";
            this.AddETableButton.Size = new System.Drawing.Size(60, 23);
            this.AddETableButton.TabIndex = 23;
            this.AddETableButton.Text = "Add...";
            this.AddETableButton.UseVisualStyleBackColor = true;
            this.AddETableButton.Click += new System.EventHandler(this.AddETableButton_Click);
            // 
            // SelectETableButton
            // 
            this.SelectETableButton.Location = new System.Drawing.Point(6, 703);
            this.SelectETableButton.Name = "SelectETableButton";
            this.SelectETableButton.Size = new System.Drawing.Size(60, 23);
            this.SelectETableButton.TabIndex = 22;
            this.SelectETableButton.Text = "Select...";
            this.SelectETableButton.UseVisualStyleBackColor = true;
            this.SelectETableButton.Click += new System.EventHandler(this.SelectETableButton_Click);
            // 
            // ETableBox
            // 
            this.ETableBox.Location = new System.Drawing.Point(6, 602);
            this.ETableBox.Multiline = true;
            this.ETableBox.Name = "ETableBox";
            this.ETableBox.ReadOnly = true;
            this.ETableBox.Size = new System.Drawing.Size(232, 95);
            this.ETableBox.TabIndex = 21;
            // 
            // ETableIdLabel
            // 
            this.ETableIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ETableIdLabel.Location = new System.Drawing.Point(178, 586);
            this.ETableIdLabel.Name = "ETableIdLabel";
            this.ETableIdLabel.Size = new System.Drawing.Size(60, 13);
            this.ETableIdLabel.TabIndex = 20;
            this.ETableIdLabel.Text = "#";
            this.ETableIdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 586);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Encounter Table";
            // 
            // OnEnterBox
            // 
            this.OnEnterBox.FormattingEnabled = true;
            this.OnEnterBox.Location = new System.Drawing.Point(112, 733);
            this.OnEnterBox.Name = "OnEnterBox";
            this.OnEnterBox.Size = new System.Drawing.Size(126, 21);
            this.OnEnterBox.TabIndex = 18;
            this.OnEnterBox.SelectedIndexChanged += new System.EventHandler(this.OnEnterBox_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 735);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "On Enter";
            // 
            // AddDescriptionButton
            // 
            this.AddDescriptionButton.Location = new System.Drawing.Point(178, 560);
            this.AddDescriptionButton.Name = "AddDescriptionButton";
            this.AddDescriptionButton.Size = new System.Drawing.Size(60, 23);
            this.AddDescriptionButton.TabIndex = 16;
            this.AddDescriptionButton.Text = "Add...";
            this.AddDescriptionButton.UseVisualStyleBackColor = true;
            this.AddDescriptionButton.Click += new System.EventHandler(this.AddDescriptionButton_Click);
            // 
            // SelectDescriptionButton
            // 
            this.SelectDescriptionButton.Location = new System.Drawing.Point(6, 560);
            this.SelectDescriptionButton.Name = "SelectDescriptionButton";
            this.SelectDescriptionButton.Size = new System.Drawing.Size(60, 23);
            this.SelectDescriptionButton.TabIndex = 15;
            this.SelectDescriptionButton.Text = "Select...";
            this.SelectDescriptionButton.UseVisualStyleBackColor = true;
            this.SelectDescriptionButton.Click += new System.EventHandler(this.SelectDescriptionButton_Click);
            // 
            // DescriptionIdLabel
            // 
            this.DescriptionIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionIdLabel.Location = new System.Drawing.Point(178, 443);
            this.DescriptionIdLabel.Name = "DescriptionIdLabel";
            this.DescriptionIdLabel.Size = new System.Drawing.Size(60, 13);
            this.DescriptionIdLabel.TabIndex = 14;
            this.DescriptionIdLabel.Text = "#";
            this.DescriptionIdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DescriptionBox
            // 
            this.DescriptionBox.Location = new System.Drawing.Point(6, 459);
            this.DescriptionBox.Multiline = true;
            this.DescriptionBox.Name = "DescriptionBox";
            this.DescriptionBox.ReadOnly = true;
            this.DescriptionBox.Size = new System.Drawing.Size(232, 95);
            this.DescriptionBox.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 443);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Description";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 390);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Ceiling";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 330);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Floor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "West Wall";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(63, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "South Wall";
            // 
            // SouthWall
            // 
            this.SouthWall.Face = DosjunEditor.WallLocation.South;
            this.SouthWall.Location = new System.Drawing.Point(66, 232);
            this.SouthWall.Name = "SouthWall";
            this.SouthWall.Size = new System.Drawing.Size(116, 80);
            this.SouthWall.TabIndex = 4;
            this.SouthWall.AnyChanged += new System.EventHandler(this.DataElement_Changed);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(129, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "East Wall";
            // 
            // EastWall
            // 
            this.EastWall.Face = DosjunEditor.WallLocation.East;
            this.EastWall.Location = new System.Drawing.Point(130, 131);
            this.EastWall.Name = "EastWall";
            this.EastWall.Size = new System.Drawing.Size(116, 80);
            this.EastWall.TabIndex = 2;
            this.EastWall.AnyChanged += new System.EventHandler(this.DataElement_Changed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(63, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "North Wall";
            // 
            // NorthWall
            // 
            this.NorthWall.Face = DosjunEditor.WallLocation.North;
            this.NorthWall.Location = new System.Drawing.Point(66, 32);
            this.NorthWall.Name = "NorthWall";
            this.NorthWall.Size = new System.Drawing.Size(116, 80);
            this.NorthWall.TabIndex = 1;
            this.NorthWall.AnyChanged += new System.EventHandler(this.DataElement_Changed);
            // 
            // Map
            // 
            this.Map.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Map.Location = new System.Drawing.Point(0, 24);
            this.Map.Name = "Map";
            this.Map.Size = new System.Drawing.Size(934, 937);
            this.Map.TabIndex = 0;
            this.Map.TileSize = 16;
            this.Map.Zone = null;
            this.Map.TileSelected += new DosjunEditor.ZoneView.TileEventHandler(this.Map_TileSelected);
            this.Map.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Map_KeyUp);
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
            this.MenuLoad,
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
            // MenuLoad
            // 
            this.MenuLoad.Name = "MenuLoad";
            this.MenuLoad.Size = new System.Drawing.Size(148, 22);
            this.MenuLoad.Text = "&Load JC";
            this.MenuLoad.Click += new System.EventHandler(this.MenuLoad_Click);
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
            // OnUseBox
            // 
            this.OnUseBox.FormattingEnabled = true;
            this.OnUseBox.Location = new System.Drawing.Point(112, 760);
            this.OnUseBox.Name = "OnUseBox";
            this.OnUseBox.Size = new System.Drawing.Size(126, 21);
            this.OnUseBox.TabIndex = 34;
            this.OnUseBox.SelectedIndexChanged += new System.EventHandler(this.OnUseBox_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 763);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 33;
            this.label12.Text = "On Use";
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
            // ZoneForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 961);
            this.Controls.Add(this.Map);
            this.Controls.Add(this.SidePanel);
            this.Controls.Add(this.TopMenu);
            this.MainMenuStrip = this.TopMenu;
            this.Name = "ZoneForm";
            this.Text = "Zone Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ZoneForm_FormClosing);
            this.SidePanel.ResumeLayout(false);
            this.SidePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DangerBox)).EndInit();
            this.FlagsBox.ResumeLayout(false);
            this.FlagsBox.PerformLayout();
            this.TopMenu.ResumeLayout(false);
            this.TopMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox SidePanel;
        private ZoneView Map;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private WallEditor SouthWall;
        private System.Windows.Forms.Label label2;
        private WallEditor EastWall;
        private System.Windows.Forms.Label label1;
        private WallEditor NorthWall;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox DescriptionBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label DescriptionIdLabel;
        private System.Windows.Forms.Button AddDescriptionButton;
        private System.Windows.Forms.Button SelectDescriptionButton;
        private System.Windows.Forms.MenuStrip TopMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuSave;
        private System.Windows.Forms.ToolStripMenuItem MenuExit;
        private System.Windows.Forms.ToolStripMenuItem MenuLoad;
        private System.Windows.Forms.ComboBox OnEnterBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button SelectETableButton;
        private System.Windows.Forms.TextBox ETableBox;
        private System.Windows.Forms.Label ETableIdLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox FlagsBox;
        private System.Windows.Forms.ComboBox ThingBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolStripMenuItem tablesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuEncounters;
        private System.Windows.Forms.ToolStripMenuItem MenuETables;
        private System.Windows.Forms.Button EditETableButton;
        private System.Windows.Forms.Button AddETableButton;
        private TextureComboBox CeilingTexture;
        private TextureComboBox FloorTexture;
        private WallEditor WestWall;
        private System.Windows.Forms.NumericUpDown DangerBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ToolStripMenuItem MenuZone;
        private System.Windows.Forms.ComboBox OnUseBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox ImpassableFlag;
    }
}