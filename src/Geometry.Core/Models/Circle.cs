using System;

namespace Geometry.Core.Models
{
    /// <summary>The limiting case of <see cref="Ellipse"/> with equal semi-axis.</summary>
    public sealed class Circle : Ellipse
    {
        public override double Circumference => CalculateCircumference(SemiMajorAxisLength);

        public Circle(Vertex center, double radius)
            : base(center, radius, radius)
        {
        }
        
        public static double CalculateCircumference(double radius)
        {
            return Math.PI * radius * 2;
        }
    }
}