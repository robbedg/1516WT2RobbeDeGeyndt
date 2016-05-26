using Helper;
using Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Visuals;

namespace Logic
{
    public class GameLogic
    {
        private int Width { get; set; }
        private int Height { get; set; }
        private Board Board { get; set; }
        private AI ai { get; set; }
        private AI ai2 { get; set; }
        private CreateVisuals Visuals { get; set; }
        public Bitmap Bitmap { get; set; }
        public bool GameOver { get; set; }
        public bool Retry { get; set; }
        public GameLogic(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            Board = new Board();
            ai = new AI();
            ai2 = new AI();
            Visuals = new CreateVisuals(Board, width, height);
            Bitmap = Visuals.output;
        }

        public void Move(int column, Player player)
        {
            try
            {
                Board.Update(column, player);
                Visuals = new CreateVisuals(Board, Width, Height);
                Bitmap = Visuals.output;
            }
            catch
            {
                if (Board.OpenColumns.Count == 0)
                {
                    MessageBox.Show("It's a draw.", "Game over", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    GameOver = true;
                }
                else
                {
                    MessageBox.Show("This row is full.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Retry = true;
                }
            }
        }

        public void CheckWinner()
        {
            Player player = Board.CheckWinner();

            if (player != Player.Empty)
            {
                MessageBox.Show(player.ToString() + " has won.", "Game over", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                GameOver = true;
            }
        }

        public void ComputerMove(Player player)
        {
            try
            {
                Move move = new Move();
                if (player == Player.One) move = ai.BestMove(Board, player);
                else move = ai2.BestMove(Board, player);
                Board.Update(move.X, player);
                Visuals = new CreateVisuals(Board, Width, Height);
                Bitmap = Visuals.output;
            }
            catch
            {
                MessageBox.Show("It's a draw.", "Game over", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                GameOver = true;
            }
        }
    }
}
