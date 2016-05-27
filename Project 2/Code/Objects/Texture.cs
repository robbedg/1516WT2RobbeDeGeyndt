using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Objects
{
    public class Texture
    {
        private Bitmap bitmap { get; set; }
        private float[,] heights { get; set; }
        private float max { get; set; }
        private float min { get; set; }

        public Texture(float[,] heights)
        {
            this.heights = heights;
            bitmap = new Bitmap(heights.GetLength(1), heights.GetLength(0));
            GetMaxMin();
            Create();
        }

        private void Create()
        {
            float boundry1 = ((max - min) / 4) * 1 + min;
            float boundry2 = ((max - min) / 4) * 2 + min;
            float boundry3 = ((max - min) / 4) * 3 + min;

            for (int y = 0; y < heights.GetLength(0); y++)
            {
                int reversey = heights.GetLength(0) - 1 - y;
                for (int x = 0; x < heights.GetLength(1); x++)
                {
                    if (heights[y,x] == -9999)
                    {
                        bitmap.SetPixel(x, reversey, Color.Transparent);
                    }
                    else if (heights[y, x] <= boundry1)
                    {
                        bitmap.SetPixel(x, reversey, Color.LightBlue);
                    }
                    else if ((heights[y, x] > boundry1) && (heights[y,x] <= boundry2))
                    {
                        bitmap.SetPixel(x, reversey, Color.LightGreen);
                    } 
                    else if ((heights[y, x] > boundry2) && (heights[y,x] <= boundry3))
                    {
                        bitmap.SetPixel(x, reversey, Color.LightYellow);
                    }
                    else if (heights[y,x] > boundry3)
                    {
                        bitmap.SetPixel(x, reversey, Color.LightCoral);
                    }
                }
            }
            bitmap.Save(@"texture.bmp");
        }

        private void GetMaxMin()
        {
            float max = -999999f;
            float min = 999999f;

            for (int y = 0; y < heights.GetLength(0); y++)
            {
                for (int x = 0; x < heights.GetLength(1); x++)
                {
                    if (heights[y,x] > max)
                    {
                        max = heights[y, x];
                    }
                    if ((heights[y,x] < min) && (heights[y,x] != -9999))
                    {
                        min = heights[y, x];
                    }
                }
            }

            this.max = max;
            this.min = min;
        }
    }
}
