using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShapes
{
    public interface IRectangle
    {
        double mass { get; set; }
        double staticFriction { get; set; }
        double kineticFriction { get; set; }
        int width { get; set; }
        int height { get; set; }
        int X { get; set; }
        int Y { get; set; }
        double speed { get; set; }
        double acceleration { get; set; }
    }
}
