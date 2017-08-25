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
            DosjunEditor.Wall wall9 = new DosjunEditor.Wall();
            DosjunEditor.Wall wall10 = new DosjunEditor.Wall();
            DosjunEditor.Wall wall11 = new DosjunEditor.Wall();
            DosjunEditor.Wall wall12 = new DosjunEditor.Wall();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CeilingColour = new DosjunEditor.PalettePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.FloorColour = new DosjunEditor.PalettePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.WestWall = new DosjunEditor.WallEditor();
            this.label3 = new System.Windows.Forms.Label();
            this.SouthWall = new DosjunEditor.WallEditor();
            this.label2 = new System.Windows.Forms.Label();
            this.EastWall = new DosjunEditor.WallEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.NorthWall = new DosjunEditor.WallEditor();
            this.Map = new DosjunEditor.ZoneView();
            this.label7 = new System.Windows.Forms.Label();
            this.DescriptionBox = new System.Windows.Forms.TextBox();
            this.DescriptionIdLabel = new System.Windows.Forms.Label();
            this.SelectDescriptionButton = new System.Windows.Forms.Button();
            this.AddDescriptionButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AddDescriptionButton);
            this.groupBox1.Controls.Add(this.SelectDescriptionButton);
            this.groupBox1.Controls.Add(this.DescriptionIdLabel);
            this.groupBox1.Controls.Add(this.DescriptionBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.CeilingColour);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.FloorColour);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.WestWall);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.SouthWall);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.EastWall);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.NorthWall);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(568, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 561);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tile Details";
            // 
            // CeilingColour
            // 
            this.CeilingColour.Colour = ((byte)(0));
            this.CeilingColour.Location = new System.Drawing.Point(83, 353);
            this.CeilingColour.Name = "CeilingColour";
            this.CeilingColour.Size = new System.Drawing.Size(121, 20);
            this.CeilingColour.TabIndex = 11;
            this.CeilingColour.ColourChanged += new System.EventHandler(this.CeilingColour_ColourChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 356);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Ceiling";
            // 
            // FloorColour
            // 
            this.FloorColour.Colour = ((byte)(0));
            this.FloorColour.Location = new System.Drawing.Point(83, 327);
            this.FloorColour.Name = "FloorColour";
            this.FloorColour.Size = new System.Drawing.Size(121, 20);
            this.FloorColour.TabIndex = 9;
            this.FloorColour.ColourChanged += new System.EventHandler(this.FloorColour_ColourChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 330);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Floor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "West Wall";
            // 
            // WestWall
            // 
            this.WestWall.Colour = ((byte)(0));
            this.WestWall.Location = new System.Drawing.Point(9, 265);
            this.WestWall.Name = "WestWall";
            this.WestWall.Size = new System.Drawing.Size(200, 56);
            this.WestWall.TabIndex = 6;
            this.WestWall.Type = DosjunEditor.WallType.Normal;
            wall9.Texture = ((byte)(0));
            wall9.Type = DosjunEditor.WallType.Normal;
            this.WestWall.Wall = wall9;
            this.WestWall.AnyChanged += new System.EventHandler(this.DataElement_Changed);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "South Wall";
            // 
            // SouthWall
            // 
            this.SouthWall.Colour = ((byte)(0));
            this.SouthWall.Location = new System.Drawing.Point(9, 190);
            this.SouthWall.Name = "SouthWall";
            this.SouthWall.Size = new System.Drawing.Size(200, 56);
            this.SouthWall.TabIndex = 4;
            this.SouthWall.Type = DosjunEditor.WallType.Normal;
            wall10.Texture = ((byte)(0));
            wall10.Type = DosjunEditor.WallType.Normal;
            this.SouthWall.Wall = wall10;
            this.SouthWall.AnyChanged += new System.EventHandler(this.DataElement_Changed);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "East Wall";
            // 
            // EastWall
            // 
            this.EastWall.Colour = ((byte)(0));
            this.EastWall.Location = new System.Drawing.Point(9, 115);
            this.EastWall.Name = "EastWall";
            this.EastWall.Size = new System.Drawing.Size(200, 56);
            this.EastWall.TabIndex = 2;
            this.EastWall.Type = DosjunEditor.WallType.Normal;
            wall11.Texture = ((byte)(0));
            wall11.Type = DosjunEditor.WallType.Normal;
            this.EastWall.Wall = wall11;
            this.EastWall.AnyChanged += new System.EventHandler(this.DataElement_Changed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "North Wall";
            // 
            // NorthWall
            // 
            this.NorthWall.Colour = ((byte)(0));
            this.NorthWall.Location = new System.Drawing.Point(10, 40);
            this.NorthWall.Name = "NorthWall";
            this.NorthWall.Size = new System.Drawing.Size(200, 56);
            this.NorthWall.TabIndex = 0;
            this.NorthWall.Type = DosjunEditor.WallType.Normal;
            wall12.Texture = ((byte)(0));
            wall12.Type = DosjunEditor.WallType.Normal;
            this.NorthWall.Wall = wall12;
            this.NorthWall.AnyChanged += new System.EventHandler(this.DataElement_Changed);
            // 
            // Map
            // 
            this.Map.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Map.Location = new System.Drawing.Point(0, 0);
            this.Map.Name = "Map";
            this.Map.Size = new System.Drawing.Size(568, 561);
            this.Map.TabIndex = 1;
            this.Map.TileSize = 16;
            this.Map.Zone = null;
            this.Map.TileSelected += new DosjunEditor.ZoneView.TileEventHandler(this.Map_TileSelected);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 390);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Description";
            // 
            // DescriptionBox
            // 
            this.DescriptionBox.Location = new System.Drawing.Point(10, 406);
            this.DescriptionBox.Multiline = true;
            this.DescriptionBox.Name = "DescriptionBox";
            this.DescriptionBox.ReadOnly = true;
            this.DescriptionBox.Size = new System.Drawing.Size(194, 95);
            this.DescriptionBox.TabIndex = 13;
            // 
            // DescriptionIdLabel
            // 
            this.DescriptionIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionIdLabel.Location = new System.Drawing.Point(144, 390);
            this.DescriptionIdLabel.Name = "DescriptionIdLabel";
            this.DescriptionIdLabel.Size = new System.Drawing.Size(60, 13);
            this.DescriptionIdLabel.TabIndex = 14;
            this.DescriptionIdLabel.Text = "#";
            this.DescriptionIdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SelectDescriptionButton
            // 
            this.SelectDescriptionButton.Enabled = false;
            this.SelectDescriptionButton.Location = new System.Drawing.Point(10, 507);
            this.SelectDescriptionButton.Name = "SelectDescriptionButton";
            this.SelectDescriptionButton.Size = new System.Drawing.Size(75, 23);
            this.SelectDescriptionButton.TabIndex = 15;
            this.SelectDescriptionButton.Text = "Select...";
            this.SelectDescriptionButton.UseVisualStyleBackColor = true;
            // 
            // AddDescriptionButton
            // 
            this.AddDescriptionButton.Location = new System.Drawing.Point(129, 507);
            this.AddDescriptionButton.Name = "AddDescriptionButton";
            this.AddDescriptionButton.Size = new System.Drawing.Size(75, 23);
            this.AddDescriptionButton.TabIndex = 16;
            this.AddDescriptionButton.Text = "Add...";
            this.AddDescriptionButton.UseVisualStyleBackColor = true;
            this.AddDescriptionButton.Click += new System.EventHandler(this.AddDescriptionButton_Click);
            // 
            // ZoneForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.Map);
            this.Controls.Add(this.groupBox1);
            this.Name = "ZoneForm";
            this.Text = "Zone Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ZoneForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private ZoneView Map;
        private System.Windows.Forms.Label label4;
        private WallEditor WestWall;
        private System.Windows.Forms.Label label3;
        private WallEditor SouthWall;
        private System.Windows.Forms.Label label2;
        private WallEditor EastWall;
        private System.Windows.Forms.Label label1;
        private WallEditor NorthWall;
        private PalettePicker CeilingColour;
        private System.Windows.Forms.Label label6;
        private PalettePicker FloorColour;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox DescriptionBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label DescriptionIdLabel;
        private System.Windows.Forms.Button AddDescriptionButton;
        private System.Windows.Forms.Button SelectDescriptionButton;
    }
}