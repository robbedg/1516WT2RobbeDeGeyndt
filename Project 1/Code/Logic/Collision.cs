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
            double friction = rectangle.staticFriction;
            
            Calculation:
                double fn = rectangle.mass * standardGravity * Math.Cos((angle / 180) * Math.PI);
                double ff = friction * fn;
                double fp = rectangle.mass * standardGravity * Math.Sin((angle / 180) * Math.PI);

                double fcircle = circle.mass * acceleration;

                double totalForce = (fp + fcircle) - ff;

            if ((friction == rectangle.staticFriction) && (totalForce > 0))
            {
                friction = rectangle.kineticFriction;
                goto Calculation;
            }
            else if ((friction == rectangle.staticFriction) && (totalForce <= 0))
            {
                return 0d;
            }
            

            return totalForce / (circle.mass + rectangle.mass);
        }
    }
}
