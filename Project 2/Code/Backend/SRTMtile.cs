using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Backend
{
    public class SRTMtile
    {
        //Path to file
        private string __path;
        //Dictionary with properties
        private Dictionary<string, double> __properties;
        //Array with y-coordinates
        private float[] __ycoordinates;
        //Array with x-ciirdinates
        private float[] __xcoordinates;

        //public values
        public string path
        {
            get { return __path; }
        }
        public Dictionary<string, double> properties
        {
            get { return __properties; }
        }
        
        public float[] ycoordinates
        {
            get { return __ycoordinates; }
        }

        public float[] xcoordinates
        {
            get { return __xcoordinates; }
        }

        //constructor
        public SRTMtile(string path)
        {
            this.__path = path;
            GetCoordinates();
        }

        private void GetCoordinates()
        {
            using (StreamReader sr = new StreamReader(__path))
            {
                //get properties
                __properties = new Dictionary<string, double>();

                NumberFormatInfo nfi = new NumberFormatInfo();
                nfi.NumberDecimalSeparator = ".";

                for (int i = 0; i < 6; i++)
                {
                    string propline = sr.ReadLine();
                    var propvalues = propline.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    double doubleval;
                    double.TryParse(propvalues[1], NumberStyles.Any, nfi, out doubleval);
                    __properties.Add(propvalues[0], doubleval);
                }
                sr.Close();
            }

            Thread ycoordinates = new Thread(new ThreadStart(YcoordinatesThread));
            Thread xcoordinates = new Thread(new ThreadStart(XcoordinatesThread));

            xcoordinates.Start();
            ycoordinates.Start();

            xcoordinates.Join();
            ycoordinates.Join();
        }

        private void YcoordinatesThread()
        {
            __ycoordinates = new float[Convert.ToInt32(__properties["nrows"])];
   
                                                                                                //Acomodate for row 0
            double firstcelly = (__properties["yllcorner"] + (__properties["cellsize"] / 2)) + ((__properties["nrows"] - 1) * __properties["cellsize"]);

            for (int row = 0; row < __ycoordinates.Count(); row++)
            {
                __ycoordinates[row] = (float)(firstcelly - (row * __properties["cellsize"]));
            }
        }

        private void XcoordinatesThread()
        {
            __xcoordinates = new float[Convert.ToInt32(__properties["ncols"])];

            double firstcellx = __properties["xllcorner"] + (__properties["cellsize"] / 2);

            for (int col = 0; col < __xcoordinates.Count(); col++)
            {
                __xcoordinates[col] = (float)(firstcellx + (col * __properties["cellsize"]));
            }
        }
        
        public float[,] GetHeights(int radius, float y, float x)
        {
            //Get indexes
            int[] indexes = GetIndexes(y, x);

            //Array with matrixes
            float[,] heights = new float[(radius * 2) + 1, (radius * 2) + 1];
            
            using (StreamReader sr = new StreamReader(__path))
            {
                //skip header
                for (int i = 0; i < 6; i++) sr.ReadLine();

                //skip unnescessary lines
                for (int i = 0; i < indexes[0] - radius - 1; i++) sr.ReadLine();

                string line;
                for (int nline = 0; nline < (radius * 2) + 1; nline++)
                {
                    line = sr.ReadLine();
                    var numbers = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    int nval = 0;
                    for (int j = (indexes[1] - radius - 1); j < (indexes[1] + radius); j++ )
                    {
                        float val;
                        float.TryParse(numbers[j], out val);

                        heights[nline, nval] = val;
                        nval++;
                    }
                }
                sr.Close();
            }
            return heights;
        }

        private int[] GetIndexes(float y, float x)
        {
            int closesty = 99999;
            int closestx = 99999;

            Thread closestyThread = new Thread(() => { closesty = GetClosest(y, __ycoordinates); });
            Thread closestxThread = new Thread(() => { closestx = GetClosest(x, __xcoordinates); });

            closestyThread.Start();
            closestxThread.Start();

            closestyThread.Join();
            closestxThread.Join();

            return new int[] { closesty, closestx };
        }

        private int GetClosest(float value, float[] array)
        {
            float min = 9999;
            float mindifference = 9999;
            for (int i = 0; i < array.Count(); i++)
            {
                float difference = Math.Abs(array[i] - value);

                if (difference < mindifference)
                {
                    mindifference = difference;
                    min = array[i];
                }
            }

            int index = 9999;
            for (int i = 0; i < array.Count(); i++)
            {
                if (array[i] == min) index = i;
            }

            return index;
        }
    }
}
