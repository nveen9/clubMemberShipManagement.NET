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
    public partial class Comp : Form
    {
        public Comp()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are You Sure, You Want to Exit without Joining", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }   
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBoxCodCW.Checked == false && checkBoxCodMW.Checked == false && checkBoxfort.Checked == false && checkBoxfh4.Checked == false && checkBoxPub.Checked == false && checkBoxCrew.Checked == false && checkBoxLol.Checked == false)
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
                    string sql = "Update competition set CodCW='" + checkBoxCodCW.Checked + "',CodMW='" + checkBoxCodMW.Checked + "',Fort='" + checkBoxfort.Checked + "',FH='" + checkBoxfh4.Checked + "',Pub='" + checkBoxPub.Checked + "',Crew='" + checkBoxCrew.Checked + "',Lol ='" + checkBoxLol.Checked + "' where username = '" + Login.un + "'";
                    SqlCommand com = new SqlCommand(sql, cnn);

                    int i = com.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Successfully Joined the Competitions, We'll get back to you soon.", "Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
        
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
      
        }

        private void Comp_Load(object sender, EventArgs e)
        {
            try
            {
                string connectionString;
                SqlConnection cnn;
                connectionString = @"Data Source=SCROLL;Initial Catalog=Sport;Integrated Security=True";
                cnn = new SqlConnection(connectionString);
                cnn.Open();
                SqlCommand cmd = new SqlCommand("Select CodCW,CodMW,Fort,FH,Pub,Crew,Lol from competition where username = '" + Login.un + "'", cnn);
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    if (da.GetValue(0).ToString() == "True")
                    {
                        checkBoxCodCW.Checked = true;
                    }
                    if (da.GetValue(1).ToString() == "True")
                    {
                        checkBoxCodMW.Checked = true;
                    }
                    if (da.GetValue(2).ToString() == "True")
                    {
                        checkBoxfort.Checked = true;
                    }
                    if (da.GetValue(3).ToString() == "True")
                    {
                        checkBoxfh4.Checked = true;
                    }
                    if (da.GetValue(4).ToString() == "True")
                    {
                        checkBoxPub.Checked = true;
                    }
                    if (da.GetValue(5).ToString() == "True")
                    {
                        checkBoxCrew.Checked = true;
                    }
                    if (da.GetValue(6).ToString() == "True")
                    {
                        checkBoxLol.Checked = true;
                    }
                }
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
