using System;
using System.Linq;

namespace Geometry.Core.Models
{
    /// <summary>The limiting case of <see cref="Polygon"/> with 3 <see cref="Vertex"/>s.</summary>
    public sealed class Triangle : Polygon
    {
        private const double TOLERANCE = 0.000001;
        
        /// <summary>Is triangle has one 90 degree angle?</summary>
        public bool IsRight => CalculateIsRight(_vertices[0], _vertices[1], _vertices[2], TOLERANCE);
        
        public Triangle(Vertex v1, Vertex v2, Vertex v3)
            : base(v1, v2, v3)
        {
        }

        protected override void CheckVerticesCount(Vertex[] vertices)
        {
            if (vertices.Length != 3)
            {
                throw new ArgumentException(
                    "Triangle must consist of exactly 3 points.", nameof(vertices));
            }
        }
        
        /// <summary>
        /// Calculate area of triangle by its edges using numerically stable version of Heron's formula.
        /// See <see cref="http://en.wikipedia.org/wiki/Heron%27s_formula#Numerical_stability"/> for details.
        /// </summary>
        public static double CalculateArea(double edge1, double edge2, double edge3)
        {
            CheckEdges(edge1, edge2, edge3);
            
            var sortedEdges = new[] {edge1, edge2, edge3}
                .OrderByDescending(i => i)
                .ToArray();

            return Math.Sqrt(
                       (sortedEdges[0] + (sortedEdges[1] + sortedEdges[2])) *
                       (sortedEdges[2] - (sortedEdges[0] - sortedEdges[1])) *
                       (sortedEdges[2] + (sortedEdges[0] - sortedEdges[1])) *
                       (sortedEdges[0] + (sortedEdges[1] - sortedEdges[2]))) / 4d;
        }
        
        public static bool CalculateIsRight(Vertex v1, Vertex v2, Vertex v3, double tolerance)
        {
            var edge1 = LineSegment.CalculateLength(v1, v2);
            var edge2 = LineSegment.CalculateLength(v2, v3);
            var edge3 = LineSegment.CalculateLength(v3, v1);

            return CalculateIsRight(edge1, edge2, edge3, tolerance);
        }
        
        public static bool CalculateIsRight(double edge1, double edge2, double edge3, double tolerance)
        {
            var sortedEdges = new[] {edge1, edge2, edge3}
                .OrderByDescending(i => i)
                .ToArray();

            var hypotenuseSquare = Math.Pow(sortedEdges[0], 2);
            var sumOfSideSquares = Math.Pow(sortedEdges[1], 2) + Math.Pow(sortedEdges[2], 2);

            return Math.Abs(hypotenuseSquare - sumOfSideSquares) <= tolerance;
        }



        private static void CheckEdges(double edge1, double edge2, double edge3)
        {
            var sortedEdges = new[] {edge1, edge2, edge3}
                .OrderByDescending(i => i)
                .ToArray();

            if (sortedEdges[0] > sortedEdges[1] + sortedEdges[2])
            {
                throw new ArgumentException(
                    "The longest edge of triangle must be no longer than the sum of two others.");
            }
        }
    }
}