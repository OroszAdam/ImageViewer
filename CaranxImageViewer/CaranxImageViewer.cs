using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.Linq;

namespace CaranxImageViewer
{
    public partial class CaranxImageViewer : Form
    {
        private int currentImageIndex = 0;

        // Conversion rate: pixel to millimetres
        public const int pixelinMM = 2;

        private List<ImageData> imageDataList;
        private GraphicsPath curvePath;
        private List<PointF> pathPoints;

        Graphics graphics;
        Pen greenPen;

        private int selectedPointIndex;
        private bool isDragging = false;
        public CaranxImageViewer()
        {
            InitializeComponent();
            imageNumberInfo.Text = "No images loaded";
            imageDataList = new List<ImageData>();
            graphics = pictureBox1.CreateGraphics();
            greenPen = new Pen(Color.Green, 1);
        }

        private void buttonLoadImages_Click(object sender, EventArgs e)
        {
            LoadImages();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            // Change the currently shown image based on scroll value
            currentImageIndex = e.NewValue;
            ShowCurrentImage();
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if(imageDataList != null && imageDataList.Count > 0 && currentImageIndex >= 0 && currentImageIndex < imageDataList.Count)
            {
                // Check if a point is being clicked
                for (int i = 0; i < imageDataList[currentImageIndex].Points.Length; i++)
                {
                    RectangleF rect = new RectangleF(imageDataList[currentImageIndex].Points[i].X - 3, imageDataList[currentImageIndex].Points[i].Y - 3, 10, 10);
                    if (rect.Contains(e.Location))
                    {
                        selectedPointIndex = i;
                        isDragging = true;
                        break;
                    }
                }
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && selectedPointIndex != null)
            {
                // Update the selected point's position
                imageDataList[currentImageIndex].Points[selectedPointIndex].X = e.X;
                imageDataList[currentImageIndex].Points[selectedPointIndex].Y = e.Y;

                UpdateGraphics(imageDataList[currentImageIndex].Points);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            if (imageDataList[currentImageIndex].nrOfDefinedPoints == 3)
            {
                imagePointDataText.Text = $"Landmark coordinates:{Environment.NewLine}";
                imagePointDataText.Text += string.Format($"X: {imageDataList[currentImageIndex].Points[0].X}," +
                $" Y: {imageDataList[currentImageIndex].Points[0].Y}{Environment.NewLine}" +
                $"X: {imageDataList[currentImageIndex].Points[1].X}," +
                $" Y: {imageDataList[currentImageIndex].Points[1].Y}{Environment.NewLine}" +
                $"X: {imageDataList[currentImageIndex].Points[2].X}," +
                $" Y: {imageDataList[currentImageIndex].Points[2].Y}{Environment.NewLine}");
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            // Get the PointData object for the current image
            ImageData currentPointData = imageDataList.Find(p => p.ImageName == imageDataList[currentImageIndex].ImageName);
            if(currentPointData != null)
            {
                // Add points with left mouse button
                if (e.Button == MouseButtons.Left)
                {
                    if (imageDataList[currentImageIndex].nrOfDefinedPoints < 3)
                    {
                        Point position = e.Location;
                        currentPointData.Points[imageDataList[currentImageIndex].nrOfDefinedPoints] = position;
                        imageDataList[currentImageIndex].nrOfDefinedPoints++;
                        UpdateGraphics(imageDataList[currentImageIndex].Points);

                        if (imageDataList[currentImageIndex].nrOfDefinedPoints == 1)
                            imagePointDataText.Text = $"Landmark coordinates:{Environment.NewLine}";
                        imagePointDataText.Text += string.Format($"X: {imageDataList[currentImageIndex].Points[imageDataList[currentImageIndex].nrOfDefinedPoints -1].X}," +
                            $" Y: {imageDataList[currentImageIndex].Points[imageDataList[currentImageIndex].nrOfDefinedPoints - 1].Y}{Environment.NewLine}");
                    }
                }
                // Remove all points for the current image using the right mouse button)
                else if (e.Button == MouseButtons.Right)
                {
                    currentPointData.Points = new PointF[3];
                    imageDataList[currentImageIndex].nrOfDefinedPoints = 0;
                    UpdateGraphics(imageDataList[currentImageIndex].Points);
                    imagePointDataText.Text = "Removed all landmarks on this image.";
                }
            }

        }
        private void exportButton_Click(object sender, EventArgs e)
        {
            ExportLandmarks();
        }

        private void LoadImages()
        {
            // No accumulation when loading images
            imageDataList = new List<ImageData>();

            // Opening multiple files with filters
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Multiselect = true,
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All Files|*.*"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Store the image paths
                foreach (string imagePath in openFileDialog.FileNames)
                {
                    ImageData imageData = new ImageData
                    {
                        ImageName = imagePath
                    };
                    imageDataList.Add(imageData);
                }
                // Show the first image when loaded
                currentImageIndex = 0;

                // Adjust the scrollbar
                vScrollBar1.Maximum = imageDataList.Count - 1;
                vScrollBar1.LargeChange = 1;
                ShowCurrentImage();
            }
        }

        private void ShowCurrentImage()
        {
            // If there are loaded images, show the one with a certain index
            if (imageDataList != null && imageDataList.Count > 0 && currentImageIndex >= 0 && currentImageIndex < imageDataList.Count)
            {
                string filePath = imageDataList[currentImageIndex].ImageName;
                pictureBox1.Image = new Bitmap(filePath);
            }
            UpdateGraphics(imageDataList[currentImageIndex].Points);

            // Update information textbox
            imageNumberInfo.Text = string.Format($"Image {currentImageIndex + 1}/{imageDataList.Count}");
            imageNameText.Text = string.Format($"{imageDataList[currentImageIndex]?.ImageName}");
        }
        /// <summary>
        /// Updates graphics
        /// </summary>
        /// <param name="landmarks">Array of landmark positions</param>
        private void UpdateGraphics(PointF[] landmarks)
        {
            pictureBox1.Refresh();

            foreach (PointF pos in landmarks)
            {
                if(pos != null)
                {
                    // Draw a circle to show the landmark
                    graphics.FillEllipse(Brushes.Red, pos.X - 3, pos.Y - 3, 6, 6);
                }
            }
            // Draw a closed curve only when we have 3 points
            if (imageDataList[currentImageIndex].nrOfDefinedPoints == 3)
            {
                DrawClosedCurve(landmarks);
                infoTextBox.Text = string.Format($"Shape created!{Environment.NewLine}Area: {CalculateArea(curvePath)} mm^2, Perimeter: {CalculatePerimeter(pathPoints)} mm");
            }
            else
            {
                infoTextBox.Text = string.Format($"Left click on the image to create landmarks.{Environment.NewLine}Right click to remove them{Environment.NewLine}Placing 3 of them will result in a closed shape.");
            }
        }

        /// <summary>
        /// Draw a closed curve based on a flattened approximation
        /// </summary>
        /// <param name="points"></param>
        private void DrawClosedCurve(PointF[] points)
        {
            curvePath = new GraphicsPath();

            curvePath.AddLines(points.ToArray());
            
            using (var id = new Matrix(1, 0, 0, 1, 0, 0))
            {
                // Flatten converts each curve in the path to line segments
                // id is an identity matrix
                // flatness defines the maximum permitted error between the curve and the approximation
                curvePath.Flatten(id, 0.1f);
            }
            pathPoints = new List<PointF>(curvePath.PathPoints);

            // Draw curves between the points
            for (int i = 0; i < pathPoints.Count; i++)
            {
                PointF point1 = pathPoints[i];
                PointF point2 = pathPoints[i == pathPoints.Count - 1 ? 0 : i + 1];
                Debug.WriteLine($"Point #{i}: X={pathPoints[i].X}, Y={pathPoints[i].Y}");
                graphics.DrawCurve(greenPen, new PointF[] { point1, point2 });
            }

        }

        /// <summary>
        /// Approximates the area after segmenting the shape (created from GraphicsPath path) into rectangles
        /// </summary>
        /// <param name="path"></param>
        /// <returns>Area (mm^2) double</returns>
        public double CalculateArea(GraphicsPath path)
        {
            if(path != null)
            {
                double area = 0;
                var region = new Region(path);
                var rects = region.GetRegionScans(new Matrix(1, 0, 0, 1, 0, 0));

                // Calculate area by summing each scanned rectangle, keeping in mind the conversion rate
                foreach (var rc in rects)
                    area += rc.Width * rc.Height * pixelinMM * pixelinMM;
                Debug.WriteLine("Area = " + area);

                graphics.FillRegion(Brushes.Green, region);
                return area;
            }
            return -1;
        }

        /// <summary>
        /// Approximates the perimeter based on segmented lines between each element of pathPoints
        /// </summary>
        /// <param name="pathPoints"></param>
        /// <returns>perimeter (mm): double</returns>
        public double CalculatePerimeter(List<PointF> pathPoints)
        {
            if(pathPoints != null)
            {
                double perimeter = 0;
                for (int i = 0; i < pathPoints.Count; i++)
                {
                    var point1 = pathPoints[i];
                    var point2 = pathPoints[i == pathPoints.Count - 1 ? 0 : i + 1];
                    // Calculate area by summing the distance between points, keeping in mind the conversion rate
                    perimeter += (Math.Sqrt(Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y, 2)) * pixelinMM);
                    //Debug.WriteLine($"i: {i}, x1: {point1.X}, x2: {point2.X}, y1: {point1.Y}, y2: {point2.Y}");
                }
                Debug.WriteLine("Perimeter = " + perimeter);
                return perimeter;
            }
            return -1;
        }
        /// <summary>
        /// Export image data into a JSON file
        /// </summary>
        private void ExportLandmarks()
        {
            string fileName = "points_data.json";
            if (imageDataList.Count > 0)
            {
                string json = JsonConvert.SerializeObject(imageDataList, Formatting.Indented);
                File.WriteAllText(fileName, json);
                infoTextBox.Text = $"Export done to {fileName}.";
            }
            else
            {
                File.WriteAllText("points_data.json", "There were no image data to export.");
                infoTextBox.Text = "There were no image data to export.";
            }
        }

    }

    public class ImageData
    {
        public string ImageName { get; set; }
        public int nrOfDefinedPoints { get; set; }
        public PointF[] Points { get; set; } = new PointF[3];
    }
}
