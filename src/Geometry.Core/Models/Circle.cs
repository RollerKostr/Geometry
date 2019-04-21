namespace Geometry.Core.Models
{
    public sealed class Circle : Ellipse
    {
        public Circle(Vertex center, double radius)
            : base(center, center, radius)
        {
        }
    }
}