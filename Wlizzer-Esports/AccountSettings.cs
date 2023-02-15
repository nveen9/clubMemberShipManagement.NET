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
    public partial class AccountSettings : Form
    {
        public AccountSettings()
        {
            InitializeComponent();
            buttonSave.Select();
        }

        private void AccountSettings_Load(object sender, EventArgs e)
        {
            try
            {
                string connectionString;
                SqlConnection cnn;
                connectionString = @"Data Source=SCROLL;Initial Catalog=Sport;Integrated Security=True";
                cnn = new SqlConnection(connectionString);
                cnn.Open();
                SqlCommand cmd = new SqlCommand("Select first_name,last_name,dob,gender,email,category from login where username = '" + Login.un + "'", cnn);
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    textBoxFirstName.Text = da.GetValue(0).ToString();
                    textBoxLastName.Text = da.GetValue(1).ToString();
                    dateTimePickerDob.Value = da.GetDateTime(2);
                    if (da.GetValue(3).ToString() == "Male")
                    {
                        radioButtonMale.Checked = true;
                    }
                    else
                    {
                        radioButtonFemale.Checked = true;
                    }
                    textBoxEmAd.Text = da.GetValue(4).ToString();
                    labelCatt.Text = da.GetValue(5).ToString();
                }
                cnn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        String Gender;
        private void buttonSaveDetails_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonMale.Checked == true)
                {
                    Gender = "Male";
                }
                else
                    Gender = "Female";

                String cat = "";
                if (checkBoxAction.CheckState == CheckState.Checked)
                {
                    cat += "Action ";
                }
                if (checkBoxAdventure.CheckState == CheckState.Checked)
                {
                    cat += "Adventure ";
                }
                if (checkBoxShooting.CheckState == CheckState.Checked)
                {
                    cat += "Shooting ";
                }
                if (checkBoxRacing.CheckState == CheckState.Checked)
                {
                    cat += "Racing ";
                }
                if (checkBoxSports.CheckState == CheckState.Checked)
                {
                    cat += "Sports ";
                }

                string connectionString;
                SqlConnection cnn;
                connectionString = @"Data Source=SCROLL;Initial Catalog=Sport;Integrated Security=True";
                cnn = new SqlConnection(connectionString);
                cnn.Open();
                string sql = "Update login set first_name='" + textBoxFirstName.Text + "',last_name='" + textBoxLastName.Text + "',dob='" + dateTimePickerDob.Value + "',gender='" + Gender + "',email='" + textBoxEmAd.Text + "',category='" + cat + "' where username = '" + Login.un + "'";
                SqlCommand com = new SqlCommand(sql, cnn);

                int i = com.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Successfully Updated");
                    this.Close();
                    AccountSettings fm = new AccountSettings();
                    fm.Show();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void chckShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chckShowPassword.Checked)
            {
                textBoxCurrentPass.PasswordChar = '\0';
            }
            else
            {
                textBoxCurrentPass.PasswordChar = '•';
            }
        }

        private void textBoxCurrentPass_Enter(object sender, EventArgs e)
        {
            if (textBoxCurrentPass.Text == "Current Password")
            {
                textBoxCurrentPass.Text = "";
                textBoxCurrentPass.PasswordChar = '•';
                textBoxCurrentPass.ForeColor = Color.Black;
            }
        }

        private void textBoxCurrentPass_Leave(object sender, EventArgs e)
        {
            if (textBoxCurrentPass.Text == "")
            {
                textBoxCurrentPass.Text = "Current Password";
                textBoxCurrentPass.PasswordChar = '\0';
                textBoxCurrentPass.ForeColor = Color.DarkGray;
            }
        }

        private void checkBoxShowPass1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPass1.Checked)
            {
                textBoxNewPass.PasswordChar = '\0';
                textBoxConfPass.PasswordChar = '\0';
            }
            else
            {
                textBoxNewPass.PasswordChar = '•';
                textBoxConfPass.PasswordChar = '•';
            }
        }

        private void textBoxNewPass_Enter(object sender, EventArgs e)
        {
            if (textBoxNewPass.Text == "New Password")
            {
                textBoxNewPass.Text = "";
                textBoxNewPass.PasswordChar = '•';
                textBoxNewPass.ForeColor = Color.Black;
            }
        }

        private void textBoxNewPass_Leave(object sender, EventArgs e)
        {
            if (textBoxNewPass.Text == "")
            {
                textBoxNewPass.Text = "New Password";
                textBoxNewPass.PasswordChar = '\0';
                textBoxNewPass.ForeColor = Color.DarkGray;
            }
        }

        private void textBoxConfPass_Enter(object sender, EventArgs e)
        {
            if (textBoxConfPass.Text == "Confirm Password")
            {
                textBoxConfPass.Text = "";
                textBoxConfPass.PasswordChar = '•';
                textBoxConfPass.ForeColor = Color.Black;
            }
        }

        private void textBoxConfPass_Leave(object sender, EventArgs e)
        {
            if (textBoxConfPass.Text == "")
            {
                textBoxConfPass.Text = "Confirm Password";
                textBoxConfPass.PasswordChar = '\0';
                textBoxConfPass.ForeColor = Color.DarkGray;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxCurrentPass.Text == Login.pw)
                {
                    groupBoxChngPass1.Show();
                    groupBoxChngPass.Hide();
                }
                else
                {
                    MessageBox.Show("Incorrect Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxNewPass.Text == textBoxConfPass.Text)
                {
                    string connectionString;
                    SqlConnection cnn;
                    connectionString = @"Data Source=SCROLL;Initial Catalog=Sport;Integrated Security=True";
                    cnn = new SqlConnection(connectionString);
                    cnn.Open();
                    string sql = "Update login set password='" + textBoxNewPass.Text + "' where username = '" + Login.un + "'";
                    SqlCommand com = new SqlCommand(sql, cnn);

                    int i = com.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Successfully Changed the Password", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Login lg = new Login();
                        this.Hide();
                        lg.Show();
                    }
                }
                else
                    MessageBox.Show("Password Not Match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void buttonDelAccount_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Are You Sure, You Want to Execute the Membership", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    string connectionString;
                    SqlConnection cnn;
                    connectionString = @"Data Source=SCROLL;Initial Catalog=Sport;Integrated Security=True";
                    cnn = new SqlConnection(connectionString);
                    cnn.Open();
                    string sql = "Delete from login where username = '" + Login.un + "'";
                    SqlCommand com = new SqlCommand(sql, cnn);

                    int i = com.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Your Membership has been Executed", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                if (dr == DialogResult.Yes)
                {
                    string connectionString;
                    SqlConnection cnn;
                    connectionString = @"Data Source=SCROLL;Initial Catalog=Sport;Integrated Security=True";
                    cnn = new SqlConnection(connectionString);
                    cnn.Open();
                    string sql = "Delete from competition where username = '" + Login.un + "'";
                    SqlCommand com = new SqlCommand(sql, cnn);

                    int i = com.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Your Competition Details has been Executed", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                if (dr == DialogResult.Yes)
                {
                    string connectionString;
                    SqlConnection cnn;
                    connectionString = @"Data Source=SCROLL;Initial Catalog=Sport;Integrated Security=True";
                    cnn = new SqlConnection(connectionString);
                    cnn.Open();
                    string sql = "Delete from Notification where username = '" + Login.un + "'";
                    SqlCommand com = new SqlCommand(sql, cnn);

                    int i = com.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Your Notes has been Executed", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Login newform = new Login();
                        newform.Show();
                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }          

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Home newform = new Home();
            newform.Show();
            this.Hide();
        }

        private void textBoxCurrentPass_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCurrentPass.Text != "")
            {
                btnNext.Enabled = true;
            }
            else
            {
                btnNext.Enabled = false;
            }
        }
    }
}
