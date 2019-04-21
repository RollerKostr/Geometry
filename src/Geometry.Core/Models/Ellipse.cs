using System;

namespace Geometry.Core.Models
{
    public class Ellipse : Shape
    {
        public Vertex Center { get; }
        public Vertex Focus1 { get; }
        public Vertex Focus2 { get; }
        public double SemiMajorAxisLength { get; }
        public double SemiMinorAxisLength { get; }
        public double FocalLength { get; }
        public double Eccentricity { get; }
        public virtual double Circumference => CalculateCircumference();
        public override double Area => CalculateArea(SemiMajorAxisLength, SemiMinorAxisLength);

        // TODO[mk] add more ctors allowing inclined ellipses
        public Ellipse(Vertex center, double semiMajorAxisLength, double semiMinorAxisLength)
        {
            CheckSemiAxis(semiMajorAxisLength, semiMinorAxisLength);
            
            Center = center ?? throw new ArgumentNullException(nameof(center));
            SemiMajorAxisLength = semiMajorAxisLength;
            SemiMinorAxisLength = semiMinorAxisLength;

            FocalLength = CalculateFocalLength(SemiMajorAxisLength, SemiMinorAxisLength);
            Eccentricity = CalculateEccentricity(SemiMajorAxisLength, SemiMinorAxisLength);
            Focus1 = new Vertex(-FocalLength, 0d);
            Focus2 = new Vertex(FocalLength, 0d);
        }

        private double CalculateCircumference()
        {
            // Precise formula for ellipse circumference does not exists and I don't want to calculate approximate value.
            throw new NotImplementedException();
        }

        public static double CalculateArea(double semiMajorAxisLength, double semiMinorAxisLength)
        {
            return Math.PI * semiMajorAxisLength * semiMinorAxisLength;
        }
        
        public static double CalculateFocalLength(double semiMajorAxisLength, double semiMinorAxisLength)
        {
            CheckSemiAxis(semiMajorAxisLength, semiMinorAxisLength);
            
            return Math.Sqrt(Math.Pow(semiMajorAxisLength, 2) - Math.Pow(semiMinorAxisLength, 2));
        }
        
        public static double CalculateEccentricity(double semiMajorAxisLength, double semiMinorAxisLength)
        {
            CheckSemiAxis(semiMajorAxisLength, semiMinorAxisLength);
            
            return Math.Sqrt(1d - Math.Pow(semiMinorAxisLength/semiMajorAxisLength, 2));
        }
        
        
        
        private static void CheckSemiAxis(double semiMajorAxisLength, double semiMinorAxisLength)
        {
            if (semiMajorAxisLength < semiMinorAxisLength)
            {
                throw new ArgumentException(
                    "Semi-major axis length must be greater or equal to semi-minor one.");
            }
        }
    }
}