using Helper;
using Objects;
using System;
using System.Collections.Generic;
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
        private Board Board {get; set; }
        public CreateVisuals Visuals { get; set; }

        public GameLogic(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            Board = new Board();
            Visuals = new CreateVisuals(Board, width, height);
        }

        public void Move(int column, Player player)
        {
            Board.Update(column, player);
            Visuals = new CreateVisuals(Board, Width, Height);
        }

        public void CheckWinner()
        {
            Player player = Board.CheckWinner();

            if (player != Player.Empty)
            {
                MessageBox.Show(player.ToString() + " has won.", "Game over", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
