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
    public partial class CreateAccount : Form
    {
        SqlConnection con = new SqlConnection("Data Source=SCROLL;Initial Catalog=Sport;Integrated Security=True");
        public CreateAccount()
        {
            InitializeComponent();
            btnLogin.Select();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            panelDetails.BackColor = Color.FromArgb(100, 0, 0, 0);
            panelLogin.BackColor = Color.FromArgb(100, 0, 0, 0);
            panelDetails.Hide();
            panelLogin.Show();
        }

        String Gender;
        private void btnSave_Click(object sender, EventArgs e)
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

                if (textBoxFirstName.Text == "" && textBoxLastName.Text == "" && dateTimePickerDob.Text == "" && Gender == "" && textBoxEmAd.Text == "" && cat == "")
                {
                    MessageBox.Show("Some fileds are empty", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    SqlDataAdapter da = new SqlDataAdapter("Select username From login where username = '" + txtUsername.Text + "'", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count >= 1)
                    {
                        MessageBox.Show("Username Already Exist", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand(@"INSERT INTO[dbo].[login]
                    ([username],[password],[first_name],[last_name],[dob],[gender],[email],[category]) VALUES
                    ('" + txtUsername.Text + "','" + txtPassword.Text + "','" + textBoxFirstName.Text + "','" + textBoxLastName.Text + "','" + dateTimePickerDob.Value + "','" + Gender + "','" + textBoxEmAd.Text + "','" + cat + "')", con);
                        SqlCommand cmm = new SqlCommand(@"INSERT INTO[dbo].[competition]
                    ([username]) VALUES
                    ('" + txtUsername.Text + "')", con);
                        SqlCommand cmmm = new SqlCommand(@"INSERT INTO[dbo].[Notification]
                    ([username]) VALUES
                    ('" + txtUsername.Text + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        cmm.ExecuteNonQuery();
                        cmmm.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Registered Successfully", "Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnCreateAc_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select username From login where username = '" + txtUsername.Text + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    MessageBox.Show("Username Already Exist", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtUsername.Text == "" && txtPassword.Text == "")
                {
                    MessageBox.Show("Username or Password fileds are empty", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtPassword.Text == txtConfPassword.Text)
                {
                    panelDetails.Show();
                    panelLogin.Hide();
                    panelDetails.BringToFront();
                }
                else
                    MessageBox.Show("Password not Match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login newform = new Login();
            newform.Show();
            this.Hide();
        }

        private void chckShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chckShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtConfPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '•';
                txtConfPassword.PasswordChar = '•';
            }
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Username")
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = Color.Black;
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                txtUsername.Text = "Username";
                txtUsername.ForeColor = Color.DarkGray;
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (txtUsername.Text != "")
            {
                btnCreateAc.Enabled = true;
            }
            else
            {
                btnCreateAc.Enabled = false;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";
                txtPassword.PasswordChar = '•';
                txtPassword.ForeColor = Color.Black;

            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Password";
                txtPassword.PasswordChar = '\0';
                txtPassword.ForeColor = Color.DarkGray;
            }
        }

        private void txtConfPassword_Enter(object sender, EventArgs e)
        {
            if (txtConfPassword.Text == "Confirm Password")
            {
                txtConfPassword.Text = "";
                txtConfPassword.PasswordChar = '•';
                txtConfPassword.ForeColor = Color.Black;
            }
        }

        private void txtConfPassword_Leave(object sender, EventArgs e)
        {
            if (txtConfPassword.Text == "")
            {
                txtConfPassword.Text = "Confirm Password";
                txtConfPassword.PasswordChar = '\0';
                txtConfPassword.ForeColor = Color.DarkGray;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text != "")
            {
                btnCreateAc.Enabled = true;
            }
            else
            {
                btnCreateAc.Enabled = false;
            }
        }

        private void txtConfPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtConfPassword.Text != "")
            {
                btnCreateAc.Enabled = true;
            }
            else
            {
                btnCreateAc.Enabled = false;
            }
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            First nw = new First();
            nw.Show();
            this.Hide();
        }
    }

    
}
