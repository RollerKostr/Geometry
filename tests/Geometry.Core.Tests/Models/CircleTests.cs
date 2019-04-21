using FluentAssertions;
using Geometry.Core.Models;
using Xunit;

namespace Geometry.Core.Tests.Models
{
    public class CircleTests
    {
        private const double TOLERANCE = 0.000001d;
        
        [Fact]
        public void Eccentricity_ShouldReturnZero()
        {
            // Arrange
            var center = new Vertex(0d, 0d);
            var radius = 1d;
            
            var circle = new Circle(center, radius);
            
            // Act
            // Assert
            circle.Eccentricity.Should().BeApproximately(0d, TOLERANCE);
        }
        
        [Fact]
        public void FocalLength_ShouldReturnZero()
        {
            // Arrange
            var center = new Vertex(0d, 0d);
            var radius = 1d;
            
            var circle = new Circle(center, radius);
            
            // Act
            // Assert
            circle.FocalLength.Should().BeApproximately(0d, TOLERANCE);
        }
        
        [Theory]
        [InlineData(1d, 3.1415926)]
        [InlineData(2d, 12.5663706)]
        public void CalculateArea_ShouldReturnCorrectResult(double radius, double expectedResult)
        {
            // Arrange
            var center = new Vertex(0d, 0d);
            
            var circle = new Circle(center, radius);
            
            // Act
            // Assert
            circle.Area.Should().BeApproximately(expectedResult, TOLERANCE);
        }
    }
}