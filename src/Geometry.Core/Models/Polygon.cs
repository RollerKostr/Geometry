using System;

namespace Geometry.Core.Models
{
    public class Polygon : Shape
    {
        private readonly Vertex[] _vertices;

        public override double Area => CalculateArea();
        
        public Polygon(params Vertex[] vertices)
        {
            _vertices = Validate(vertices);
        }



        private Vertex[] Validate(Vertex[] vertices)
        {
            if (vertices == null)
            {
                throw new ArgumentNullException(nameof(vertices));
            }

            if (vertices.Length < 1)
            {
                throw new ArgumentException(
                    "Polygon must consist of at least 1 vertex.", nameof(vertices));
            }

            return vertices;
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
    }
}