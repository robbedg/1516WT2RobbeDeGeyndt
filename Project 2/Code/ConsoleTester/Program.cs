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
            for (int i = 0; i < 6001; i++)
            {
                for (int j = 0; j < 6001; j++)
                {
                    Console.Write(st.values[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
