using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    public class Move
    {
        public int X { get; set; }
        public double Rank { get; set; }

        public Move() { }

        public Move(int x, double rank)
        {
            this.X = x;
            this.Rank = rank;
        }
    }
}
