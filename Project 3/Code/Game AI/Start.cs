using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_AI
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            Game game = new Game();
            game.Show();
            this.Hide();
        }
    }
}
