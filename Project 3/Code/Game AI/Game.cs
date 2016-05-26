using Helper;
using Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_AI
{
    public partial class Game : Form
    {
        private GUIManager Manager { get; set; }
        private GameLogic Logic { get; set; }
        public Game(GUIManager manager)
        {
            InitializeComponent();
            this.Manager = manager;
            Initiate();
        }

        public void Initiate()
        {
            Logic = new GameLogic(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.ImageLocation = "board.bmp";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point Coordinates = me.Location;
            Player player = Player.Two;
            float width = pictureBox1.Width / 7f;

            #region analyze click
            if (width > Coordinates.X)
            {
                Logic.Move(0, player);
            }
            else if ((width < Coordinates.X) && (width * 2 > Coordinates.X)) {
                Logic.Move(1, player);
            }
            else if ((width * 2 < Coordinates.X) && (width * 3 > Coordinates.X))
            {
                Logic.Move(2, player);
            }
            else if ((width * 3 < Coordinates.X) && (width * 4 > Coordinates.X))
            {
                Logic.Move(3, player);
            }
            else if ((width * 4 < Coordinates.X) && (width * 5 > Coordinates.X))
            {
                Logic.Move(4, player);
            }
            else if ((width * 5 < Coordinates.X) && (width * 6 > Coordinates.X))
            {
                Logic.Move(5, player);
            }
            else if (width * 6 < Coordinates.X)
            {
                Logic.Move(6, player);
            }
            #endregion

            pictureBox1.ImageLocation = "board.bmp";
            pictureBox1.Refresh();
            Logic.CheckWinner();

            //TEMP
            Logic.ComputerMove(Player.One);
            pictureBox1.ImageLocation = "board.bmp";
            pictureBox1.Refresh();
            Logic.CheckWinner();
        }

        private void Game_FormClosed(object sender, FormClosedEventArgs e)
        {
            Manager.Dispose();
        }
    }
}
