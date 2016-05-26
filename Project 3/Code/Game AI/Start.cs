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
            nudSteps2.Visible = false;
            label4.Visible = false;
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            if (cbPlayer2.SelectedItem.Equals("User"))
            {
                Manager.IsClickable = true;
                Manager.StepsAI1 = (int)nudSteps1.Value;
                Manager.InitiateGame();
            }
            else if (cbPlayer2.SelectedItem.Equals("AI"))
            {
                Manager.IsClickable = false;
                Manager.StepsAI1 = (int)nudSteps1.Value;
                Manager.StepsAI2 = (int)nudSteps2.Value;
                Manager.InitiateGame();
            }
        }

        private void cbPlayer2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPlayer2.SelectedItem.Equals("AI"))
            {
                nudSteps2.Visible = true;
                label4.Visible = true;
            }
            else
            {
                nudSteps2.Visible = false;
                label4.Visible = false;
            }
        }
    }
}
