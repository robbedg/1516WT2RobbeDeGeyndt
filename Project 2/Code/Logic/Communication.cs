using Backend;
using Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;

namespace Logic
{
    public class Communication
    {
        private SRTMtile SRTM { get; set; }
        private PeekFilter peekFilter { get; set; }
        public float[,] heights { get; set; }
        public float[] distances { get; set; }
        public Dictionary<Model3D, string> markers { get; set; }

        public Communication(string path)
        {
            SRTM = new SRTMtile(path);
            peekFilter = new PeekFilter();
        }

        public void StartMap(Coordinates coordinates, int range)
        {

            heights = SRTM.GetHeights(300, coordinates);

            distances = GetDistances(coordinates);

            //Create texture
            Texture textures = new Texture(heights);

            //Create Peekobjects
            string[,] peeks = peekFilter.PeekArray(SRTM, coordinates, 300);
            CreateMarkers cm = new CreateMarkers(heights, peeks, distances);
            markers = cm.markers;
        }

        //https://stackoverflow.com/questions/4102520/how-to-transform-a-distance-from-degrees-to-metres
        private float[] GetDistances(Coordinates coordinates)
        {
            //Radius of Earth
            double R = 6371;

            //Difference in degrees
            double dLat = (SRTM.ycoordinates.Last() - SRTM.ycoordinates.First()) * (Math.PI / 180);
            double dLon = (SRTM.xcoordinates.Last() - SRTM.xcoordinates.First()) * (Math.PI / 180);

            //Calculate Distance Lat
            double aLat = Math.Sin(dLat / 2) * Math.Sin(dLat / 2);

            //Calculate Distance Lon
            double aLon = Math.Cos(coordinates.y) * Math.Cos(coordinates.y) *
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
