namespace DIP_Processing
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            fileToolStripMenuItem1 = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            basicCopy = new Button();
            greyScale = new Button();
            colorInversion = new Button();
            histogram = new Button();
            sepia = new Button();
            pictureBox3 = new PictureBox();
            loadImage = new Button();
            subtract = new Button();
            openBackground = new Button();
            loadBackground = new Button();
            openCamera = new Button();
            button1 = new Button();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1114, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { fileToolStripMenuItem1, openToolStripMenuItem, saveToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // fileToolStripMenuItem1
            // 
            fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            fileToolStripMenuItem1.Size = new Size(103, 22);
            fileToolStripMenuItem1.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(103, 22);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(103, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(63, 127);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(333, 295);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(449, 127);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(333, 295);
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // basicCopy
            // 
            basicCopy.Location = new Point(826, 127);
            basicCopy.Name = "basicCopy";
            basicCopy.Size = new Size(115, 37);
            basicCopy.TabIndex = 3;
            basicCopy.Text = "Basic Copy";
            basicCopy.UseVisualStyleBackColor = true;
            basicCopy.Click += basicCopy_Click;
            // 
            // greyScale
            // 
            greyScale.Location = new Point(826, 184);
            greyScale.Name = "greyScale";
            greyScale.Size = new Size(115, 37);
            greyScale.TabIndex = 4;
            greyScale.Text = "GreyScale";
            greyScale.UseVisualStyleBackColor = true;
            greyScale.Click += greyScale_Click;
            // 
            // colorInversion
            // 
            colorInversion.Location = new Point(826, 239);
            colorInversion.Name = "colorInversion";
            colorInversion.Size = new Size(115, 37);
            colorInversion.TabIndex = 5;
            colorInversion.Text = "Color Inversion";
            colorInversion.UseVisualStyleBackColor = true;
            colorInversion.Click += colorInversion_Click;
            // 
            // histogram
            // 
            histogram.Location = new Point(826, 299);
            histogram.Name = "histogram";
            histogram.Size = new Size(115, 37);
            histogram.TabIndex = 6;
            histogram.Text = "Histogram";
            histogram.UseVisualStyleBackColor = true;
            histogram.Click += histogram_Click;
            // 
            // sepia
            // 
            sepia.Location = new Point(826, 361);
            sepia.Name = "sepia";
            sepia.Size = new Size(115, 37);
            sepia.TabIndex = 7;
            sepia.Text = "Sepia";
            sepia.UseVisualStyleBackColor = true;
            sepia.Click += sepia_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Location = new Point(244, 500);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(333, 295);
            pictureBox3.TabIndex = 8;
            pictureBox3.TabStop = false;
            // 
            // loadImage
            // 
            loadImage.Location = new Point(362, 428);
            loadImage.Name = "loadImage";
            loadImage.Size = new Size(115, 37);
            loadImage.TabIndex = 9;
            loadImage.Text = "Open Image";
            loadImage.UseVisualStyleBackColor = true;
            loadImage.Click += loadImage_Click;
            // 
            // subtract
            // 
            subtract.Location = new Point(826, 428);
            subtract.Name = "subtract";
            subtract.Size = new Size(115, 37);
            subtract.TabIndex = 10;
            subtract.Text = "Subtract";
            subtract.UseVisualStyleBackColor = true;
            subtract.Click += subtract_Click;
            // 
            // openBackground
            // 
            openBackground.Location = new Point(504, 428);
            openBackground.Name = "openBackground";
            openBackground.Size = new Size(115, 37);
            openBackground.TabIndex = 11;
            openBackground.Text = "Open Background";
            openBackground.UseVisualStyleBackColor = true;
            openBackground.Click += loadBackground_Click;
            // 
            // loadBackground
            // 
            loadBackground.Location = new Point(650, 428);
            loadBackground.Name = "loadBackground";
            loadBackground.Size = new Size(115, 37);
            loadBackground.TabIndex = 12;
            loadBackground.Text = "Load Background";
            loadBackground.UseVisualStyleBackColor = true;
            loadBackground.Click += loadBackground_Click_1;
            // 
            // openCamera
            // 
            openCamera.Location = new Point(81, 84);
            openCamera.Name = "openCamera";
            openCamera.Size = new Size(115, 37);
            openCamera.TabIndex = 13;
            openCamera.Text = "Open Camera";
            openCamera.UseVisualStyleBackColor = true;
            openCamera.Click += openCamera_Click;
            // 
            // button1
            // 
            button1.Location = new Point(265, 84);
            button1.Name = "button1";
            button1.Size = new Size(115, 37);
            button1.TabIndex = 14;
            button1.Text = "Snapshot";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1114, 974);
            Controls.Add(button1);
            Controls.Add(openCamera);
            Controls.Add(loadBackground);
            Controls.Add(openBackground);
            Controls.Add(subtract);
            Controls.Add(loadImage);
            Controls.Add(pictureBox3);
            Controls.Add(sepia);
            Controls.Add(histogram);
            Controls.Add(colorInversion);
            Controls.Add(greyScale);
            Controls.Add(basicCopy);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem fileToolStripMenuItem1;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Button basicCopy;
        private Button greyScale;
        private Button colorInversion;
        private Button histogram;
        private Button sepia;
        private PictureBox pictureBox3;
        private Button loadImage;
        private Button subtract;
        private Button openBackground;
        private Button loadBackground;
        private Button openCamera;
        private Button button1;
    }
}
