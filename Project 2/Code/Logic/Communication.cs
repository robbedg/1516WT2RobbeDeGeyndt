﻿using Backend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Communication
    {
        private SRTMtile SRTM { get; set; }
        public float[,] heights { get; set; }
        public float[] distances { get; set; }

        public Communication()
        {
            SRTM = new SRTMtile("srtm_38_03.asc");
            heights = SRTM.GetHeights(300, 46.5383608F, 7.5423949F);
            distances = GetDistances(46.5383608F);

        }

        //https://stackoverflow.com/questions/4102520/how-to-transform-a-distance-from-degrees-to-metres
        private float[] GetDistances(float y)
        {
            //Radius of Earth
            double R = 6371;

            //Difference in degrees
            double dLat = (SRTM.ycoordinates.Last() - SRTM.ycoordinates.First()) * (Math.PI / 180);
            double dLon = (SRTM.xcoordinates.Last() - SRTM.xcoordinates.First()) * (Math.PI / 180);

            //Calculate Distance Lat
            double aLat = Math.Sin(dLat / 2) * Math.Sin(dLat / 2);

            //Calculate Distance Lon
            double aLon = Math.Cos(y) * Math.Cos(y) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            double cLat = 2 * Math.Atan2(Math.Sqrt(aLat), Math.Sqrt(1 - aLat));
            double cLon = 2 * Math.Atan2(Math.Sqrt(aLon), Math.Sqrt(1 - aLon));

            //Distances in KM
            double dLatMetric = R * cLat;
            double dLonMetric = R * cLon;

            //To Distance from point to point in m.
            float ydist = (float)((dLatMetric * 1000) / (SRTM.properties["nrows"] - 1));
            float xdist = (float)((dLonMetric * 1000) / (SRTM.properties["ncols"] - 1));

            return new float[] { ydist, xdist };
        }
    }
}
