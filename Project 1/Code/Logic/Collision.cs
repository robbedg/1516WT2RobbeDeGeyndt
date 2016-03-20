using ILogic;
using Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Collision : ICollision
    {
        public bool CheckCollision(Circle circle, Shapes.Rectangle rectangle)
        {
            int test = circle.X - circle.radius;
            int test2 = rectangle.X + rectangle.width;
            if ((circle.X - circle.radius) <= (rectangle.X + (rectangle.width / 2)))
            {
                return true;
            }
            return false;
        }
    }
}
