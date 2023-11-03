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
        public void CalculateArea_ReturnsCorrectArea()
        {
            // Arrange
            GraphicsPath path = new GraphicsPath();
            path.AddLines(new PointF[] { 
                new PointF(0, 0),
                new PointF(0, 400), 
                new PointF(400, 400)});
            double expectedArea = 80000 * pixelInMM * pixelInMM;

            // Act
            double actualArea = caranxImageViewer.CalculateArea(path);

            // Assert
            Assert.That(expectedArea, Is.EqualTo(actualArea).Within(2).Percent);
        }

        [Test]
        public void CalculatePerimeter_ReturnsCorrectPerimeter()
        {
            // Arrange
            List<PointF> pathPoints = new List<PointF>
        {
            new PointF(0, 0),
            new PointF(0, 2),
            new PointF(2, 2),
        };
            double expectedPerimeter = (4 + Math.Sqrt(8)) * pixelInMM;

            // Act
            double actualPerimeter = caranxImageViewer.CalculatePerimeter(pathPoints);

            // Assert
            Assert.That(expectedPerimeter, Is.EqualTo(actualPerimeter).Within(2).Percent);
        }
    }
}
