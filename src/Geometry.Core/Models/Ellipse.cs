namespace Geometry.Core.Models
{
    public class Ellipse : Shape
    {
        private readonly Vertex _focus1;
        private readonly Vertex _focus2;
        private readonly double _semiMajorAxis;

        public override double Perimeter => CalculatePerimeter();
        public override double Area => CalculateArea();
        public double Eccentricity => CalculateEccentricity();
        public Vertex Center => CalculateCenter();
        
        public Ellipse(Vertex focus1, Vertex focus2, double semiMajorAxis)
        {
            _focus1 = focus1;
            _focus2 = focus2;
            _semiMajorAxis = semiMajorAxis;
        }

        private double CalculatePerimeter()
        {
            return 0d;
        }

        private double CalculateArea()
        {
            return 0d;
        }
        
        private double CalculateEccentricity()
        {
            return 0d;
        }

        private Vertex CalculateCenter()
        {
            return new Vertex(0d, 0d);
        }
    }
}