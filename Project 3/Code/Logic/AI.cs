using Helper;
using Objects;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Visuals;

namespace Logic
{
    public class AI
    {
        private int Steps { get; set; }
        public AI(int steps)
        {
            Steps = steps;
        }

        //https://msdn.microsoft.com/en-us/library/ee256691(v=vs.110).aspx
        public Move BestMove(Board board, Player player)
        {
            ConcurrentQueue<Move> AllMoves = new ConcurrentQueue<Move>();
            Move bestMove = null;


            Parallel.ForEach(board.OpenColumns, x =>
            {
               Board newBoard;

               newBoard = board.Clone();
               newBoard.depth = board.depth + 1;

               Move newMove = new Move();
               newMove.X = x;

               newBoard.Update(x, player);

               ProgressChecker pc = new ProgressChecker();
               int[] results = pc.InARow(newBoard, player);

               if (results[0] < 3 && results[1] < 3 && newBoard.OpenColumns.Count > 0 && newBoard.depth <= Steps)
               {
                   Player counterPlayer;

                   if (player == Player.One)
                   {
                       counterPlayer = Player.Two;
                   }
                   else
                   {
                       counterPlayer = Player.One;
                   }

                   Move tempMove = BestMove(newBoard, counterPlayer);
                   newMove.Rank = -tempMove.Rank / 2;
               }
               else
               {
                   newMove.Rank = results[0] - results[1];
               }

                //Put move in que
                AllMoves.Enqueue(newMove);
            });
            
            foreach (Move move in AllMoves)
            {
                if ((bestMove == null) || bestMove.Rank < move.Rank)
                {
                    bestMove = move;
                }
            }

            return bestMove;
        }
    }
}
