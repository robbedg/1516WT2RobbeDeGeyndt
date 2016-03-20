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
        public int width { get; set; }
        public int height { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Rectangle()
        {
            this.width = 0;
            this.height = 0;
            this.X = 0;
            this.Y = 0;
        }

        public Rectangle(int width, int height, int X, int Y)
        {
            this.width = width;
            this.height = height;
            this.X = X;
            this.Y = Y;
        }
    }
}
