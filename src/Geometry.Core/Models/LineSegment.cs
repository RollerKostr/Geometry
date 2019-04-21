using System;

namespace Geometry.Core.Models
{
    public class LineSegment
    {
        public Vertex Endpoint1 { get; }
        public Vertex Endpoint2 { get; }
        public Vertex Midpoint => CalculateMidpoint(Endpoint1, Endpoint2);
        public double Length => CalculateLength(Endpoint1, Endpoint2);
        
        public LineSegment(Vertex endpoint1, Vertex endpoint2)
        {
            Endpoint1 = endpoint1;
            Endpoint2 = endpoint2;
        }



        public static Vertex CalculateMidpoint(Vertex endpoint1, Vertex endpoint2)
        {
            var midpointX = endpoint1.X + (endpoint2.X - endpoint1.X) / 2d;
            var midpointY = endpoint1.Y + (endpoint2.Y - endpoint1.Y) / 2d;
            
            return new Vertex(midpointX, midpointY);
        }

        public static double CalculateLength(Vertex endpoint1, Vertex endpoint2)
        {
            return Math.Sqrt((endpoint2.X - endpoint1.X) * (endpoint2.Y - endpoint1.Y));
        }
    }
}