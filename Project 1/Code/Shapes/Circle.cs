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
        public int radius { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Circle()
        {
            radius = 0;
            X = 0;
            Y = 0;
        }

        public Circle(int radius , int X, int Y)
        {
            this.radius = radius;
            this.X = X;
            this.Y = Y;
        }
    }
}
