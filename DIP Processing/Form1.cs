using System;
using System.Drawing;
using System.Drawing.Imaging;
using ImageProcess2;
using OpenCvSharp;
using OpenCvSharp.Extensions; // Add this namespace at the top of your file


namespace DIP_Processing
{
    public partial class Form1 : Form
    {
        Bitmap loaded, processed, subtractImage;
        VideoCapture capture;
        Mat frame;
        private Thread camera;
        bool isCameraRunning = false;



        private void CaptureCamera()
        {
            camera = new Thread(new ThreadStart(CaptureCameraCallback));
            camera.Start();
        }

        private void CaptureCameraCallback()
        {

            frame = new Mat();
            capture = new VideoCapture(0);

            // Check if the camera opened successfully
            if (!capture.IsOpened())
            {
                Console.WriteLine("Camera could not be opened.");
                return; // Exit if the camera cannot be opened
            }

            while (isCameraRunning)
            {
                // Read frame only if camera is running
                if (capture.Read(frame))
                {
                    loaded = BitmapConverter.ToBitmap(frame);

                    // Dispose of previous image to prevent memory leaks
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();
                    }
                    pictureBox1.Image = loaded;
                }
                else
                {
                    Console.WriteLine("Failed to read from the camera.");
                }
            }

        }

        public Form1()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
            loaded = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = loaded;


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = (Bitmap)processed.Clone();
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp|GIF Image|*.gif";
                saveFileDialog.Title = "Save an Image File";
                saveFileDialog.FileName = "image"; // Default file name

                // Show the dialog and check if the user clicked the Save button
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Save the bitmap to the selected file
                    string filePath = saveFileDialog.FileName;
                    try
                    {
                        bitmap.Save(filePath); // Save as default format (PNG)
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void greyScale_Click(object sender, EventArgs e)
        {
            if (loaded == null)
            {
                return;
            }
            Bitmap b = (Bitmap)loaded.Clone();

            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;
            unsafe
            {
                byte* p = (byte*)(void*)Scan0;

                int nOffset = stride - b.Width * 3;

                byte red, green, blue;

                for (int y = 0; y < b.Height; ++y)
                {
                    for (int x = 0; x < b.Width; ++x)
                    {
                        blue = p[0];
                        green = p[1];
                        red = p[2];

                        p[0] = p[1] = p[2] = (byte)(.299 * red + .587 * green + .114 * blue);

                        p += 3;
                    }
                    p += nOffset;
                }
            }

            b.UnlockBits(bmData);

            pictureBox2.Image = b;
            processed = b;


        }

        //Basic
        private void basicCopy_Click(object sender, EventArgs e)
        {
            if (loaded == null)
            {
                return;
            }
            Bitmap a = (Bitmap)loaded.Clone();

            Bitmap b = new Bitmap(a.Width, a.Height);
            for (int x = 0; x < a.Width; x++)
            {
                for (int y = 0; y < a.Height; y++)
                {
                    Color data = a.GetPixel(x, y);
                    b.SetPixel(x, y, data);
                }

            }

            processed = b;
            pictureBox2.Image = null;
            pictureBox2.Image = processed;


        }

        private void colorInversion_Click(object sender, EventArgs e)
        {
            // GDI+ still lies to us - the return format is BGR, NOT RGB.
            if (loaded == null)
            {
                return;
            }
            Bitmap b = (Bitmap)loaded.Clone();
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;

                int nOffset = stride - b.Width * 3;
                int nWidth = b.Width * 3;

                for (int y = 0; y < b.Height; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        p[0] = (byte)(255 - p[0]);
                        ++p;
                    }
                    p += nOffset;
                }
            }

            b.UnlockBits(bmData);

            pictureBox2.Image = b;
            processed = b;

        }

        private void histogram_Click(object sender, EventArgs e)
        {
            Bitmap a = (Bitmap)loaded.Clone();
            Color sample;
            Color gray;
            Byte graydata;
            //Grayscale Convertion;
            for (int x = 0; x < a.Width; x++)
            {
                for (int y = 0; y < a.Height; y++)
                {
                    sample = a.GetPixel(x, y);
                    graydata = (byte)((sample.R + sample.G + sample.B) / 3);
                    gray = Color.FromArgb(graydata, graydata, graydata);
                    a.SetPixel(x, y, gray);
                }
            }

            //histogram 1d data;
            int[] histdata = new int[256]; // array from 0 to 255
            for (int x = 0; x < a.Width; x++)
            {
                for (int y = 0; y < a.Height; y++)
                {
                    sample = a.GetPixel(x, y);
                    histdata[sample.R]++; // can be any color property r,g or b
                }
            }

            // Bitmap Graph Generation
            // Setting empty Bitmap with background color
            Bitmap b = new Bitmap(256, 800);
            for (int x = 0; x < 256; x++)
            {
                for (int y = 0; y < 800; y++)
                {
                    b.SetPixel(x, y, Color.White);
                }
            }
            // plotting points based from histdata
            for (int x = 0; x < 256; x++)
            {
                for (int y = 0; y < Math.Min(histdata[x] / 5, b.Height - 1); y++)
                {
                    b.SetPixel(x, (b.Height - 1) - y, Color.Black);
                }
            }

            processed = b;
            pictureBox2.Image = processed;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;

        }

        private void sepia_Click(object sender, EventArgs e)
        {

            Bitmap bmp = (Bitmap)loaded.Clone();
            //get image dimension
            int width = bmp.Width;
            int height = bmp.Height;

            //color of pixel
            Color p;

            //sepia
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //get pixel value
                    p = bmp.GetPixel(x, y);

                    //extract pixel component ARGB
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    //calculate temp value
                    int tr = (int)(0.393 * r + 0.769 * g + 0.189 * b);
                    int tg = (int)(0.349 * r + 0.686 * g + 0.168 * b);
                    int tb = (int)(0.272 * r + 0.534 * g + 0.131 * b);

                    //set new RGB value
                    if (tr > 255)
                    {
                        r = 255;
                    }
                    else
                    {
                        r = tr;
                    }

                    if (tg > 255)
                    {
                        g = 255;
                    }
                    else
                    {
                        g = tg;
                    }

                    if (tb > 255)
                    {
                        b = 255;
                    }
                    else
                    {
                        b = tb;
                    }

                    //set the new RGB value in image pixel
                    bmp.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                }
            }
            processed = bmp;
            pictureBox2.Image = bmp;
        }

        private void loadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
            loaded = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = loaded;
        }

        private void loadBackground_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog2 = new OpenFileDialog();
            openFileDialog2.ShowDialog();
            processed = new Bitmap(openFileDialog2.FileName);
            pictureBox2.Image = processed;

        }

        private void subtract_Click(object sender, EventArgs e)
        {
            if (loaded == null)
            {
                return;
            }

            Bitmap input = (Bitmap)loaded.Clone();
            Bitmap output = new Bitmap(input.Width, input.Height);

            for (int y = 0; y < output.Height; y++)
            {
                for (int x = 0; x < output.Width; x++)
                {
                    Color camColor = input.GetPixel(x, y);

                    byte max = Math.Max(Math.Max(camColor.R, camColor.G), camColor.B);
                    byte min = Math.Min(Math.Min(camColor.R, camColor.G), camColor.B);

                    bool replace =
                        camColor.G != min
                        && (camColor.G == max
                        || max - camColor.G < 8)
                        && (max - min) > 96;

                    if (replace)
                        camColor = Color.Transparent;

                    // Set the output pixel
                    output.SetPixel(x, y, camColor);
                }
            }

            pictureBox3.Image = output;
            subtractImage = output;
        }

        private void loadBackground_Click_1(object sender, EventArgs e)
        {
            if (loaded == null || processed == null)
            {
                return;
            }

            subtract_Click(null, EventArgs.Empty);
            Bitmap foregroundImage = (Bitmap)subtractImage.Clone();

            Bitmap backgroundImage = (Bitmap)processed.Clone();

            Bitmap imageWithBackground = new Bitmap(backgroundImage.Width, backgroundImage.Height);

            int xPosition = (backgroundImage.Width - foregroundImage.Width) / 2;
            int yPosition = (backgroundImage.Height - foregroundImage.Height) / 2;

            using (Graphics g = Graphics.FromImage(imageWithBackground))
            {
                g.DrawImage(backgroundImage, 0, 0);

                g.DrawImage(foregroundImage, new Rectangle(0, 0, backgroundImage.Width, backgroundImage.Height));
            }

            pictureBox3.Image = imageWithBackground;
            subtractImage = imageWithBackground;
        }

        private void openCamera_Click(object sender, EventArgs e)
        {
            if (openCamera.Text.Equals("Open Camera"))
            {
                CaptureCamera();
                openCamera.Text = "Stop";
                isCameraRunning = true;
            }
            else
            {
                capture.Release();
                openCamera.Text = "Open Camera";
                isCameraRunning = false;
            }
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            try
            {
                capture.Release();
                camera.Abort();
            }
            catch (Exception ex)
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isCameraRunning)
            {
                // Stop the camera
                isCameraRunning = false; // Set the flag to false to exit the camera loop

                // Wait for the camera thread to finish
                if (camera != null && camera.IsAlive)
                {
                    camera.Join(); // Wait for the thread to finish
                }

                // Release the video capture object
                if (capture != null)
                {
                    capture.Release();
                    capture.Dispose(); // Optionally dispose of the capture object
                    capture = null; // Set to null to prevent further access
                }

                // Take a snapshot of the current image
                if (pictureBox1.Image != null)
                {
                    Bitmap snapshot = new Bitmap(pictureBox1.Image);
                    loaded = snapshot; // Store the processed snapshot
                    pictureBox1.Image = loaded;
                }
                openCamera.Text = "Open Camera";
            }
            else
            {
                Console.WriteLine("Cannot take picture if the camera isn't capturing image!");
            }
        }

        private void saveImageWithBackgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = (Bitmap)subtractImage.Clone();
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp|GIF Image|*.gif";
                saveFileDialog.Title = "Save an Image File";
                saveFileDialog.FileName = "image"; // Default file name

                // Show the dialog and check if the user clicked the Save button
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Save the bitmap to the selected file
                    string filePath = saveFileDialog.FileName;
                    try
                    {
                        bitmap.Save(filePath); // Save as default format (PNG)
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void smooth_Click(object sender, EventArgs e)
        {

            if (processed == null)
                processed = (Bitmap)loaded.Clone();
            try
            {
                if (BitmapFilter.Smooth(processed, 5))
                {
                    pictureBox2.Image = processed;


                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Smooth Operation Failed");

            }


        }
        private void gaussianBlur_Click(object sender, EventArgs e)
        {

            if (processed == null)
                processed = (Bitmap)loaded.Clone();
            try
            {
                if (BitmapFilter.GaussianBlur(processed, 5))
                {
                    pictureBox2.Image = processed;
                }

            }
            catch (Exception exception)
            {


                MessageBox.Show("Gaussian Blur Operation Failed");

            }

        }

        private void meanRemoval_Click(object sender, EventArgs e)
        {

            if (processed == null)
                processed = (Bitmap)loaded.Clone();
            try
            {

                if (BitmapFilter.MeanRemoval(processed, 5))
                {
                    pictureBox2.Image = processed;
                }

            }
            catch (Exception exception)
            {

                MessageBox.Show("Mean Removal Operation Failed");
            }

        }

        private void sharpen_Click(object sender, EventArgs e)
        {
            if (processed == null)
                processed = (Bitmap)loaded.Clone();
            try
            {
                if (BitmapFilter.Sharpen(processed, 5))
                {
                    pictureBox2.Image = processed;
                }
                else
                {
                    MessageBox.Show("Sharpen Operation Failed");
                }

            }
            catch (Exception exception)
            {


                MessageBox.Show("Sharpen Operation Failed");
            }

        }

        private void embossLaplascian_Click(object sender, EventArgs e)
        {
            if (processed == null)
                processed = (Bitmap)loaded.Clone();
            try
            {
                if (BitmapFilter.EmbossLaplacian(processed))
                {
                    pictureBox2.Image = processed;
                }
                else
                {
                    MessageBox.Show("Emboss Laplascian Operation Failed");
                }


            }
            catch (Exception exception)
            {
                MessageBox.Show("Emboss Laplascian Operation Failed");
            }
        }
    }
}