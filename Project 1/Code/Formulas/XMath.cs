using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formulas
{
    public static class XMath
    {
        //https://www.physicsforums.com/threads/help-solve-for-x-in-a-g-sin-x-uk-cos-x.348780/
        public static double Acceleration(double standardGravity, double angle, double slidingFriction)
        {
            double angleRad = (angle / 180) * Math.PI;
            return standardGravity * (Math.Sin(angleRad) - (slidingFriction * Math.Cos(angleRad)));
        }

    }
}
