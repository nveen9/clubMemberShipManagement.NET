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
    public partial class Login : Form
    {
        
        public Login()
        {
            InitializeComponent();
            btnLogin.Select();
        }
        public static String un;
        public static String pw;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=SCROLL;Initial Catalog=Sport;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from login where username='" + txtUsername.Text + "' and password='" + txtPassword.Text + "'", con);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {
                    Home newform = new Home();
                    un = txtUsername.Text;
                    pw = txtPassword.Text;
                    newform.Show();
                    this.Hide();
                }
                else if (txtUsername.Text == "" && txtPassword.Text == "")
                {
                    MessageBox.Show("Username or Password fileds are empty");
                }
                else
                    MessageBox.Show("Invalid Username or Password", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateAccount newform = new CreateAccount();
            newform.Show();
            this.Hide();
        }

        private void chckShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chckShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '•';
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
