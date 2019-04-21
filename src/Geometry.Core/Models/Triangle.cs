using System;
using System.Linq;

namespace Geometry.Core.Models
{
    /// <summary>The limiting case of <see cref="Polygon"/> with 3 <see cref="Vertex"/>s.</summary>
    public sealed class Triangle : Polygon
    {
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