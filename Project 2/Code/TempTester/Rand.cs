using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempTester
{
    public static class Rand
    {
        public static double[,] GetRandoms()
        {
            double[,] output = new double[250, 250];
            Random rnd = new Random(2);

            for (int i = 0; i < 250; i++)
            {
                for (int j = 0; j < 250; j++)
                {
                    output[i, j] = rnd.Next(-10, 10);
                }
            }
            return output;
        }
    }
}
