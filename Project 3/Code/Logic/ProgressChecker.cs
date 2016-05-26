using Helper;
using Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ProgressChecker
    {
        private int[] _InARow { get; set; }
        private Queue<int> ThisPlayer { get; set; }
        private Queue<int> CounterPlayer { get; set; }

        public ProgressChecker() { }

        public int[] InARow(Board board, Player player)
        {
            ThisPlayer = new Queue<int>();
            CounterPlayer = new Queue<int>();

            ThisPlayer.Enqueue(0);
            CounterPlayer.Enqueue(0);

            Player counterPlayer;

            #region SetCounterPlayer
            if (player == Player.One)
            {
                counterPlayer = Player.Two;
            }
            else
            {
                counterPlayer = Player.One;
            }
            #endregion

            Player[,] positions = board.Positions;

            Parallel.For(0, positions.GetLength(0), x =>
            {
                Parallel.For(0, positions.GetLength(1), y =>
                {
                    //Check on Y
                    try
                    {
                        if ((positions[x, y] == positions[x, y + 1]) && (positions[x, y] != Player.Empty))
                        {
                            if ((positions[x, y] == positions[x, y + 1]) && (positions[x, y] == positions[x, y + 2]) && (positions[x, y] != Player.Empty))
                            {
                                if ((positions[x, y] == positions[x, y + 1]) && (positions[x, y] == positions[x, y + 2]) && (positions[x, y] == positions[x, y + 3]) && (positions[x, y] != Player.Empty))
                                {
                                    if (positions[x, y] == player) ThisPlayer.Enqueue(3);
                                    else if (positions[x, y] == counterPlayer) CounterPlayer.Enqueue(3);
                                }
                                if (positions[x, y] == player) ThisPlayer.Enqueue(2);
                                else if (positions[x, y] == counterPlayer) CounterPlayer.Enqueue(2);
                            }
                            if (positions[x, y] == player) ThisPlayer.Enqueue(1);
                            else if (positions[x, y] == counterPlayer) CounterPlayer.Enqueue(1);
                        }
                        if (positions[x, y] == player) ThisPlayer.Enqueue(0);
                        else if (positions[x, y] == counterPlayer) CounterPlayer.Enqueue(0);
                    }
                    catch { }

                    //Check on X
                    try
                    {
                        if ((positions[x, y] == positions[x + 1, y]) && (positions[x, y] != Player.Empty))
                        {
                            if ((positions[x, y] == positions[x + 1, y]) && (positions[x, y] == positions[x + 2, y]) && (positions[x, y] != Player.Empty))
                            {
                                if ((positions[x, y] == positions[x + 1, y]) && (positions[x, y] == positions[x + 2, y]) && (positions[x, y] == positions[x + 3, y]) && (positions[x, y] != Player.Empty))
                                {
                                    if (positions[x, y] == player) ThisPlayer.Enqueue(3);
                                    else if (positions[x, y] == counterPlayer) CounterPlayer.Enqueue(3);
                                }
                                if (positions[x, y] == player) ThisPlayer.Enqueue(2);
                                else if (positions[x, y] == counterPlayer) CounterPlayer.Enqueue(2);
                            }
                            if (positions[x, y] == player) ThisPlayer.Enqueue(1);
                            else if (positions[x, y] == counterPlayer) CounterPlayer.Enqueue(1);
                        }
                        if (positions[x, y] == player) ThisPlayer.Enqueue(0);
                        else if (positions[x, y] == counterPlayer) CounterPlayer.Enqueue(0);
                    }
                    catch { }

                    // Check on /
                    try
                    {
                        if ((positions[x, y] == positions[x + 1, y + 1]) && (positions[x, y] != Player.Empty))
                        {
                            if ((positions[x, y] == positions[x + 1, y + 1]) && (positions[x, y] == positions[x + 2, y + 2]) && (positions[x, y] != Player.Empty))
                            {
                                if ((positions[x, y] == positions[x + 1, y + 1]) && (positions[x, y] == positions[x + 2, y + 2]) && (positions[x, y] == positions[x + 3, y + 3]) && (positions[x, y] != Player.Empty))
                                {
                                    if (positions[x, y] == player) ThisPlayer.Enqueue(3);
                                    else if (positions[x, y] == counterPlayer) CounterPlayer.Enqueue(3);
                                }
                                if (positions[x, y] == player) ThisPlayer.Enqueue(2);
                                else if (positions[x, y] == counterPlayer) CounterPlayer.Enqueue(2);
                            }
                            if (positions[x, y] == player) ThisPlayer.Enqueue(1);
                            else if (positions[x, y] == counterPlayer) CounterPlayer.Enqueue(1);
                        }
                        if (positions[x, y] == player) ThisPlayer.Enqueue(0);
                        else if (positions[x, y] == counterPlayer) CounterPlayer.Enqueue(0);
                    }
                    catch { }

                    //Check on \
                    try
                    {
                        if ((positions[x, y] == positions[x + 1, y - 1]) && (positions[x, y] != Player.Empty))
                        {
                            if ((positions[x, y] == positions[x + 1, y - 1]) && (positions[x, y] == positions[x + 2, y - 2]) && (positions[x, y] != Player.Empty))
                            {
                                if ((positions[x, y] == positions[x + 1, y - 1]) && (positions[x, y] == positions[x + 2, y - 2]) && (positions[x, y] == positions[x + 3, y - 3]) && (positions[x, y] != Player.Empty))
                                {
                                    if (positions[x, y] == player) ThisPlayer.Enqueue(3);
                                    else if (positions[x, y] == counterPlayer) CounterPlayer.Enqueue(3);
                                }
                                if (positions[x, y] == player) ThisPlayer.Enqueue(2);
                                else if (positions[x, y] == counterPlayer) CounterPlayer.Enqueue(2);
                            }
                            if (positions[x, y] == player) ThisPlayer.Enqueue(1);
                            else if (positions[x, y] == counterPlayer) CounterPlayer.Enqueue(1);
                        }
                        if (positions[x, y] == player) ThisPlayer.Enqueue(0);
                        else if (positions[x, y] == counterPlayer) CounterPlayer.Enqueue(0);
                    }
                    catch { }
                });
            });
            Updater();
            return _InARow;


        }
        private void Updater()
        {
            _InARow = new int[] { ThisPlayer.Max(), CounterPlayer.Max() };
        }
    }
}
