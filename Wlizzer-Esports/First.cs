using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wlizzer_Esports
{
    public partial class First : Form
    {
        private bool expnd;
        public First()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDrpMenu_Click(object sender, EventArgs e)
        {
            if (expnd)
            {

                panelDropMenu.Height = 58;
                expnd = false;

            }
            else
            {

                panelDropMenu.Height = 254;
                expnd = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login nw = new Login();
            nw.Show();
            this.Hide();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            CreateAccount nw = new CreateAccount();
            nw.Show();
            this.Hide();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            LoginAd nw = new LoginAd();
            nw.Show();
            this.Hide();
        }
    }
}
