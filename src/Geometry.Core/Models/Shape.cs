namespace Geometry.Core.Models
{
    /// <summary>Represents closed 2D shape.</summary>
    public abstract class Shape
    {
        public abstract double Perimeter { get; }
        public abstract double Area { get; }
    }
}