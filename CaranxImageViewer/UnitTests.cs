using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CaranxImageViewer;
using System.Drawing.Drawing2D;
using System.Drawing;
using CaranxImageViewer;

namespace CaranxImageViewer.Tests
{
    internal class UnitTests
    {
        CaranxImageViewer caranxImageViewer = new CaranxImageViewer();
        int pixelInMM = 2;
        [Test]
        public void CalculateArea_ValidPath_ReturnsCorrectArea()
        {
            // Arrange
            GraphicsPath path = new GraphicsPath();
            path.AddPolygon(new PointF[] { 
                new PointF(0, 0),
                new PointF(0, 2), 
                new PointF(2, 2)});
            double expectedArea = 2 * pixelInMM; // Assuming the conversion factor is 1 (pixel to mm)

            // Act
            double actualArea = caranxImageViewer.CalculateArea(path);

            // Assert
            Assert.AreEqual(expectedArea, actualArea, 0.01);
        }

        [Test]
        public void CalculatePerimeter_ValidPath_ReturnsCorrectPerimeter()
        {
            // Arrange
            List<PointF> pathPoints = new List<PointF>
        {
            new PointF(0, 0),
            new PointF(0, 2),
            new PointF(2, 2),
        };
            double expectedPerimeter = (4 + Math.Sqrt(8)) * pixelInMM; // Assuming the conversion factor is 1 (pixel to mm)

            // Act
            double actualPerimeter = caranxImageViewer.CalculatePerimeter(pathPoints);

            // Assert
            Assert.AreEqual(expectedPerimeter, actualPerimeter, 0.01);
        }
    }
}
