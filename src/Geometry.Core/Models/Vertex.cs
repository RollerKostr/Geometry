using System;
using System.Diagnostics;
using System.Globalization;

namespace Geometry.Core.Models
{
    // TODO[mk] rename to just Point.
    public class Vertex
    {
        public double X { get; }
        public double Y { get; }
        
        public Vertex(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            var xStr = X.ToString(CultureInfo.InvariantCulture);
            var yStr = Y.ToString(CultureInfo.InvariantCulture);
            
            return $"({xStr},{yStr})";
        }
    }
}