using IShapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Circle : ICircle
    {
        public double mass { get; set; }
        public int radius { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Circle()
        {
            this.mass = 0;
            this.radius = 0;
            this.X = 0;
            this.Y = 0;
        }

        public Circle(double mass, int radius, int X, int Y)
        {
            this.mass = mass;
            this.radius = radius;
            this.X = X;
            this.Y = Y;
        }
    }
}
