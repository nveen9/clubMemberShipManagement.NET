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
    public partial class NotificationMessage : Form
    {
        public NotificationMessage()
        {
            InitializeComponent();
        }

        private void NotificationMessage_Load(object sender, EventArgs e)
        {
            try
            {
                string connectionString;
                SqlConnection cnn;
                connectionString = @"Data Source=SCROLL;Initial Catalog=Sport;Integrated Security=True";
                cnn = new SqlConnection(connectionString);


                SqlDataAdapter daa = new SqlDataAdapter("Select NotifyCW,NotifyMW,NotifyFort,NotifyFH,NotifyPub,NotifyCrew,NotifyLol From competition where username = '" + Login.un + "'", cnn);
                DataTable dt = new DataTable();
                daa.Fill(dt);
                if (dt.Rows[0][0] != DBNull.Value)
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand("Select NotifyCW from competition where username = '" + Login.un + "'", cnn);
                    SqlDataReader da = cmd.ExecuteReader();
                    while (da.Read())
                    {
                        labelCW.Text = da.GetValue(0).ToString();
                    }
                    cnn.Close();
                }
                else
                {
                    labelCW.Visible = true;
                }

                if (dt.Rows[0][1] != DBNull.Value)
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand("Select NotifyMW from competition where username = '" + Login.un + "'", cnn);
                    SqlDataReader da = cmd.ExecuteReader();
                    while (da.Read())
                    {
                        labelMW.Text = da.GetValue(0).ToString();
                    }
                    cnn.Close();
                }
                else
                {
                    labelMW.Visible = true;
                }

                if (dt.Rows[0][2] != DBNull.Value)
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand("Select NotifyFort from competition where username = '" + Login.un + "'", cnn);
                    SqlDataReader da = cmd.ExecuteReader();
                    while (da.Read())
                    {
                        labelF.Text = da.GetValue(0).ToString();
                    }
                    cnn.Close();
                }
                else
                {
                    labelF.Visible = true;
                }


                if (dt.Rows[0][3] != DBNull.Value)
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand("Select NotifyFH from competition where username = '" + Login.un + "'", cnn);
                    SqlDataReader da = cmd.ExecuteReader();
                    while (da.Read())
                    {
                        labelFH.Text = da.GetValue(0).ToString();
                    }
                    cnn.Close();
                }
                else
                {
                    labelFH.Visible = true;
                }


                if (dt.Rows[0][4] != DBNull.Value)
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand("Select NotifyPub from competition where username = '" + Login.un + "'", cnn);
                    SqlDataReader da = cmd.ExecuteReader();
                    while (da.Read())
                    {
                        labelPub.Text = da.GetValue(0).ToString();
                    }
                    cnn.Close();
                }
                else
                {
                    labelPub.Visible = true;
                }

                if (dt.Rows[0][5] != DBNull.Value)
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand("Select NotifyCrew from competition where username = '" + Login.un + "'", cnn);
                    SqlDataReader da = cmd.ExecuteReader();
                    while (da.Read())
                    {
                        labelCrew.Text = da.GetValue(0).ToString();
                    }
                    cnn.Close();
                }
                else
                {
                    labelCrew.Visible = true;
                }

                if (dt.Rows[0][6] != DBNull.Value)
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand("Select NotifyLol from competition where username = '" + Login.un + "'", cnn);
                    SqlDataReader da = cmd.ExecuteReader();
                    while (da.Read())
                    {
                        labelLol.Text = da.GetValue(0).ToString();
                    }
                    cnn.Close();
                }
                else
                {
                    labelLol.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
