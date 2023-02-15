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
    public partial class Notify : Form
    {
        public Notify()
        {
            InitializeComponent();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxNoti.Text == "")
                {
                    MessageBox.Show("Empty Notification, Please type a Notification to send","Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (radioButtonCodCW.Checked == false && radioButtonCodMW.Checked == false && radioButtonFort.Checked == false && radioButtonFh4.Checked == false && radioButtonPub.Checked == false && radioButtonCrew.Checked == false && radioButtonLol.Checked == false)
                    {
                        MessageBox.Show("Didn't check any Game", "Note", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string connectionString;
                        SqlConnection cnn;
                        connectionString = @"Data Source=SCROLL;Initial Catalog=Sport;Integrated Security=True";
                        cnn = new SqlConnection(connectionString);
                        cnn.Open();

                        if (radioButtonCodCW.Checked == true)
                        {

                            string sql = "Update competition set NotifyCW='" + textBoxNoti.Text + "' where CodCW = '" + true + "'";
                            SqlCommand com = new SqlCommand(sql, cnn);

                            int i = com.ExecuteNonQuery();
                            if (i > 0)
                            {
                                MessageBox.Show("Successfully Sent the Notification");

                            }
                        }

                        if (radioButtonCodMW.Checked == true)
                        {
                            string sql = "Update competition set NotifyMW='" + textBoxNoti.Text + "' where CodMW = '" + true + "'";
                            SqlCommand com = new SqlCommand(sql, cnn);

                            int i = com.ExecuteNonQuery();
                            if (i > 0)
                            {
                                MessageBox.Show("Successfully Sent the Notification");

                            }
                        }

                        if (radioButtonFort.Checked == true)
                        {
                            string sql = "Update competition set NotifyFort='" + textBoxNoti.Text + "' where Fort = '" + true + "'";
                            SqlCommand com = new SqlCommand(sql, cnn);

                            int i = com.ExecuteNonQuery();
                            if (i > 0)
                            {
                                MessageBox.Show("Successfully Sent the Notification");

                            }
                        }

                        if (radioButtonFh4.Checked == true)
                        {
                            string sql = "Update competition set NotifyFH='" + textBoxNoti.Text + "' where FH = '" + true + "'";
                            SqlCommand com = new SqlCommand(sql, cnn);

                            int i = com.ExecuteNonQuery();
                            if (i > 0)
                            {
                                MessageBox.Show("Successfully Sent the Notification");

                            }
                        }

                        if (radioButtonPub.Checked == true)
                        {
                            string sql = "Update competition set NotifyPub='" + textBoxNoti.Text + "' where Pub = '" + true + "'";
                            SqlCommand com = new SqlCommand(sql, cnn);

                            int i = com.ExecuteNonQuery();
                            if (i > 0)
                            {
                                MessageBox.Show("Successfully Sent the Notification");

                            }
                        }

                        if (radioButtonCrew.Checked == true)
                        {
                            string sql = "Update competition set NotifyCrew='" + textBoxNoti.Text + "' where Crew = '" + true + "'";
                            SqlCommand com = new SqlCommand(sql, cnn);

                            int i = com.ExecuteNonQuery();
                            if (i > 0)
                            {
                                MessageBox.Show("Successfully Sent the Notification");

                            }
                        }

                        if (radioButtonLol.Checked == true)
                        {
                            string sql = "Update competition set NotifyLol='" + textBoxNoti.Text + "' where Lol = '" + true + "'";
                            SqlCommand com = new SqlCommand(sql, cnn);

                            int i = com.ExecuteNonQuery();
                            if (i > 0)
                            {
                                MessageBox.Show("Successfully Sent the Notification");

                            }
                        }
                    }
                    
                }
                
            }
            
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSendMem_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxNoti.Text == "")
                {
                    MessageBox.Show("Empty Notification, Please type a Notification to send", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string connectionString;
                    SqlConnection cnn;
                    connectionString = @"Data Source=SCROLL;Initial Catalog=Sport;Integrated Security=True";
                    cnn = new SqlConnection(connectionString);
                    cnn.Open();
                    string sql = "Update Notification set notification='" + textBoxNoti.Text + "' where username = '" + textBoxUsId.Text + "'";
                    SqlCommand com = new SqlCommand(sql, cnn);

                    int i = com.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Successfully Sent the Notification");

                    }
                    cnn.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void groupBoxUser_Enter(object sender, EventArgs e)
        {
            groupBoxGame.Enabled = false;
        }

        private void groupBoxUser_Leave(object sender, EventArgs e)
        {
            groupBoxGame.Enabled = true;
        }

        private void groupBoxGame_Enter(object sender, EventArgs e)
        {
            groupBoxUser.Enabled = false;
        }

        private void groupBoxGame_Leave(object sender, EventArgs e)
        {
            groupBoxUser.Enabled = true;
        }

        private void buttonSendAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxNoti.Text == "")
                {
                    MessageBox.Show("Empty Notification, Please type a Notification to send", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string connectionString;
                    SqlConnection cnn;
                    connectionString = @"Data Source=SCROLL;Initial Catalog=Sport;Integrated Security=True";
                    cnn = new SqlConnection(connectionString);
                    cnn.Open();
                    string sql = "Update Notification set notification='" + textBoxNoti.Text + "'";
                    SqlCommand com = new SqlCommand(sql, cnn);

                    int i = com.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Successfully Sent the Notification");

                    }
                    cnn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

}
