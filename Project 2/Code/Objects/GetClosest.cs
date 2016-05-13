using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    public class GetClosest
    {
        private int _index { get; set; }
        public int index
        {
            get { return _index; }
        }
        public GetClosest() { }
        public GetClosest(float value, float[] array)
        {
            float min = 99999;
            float mindifference = 99999;
            for (int i = 0; i < array.Count(); i++)
            {
                float difference = Math.Abs(array[i] - value);

                if (difference < mindifference)
                {
                    mindifference = difference;
                    min = array[i];
                }
            }

            int index = 99999;
            for (int i = 0; i < array.Count(); i++)
            {
                if (array[i] == min) index = i;
            }

            _index = index;
        }
    }
}
