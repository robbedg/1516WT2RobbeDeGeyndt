﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IShapes
{
    public interface ICircle
    {
        double mass { get; set; }
        int radius { get; set; }
        int X { get; set; }
        int Y { get; set; }
        double speed { get; set; }
        double acceleration { get; set; }
    }
}
