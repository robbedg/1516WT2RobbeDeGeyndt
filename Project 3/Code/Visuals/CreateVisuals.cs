using Helper;
using Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visuals
{
    public class CreateVisuals
    {
        private Bitmap output { get; set; }
        public CreateVisuals(Board board, int width, int height)
        {
            output = new Bitmap(width, height);

            Bitmap temp = (Bitmap)output.Clone();

            float difwidth = ((float)output.Width) / (float)(board.Positions.GetLength(0));
            float difheight = ((float)output.Height) / (float)(board.Positions.GetLength(1));

            #region grid
            //Vertical lines
            for (var x = 0f; x < output.Width; x = x + difwidth)
            {
                for (int y = 0; y < output.Height; y++)
                {
                    temp.SetPixel((int)x, y, Color.Black);
                }
            }

            //Outer border vertical
            for (var y = 0; y < output.Height; y++)
            {
                temp.SetPixel(output.Width - 1, y, Color.Black);
            }

            //Horizontal lines
            for (var y = 0f; y < output.Height; y = y + difheight)
            {
                for (int x = 0; x < output.Width; x++)
                {
                    temp.SetPixel(x, (int)y, Color.Black);
                }
            }

            //Outer border horizontal
            for (var x = 0; x < output.Width; x++)
            {
                temp.SetPixel(x, output.Height - 1, Color.Black);
            }
            #endregion

            for (int x = 0; x < board.Positions.GetLength(0); x++)
            {
                for (int y = 0; y < board.Positions.GetLength(1); y++)
                {
                    if (board.Positions[x,y] != Player.Empty)
                    {
                        int startwidth = (int)((difwidth) * x);
                        int startheight = (int)((difheight) * y);
                        Player player = board.Positions[x, y];

                        for (int xp = startwidth; xp < startwidth + difwidth; xp++)
                        {
                            for (int yp = startheight; yp < startheight + difheight; yp++)
                            {
                                if (player == Player.One)
                                {
                                    temp.SetPixel(xp, yp, Color.Red);
                                }
                                else if (player == Player.Two)
                                {
                                    temp.SetPixel(xp, yp, Color.Blue);
                                }
                            }
                        }
                    }
                }
            }

            #region reverse
            for (int x = 0; x < output.Width; x++)
            {
                for (int y = 0; y < output.Height; y++)
                {
                    output.SetPixel(x, output.Height - 1 - y, temp.GetPixel(x, y));
                }
            }
            #endregion

            output.Save("board.bmp");
        }
    }
}
