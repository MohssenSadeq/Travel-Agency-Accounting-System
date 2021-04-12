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
namespace HejAndOmra
{
    public partial class Change_Password : MetroFramework.Forms.MetroForm
    {
        SqlConnection conn = new SqlConnection(connectionstring.con);
        SqlCommand addcommand = new SqlCommand();
     
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();


        public Change_Password()
        {
          
            InitializeComponent();
        }

        private void Change_Password_Load(object sender, EventArgs e)
        {
            btnChangePassword.Enabled = false;

        }

        private void Change_Password_FormClosed(object sender, FormClosedEventArgs e)
        {
        
        }

        private void user_NameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 47 && e.KeyChar < 57) || (e.KeyChar > 64 && e.KeyChar < 91) || (e.KeyChar > 96 && e.KeyChar < 123) || e.KeyChar == 95 | e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void user_NameTextBox_TextChanged(object sender, EventArgs e)
        {
            label7.ForeColor = System.Drawing.SystemColors.Window;
            if (conn.State == ConnectionState.Closed)
            { conn.Open(); }
            SqlCommand add = new SqlCommand("Select *from Users", conn);
            SqlDataReader dr = add.ExecuteReader();
            TextBox tb = (TextBox)sender;
            try
            {
                while (dr.Read())
                {
                  
                    if (user_NameTextBox.Text != dr["user_name"].ToString() || user_NameTextBox.Text == "")
                    {
                        tb.BackColor = Color.Red;
                        label7.ForeColor = Color.Red;
                        btnChangePassword.Enabled = false;
                        
                    }
                    else
                    {
                        tb.BackColor = Color.LightGreen;
                        label7.ForeColor = Color.LightGreen;
                        if (user_NameTextBox.Text != "" && user_PwdTextBox.Text != "" && textBox1.Text != "" && txtNewPassword.Text != "") { btnChangePassword.Enabled = true; }
                      
                        break;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                conn.Close();
            }
        }

        private void txtNewPassword_TextChanged(object sender, EventArgs e)
        {

            if (textBox1.Text == txtNewPassword.Text)
            {
                textBox1.BackColor = Color.LightGreen;
                label5.ForeColor = Color.LightGreen;
                if (user_NameTextBox.Text != "" && user_PwdTextBox.Text != "" && textBox1.Text != "" && txtNewPassword.Text != "") { btnChangePassword.Enabled = true; }
            }
            else
            {
                textBox1.BackColor = Color.Red;
                label5.ForeColor = Color.Red;
                btnChangePassword.Enabled = false;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (textBox1.Text != txtNewPassword.Text)
            {
                tb.BackColor = Color.Red;
                label5.ForeColor = Color.Red;
                btnChangePassword.Enabled = false;
            }
            else
            {
                tb.BackColor = Color.LightGreen;
                label5.ForeColor = Color.LightGreen;
                if (user_NameTextBox.Text != "" && user_PwdTextBox.Text != "" && textBox1.Text != "" && txtNewPassword.Text != "") { btnChangePassword.Enabled = true; }
            }
            
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (user_NameTextBox.Text == "")
            {
                MessageBox.Show("Please Enter User Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                user_NameTextBox.Focus();
                return;
            }
            if (user_PwdTextBox.Text == "")
            {
                MessageBox.Show("Please Enter Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                user_PwdTextBox.Focus(); 
                return;
            }
            if (textBox1.Text == "" || textBox1.Text != txtNewPassword.Text)
            {
                MessageBox.Show("Please  Enter The Correct  Password Again:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus(); 
                return;
            }
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            try
            {
                SqlCommand m = new SqlCommand("Update Users set user_Pwd= '" + txtNewPassword.Text + "' where user_name ='" + user_NameTextBox.Text + "'", conn);
           
                m.ExecuteNonQuery();
                MessageBox.Show("Update Successful");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                conn.Close();
         
            }
        }

        private void user_PwdTextBox_TextChanged(object sender, EventArgs e)
        {
            label6.ForeColor = System.Drawing.SystemColors.Window;
            if (conn.State == ConnectionState.Closed)
            { conn.Open(); }
            SqlCommand add = new SqlCommand("Select *from Users where user_name='"+ user_NameTextBox.Text+ "'", conn);
            SqlDataReader dr = add.ExecuteReader();
            TextBox tb = (TextBox)sender;
            try
            {
                while (dr.Read())
                {

                    if (user_PwdTextBox.Text != dr["user_Pwd"].ToString() || user_PwdTextBox.Text == "")
                    {
                        tb.BackColor = Color.Red;
                        label6.ForeColor = Color.Red;
                        btnChangePassword.Enabled = false;

                    }
                    else
                    {
                        tb.BackColor = Color.LightGreen;
                        label6.ForeColor = Color.LightGreen;
                        if (user_NameTextBox.Text != "" && user_PwdTextBox.Text != "" && textBox1.Text != "" && txtNewPassword.Text != "") { btnChangePassword.Enabled = true; }
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                conn.Close();
            }
        }
            }
    }

