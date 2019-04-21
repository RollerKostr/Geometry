using System;
using FluentAssertions;
using Geometry.Core.Models;
using Xunit;

namespace Geometry.Core.Tests.Models
{
    public class EllipseTests
    {
        private const double TOLERANCE = 0.000001d;

        [Fact]
        public void Ctor_IfInvalidSemiAxesPassed_ShouldThrow()
        {
            // Arrange
            var center = new Vertex(0d, 0d);
            
            // Act
            Action act = () => _ = new Ellipse(center, 1d, 2d);

            // Assert
            act.Should().ThrowExactly<ArgumentException>();
        }
        
        [Fact]
        public void CalculateFocalLength_IfInvalidSemiAxesPassed_ShouldThrow()
        {
            // Arrange
            var center = new Vertex(0d, 0d);
            
            // Act
            Action act = () => _ = Ellipse.CalculateFocalLength(1d, 2d);

            // Assert
            act.Should().ThrowExactly<ArgumentException>();
        }
        
        [Theory]
        [InlineData(2d, 1d, 1.732050d)]
        [InlineData(4d, 0.5d, 3.968626d)]
        public void CalculateFocalLength_ShouldReturnCorrectResult(
            double semiMajorAxisLength, double semiMinorAxisLength, double expectedResult)
        {
            // Arrange
            var center = new Vertex(0d, 0d);
            
            // Act
            var result = Ellipse.CalculateFocalLength(semiMajorAxisLength, semiMinorAxisLength);

            // Assert
            result.Should().BeApproximately(expectedResult, TOLERANCE);
        }
        
        [Fact]
        public void CalculateEccentricity_IfInvalidSemiAxesPassed_ShouldThrow()
        {
            // Arrange
            var center = new Vertex(0d, 0d);
            
            // Act
            Action act = () => _ = Ellipse.CalculateEccentricity(1d, 2d);

            // Assert
            act.Should().ThrowExactly<ArgumentException>();
        }
        
        [Theory]
        [InlineData(2d, 1d, 0.866025d)]
        [InlineData(4d, 0.5d, 0.992156d)]
        public void CalculateEccentricity_ShouldReturnCorrectResult(
            double semiMajorAxisLength, double semiMinorAxisLength, double expectedResult)
        {
            // Arrange
            var center = new Vertex(0d, 0d);
            
            // Act
            var result = Ellipse.CalculateEccentricity(semiMajorAxisLength, semiMinorAxisLength);

            // Assert
            result.Should().BeApproximately(expectedResult, TOLERANCE);
        }
        
        [Fact]
        public void CalculateArea_IfInvalidSemiAxesPassed_ShouldNotThrow()
        {
            // Arrange
            var center = new Vertex(0d, 0d);
            
            // Act
            Action act = () => _ = Ellipse.CalculateArea(1d, 2d);

            // Assert
            act.Should().NotThrow();
        }
        
        [Theory]
        [InlineData(2d, 1d, 6.283185d)]
        [InlineData(4d, 0.5d, 6.283185d)]
        public void CalculateArea_ShouldReturnCorrectResult(
            double semiMajorAxisLength, double semiMinorAxisLength, double expectedResult)
        {
            // Arrange
            var center = new Vertex(0d, 0d);
            
            // Act
            var result = Ellipse.CalculateArea(semiMajorAxisLength, semiMinorAxisLength);

            // Assert
            result.Should().BeApproximately(expectedResult, TOLERANCE);
        }
    }
}