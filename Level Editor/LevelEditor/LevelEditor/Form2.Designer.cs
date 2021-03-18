namespace LevelEditor
{
    partial class levelEditor
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
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.mapBox = new System.Windows.Forms.GroupBox();
            this.pictureSelect = new System.Windows.Forms.ListBox();
            this.textureBox = new System.Windows.Forms.GroupBox();
            this.texturePic = new System.Windows.Forms.PictureBox();
            this.recentlyUsed = new System.Windows.Forms.ListBox();
            this.texturesLabel = new System.Windows.Forms.Label();
            this.recentlyUsedLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.basicColors = new System.Windows.Forms.GroupBox();
            this.colorSelect = new System.Windows.Forms.PictureBox();
            this.currentColorLabel = new System.Windows.Forms.Label();
            this.vectorIndicators = new System.Windows.Forms.GroupBox();
            this.color14 = new System.Windows.Forms.Button();
            this.color11 = new System.Windows.Forms.Button();
            this.color2 = new System.Windows.Forms.Button();
            this.color1 = new System.Windows.Forms.Button();
            this.colorPick = new System.Windows.Forms.ColorDialog();
            this.textureBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.texturePic)).BeginInit();
            this.basicColors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorSelect)).BeginInit();
            this.vectorIndicators.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.LavenderBlush;
            this.saveButton.Location = new System.Drawing.Point(223, 434);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(90, 86);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "Save File";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.BackColor = System.Drawing.Color.LavenderBlush;
            this.loadButton.Location = new System.Drawing.Point(319, 434);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(91, 86);
            this.loadButton.TabIndex = 8;
            this.loadButton.Text = "Load File";
            this.loadButton.UseVisualStyleBackColor = false;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // mapBox
            // 
            this.mapBox.BackColor = System.Drawing.Color.Cornsilk;
            this.mapBox.Location = new System.Drawing.Point(433, 12);
            this.mapBox.Name = "mapBox";
            this.mapBox.Size = new System.Drawing.Size(750, 750);
            this.mapBox.TabIndex = 9;
            this.mapBox.TabStop = false;
            this.mapBox.Text = "Map";
            // 
            // pictureSelect
            // 
            this.pictureSelect.FormattingEnabled = true;
            this.pictureSelect.ItemHeight = 16;
            this.pictureSelect.Location = new System.Drawing.Point(115, 13);
            this.pictureSelect.Name = "pictureSelect";
            this.pictureSelect.Size = new System.Drawing.Size(295, 148);
            this.pictureSelect.TabIndex = 10;
            this.pictureSelect.SelectedIndexChanged += new System.EventHandler(this.pictureSelect_SelectedIndexChanged);
            // 
            // textureBox
            // 
            this.textureBox.Controls.Add(this.texturePic);
            this.textureBox.Location = new System.Drawing.Point(17, 273);
            this.textureBox.Name = "textureBox";
            this.textureBox.Size = new System.Drawing.Size(199, 206);
            this.textureBox.TabIndex = 11;
            this.textureBox.TabStop = false;
            this.textureBox.Text = "Current Texture";
            // 
            // texturePic
            // 
            this.texturePic.Location = new System.Drawing.Point(22, 37);
            this.texturePic.Name = "texturePic";
            this.texturePic.Size = new System.Drawing.Size(151, 143);
            this.texturePic.TabIndex = 0;
            this.texturePic.TabStop = false;
            // 
            // recentlyUsed
            // 
            this.recentlyUsed.FormattingEnabled = true;
            this.recentlyUsed.ItemHeight = 16;
            this.recentlyUsed.Location = new System.Drawing.Point(115, 167);
            this.recentlyUsed.Name = "recentlyUsed";
            this.recentlyUsed.Size = new System.Drawing.Size(294, 100);
            this.recentlyUsed.TabIndex = 12;
            this.recentlyUsed.SelectedIndexChanged += new System.EventHandler(this.RecentSelect);
            // 
            // texturesLabel
            // 
            this.texturesLabel.AutoSize = true;
            this.texturesLabel.BackColor = System.Drawing.Color.Cornsilk;
            this.texturesLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.texturesLabel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.texturesLabel.Location = new System.Drawing.Point(12, 13);
            this.texturesLabel.Name = "texturesLabel";
            this.texturesLabel.Size = new System.Drawing.Size(91, 27);
            this.texturesLabel.TabIndex = 13;
            this.texturesLabel.Text = "Textures";
            // 
            // recentlyUsedLabel
            // 
            this.recentlyUsedLabel.AutoSize = true;
            this.recentlyUsedLabel.BackColor = System.Drawing.Color.Cornsilk;
            this.recentlyUsedLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.recentlyUsedLabel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recentlyUsedLabel.Location = new System.Drawing.Point(7, 167);
            this.recentlyUsedLabel.Name = "recentlyUsedLabel";
            this.recentlyUsedLabel.Size = new System.Drawing.Size(92, 54);
            this.recentlyUsedLabel.TabIndex = 14;
            this.recentlyUsedLabel.Text = "Recently\r\nUsed\r\n";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LavenderBlush;
            this.button1.Location = new System.Drawing.Point(223, 274);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(187, 72);
            this.button1.TabIndex = 15;
            this.button1.Text = "Background";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LavenderBlush;
            this.button2.Location = new System.Drawing.Point(223, 353);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(187, 75);
            this.button2.TabIndex = 16;
            this.button2.Text = "Overlay";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // basicColors
            // 
            this.basicColors.Controls.Add(this.colorSelect);
            this.basicColors.Controls.Add(this.currentColorLabel);
            this.basicColors.Controls.Add(this.vectorIndicators);
            this.basicColors.Location = new System.Drawing.Point(13, 520);
            this.basicColors.Name = "basicColors";
            this.basicColors.Size = new System.Drawing.Size(397, 242);
            this.basicColors.TabIndex = 17;
            this.basicColors.TabStop = false;
            this.basicColors.Text = "Vector2 and Tower(?) indicators";
            // 
            // colorSelect
            // 
            this.colorSelect.BackColor = System.Drawing.Color.Red;
            this.colorSelect.Location = new System.Drawing.Point(116, 161);
            this.colorSelect.Name = "colorSelect";
            this.colorSelect.Size = new System.Drawing.Size(275, 75);
            this.colorSelect.TabIndex = 3;
            this.colorSelect.TabStop = false;
            // 
            // currentColorLabel
            // 
            this.currentColorLabel.AutoSize = true;
            this.currentColorLabel.Location = new System.Drawing.Point(18, 190);
            this.currentColorLabel.Name = "currentColorLabel";
            this.currentColorLabel.Size = new System.Drawing.Size(92, 17);
            this.currentColorLabel.TabIndex = 2;
            this.currentColorLabel.Text = "Current Color";
            // 
            // vectorIndicators
            // 
            this.vectorIndicators.Controls.Add(this.color14);
            this.vectorIndicators.Controls.Add(this.color11);
            this.vectorIndicators.Controls.Add(this.color2);
            this.vectorIndicators.Controls.Add(this.color1);
            this.vectorIndicators.Location = new System.Drawing.Point(6, 21);
            this.vectorIndicators.Name = "vectorIndicators";
            this.vectorIndicators.Size = new System.Drawing.Size(260, 134);
            this.vectorIndicators.TabIndex = 0;
            this.vectorIndicators.TabStop = false;
            this.vectorIndicators.Text = "Vector2 Indicators (Right Click)";
            // 
            // color14
            // 
            this.color14.Location = new System.Drawing.Point(167, 21);
            this.color14.Name = "color14";
            this.color14.Size = new System.Drawing.Size(43, 107);
            this.color14.TabIndex = 13;
            this.color14.Text = "R\r\nE\r\nS\r\nE\r\nT";
            this.color14.UseVisualStyleBackColor = true;
            this.color14.Click += new System.EventHandler(this.ColorPicker);
            // 
            // color11
            // 
            this.color11.Location = new System.Drawing.Point(118, 23);
            this.color11.Name = "color11";
            this.color11.Size = new System.Drawing.Size(43, 105);
            this.color11.TabIndex = 11;
            this.color11.Text = "-1\r\n-1";
            this.color11.UseVisualStyleBackColor = true;
            this.color11.Click += new System.EventHandler(this.ColorPicker);
            // 
            // color2
            // 
            this.color2.Location = new System.Drawing.Point(69, 23);
            this.color2.Name = "color2";
            this.color2.Size = new System.Drawing.Size(43, 105);
            this.color2.TabIndex = 1;
            this.color2.Text = "1\r\n-1";
            this.color2.UseVisualStyleBackColor = true;
            this.color2.Click += new System.EventHandler(this.ColorPicker);
            // 
            // color1
            // 
            this.color1.Location = new System.Drawing.Point(20, 23);
            this.color1.Name = "color1";
            this.color1.Size = new System.Drawing.Size(43, 105);
            this.color1.TabIndex = 0;
            this.color1.Text = "-1\r\n1";
            this.color1.UseVisualStyleBackColor = true;
            this.color1.Click += new System.EventHandler(this.ColorPicker);
            // 
            // levelEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(1252, 854);
            this.Controls.Add(this.basicColors);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.recentlyUsedLabel);
            this.Controls.Add(this.texturesLabel);
            this.Controls.Add(this.recentlyUsed);
            this.Controls.Add(this.textureBox);
            this.Controls.Add(this.pictureSelect);
            this.Controls.Add(this.mapBox);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.saveButton);
            this.Name = "levelEditor";
            this.Text = "Level Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LevelEditor_FormClosing);
            this.Load += new System.EventHandler(this.LevelEditor_Load);
            this.textureBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.texturePic)).EndInit();
            this.basicColors.ResumeLayout(false);
            this.basicColors.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorSelect)).EndInit();
            this.vectorIndicators.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.GroupBox mapBox;
        private System.Windows.Forms.ListBox pictureSelect;
        private System.Windows.Forms.GroupBox textureBox;
        private System.Windows.Forms.PictureBox texturePic;
        private System.Windows.Forms.ListBox recentlyUsed;
        private System.Windows.Forms.Label texturesLabel;
        private System.Windows.Forms.Label recentlyUsedLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox basicColors;
        private System.Windows.Forms.GroupBox vectorIndicators;
        private System.Windows.Forms.Button color2;
        private System.Windows.Forms.Button color1;
        private System.Windows.Forms.ColorDialog colorPick;
        private System.Windows.Forms.Button color14;
        private System.Windows.Forms.Button color11;
        private System.Windows.Forms.PictureBox colorSelect;
        private System.Windows.Forms.Label currentColorLabel;
    }
}