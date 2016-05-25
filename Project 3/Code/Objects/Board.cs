using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects
{
    public class Board
    {
        public Player[,] Positions {get; set;}

        public Board()
        {
            Positions = new Player[7, 6];
        }

        public void Update(int x, Player player)
        {
            for (int y = Positions.GetLength(1) - 1; y >= 0; y--)
            {
                if (Positions[x,y] != Player.Empty)
                {
                    Positions[x, y + 1] = player;
                    break;
                }

                //if row still empty
                if ((y == 0) && (Positions[x,y] == Player.Empty))
                {
                    Positions[x, y] = player;
                }
            }
        }

        public Player CheckWinner()
        {
            for (int x = 0; x < Positions.GetLength(0); x++)
            {
                for (int y = 0; y < Positions.GetLength(1); y++)
                {
                    //Check on Y
                    try
                    {
                        if ((Positions[x, y] == Positions[x, y + 1]) && (Positions[x, y] == Positions[x, y + 2]) && (Positions[x, y] == Positions[x, y + 3]) && (Positions[x, y] != Player.Empty))
                        {
                            return Positions[x, y];
                        }
                    } catch { }

                    //Check on X
                    try
                    {
                        if ((Positions[x, y] == Positions[x + 1, y]) && (Positions[x, y] == Positions[x + 2, y]) && (Positions[x, y] == Positions[x + 3, y]) && (Positions[x, y] != Player.Empty))
                        {
                            return Positions[x, y];
                        }
                    } catch { }

                    // Check on /
                    try
                    {
                        if ((Positions[x, y] == Positions[x + 1, y + 1]) && (Positions[x, y] == Positions[x + 2, y + 2]) && (Positions[x, y] == Positions[x + 3, y + 3]) && (Positions[x, y] != Player.Empty))
                        {
                            return Positions[x, y];
                        }
                    } catch { }

                    //Check on \
                    try
                    {
                        if ((Positions[x, y] == Positions[x + 1, y - 1]) && (Positions[x, y] == Positions[x + 2, y - 2]) && (Positions[x, y] == Positions[x + 3, y - 3]) && (Positions[x, y] != Player.Empty))
                        {
                            return Positions[x, y];
                        }
                    } catch { }
                }
            }
            return Player.Empty;
        }
    }
}
