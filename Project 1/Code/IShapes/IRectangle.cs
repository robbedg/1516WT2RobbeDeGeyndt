using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShapes
{
    public interface IRectangle
    {
        int width { get; set; }
        int height { get; set; }
        int X { get; set; }
        int Y { get; set; }
    }
}
