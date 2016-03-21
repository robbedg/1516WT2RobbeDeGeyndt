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

        //http://www.learneasy.info/MDME/MEMmods/MEM23041A-busted/dynamics/friction/Friction.html
        public double ResultForce(double acceleration, double standardGravity, double angle, Circle circle, Shapes.Rectangle rectangle)
        {
            double fn = rectangle.mass * standardGravity * Math.Cos((angle / 180) * Math.PI);
            double ff = rectangle.staticFriction * fn;
            double fp = rectangle.mass * standardGravity * Math.Sin((angle / 180) * Math.PI);

            double fcircle = circle.mass * acceleration;

            return (fp + fcircle) - ff;
        }
    }
}
