using Backend;
using Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Logic
{
    public class PeekFilter
    {
        public string[,] PeekArray(SRTMtile tile, Coordinates coordinates, int range)
        {
            //Make values ascending
            float[] ycoordinatesASC = (float[])tile.ycoordinates.Reverse().ToArray();
            float[] xcoordinatesASC = (float[])tile.xcoordinates;

            //Starting threads
            GetClosest gety = new GetClosest();
            GetClosest getx = new GetClosest();

            Thread getyThread = new Thread(() => { gety = new GetClosest(coordinates.y, ycoordinatesASC); });
            Thread getxThread = new Thread(() => { getx = new GetClosest(coordinates.x, xcoordinatesASC); });

            getyThread.Start();
            getxThread.Start();
            getyThread.Join();


            //Getting y-values
            int starty = gety.index - 1 - range;
            float miny = ycoordinatesASC[starty];
            int endy = gety.index + 1 + range;
            float maxy = ycoordinatesASC[endy];

            getxThread.Join();

            //Getting x-values
            int startx = getx.index - 1 - range;
            float minx = xcoordinatesASC[startx];
            int endx = getx.index + 1 + range;
            float maxx = xcoordinatesASC[endx];

            OSMreader or = new OSMreader();
            List<Peek> peeks = or.peeks;
            List<Peek> filteredPeeks = new List<Peek>();

            //filtering peeks
            foreach (Peek peek in peeks)
            {
                if ((miny <= peek.coordinates.y) && (maxy >= peek.coordinates.y))
                {
                    if ((minx <= peek.coordinates.x) && (maxx >= peek.coordinates.x))
                    {
                        filteredPeeks.Add(peek);
                    }
                }
            }

            //Put in stringarray, simmilar to heights array
            string[,] peekMatrix = new string[(range * 2 + 1), (range * 2 + 1)];

            foreach (Peek peek in filteredPeeks)
            {
                GetClosest closesty = new GetClosest();
                GetClosest closestx = new GetClosest();

                Thread closestyThread = new Thread(() => { closesty = new GetClosest(peek.coordinates.y, ycoordinatesASC); });
                Thread closestxThread = new Thread(() => { closestx = new GetClosest(peek.coordinates.x, xcoordinatesASC); });
                closestyThread.Start();
                closestxThread.Start();
                closestyThread.Join();
                closestxThread.Join();

                int y = closesty.index - starty - 1;
                int x = closestx.index - startx - 1;

                //reverse y back
                y = (range * 2) - y;

                peekMatrix[y, x] = peek.name;
            }

            return peekMatrix;
        }
    }
}
