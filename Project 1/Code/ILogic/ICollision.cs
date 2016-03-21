using Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILogic
{
    public interface ICollision
    {
        bool CheckCollision(Circle circle, Shapes.Rectangle rectangle);
        double ResultForce(double acceleration, double standardGravity, double angle, Circle circle, Shapes.Rectangle rectangle);
    }
}
