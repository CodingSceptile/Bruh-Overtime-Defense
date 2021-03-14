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
            this.textureBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.texturePic)).BeginInit();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.LavenderBlush;
            this.saveButton.Location = new System.Drawing.Point(12, 564);
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
            this.loadButton.Location = new System.Drawing.Point(12, 656);
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
            this.mapBox.Location = new System.Drawing.Point(338, 13);
            this.mapBox.Name = "mapBox";
            this.mapBox.Size = new System.Drawing.Size(759, 729);
            this.mapBox.TabIndex = 9;
            this.mapBox.TabStop = false;
            this.mapBox.Text = "Map";
            // 
            // pictureSelect
            // 
            this.pictureSelect.FormattingEnabled = true;
            this.pictureSelect.ItemHeight = 16;
            this.pictureSelect.Items.AddRange(new object[] {
            "Test Image 1",
            "Test Image 2",
            "Test Image 3 ",
            "Test Image 4",
            "Test Image 5"});
            this.pictureSelect.Location = new System.Drawing.Point(12, 13);
            this.pictureSelect.Name = "pictureSelect";
            this.pictureSelect.Size = new System.Drawing.Size(295, 84);
            this.pictureSelect.TabIndex = 10;
            this.pictureSelect.SelectedIndexChanged += new System.EventHandler(this.pictureSelect_SelectedIndexChanged);
            // 
            // textureBox
            // 
            this.textureBox.Controls.Add(this.texturePic);
            this.textureBox.Location = new System.Drawing.Point(13, 126);
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
            // LevelEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(1252, 854);
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

        }

        #endregion
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.GroupBox mapBox;
        private System.Windows.Forms.ListBox pictureSelect;
        private System.Windows.Forms.GroupBox textureBox;
        private System.Windows.Forms.PictureBox texturePic;
    }
}