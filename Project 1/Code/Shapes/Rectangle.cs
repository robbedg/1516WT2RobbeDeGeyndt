using IShapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Rectangle : IRectangle
    {
        public double mass { get; set; }
        public double staticFriction { get; set; }
        public double kineticFriction { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public double speed { get; set; }
        public double acceleration { get; set; }

        public Rectangle()
        {
            this.mass = 0;
            this.staticFriction = 0;
            this.kineticFriction = 0;
            this.width = 0;
            this.height = 0;
            this.X = 0;
            this.Y = 0;
            this.speed = 0;
            this.acceleration = 0;
        }

        public Rectangle(double mass, double staticFriction, double kineticFriction, int width, int height, int X, int Y)
        {
            this.mass = mass;
            this.staticFriction = staticFriction;
            this.kineticFriction = kineticFriction;
            this.width = width;
            this.height = height;
            this.X = X;
            this.Y = Y;
            this.speed = 0;
            this.acceleration = 0;
        }
    }
}
