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
        private GUIManager Manager { get; set; }
        public Start(GUIManager manager)
        {
            InitializeComponent();
            this.Manager = manager;
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            Manager.InitiateGame();
        }
    }
}
