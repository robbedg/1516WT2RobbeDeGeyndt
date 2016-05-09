using Backend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Communication
    {
        SRTMtile SRTM = new SRTMtile("srtm_37_02.asc");

        public float[,] GetOutcome
        {
            get { return SRTM.getHeights(300, 50.8621458F, 4.3047604F); }
        }
    }
}
