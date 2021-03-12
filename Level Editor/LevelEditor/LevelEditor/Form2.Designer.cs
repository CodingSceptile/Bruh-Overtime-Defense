namespace LevelEditor
{
    partial class LevelEditor
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
            this.tileBox = new System.Windows.Forms.GroupBox();
            this.redTile = new System.Windows.Forms.Button();
            this.yellowTile = new System.Windows.Forms.Button();
            this.grayTile = new System.Windows.Forms.Button();
            this.brownColor = new System.Windows.Forms.Button();
            this.blueTile = new System.Windows.Forms.Button();
            this.greenTile = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.currentTile = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.mapBox = new System.Windows.Forms.GroupBox();
            this.tileBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tileBox
            // 
            this.tileBox.Controls.Add(this.redTile);
            this.tileBox.Controls.Add(this.yellowTile);
            this.tileBox.Controls.Add(this.grayTile);
            this.tileBox.Controls.Add(this.brownColor);
            this.tileBox.Controls.Add(this.blueTile);
            this.tileBox.Controls.Add(this.greenTile);
            this.tileBox.ForeColor = System.Drawing.Color.Red;
            this.tileBox.Location = new System.Drawing.Point(13, 13);
            this.tileBox.Name = "tileBox";
            this.tileBox.Size = new System.Drawing.Size(124, 199);
            this.tileBox.TabIndex = 0;
            this.tileBox.TabStop = false;
            this.tileBox.Text = "Tile Selector";
            // 
            // redTile
            // 
            this.redTile.BackColor = System.Drawing.Color.Red;
            this.redTile.Location = new System.Drawing.Point(63, 135);
            this.redTile.Name = "redTile";
            this.redTile.Size = new System.Drawing.Size(55, 51);
            this.redTile.TabIndex = 5;
            this.redTile.UseVisualStyleBackColor = false;
            this.redTile.Click += new System.EventHandler(this.button_Click);
            // 
            // yellowTile
            // 
            this.yellowTile.BackColor = System.Drawing.Color.Yellow;
            this.yellowTile.Location = new System.Drawing.Point(6, 135);
            this.yellowTile.Name = "yellowTile";
            this.yellowTile.Size = new System.Drawing.Size(55, 51);
            this.yellowTile.TabIndex = 4;
            this.yellowTile.UseVisualStyleBackColor = false;
            this.yellowTile.Click += new System.EventHandler(this.button_Click);
            // 
            // grayTile
            // 
            this.grayTile.BackColor = System.Drawing.Color.Gray;
            this.grayTile.Location = new System.Drawing.Point(63, 78);
            this.grayTile.Name = "grayTile";
            this.grayTile.Size = new System.Drawing.Size(55, 51);
            this.grayTile.TabIndex = 3;
            this.grayTile.UseVisualStyleBackColor = false;
            this.grayTile.Click += new System.EventHandler(this.button_Click);
            // 
            // brownColor
            // 
            this.brownColor.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.brownColor.Location = new System.Drawing.Point(6, 78);
            this.brownColor.Name = "brownColor";
            this.brownColor.Size = new System.Drawing.Size(55, 51);
            this.brownColor.TabIndex = 2;
            this.brownColor.UseVisualStyleBackColor = false;
            this.brownColor.Click += new System.EventHandler(this.button_Click);
            // 
            // blueTile
            // 
            this.blueTile.BackColor = System.Drawing.Color.Aqua;
            this.blueTile.Location = new System.Drawing.Point(63, 21);
            this.blueTile.Name = "blueTile";
            this.blueTile.Size = new System.Drawing.Size(55, 51);
            this.blueTile.TabIndex = 1;
            this.blueTile.UseVisualStyleBackColor = false;
            this.blueTile.Click += new System.EventHandler(this.button_Click);
            // 
            // greenTile
            // 
            this.greenTile.BackColor = System.Drawing.Color.Lime;
            this.greenTile.Location = new System.Drawing.Point(6, 21);
            this.greenTile.Name = "greenTile";
            this.greenTile.Size = new System.Drawing.Size(55, 51);
            this.greenTile.TabIndex = 0;
            this.greenTile.UseVisualStyleBackColor = false;
            this.greenTile.Click += new System.EventHandler(this.button_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.currentTile);
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(13, 218);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(118, 114);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Current Tile";
            // 
            // currentTile
            // 
            this.currentTile.BackColor = System.Drawing.Color.Lime;
            this.currentTile.Location = new System.Drawing.Point(30, 35);
            this.currentTile.Name = "currentTile";
            this.currentTile.Size = new System.Drawing.Size(55, 51);
            this.currentTile.TabIndex = 0;
            this.currentTile.UseVisualStyleBackColor = false;
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.LavenderBlush;
            this.saveButton.Location = new System.Drawing.Point(19, 368);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(112, 86);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "Save File";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.BackColor = System.Drawing.Color.LavenderBlush;
            this.loadButton.Location = new System.Drawing.Point(19, 460);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(112, 86);
            this.loadButton.TabIndex = 8;
            this.loadButton.Text = "Load File";
            this.loadButton.UseVisualStyleBackColor = false;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // mapBox
            // 
            this.mapBox.BackColor = System.Drawing.Color.Cornsilk;
            this.mapBox.Location = new System.Drawing.Point(143, 13);
            this.mapBox.Name = "mapBox";
            this.mapBox.Size = new System.Drawing.Size(500, 500);
            this.mapBox.TabIndex = 9;
            this.mapBox.TabStop = false;
            this.mapBox.Text = "Map";
            // 
            // LevelEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(682, 591);
            this.Controls.Add(this.mapBox);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tileBox);
            this.Name = "LevelEditor";
            this.Text = "Level Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LevelEditor_FormClosing);
            this.Load += new System.EventHandler(this.LevelEditor_Load);
            this.tileBox.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox tileBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button redTile;
        private System.Windows.Forms.Button yellowTile;
        private System.Windows.Forms.Button grayTile;
        private System.Windows.Forms.Button brownColor;
        private System.Windows.Forms.Button blueTile;
        private System.Windows.Forms.Button greenTile;
        private System.Windows.Forms.Button currentTile;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.GroupBox mapBox;
    }
}