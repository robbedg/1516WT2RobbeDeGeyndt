using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_AI
{
    public class GUIManager
    {
        public Start Start { get; set; }
        public Game Game { get; set; }
        public bool IsClickable { get; set; }
        public int StepsAI1 { get; set; }
        public int StepsAI2 { get; set; }

        public GUIManager()
        {
            Start = new Start(this);
            Application.Run(Start);
        }

        public void InitiateGame()
        {
            Start.Hide();
            Game = new Game(this);
            Game.Show();
        }

        public void Dispose()
        {
            Application.Exit();
        }
    }
}
