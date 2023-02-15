using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Wlizzer_Esports
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            try
            {
                string connectionString;
                SqlConnection cnn;
                connectionString = @"Data Source=SCROLL;Initial Catalog=Sport;Integrated Security=True";
                cnn = new SqlConnection(connectionString);
                cnn.Open();
                SqlCommand cmd = new SqlCommand("Select first_name from login where username = '" + Login.un + "'", cnn);
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    labelFn.Text = da.GetValue(0).ToString();
                }
                cnn.Close();
                cnn.Open();
                SqlCommand cmm = new SqlCommand("Select notification from Notification where username = '" + Login.un + "'", cnn);
                SqlDataReader dr = cmm.ExecuteReader();
                while (dr.Read())
                {
                    labelNote.Text = dr.GetValue(0).ToString();
                }
                cnn.Close();

                labelUs.Text = Login.un;
                pnlHome.BackColor = Color.FromArgb(100, 0, 0, 0);


                SqlDataAdapter daa = new SqlDataAdapter("Select NotifyCW,NotifyMW,NotifyFort,NotifyFH,NotifyPub,NotifyCrew,NotifyLol From competition where username = '" + Login.un + "'", cnn);
                DataTable dt = new DataTable();
                daa.Fill(dt);
                if (dt.Rows[0][0] != DBNull.Value || dt.Rows[0][1] != DBNull.Value || dt.Rows[0][2] != DBNull.Value || dt.Rows[0][3] != DBNull.Value || dt.Rows[0][4] != DBNull.Value || dt.Rows[0][5] != DBNull.Value || dt.Rows[0][6] != DBNull.Value)
                {
                    pictureBoxNoti.Show();
                    pictureBoxNoti1.Hide();
                }
                else
                {
                    pictureBoxNoti1.Show();
                    pictureBoxNoti.Hide();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }         
            

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBoxSettings_Click(object sender, EventArgs e)
        {
            AccountSettings newform = new AccountSettings();
            newform.Show();
            this.Hide();
        }

        private void pictureBoxSettings_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void pictureBoxSettings_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void pictureBoxGame_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void pictureBoxGame_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void pictureBoxLogOut_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void pictureBoxLogOut_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void pictureBoxLogOut_Click(object sender, EventArgs e)
        {
            Login newform = new Login();
            newform.Show();
            this.Hide();
        }

        private void pictureBoxGame_Click(object sender, EventArgs e)
        {
            AvaComp ac = new AvaComp();
            ac.Show();
        }


        private void pictureBoxNoti_Click(object sender, EventArgs e)
        {
            NotificationMessage nm = new NotificationMessage();
            nm.Show();
            pictureBoxNoti1.Show();
            pictureBoxNoti.Hide();
        }

        private void pictureBoxNoti1_Click(object sender, EventArgs e)
        {
            NotificationMessage nm = new NotificationMessage();
            nm.Show();
        }

    }
}
