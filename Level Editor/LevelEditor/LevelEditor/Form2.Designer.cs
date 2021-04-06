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
            this.textureBox = new System.Windows.Forms.GroupBox();
            this.texturePic = new System.Windows.Forms.PictureBox();
            this.backgroundButton = new System.Windows.Forms.Button();
            this.overlayButton = new System.Windows.Forms.Button();
            this.basicColors = new System.Windows.Forms.GroupBox();
            this.colorSelect = new System.Windows.Forms.PictureBox();
            this.currentColorLabel = new System.Windows.Forms.Label();
            this.vectorIndicators = new System.Windows.Forms.GroupBox();
            this.color15 = new System.Windows.Forms.Button();
            this.color3 = new System.Windows.Forms.Button();
            this.color4 = new System.Windows.Forms.Button();
            this.color14 = new System.Windows.Forms.Button();
            this.color11 = new System.Windows.Forms.Button();
            this.color2 = new System.Windows.Forms.Button();
            this.color1 = new System.Windows.Forms.Button();
            this.colorPick = new System.Windows.Forms.ColorDialog();
            this.collisionsButton = new System.Windows.Forms.Button();
            this.rotateTexture = new System.Windows.Forms.Button();
            this.texture1 = new System.Windows.Forms.PictureBox();
            this.texture2 = new System.Windows.Forms.PictureBox();
            this.texture4 = new System.Windows.Forms.PictureBox();
            this.texture3 = new System.Windows.Forms.PictureBox();
            this.texture8 = new System.Windows.Forms.PictureBox();
            this.texture7 = new System.Windows.Forms.PictureBox();
            this.texture6 = new System.Windows.Forms.PictureBox();
            this.texture5 = new System.Windows.Forms.PictureBox();
            this.textures = new System.Windows.Forms.GroupBox();
            this.textureBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.texturePic)).BeginInit();
            this.basicColors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorSelect)).BeginInit();
            this.vectorIndicators.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.texture1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.texture2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.texture4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.texture3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.texture8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.texture7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.texture6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.texture5)).BeginInit();
            this.textures.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.LavenderBlush;
            this.saveButton.Location = new System.Drawing.Point(223, 434);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(90, 80);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "Save File";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.BackColor = System.Drawing.Color.LavenderBlush;
            this.loadButton.Location = new System.Drawing.Point(223, 352);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(90, 80);
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
            // backgroundButton
            // 
            this.backgroundButton.BackColor = System.Drawing.Color.LavenderBlush;
            this.backgroundButton.Location = new System.Drawing.Point(320, 273);
            this.backgroundButton.Name = "backgroundButton";
            this.backgroundButton.Size = new System.Drawing.Size(107, 72);
            this.backgroundButton.TabIndex = 15;
            this.backgroundButton.Text = "Background";
            this.backgroundButton.UseVisualStyleBackColor = false;
            this.backgroundButton.Click += new System.EventHandler(this.backgroundButton_Click);
            // 
            // overlayButton
            // 
            this.overlayButton.BackColor = System.Drawing.Color.LavenderBlush;
            this.overlayButton.Location = new System.Drawing.Point(320, 434);
            this.overlayButton.Name = "overlayButton";
            this.overlayButton.Size = new System.Drawing.Size(107, 80);
            this.overlayButton.TabIndex = 16;
            this.overlayButton.Text = "Overlay";
            this.overlayButton.UseVisualStyleBackColor = false;
            this.overlayButton.Click += new System.EventHandler(this.overlayButton_Click);
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
            this.vectorIndicators.Controls.Add(this.color15);
            this.vectorIndicators.Controls.Add(this.color3);
            this.vectorIndicators.Controls.Add(this.color4);
            this.vectorIndicators.Controls.Add(this.color14);
            this.vectorIndicators.Controls.Add(this.color11);
            this.vectorIndicators.Controls.Add(this.color2);
            this.vectorIndicators.Controls.Add(this.color1);
            this.vectorIndicators.Location = new System.Drawing.Point(6, 21);
            this.vectorIndicators.Name = "vectorIndicators";
            this.vectorIndicators.Size = new System.Drawing.Size(385, 134);
            this.vectorIndicators.TabIndex = 0;
            this.vectorIndicators.TabStop = false;
            this.vectorIndicators.Text = "Vector2 Indicators (Right Click)";
            // 
            // color15
            // 
            this.color15.Location = new System.Drawing.Point(314, 21);
            this.color15.Name = "color15";
            this.color15.Size = new System.Drawing.Size(43, 107);
            this.color15.TabIndex = 16;
            this.color15.Text = "T\r\nR\r\nA\r\nC\r\nK";
            this.color15.UseVisualStyleBackColor = true;
            this.color15.Click += new System.EventHandler(this.ColorPicker);
            // 
            // color3
            // 
            this.color3.Location = new System.Drawing.Point(118, 23);
            this.color3.Name = "color3";
            this.color3.Size = new System.Drawing.Size(43, 105);
            this.color3.TabIndex = 15;
            this.color3.Text = "-1\r\n0";
            this.color3.UseVisualStyleBackColor = true;
            this.color3.Click += new System.EventHandler(this.ColorPicker);
            // 
            // color4
            // 
            this.color4.Location = new System.Drawing.Point(167, 23);
            this.color4.Name = "color4";
            this.color4.Size = new System.Drawing.Size(43, 105);
            this.color4.TabIndex = 14;
            this.color4.Text = "0\r\n-1";
            this.color4.UseVisualStyleBackColor = true;
            this.color4.Click += new System.EventHandler(this.ColorPicker);
            // 
            // color14
            // 
            this.color14.Location = new System.Drawing.Point(265, 21);
            this.color14.Name = "color14";
            this.color14.Size = new System.Drawing.Size(43, 107);
            this.color14.TabIndex = 13;
            this.color14.Text = "R\r\nE\r\nS\r\nE\r\nT";
            this.color14.UseVisualStyleBackColor = true;
            this.color14.Click += new System.EventHandler(this.ColorPicker);
            // 
            // color11
            // 
            this.color11.Location = new System.Drawing.Point(216, 23);
            this.color11.Name = "color11";
            this.color11.Size = new System.Drawing.Size(43, 105);
            this.color11.TabIndex = 11;
            this.color11.Text = "B\r\nE\r\nG\r\nI\r\nN";
            this.color11.UseVisualStyleBackColor = true;
            this.color11.Click += new System.EventHandler(this.ColorPicker);
            // 
            // color2
            // 
            this.color2.Location = new System.Drawing.Point(69, 23);
            this.color2.Name = "color2";
            this.color2.Size = new System.Drawing.Size(43, 105);
            this.color2.TabIndex = 1;
            this.color2.Text = "0\r\n1";
            this.color2.UseVisualStyleBackColor = true;
            this.color2.Click += new System.EventHandler(this.ColorPicker);
            // 
            // color1
            // 
            this.color1.Location = new System.Drawing.Point(20, 23);
            this.color1.Name = "color1";
            this.color1.Size = new System.Drawing.Size(43, 105);
            this.color1.TabIndex = 0;
            this.color1.Text = "1\r\n0";
            this.color1.UseVisualStyleBackColor = true;
            this.color1.Click += new System.EventHandler(this.ColorPicker);
            // 
            // collisionsButton
            // 
            this.collisionsButton.BackColor = System.Drawing.Color.LavenderBlush;
            this.collisionsButton.Location = new System.Drawing.Point(320, 352);
            this.collisionsButton.Name = "collisionsButton";
            this.collisionsButton.Size = new System.Drawing.Size(107, 75);
            this.collisionsButton.TabIndex = 18;
            this.collisionsButton.Text = "Collisions";
            this.collisionsButton.UseVisualStyleBackColor = false;
            this.collisionsButton.Click += new System.EventHandler(this.collisionsButton_Click);
            // 
            // rotateTexture
            // 
            this.rotateTexture.BackColor = System.Drawing.Color.LavenderBlush;
            this.rotateTexture.Location = new System.Drawing.Point(222, 273);
            this.rotateTexture.Name = "rotateTexture";
            this.rotateTexture.Size = new System.Drawing.Size(91, 72);
            this.rotateTexture.TabIndex = 19;
            this.rotateTexture.Text = "Rotate \r\nTexture\r\n";
            this.rotateTexture.UseVisualStyleBackColor = false;
            this.rotateTexture.Click += new System.EventHandler(this.rotateTexture_Click);
            // 
            // texture1
            // 
            this.texture1.Location = new System.Drawing.Point(38, 47);
            this.texture1.Name = "texture1";
            this.texture1.Size = new System.Drawing.Size(74, 73);
            this.texture1.TabIndex = 20;
            this.texture1.TabStop = false;
            this.texture1.Click += new System.EventHandler(this.ChangePath);
            // 
            // texture2
            // 
            this.texture2.Location = new System.Drawing.Point(118, 47);
            this.texture2.Name = "texture2";
            this.texture2.Size = new System.Drawing.Size(74, 73);
            this.texture2.TabIndex = 21;
            this.texture2.TabStop = false;
            this.texture2.Click += new System.EventHandler(this.ChangePath);
            // 
            // texture4
            // 
            this.texture4.Location = new System.Drawing.Point(278, 47);
            this.texture4.Name = "texture4";
            this.texture4.Size = new System.Drawing.Size(74, 73);
            this.texture4.TabIndex = 22;
            this.texture4.TabStop = false;
            this.texture4.Click += new System.EventHandler(this.ChangePath);
            // 
            // texture3
            // 
            this.texture3.Location = new System.Drawing.Point(198, 47);
            this.texture3.Name = "texture3";
            this.texture3.Size = new System.Drawing.Size(74, 73);
            this.texture3.TabIndex = 23;
            this.texture3.TabStop = false;
            this.texture3.Click += new System.EventHandler(this.ChangePath);
            // 
            // texture8
            // 
            this.texture8.Location = new System.Drawing.Point(278, 126);
            this.texture8.Name = "texture8";
            this.texture8.Size = new System.Drawing.Size(74, 73);
            this.texture8.TabIndex = 24;
            this.texture8.TabStop = false;
            this.texture8.Click += new System.EventHandler(this.ChangePath);
            // 
            // texture7
            // 
            this.texture7.Location = new System.Drawing.Point(198, 126);
            this.texture7.Name = "texture7";
            this.texture7.Size = new System.Drawing.Size(74, 73);
            this.texture7.TabIndex = 25;
            this.texture7.TabStop = false;
            this.texture7.Click += new System.EventHandler(this.ChangePath);
            // 
            // texture6
            // 
            this.texture6.Location = new System.Drawing.Point(118, 126);
            this.texture6.Name = "texture6";
            this.texture6.Size = new System.Drawing.Size(74, 73);
            this.texture6.TabIndex = 26;
            this.texture6.TabStop = false;
            this.texture6.Click += new System.EventHandler(this.ChangePath);
            // 
            // texture5
            // 
            this.texture5.Location = new System.Drawing.Point(38, 126);
            this.texture5.Name = "texture5";
            this.texture5.Size = new System.Drawing.Size(74, 73);
            this.texture5.TabIndex = 27;
            this.texture5.TabStop = false;
            this.texture5.Click += new System.EventHandler(this.ChangePath);
            // 
            // textures
            // 
            this.textures.Controls.Add(this.texture5);
            this.textures.Controls.Add(this.texture1);
            this.textures.Controls.Add(this.texture6);
            this.textures.Controls.Add(this.texture3);
            this.textures.Controls.Add(this.texture4);
            this.textures.Controls.Add(this.texture7);
            this.textures.Controls.Add(this.texture8);
            this.textures.Controls.Add(this.texture2);
            this.textures.Location = new System.Drawing.Point(19, 32);
            this.textures.Name = "textures";
            this.textures.Size = new System.Drawing.Size(408, 235);
            this.textures.TabIndex = 28;
            this.textures.TabStop = false;
            this.textures.Text = "Textures";
            // 
            // levelEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(1252, 854);
            this.Controls.Add(this.overlayButton);
            this.Controls.Add(this.textures);
            this.Controls.Add(this.rotateTexture);
            this.Controls.Add(this.collisionsButton);
            this.Controls.Add(this.basicColors);
            this.Controls.Add(this.backgroundButton);
            this.Controls.Add(this.textureBox);
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
            ((System.ComponentModel.ISupportInitialize)(this.texture1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.texture2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.texture4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.texture3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.texture8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.texture7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.texture6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.texture5)).EndInit();
            this.textures.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.GroupBox mapBox;
        private System.Windows.Forms.GroupBox textureBox;
        private System.Windows.Forms.PictureBox texturePic;
        private System.Windows.Forms.Button backgroundButton;
        private System.Windows.Forms.Button overlayButton;
        private System.Windows.Forms.GroupBox basicColors;
        private System.Windows.Forms.GroupBox vectorIndicators;
        private System.Windows.Forms.Button color2;
        private System.Windows.Forms.Button color1;
        private System.Windows.Forms.ColorDialog colorPick;
        private System.Windows.Forms.Button color14;
        private System.Windows.Forms.Button color11;
        private System.Windows.Forms.PictureBox colorSelect;
        private System.Windows.Forms.Label currentColorLabel;
        private System.Windows.Forms.Button color3;
        private System.Windows.Forms.Button color4;
        private System.Windows.Forms.Button color15;
        private System.Windows.Forms.Button collisionsButton;
        private System.Windows.Forms.Button rotateTexture;
        private System.Windows.Forms.PictureBox texture1;
        private System.Windows.Forms.PictureBox texture2;
        private System.Windows.Forms.PictureBox texture4;
        private System.Windows.Forms.PictureBox texture3;
        private System.Windows.Forms.PictureBox texture8;
        private System.Windows.Forms.PictureBox texture7;
        private System.Windows.Forms.PictureBox texture6;
        private System.Windows.Forms.PictureBox texture5;
        private System.Windows.Forms.GroupBox textures;
    }
}