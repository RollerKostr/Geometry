using System;

namespace Geometry.Core.Models
{
    public class Polygon : Shape
    {
        private readonly Vertex[] _vertices;
        
        public override double Perimeter => CalculatePerimeter();
        public override double Area => CalculateArea();
        
        public Polygon(params Vertex[] vertices)
        {
            CheckVertices(vertices ?? throw new ArgumentNullException(nameof(vertices)));
            
            _vertices = vertices;
        }
        
        protected virtual void CheckVerticesCount(Vertex[] vertices)
        {
            if (vertices.Length < 1)
            {
                throw new ArgumentException(
                    "Polygon must consist of at least 1 vertex.", nameof(vertices));
            }
        }
        
        
        
        private void CheckVertices(Vertex[] vertices)
        {
            CheckVerticesCount(vertices);
        }

        private double CalculatePerimeter()
        {
            var perimeter = 0d;
            for (int vIndex = 0; vIndex < _vertices.Length; vIndex++)
            {
                var nextVindex = vIndex == _vertices.Length - 1 ? 0 : vIndex + 1;
                perimeter += CalculateEdgeLength(_vertices[vIndex], _vertices[nextVindex]);
            }

            return perimeter;
        }
        
        /// <summary>
        /// Using Shoelace (Gauss) formula for calculating area of arbitrary polygon.
        /// See <see cref="http://en.wikipedia.org/wiki/Shoelace_formula"/> for details.
        /// </summary>
        private double CalculateArea()
        {
            var area = 0d;
            for (var xIndex = 0; xIndex < _vertices.Length; xIndex++)
            {
                var yAddIndex = xIndex == _vertices.Length - 1 ? 0 : xIndex + 1;
                var ySubIndex = xIndex == 0 ? _vertices.Length - 1 : xIndex - 1;
                area += _vertices[xIndex].X * _vertices[yAddIndex].Y;
                area -= _vertices[xIndex].X * _vertices[ySubIndex].Y;
            }
            
            return Math.Abs(area) / 2d;
        }

        protected double CalculateEdgeLength(Vertex v1, Vertex v2)
        {
            return Math.Sqrt((v2.X - v1.X) * (v2.Y - v1.Y));
        }
    }
}