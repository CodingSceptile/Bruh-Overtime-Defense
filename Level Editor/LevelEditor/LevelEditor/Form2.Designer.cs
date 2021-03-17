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
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.mapBox = new System.Windows.Forms.GroupBox();
            this.pictureSelect = new System.Windows.Forms.ListBox();
            this.textureBox = new System.Windows.Forms.GroupBox();
            this.texturePic = new System.Windows.Forms.PictureBox();
            this.recentlyUsed = new System.Windows.Forms.ListBox();
            this.texturesLabel = new System.Windows.Forms.Label();
            this.recentlyUsedLabel = new System.Windows.Forms.Label();
            this.textureBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.texturePic)).BeginInit();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.LavenderBlush;
            this.saveButton.Location = new System.Drawing.Point(12, 652);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(295, 86);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "Save File";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.BackColor = System.Drawing.Color.LavenderBlush;
            this.loadButton.Location = new System.Drawing.Point(12, 744);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(295, 86);
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
            this.pictureSelect.Size = new System.Drawing.Size(295, 308);
            this.pictureSelect.TabIndex = 10;
            this.pictureSelect.SelectedIndexChanged += new System.EventHandler(this.pictureSelect_SelectedIndexChanged);
            // 
            // textureBox
            // 
            this.textureBox.Controls.Add(this.texturePic);
            this.textureBox.Location = new System.Drawing.Point(158, 433);
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
            this.recentlyUsed.Location = new System.Drawing.Point(115, 327);
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
            this.recentlyUsedLabel.Location = new System.Drawing.Point(7, 327);
            this.recentlyUsedLabel.Name = "recentlyUsedLabel";
            this.recentlyUsedLabel.Size = new System.Drawing.Size(92, 54);
            this.recentlyUsedLabel.TabIndex = 14;
            this.recentlyUsedLabel.Text = "Recently\r\nUsed\r\n";
            // 
            // LevelEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(1252, 854);
            this.Controls.Add(this.recentlyUsedLabel);
            this.Controls.Add(this.texturesLabel);
            this.Controls.Add(this.recentlyUsed);
            this.Controls.Add(this.textureBox);
            this.Controls.Add(this.pictureSelect);
            this.Controls.Add(this.mapBox);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.saveButton);
            this.Name = "LevelEditor";
            this.Text = "Level Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LevelEditor_FormClosing);
            this.Load += new System.EventHandler(this.LevelEditor_Load);
            this.textureBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.texturePic)).EndInit();
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
    }
}