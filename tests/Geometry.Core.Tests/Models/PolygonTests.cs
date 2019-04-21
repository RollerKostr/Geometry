using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Geometry.Core.Models;
using Xunit;

namespace Geometry.Core.Tests.Models
{
    public class PolygonTests
    {
        private const double TOLERANCE = 0.000001d;
        
        [Fact]
        public void Ctor_IfNullVerticesPassed_ShouldThrow()
        {
            // Arrange
            Action act = () => _ = new Polygon(null);

            // Act
            // Assert
            act.Should().ThrowExactly<ArgumentNullException>();
        }
        
        [Fact]
        public void Ctor_IfNoVerticesPassed_ShouldThrow()
        {
            // Arrange
            var vertices = new Vertex[0];
            Action act = () => _ = new Polygon(vertices);

            // Act
            // Assert
            act.Should().ThrowExactly<ArgumentException>();
        }
        
        [Theory]
        [MemberData(nameof(SameVerticesData))]
        public void Ctor_IfSameVerticesPassed_ShouldNotThrow(params Vertex[] vertices)
        {
            // Arrange
            Action act = () => _ = new Polygon(vertices);

            // Act
            // Assert
            act.Should().NotThrow();
        }
        
        [Theory]
        [MemberData(nameof(SameVerticesData))]
        public void Area_IfSameVertices_ShouldNotThrow(params Vertex[] vertices)
        {
            // Arrange
            var polygon = new Polygon(vertices);

            // Act
            // Assert
            polygon.Invoking(p => _ = p.Area).Should().NotThrow();
        }
        
        [Theory]
        [MemberData(nameof(VerticesWithAreaData))]
        public void Area_ShouldReturnCorrectArea(double expectedArea, params Vertex[] vertices)
        {
            // Arrange
            var polygon = new Polygon(vertices);

            // Act
            // Assert
            polygon.Area.Should().BeApproximately(expectedArea, TOLERANCE);
        }
        
        [Fact]
        public void Area_ShouldReturnSameResultRegardlessOfVerticesDirection()
        {
            // Arrange
            var v1 = new Vertex(0, 0);
            var v2 = new Vertex(2, 0);
            var v3 = new Vertex(2, 2);
            var v4 = new Vertex(0, 2);
            var ccwPolygon = new Polygon(v1, v2, v3, v4);
            var cwPolygon = new Polygon(v1, v4, v3, v2);

            // Act
            // Assert
            ccwPolygon.Area.Should().BeApproximately(cwPolygon.Area, TOLERANCE);
        }
        
        public static IEnumerable<object[]> SameVerticesData
        {
            get
            {
                object v = new Vertex(0d, 0d);
                yield return Enumerable.Repeat(v, 2).ToArray();
                yield return Enumerable.Repeat(v, 3).ToArray();
                yield return Enumerable.Repeat(v, 4).ToArray();
            }
        }
        
        public static IEnumerable<object[]> VerticesWithAreaData
        {
            get
            {
                yield return new object[]
                {
                    0d,
                    new Vertex(0d, 0d),
                };
                yield return new object[]
                {
                    0d,
                    new Vertex(0d, 0d),
                    new Vertex(0d, 0d),
                };
                yield return new object[]
                {
                    0d,
                    new Vertex(0d, 0d),
                    new Vertex(0d, 0d),
                    new Vertex(0d, 0d),
                };
                yield return new object[]
                {
                    6d,
                    new Vertex(0d, 0d),
                    new Vertex(3d, 0d),
                    new Vertex(0d, 4d),
                };
                yield return new object[]
                {
                    4d,
                    new Vertex(0d, 0d),
                    new Vertex(2d, 0d),
                    new Vertex(2d, 2d),
                    new Vertex(0d, 2d),
                };
            }
        }
    }
}