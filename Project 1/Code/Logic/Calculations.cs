using ILogic;
using Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Calculations : ICalculations
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
        public double ResultAcceleration(double acceleration, double standardGravity, double angle, Circle circle, Shapes.Rectangle rectangle)
        {
            //Check for friction when static
            double friction = rectangle.staticFriction;
            
            Calculation:
                double fn = rectangle.mass * standardGravity * Math.Cos((angle / 180) * Math.PI);
                double ff = friction * fn;
                double fp = rectangle.mass * standardGravity * Math.Sin((angle / 180) * Math.PI);

                double fcircle = circle.mass * acceleration;

                double totalForce = (fp + fcircle) - ff;

            //If the force is more than 0
            if ((friction == rectangle.staticFriction) && (totalForce > 0))
            {
                //calculate friction when in motion
                friction = rectangle.kineticFriction;
                goto Calculation;
            }
            //If not return 0
            else if ((friction == rectangle.staticFriction) && (totalForce <= 0))
            {
                return 0d;
            }
            
            //Return acceleration
            return totalForce / (circle.mass + rectangle.mass);
        }

        //Get acceleration on angle
        //https://www.physicsforums.com/threads/help-solve-for-x-in-a-g-sin-x-uk-cos-x.348780/
        public double Acceleration(double standardGravity, double angle, double slidingFriction)
        {
            double angleRad = (angle / 180) * Math.PI;
            return standardGravity * (Math.Sin(angleRad) - (slidingFriction * Math.Cos(angleRad)));
        }
    }
}
