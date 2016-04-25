using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class SRTMtile
    {
        //Path to file
        private string __path;
        //Dictionary with properties
        private Dictionary<string, double> __properties;
        //Array with float
        private float[,] __values;

        //public values
        public string path
        {
            get { return __path; }
        }
        public Dictionary<string, double> properties
        {
            get { return __properties; }
        }
        public float[,] values
        {
            get { return __values; }
        }
    
        //constructor
        public SRTMtile(string path)
        {
            this.__path = path;
            read();
        }

        private void read()
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
                    var propvalues = propline.Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    double doubleval;
                    double.TryParse(propvalues[1], NumberStyles.Any, nfi, out doubleval);
                    __properties.Add(propvalues[0], doubleval);
                }

                //Get Values
                //get size from properties
                __values = new float[Convert.ToInt32(__properties["ncols"]), Convert.ToInt32(__properties["nrows"])];

                int nline = 0;
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var numbers = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    int nval = 0;
                    foreach (var number in numbers)
                    {
                        float val;
                        float.TryParse(number, out val);

                        __values[nline, nval] = val;
                        nval++;
                    }

                    nline++;
                }
                sr.Close();
            }
        }
    }
}
