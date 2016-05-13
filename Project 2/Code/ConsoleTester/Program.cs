using Backend;
using Objects;
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
            OSMreader or = new OSMreader();
            or.read();
            List<Peek> peeks = or.peeks;

            string test = "TESTING";



            Console.ReadKey();
        }
    }
}
