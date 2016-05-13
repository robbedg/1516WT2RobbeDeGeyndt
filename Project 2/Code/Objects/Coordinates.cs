using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    public class Coordinates
    {
        public float x { get; set; }
        public float y { get; set; }

        public Coordinates() { }

        public Coordinates(float y, float x)
        {
            this.y = y;
            this.x = x;
        }
    }
}
