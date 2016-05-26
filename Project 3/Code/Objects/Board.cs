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
        public int depth { get; set; }
        public Player[,] Positions {get; set;}
        public List<int> OpenColumns { get; set; }
        public Board()
        {
            Positions = new Player[7, 6];
            OpenColumns = new List<int>();

            for (int x = 0; x < Positions.GetLength(0); x++)
            {
                OpenColumns.Add(x);
            }
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

            OpenColumns.Remove(x);
            for (int y = 0; y < Positions.GetLength(1); y++)
            {
                if (Positions[x, y] == Player.Empty)
                {
                    OpenColumns.Add(x);
                    break;
                }
            }
        }

        public Player CheckWinner()
        {
            Player winner = Player.Empty;

            Parallel.For(0, Positions.GetLength(0), x =>
           {
               Parallel.For(0, Positions.GetLength(1), y =>
              {
                   //Check on Y
                   try
                  {
                      if ((Positions[x, y] == Positions[x, y + 1]) && (Positions[x, y] == Positions[x, y + 2]) && (Positions[x, y] == Positions[x, y + 3]) && (Positions[x, y] != Player.Empty))
                      {
                          winner = Positions[x, y];
                      }
                  }
                  catch { }

                   //Check on X
                   try
                  {
                      if ((Positions[x, y] == Positions[x + 1, y]) && (Positions[x, y] == Positions[x + 2, y]) && (Positions[x, y] == Positions[x + 3, y]) && (Positions[x, y] != Player.Empty))
                      {
                          winner = Positions[x, y];
                      }
                  }
                  catch { }

                   // Check on /
                   try
                  {
                      if ((Positions[x, y] == Positions[x + 1, y + 1]) && (Positions[x, y] == Positions[x + 2, y + 2]) && (Positions[x, y] == Positions[x + 3, y + 3]) && (Positions[x, y] != Player.Empty))
                      {
                          winner = Positions[x, y];
                      }
                  }
                  catch { }

                   //Check on \
                   try
                  {
                      if ((Positions[x, y] == Positions[x + 1, y - 1]) && (Positions[x, y] == Positions[x + 2, y - 2]) && (Positions[x, y] == Positions[x + 3, y - 3]) && (Positions[x, y] != Player.Empty))
                      {
                          winner = Positions[x, y];
                      }
                  }
                  catch { }
              });
           });
            return winner;
        }

        public Board Clone()
        {
            Board copy = new Board();
            copy.depth = new int();
            copy.Positions = new Player[this.Positions.GetLength(0), this.Positions.GetLength(1)];
            copy.OpenColumns = new List<int>();

            copy.depth = this.depth;

            for (int x = 0; x < Positions.GetLength(0); x++)
            {
                for (int y = 0; y < Positions.GetLength(1); y++)
                {
                    if (this.Positions[x, y] == Player.One)
                    {
                        copy.Positions[x, y] = Player.One;
                    }
                    else if (this.Positions[x, y] == Player.Two)
                    {
                        copy.Positions[x, y] = Player.Two;
                    }
                }
            }

            foreach (int i in this.OpenColumns)
            {
                copy.OpenColumns.Add(i);
            }

            return copy;
        }
    }
}
