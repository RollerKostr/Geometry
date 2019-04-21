using System;
using FluentAssertions;
using Geometry.Core.Models;
using Xunit;

namespace Geometry.Core.Tests.Models
{
    public class TriangleTests
    {
        private const double TOLERANCE = 0.000001d;

        [Theory]
        [InlineData(0d, 0d, 1d)]
        [InlineData(3d, 4d, 8d)]
        public void CalculateArea_IfSidesHasInvalidLength_ShouldThrow(double edge1, double edge2, double edge3)
        {
            // Arrange

            // Act
            Action act = () => _ = Triangle.CalculateArea(edge1, edge2, edge3);

            // Assert
            act.Should().ThrowExactly<ArgumentException>();
        }
        
        [Theory]
        [InlineData(0d, 0d, 0d, 0d)]
        [InlineData(3d, 4d, 5d, 6d)]
        [InlineData(1d, 4d, 5d, 0d)]
        [InlineData(0d, 5d, 5d, 0d)]
        [InlineData(0.001d, 4d, 4.0005d, 0.0017321d)]
        public void CalculateArea_ShouldReturnCorrectResult(double edge1, double edge2, double edge3,
            double expectedArea)
        {
            // Arrange
            
            // Act
            var area = Triangle.CalculateArea(edge1, edge2, edge3);

            // Assert
            area.Should().BeApproximately(expectedArea, TOLERANCE);
        }
        
        [Theory]
        [InlineData(0d, 0d, 1d)]
        [InlineData(3d, 4d, 8d)]
        public void CalculateIsRight_IfSidesHasInvalidLength_ShouldThrow(double edge1, double edge2, double edge3)
        {
            // Arrange

            // Act
            Action act = () => _ = Triangle.CalculateIsRight(edge1, edge2, edge3, TOLERANCE);

            // Assert
            act.Should().ThrowExactly<ArgumentException>();
        }
        
        [Theory]
        [InlineData(3d, 4d, 5d, true)]
        [InlineData(3d, 4d, 4.99d, false)]
        [InlineData(3d, 4d, 5.01d, false)]
        public void CalculateIsRight_ShouldReturnCorrectResult(double edge1, double edge2, double edge3,
            bool expectedResult)
        {
            // Arrange

            // Act
            var isRight = Triangle.CalculateIsRight(edge1, edge2, edge3, TOLERANCE);

            // Assert
            isRight.Should().Be(expectedResult);
        }
    }
}