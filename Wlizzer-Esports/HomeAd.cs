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
    public partial class HomeAd : Form
    {
        public HomeAd()
        {
            InitializeComponent();
        }

        private void HomeAd_Load(object sender, EventArgs e)
        {
            pnlHome.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBoxNotification_Click(object sender, EventArgs e)
        {
            Notify nt = new Notify();
            nt.Show();
        }

        private void pictureBoxSettings_Click(object sender, EventArgs e)
        {
            AccountSettingsAd asa = new AccountSettingsAd();
            asa.Show();
        }

        private void pictureBoxLogOut_Click(object sender, EventArgs e)
        {
            First lg = new First();
            this.Hide();
            lg.Show();
        }
    }
}
