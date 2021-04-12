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
using System.IO;

namespace HejAndOmra
{
    public partial class Login : MetroFramework.Forms.MetroForm
    { public int f = 1;
       
     Change_Password frm = new Change_Password();
        SqlConnection conn = new SqlConnection(connectionstring.con);
        SqlCommand cmd;
        SqlDataReader dr;
        DataTable dt1 = new DataTable();
        MemoryStream ms;
        public Login()
        {
            InitializeComponent();

        }

       

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Change_Password srm = new Change_Password();
            srm.ShowDialog();
        }

       

    

        private void Login_Load(object sender, EventArgs e)
        {
            UserID.Focus();
        }

       

        private void btnOK_Click_1(object sender, EventArgs e)
        {
            
            conn.Close();
            conn.Open();

            if (UserID.Text == "")
            {
                MessageBox.Show("Please enter user ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UserID.Focus();
                return;
            }

            else if (Password.Text == "")
            {
                MessageBox.Show("Please enter password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Password.Focus();
                return;
            }
            cmd = new SqlCommand("Select user_type,user_name,user_Pwd From Users", conn);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                if (dr["user_type"].ToString() == comboBox1.Text && dr["user_name"].ToString() == UserID.Text && dr["user_Pwd"].ToString() == Password.Text)
                {
                    f = 2;
                   
                    //MessageBox.Show("Successful Login", "Congratulations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frm.Close();
                    break;
                }
                else { continue; }
            }
            dr.Close();
            conn.Close();

            if (f == 2)
            {
                Class1.m = comboBox1.Text;
                MainMenu m = new MainMenu();
                m.Show();
                this.Hide();

            }
            else { MessageBox.Show("Please Try Again With a Correct Account", "Invalid Account", MessageBoxButtons.OK, MessageBoxIcon.Error); }
           
            Password.Text = "";
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
            Environment.Exit(0);
        }

        private void UserID_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void UserID_TextChanged(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
            { conn.Open(); }

            SqlCommand add = new SqlCommand("Select *from Users where user_name='" + UserID.Text + "'", conn);
            SqlDataReader dr = add.ExecuteReader();
            while (dr.Read())
            {
                Byte[] picture = dr["user_Pic"] as byte[] ?? null;
                if (picture != null)
                {
                    ms = new MemoryStream(picture);
                    pic1.Image = System.Drawing.Image.FromStream(ms); 
                }
                System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(ms);
            }
            dr.Close();
            conn.Close();
        }
    }
}
