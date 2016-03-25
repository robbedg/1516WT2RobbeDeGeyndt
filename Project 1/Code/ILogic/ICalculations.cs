using Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILogic
{
    public interface ICalculations
    {
        bool CheckCollision(Circle circle, Shapes.Rectangle rectangle);
        double ResultAcceleration(double acceleration, double standardGravity, double angle, Circle circle, Shapes.Rectangle rectangle);
        double Acceleration(double standardGravity, double angle, double slidingFriction);
    }
}
