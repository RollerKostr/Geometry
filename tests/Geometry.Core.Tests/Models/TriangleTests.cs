using FluentAssertions;
using Geometry.Core.Models;
using Xunit;

namespace Geometry.Core.Tests.Models
{
    public class TriangleTests
    {
        private const double TOLERANCE = 0.000001d;
        
        [Theory]
        [InlineData(3d, 4d, 5d, 6d)]
        [InlineData(1d, 4d, 5d, 0d)]
        [InlineData(0d, 5d, 5d, 0d)]
        [InlineData(0.001d, 4d, 4.0005d, 0.0017321d)]
        public void CalculateArea_ShouldReturnCorrectArea(double edge1, double edge2, double edge3,
            double expectedArea)
        {
            // Arrange
            
            // Act
            var area = Triangle.CalculateArea(edge1, edge2, edge3);

            // Assert
            area.Should().BeApproximately(expectedArea, TOLERANCE);
        }
    }
}