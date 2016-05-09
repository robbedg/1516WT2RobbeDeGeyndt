using Backend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTester
{
    class Program
    {
        static void Main(string[] args)
        {
            SRTMtile st = new SRTMtile("srtm_37_02.asc");
            float[,] values = st.getHeights(3, 50.8621458F, 4.3047604F);
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Console.Write(values[i, j]);
                    Console.Write("\t");
                }
                Console.WriteLine();
            }



            Console.ReadKey();
        }
    }
}
