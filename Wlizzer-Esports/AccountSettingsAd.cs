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
    public partial class AccountSettingsAd : Form
    {
        public AccountSettingsAd()
        {
            InitializeComponent();
            textBoxUserName.Select();
        }

        private void buttonView_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString;
                SqlConnection cnn;
                connectionString = @"Data Source=SCROLL;Initial Catalog=Sport;Integrated Security=True";
                cnn = new SqlConnection(connectionString);
                SqlDataAdapter da = new SqlDataAdapter("Select username From login where username = '" + textBoxUserName.Text + "'", cnn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand("Select password,first_name,last_name,dob,gender,email,category from login where username = '" + textBoxUserName.Text + "'", cnn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        textBoxPassword.Text = dr.GetValue(0).ToString();
                        textBoxFirstName.Text = dr.GetValue(1).ToString();
                        textBoxLastName.Text = dr.GetValue(2).ToString();
                        dateTimePickerDob.Value = dr.GetDateTime(3);
                        if (dr.GetValue(4).ToString() == "Male")
                        {
                            radioButtonMale.Checked = true;
                        }
                        else
                        {
                            radioButtonFemale.Checked = true;
                        }
                        textBoxEmAd.Text = dr.GetValue(5).ToString();
                        labelCatt.Text = dr.GetValue(6).ToString();
                    }
                    cnn.Close();
                    SqlDataAdapter daa = new SqlDataAdapter("Select * from login where username = '" + textBoxUserName.Text + "'", cnn);
                    DataTable dtt = new DataTable();
                    daa.Fill(dtt);
                    dataGridViewAll.DataSource = dtt;
                }
                else
                {
                    MessageBox.Show("Invalid User Name, Click 'Search All' for view all Members", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clearTextBoxes();
                    labelCatt.Text = "";
                    dateTimePickerDob.Value = DateTime.Now;
                    ClearGender();
                    dataGridViewAll.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        public void clearTextBoxes()
        {
            foreach(Control ClearText in this.Controls)
            {
                if(ClearText is TextBox)
                {
                    ((TextBox)ClearText).Text = string.Empty;
                }
            }
        }       
        public void ClearGender()
        {
            if (radioButtonMale.Checked)
            {
                radioButtonMale.Checked = false;
            }
            if (radioButtonFemale.Checked)
            {
                radioButtonFemale.Checked = false;
            }
        }

        private void checkBoxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPass.Checked)
            {
                textBoxPassword.PasswordChar = '\0';
            }
            else
            {
                textBoxPassword.PasswordChar = '•';
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            clearTextBoxes();
            labelCatt.Text = "";
            dateTimePickerDob.Value = DateTime.Now;
            ClearGender();
            dataGridViewAll.DataSource = null;
            ClearCheck();
        }
        String Gender;
        private void buttonSaveDetails_Click(object sender, EventArgs e)
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
                string sql = "Update login set password='" + textBoxPassword.Text + "',first_name='" + textBoxFirstName.Text + "',last_name='" + textBoxLastName.Text + "',dob='" + dateTimePickerDob.Value + "',gender='" + Gender + "',email='" + textBoxEmAd.Text + "',category='" + cat + "' where username = '" + textBoxUserName.Text + "'";
                SqlCommand com = new SqlCommand(sql, cnn);

                int i = com.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("Successfully Updated");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void buttonSearchAll_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString;
                SqlConnection cnn;
                connectionString = @"Data Source=SCROLL;Initial Catalog=Sport;Integrated Security=True";
                cnn = new SqlConnection(connectionString);
                cnn.Open();
                SqlCommand command;
                SqlDataAdapter da = new SqlDataAdapter("Select * from login", cnn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewAll.DataSource = dt;
                cnn.Close();
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

        private void buttonViewFirstName_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxFirstName.Text == "")
                {
                    MessageBox.Show("First Name field is empty, Enter a First Name", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SqlConnection con = new SqlConnection("Data Source=SCROLL;Initial Catalog=Sport;Integrated Security=True");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Select * from login where first_name = '" + textBoxFirstName.Text + "'", con);
                    SqlDataReader dr;
                    dr = cmd.ExecuteReader();
                    if (dr.Read() == true)
                    {
                        string connectionString;
                        SqlConnection cnn;
                        connectionString = @"Data Source=SCROLL;Initial Catalog=Sport;Integrated Security=True";
                        cnn = new SqlConnection(connectionString);
                        cnn.Open();
                        SqlCommand command;
                        SqlDataAdapter da = new SqlDataAdapter("Select * from login where first_name = '" + textBoxFirstName.Text + "'", cnn);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridViewAll.DataSource = dt;
                        cnn.Close();
                    }
                    else
                    {
                        MessageBox.Show("Invalid First Name, Click 'Search All' for view all Members", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void buttonViewLastName_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxLastName.Text == "")
                {
                    MessageBox.Show("Last Name field is empty, Enter a Last Name", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SqlConnection con = new SqlConnection("Data Source=SCROLL;Initial Catalog=Sport;Integrated Security=True");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Select * from login where last_name = '" + textBoxLastName.Text + "'", con);
                    SqlDataReader dr;
                    dr = cmd.ExecuteReader();
                    if (dr.Read() == true)
                    {
                        string connectionString;
                        SqlConnection cnn;
                        connectionString = @"Data Source=SCROLL;Initial Catalog=Sport;Integrated Security=True";
                        cnn = new SqlConnection(connectionString);
                        cnn.Open();
                        SqlCommand command;
                        SqlDataAdapter da = new SqlDataAdapter("Select * from login where last_name = '" + textBoxLastName.Text + "'", cnn);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridViewAll.DataSource = dt;
                        cnn.Close();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Last Name, Click 'Search All' for view all Members", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void buttonViewDob_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=SCROLL;Initial Catalog=Sport;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from login where dob = '" + dateTimePickerDob.Value + "'", con);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {
                    string connectionString;
                    SqlConnection cnn;
                    connectionString = @"Data Source=SCROLL;Initial Catalog=Sport;Integrated Security=True";
                    cnn = new SqlConnection(connectionString);
                    cnn.Open();
                    SqlCommand command;
                    SqlDataAdapter da = new SqlDataAdapter("Select * from login where dob = '" + dateTimePickerDob.Value + "'", cnn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridViewAll.DataSource = dt;
                    cnn.Close();
                }
                else
                {
                    MessageBox.Show("Invalid Date, Click 'Search All' for view all Members", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        String Gndr;
        private void buttonViewGender_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonMale.Checked == true)
                {
                    Gndr = "Male";
                }
                else
                    Gndr = "Female";

                if (radioButtonMale.Checked || radioButtonFemale.Checked)
                {
                    string connectionString;
                    SqlConnection cnn;
                    connectionString = @"Data Source=SCROLL;Initial Catalog=Sport;Integrated Security=True";
                    cnn = new SqlConnection(connectionString);
                    cnn.Open();
                    SqlCommand command;
                    SqlDataAdapter da = new SqlDataAdapter("Select * from login where gender = '" + Gndr + "'", cnn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridViewAll.DataSource = dt;
                    cnn.Close();
                }
                else
                {
                    MessageBox.Show("Check any to View", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void buttonViewEmail_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxEmAd.Text == "")
                {
                    MessageBox.Show("Email Address field is empty, Enter a valid Email Address", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SqlConnection con = new SqlConnection("Data Source=SCROLL;Initial Catalog=Sport;Integrated Security=True");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Select * from login where email = '" + textBoxEmAd.Text + "'", con);
                    SqlDataReader dr;
                    dr = cmd.ExecuteReader();
                    if (dr.Read() == true)
                    {
                        string connectionString;
                        SqlConnection cnn;
                        connectionString = @"Data Source=SCROLL;Initial Catalog=Sport;Integrated Security=True";
                        cnn = new SqlConnection(connectionString);
                        cnn.Open();
                        SqlCommand command;
                        SqlDataAdapter da = new SqlDataAdapter("Select * from login where email = '" + textBoxEmAd.Text + "'", cnn);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridViewAll.DataSource = dt;
                        cnn.Close();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Email Address, Click 'Search All' for view all Members", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
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
                string connectionString;
                SqlConnection cnn;
                connectionString = @"Data Source=SCROLL;Initial Catalog=Sport;Integrated Security=True";
                cnn = new SqlConnection(connectionString);
                SqlDataAdapter da = new SqlDataAdapter("Select username From login where username = '" + textBoxUserName.Text + "'", cnn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    DialogResult dr = MessageBox.Show("Are You Sure, You Want to Execute the " + textBoxUserName.Text + "'s Membership", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        string ConnectionString;
                        SqlConnection cnnn;
                        ConnectionString = @"Data Source=SCROLL;Initial Catalog=Sport;Integrated Security=True";
                        cnnn = new SqlConnection(ConnectionString);
                        cnnn.Open();
                        string sql = "Delete from login where username = '" + textBoxUserName.Text + "'";
                        SqlCommand com = new SqlCommand(sql, cnnn);

                        int i = com.ExecuteNonQuery();
                        if (i > 0)
                        {
                            MessageBox.Show("" + textBoxUserName.Text + "'s Membership has been Executed", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    if (dr == DialogResult.Yes)
                    {
                        string ConnectionString;
                        SqlConnection cnnn;
                        ConnectionString = @"Data Source=SCROLL;Initial Catalog=Sport;Integrated Security=True";
                        cnnn = new SqlConnection(ConnectionString);
                        cnnn.Open();
                        string sql = "Delete from competition where username = '" + textBoxUserName.Text + "'";
                        SqlCommand com = new SqlCommand(sql, cnnn);

                        int i = com.ExecuteNonQuery();
                        if (i > 0)
                        {
                            MessageBox.Show("" + textBoxUserName.Text + "'s Competition Details has been Executed", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    if (dr == DialogResult.Yes)
                    {
                        string ConnectionString;
                        SqlConnection cnnn;
                        ConnectionString = @"Data Source=SCROLL;Initial Catalog=Sport;Integrated Security=True";
                        cnnn = new SqlConnection(ConnectionString);
                        cnnn.Open();
                        string sql = "Delete from Notification where username = '" + textBoxUserName.Text + "'";
                        SqlCommand com = new SqlCommand(sql, cnnn);

                        int i = com.ExecuteNonQuery();
                        if (i > 0)
                        {
                            MessageBox.Show("" + textBoxUserName.Text + "'s Notes has been Executed", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Invalid User Name, Click 'Search All' for view all Members", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
             
        }

        private void buttonDelAllAccount_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Are You Sure, You Want to Execute All Memberships and Details", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    string ConnectionString;
                    SqlConnection cnn;
                    ConnectionString = @"Data Source=SCROLL;Initial Catalog=Sport;Integrated Security=True";
                    cnn = new SqlConnection(ConnectionString);
                    cnn.Open();
                    string sql = "Delete from login";
                    SqlCommand com = new SqlCommand(sql, cnn);

                    int i = com.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("All Memberships has been Executed", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                if (dr == DialogResult.Yes)
                {
                    string ConnectionString;
                    SqlConnection cnn;
                    ConnectionString = @"Data Source=SCROLL;Initial Catalog=Sport;Integrated Security=True";
                    cnn = new SqlConnection(ConnectionString);
                    cnn.Open();
                    string sql = "Delete from competition";
                    SqlCommand com = new SqlCommand(sql, cnn);

                    int i = com.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("All Competition Deatils has been Executed", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                if (dr == DialogResult.Yes)
                {
                    string ConnectionString;
                    SqlConnection cnn;
                    ConnectionString = @"Data Source=SCROLL;Initial Catalog=Sport;Integrated Security=True";
                    cnn = new SqlConnection(ConnectionString);
                    cnn.Open();
                    string sql = "Delete from Notification";
                    SqlCommand com = new SqlCommand(sql, cnn);

                    int i = com.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("All Notes has been Executed", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        int cll;
        private void dataGridViewAll_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                cll = e.RowIndex;
                DataGridViewRow row = dataGridViewAll.Rows[cll];
                textBoxUserName.Text = row.Cells[0].Value.ToString();
                textBoxPassword.Text = row.Cells[1].Value.ToString();
                textBoxFirstName.Text = row.Cells[2].Value.ToString();
                textBoxLastName.Text = row.Cells[3].Value.ToString();
                dateTimePickerDob.Value = Convert.ToDateTime(row.Cells[4].Value);
                if (row.Cells[5].Value.ToString() == "Male")
                {
                    radioButtonMale.Checked = true;
                }
                else
                {
                    radioButtonFemale.Checked = true;
                }
                textBoxEmAd.Text = row.Cells[6].Value.ToString();
                labelCatt.Text = row.Cells[7].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearTextBoxes();
            labelCatt.Text = "";
            dateTimePickerDob.Value = DateTime.Now;
            ClearGender();
            dataGridViewAll.DataSource = null;
            ClearCheck();
        }

        public void ClearCheck()
        {
            if (checkBoxAction.Checked)
            {
                checkBoxAction.Checked = false;
            }
            if (checkBoxAdventure.Checked)
            {
                checkBoxAdventure.Checked = false;
            }
            if (checkBoxShooting.Checked)
            {
                checkBoxShooting.Checked = false;
            }
            if (checkBoxSports.Checked)
            {
                checkBoxSports.Checked = false;
            }
            if (checkBoxRacing.Checked)
            {
                checkBoxRacing.Checked = false;
            }
            if (checkBoxShowPass.Checked)
            {
                checkBoxShowPass.Checked = false;
            }
        }
    }
}
