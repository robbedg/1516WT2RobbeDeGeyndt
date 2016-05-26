using Helper;
using Objects;
using System;
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
        //https://msdn.microsoft.com/en-us/library/ee256691(v=vs.110).aspx
        public Move BestMove(Board board, Player player)
        {
            Move bestMove = null;

            //CancellationTokenSource cts = new CancellationTokenSource();
            //ParallelOptions po = new ParallelOptions();
            //po.CancellationToken = cts.Token;
            //po.MaxDegreeOfParallelism = System.Environment.ProcessorCount;

            foreach (int x in board.OpenColumns)
            {
                Board newBoard;

                Console.WriteLine(x);
                Console.WriteLine(board.Positions[x, 5]);

                newBoard = board.Clone();
                newBoard.depth = board.depth + 1;

                Move newMove = new Move();
                newMove.X = x;

                newBoard.Update(x, player);

                ProgressChecker pc = new ProgressChecker();
                int[] results = pc.InARow(newBoard, player);

                if (results[0] < 3 && results[1] < 3 && newBoard.OpenColumns.Count > 0 && newBoard.depth <=3)
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

                //Check witch move is better
                if (bestMove == null || (newMove.Rank > bestMove.Rank))
               {
                   bestMove = newMove;
               }
           }
            return bestMove;
        }
    }
}
