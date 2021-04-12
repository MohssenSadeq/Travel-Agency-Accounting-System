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
    public partial class users : Form
    {
        SqlConnection conn = new SqlConnection(connectionstring.con);
        SqlCommand addcommand = new SqlCommand();
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        MemoryStream ms;
        public users()
        {
            InitializeComponent();
        }

        void usersDGV()
        {
            if (conn.State == ConnectionState.Closed)
            { conn.Open(); }
            dt.Clear();
            addcommand = new SqlCommand("Select *from Users", conn);
            da = new SqlDataAdapter(addcommand);
            da.Fill(dt);
            UsersDataGridView.DataSource = dt;
            conn.Close();
        }

        private void users_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            usersDGV();
        }
        void userID()
        {
            if (conn.State == ConnectionState.Closed)
            { conn.Open(); }

            SqlCommand add = new SqlCommand("Select *from Users", conn);
            SqlDataReader dr = add.ExecuteReader();
            while (dr.Read())
            {
                textBox2.Text = dr["user_ID"].ToString();
            }
            dr.Close();
            conn.Close();
        }
        //Browsing Pic
        private void button7_Click(object sender, EventArgs e)
        {

            try
            {
                var img = openFileDialog1;

                img.Filter = ("Images |*.png; *.bmp; *.jpg;*.jpeg; *.gif; *.ico");
                img.FilterIndex = 4;

                //Reset the file name
                openFileDialog1.FileName = "";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    pic1.Image = Image.FromFile(openFileDialog1.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invaild pic", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        void New()
        {
            button4.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            user_typeComboBox.Text = "User";
            user_NameTextBox.Text = "";
            user_PwdTextBox.Text = "";
            textBox1.Text = "";
            user_joining_dateDateTimePicker.Value = DateTime.Now.ToLocalTime();
            pic1.Image = Properties.Resources.photo;


        }
        //User Name Check
        private void user_NameTextBox_Validating(object sender, CancelEventArgs e)
        {


        }


        //Update
        private void button3_Click(object sender, EventArgs e)
        {
           
        }
        //Delete
        private void button2_Click(object sender, EventArgs e)
        {
           
        }
        //get data
        private void UsersDataGridView_Click(object sender, EventArgs e)
        {
            if (UsersDataGridView.CurrentRow != null)
            {
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = false;
                textBox2.Text = UsersDataGridView.CurrentRow.Cells["user_ID"].Value.ToString();
                user_typeComboBox.Text = UsersDataGridView.CurrentRow.Cells["user_type"].Value.ToString();
                user_NameTextBox.Text = UsersDataGridView.CurrentRow.Cells["user_name"].Value.ToString();
                user_PwdTextBox.Text = UsersDataGridView.CurrentRow.Cells["user_Pwd"].Value.ToString();
                textBox1.Text = UsersDataGridView.CurrentRow.Cells["user_Pwd"].Value.ToString();

                user_joining_dateDateTimePicker.Text = UsersDataGridView.CurrentRow.Cells["user_joining_date"].Value.ToString();
                label7.Text = UsersDataGridView.CurrentRow.Cells["user_name"].Value.ToString();
                DataGridViewRow row;
                row = UsersDataGridView.CurrentRow;

                Byte[] picture = (Byte[])row.Cells["user_Pic"].Value;
                ms = new MemoryStream(picture);
                pic1.Image = Image.FromStream(ms);


                user_NameTextBox.BackColor = Color.LightGreen;
                    label4.ForeColor = Color.LightGreen;
             
            }
        }
        //New
        private void button1_Click(object sender, EventArgs e)
        {
           
        }
        //save
        private void button4_Click(object sender, EventArgs e)
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
            
            label4.ForeColor = System.Drawing.SystemColors.Window;
            if (conn.State == ConnectionState.Closed)
            { conn.Open(); }
            SqlCommand add = new SqlCommand("Select *from Users", conn);
            SqlDataReader dr = add.ExecuteReader();
            TextBox tb = (TextBox)sender;
            try
            {
                while (dr.Read())
                {
                    if (button4.Enabled == false && user_NameTextBox.Text == label7.Text)
                    {
                        tb.BackColor = Color.LightGreen;
                        label4.ForeColor = Color.LightGreen;
                        break;
                    }
                    if (user_NameTextBox.Text == dr["user_name"].ToString()||user_NameTextBox.Text=="")
                    {
                        tb.BackColor = Color.Red;
                        label4.ForeColor = Color.Red;
                        break;
                    }
                    else
                    {
                        tb.BackColor = Color.LightGreen;
                        label4.ForeColor = Color.LightGreen;
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (textBox1.Text!=user_PwdTextBox.Text)
            {
                tb.BackColor = Color.Red;
                label5.ForeColor = Color.Red;
            }
            else
            {
                tb.BackColor = Color.LightGreen;
                label5.ForeColor = Color.LightGreen;
            }
        }

        private void user_PwdTextBox_TextChanged(object sender, EventArgs e)
        {

            if (textBox1.Text == user_PwdTextBox.Text)
            {
                textBox1.BackColor = Color.LightGreen;
                label5.ForeColor = Color.LightGreen;
            }
            else
            {
                textBox1.BackColor = Color.Red;
                label5.ForeColor = Color.Red;
            }
            
        }

        private void UsersDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox3_Click(object sender, EventArgs e)
        { if(textBox3.Text== "Type A User  Name To Search") { textBox3.Text = ""; textBox3.ForeColor = Color.Black; }
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
            { conn.Open(); }
            dt.Clear();
            addcommand = new SqlCommand("Select *from Users where user_name like '%"+textBox3.Text+"%'", conn);
            da = new SqlDataAdapter(addcommand);
            da.Fill(dt);
            UsersDataGridView.DataSource = dt;
            conn.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox3.Text = "Type A User  Name To Search";
            textBox3.ForeColor = Color.FromKnownColor(KnownColor.ActiveCaption);
            usersDGV();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            button1.Enabled = true;

            button2.Enabled = false;
            button3.Enabled = false;
            New();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (user_NameTextBox.Text == "")
            {
                MessageBox.Show("Please Enter User Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                user_NameTextBox.Focus(); button4.Enabled = true;
                return;
            }
            if (user_PwdTextBox.Text == "")
            {
                MessageBox.Show("Please Enter Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                user_PwdTextBox.Focus(); button4.Enabled = true;
                return;
            }
            if (textBox1.Text == "" || textBox1.Text != user_PwdTextBox.Text)
            {
                MessageBox.Show("Please  Enter The Correct  Password Again:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus(); button4.Enabled = true;
                return;
            }
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            try
            {
                SqlCommand m = new SqlCommand("Update Users set user_type='" + user_typeComboBox.Text + "' ,user_name='" + user_NameTextBox.Text + "',user_Pwd= '" + user_PwdTextBox.Text + "',user_joining_date= '" + user_joining_dateDateTimePicker.Value + "',user_Pic=@23 where user_ID =" + textBox2.Text + "", conn);
                MemoryStream pp = new MemoryStream();
                pic1.Image.Save(pp, pic1.Image.RawFormat);
                Byte[] pdata = pp.GetBuffer();
                SqlParameter ppic = new SqlParameter("@23", System.Data.SqlDbType.Image);
                ppic.Value = pdata;

                m.Parameters.Add(ppic);
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
                userID();
                usersDGV();
                button4.Enabled = false;
                button3.Enabled = true;
                button2.Enabled = false;

            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DialogResult Answer = MessageBox.Show("are you sure you want to delete row number (" + textBox2.Text + ") ?", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (Answer == DialogResult.OK)
            {
                try
                {
                    conn.Open();
                    SqlCommand deletecommand = new SqlCommand("delete from Users where user_ID=" + textBox2.Text + "", conn);
                    deletecommand.ExecuteNonQuery();

                    MessageBox.Show("OK");
                    userID();
                    usersDGV();
                    New();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Table is empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {   //refresh of comboBox2 >> Driver_ID + DatagridView
                    userID();
                    usersDGV();
                    conn.Close();

                    New();
                }
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (user_typeComboBox.Text == "")
            {
                MessageBox.Show("Please Enter User Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                user_NameTextBox.Focus(); button4.Enabled = true;
                return;
            }
            if (user_NameTextBox.Text == "")
            {
                MessageBox.Show("Please Enter User Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                user_NameTextBox.Focus(); button4.Enabled = true;
                return;
            }
            if (user_PwdTextBox.Text == "")
            {
                MessageBox.Show("Please Enter Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                user_PwdTextBox.Focus(); button4.Enabled = true;
                return;
            }
            if (textBox1.Text == "" || textBox1.Text != user_PwdTextBox.Text)
            {
                MessageBox.Show("Please  Enter The Correct  Password Again:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus(); button4.Enabled = true;
                return;
            }
            try
            {
                if (conn.State == ConnectionState.Closed)
                { conn.Open(); }

                string ss = "insert into Users(user_type,user_name,user_Pwd,user_joining_date,user_Pic) values('" + user_typeComboBox.Text + "','" + user_NameTextBox.Text + "', '" + user_PwdTextBox.Text + "','" + user_joining_dateDateTimePicker.Value + "',@23)";
                SqlCommand m = new SqlCommand(ss, conn);
                MemoryStream pp = new MemoryStream();
                pic1.Image.Save(pp, pic1.Image.RawFormat);
                Byte[] pdata = pp.GetBuffer();
                SqlParameter ppic = new SqlParameter("@23", System.Data.SqlDbType.Image);
                ppic.Value = pdata;

                m.Parameters.Add(ppic);
                m.ExecuteNonQuery();
                MessageBox.Show("Add Successful");

            }
            catch (Exception ex)
            {
                button4.Enabled = false;
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                conn.Close();
                userID();
                usersDGV();
                button4.Enabled = false;
                button3.Enabled = true;
                button2.Enabled = true;

            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

            if (conn.State == ConnectionState.Closed)
            { conn.Open(); }
            dt.Clear();
            addcommand = new SqlCommand("Select *from Users where user_name like '%" + textBox3.Text + "%'", conn);
            da = new SqlDataAdapter(addcommand);
            da.Fill(dt);
            UsersDataGridView.DataSource = dt;
            conn.Close();
        }
    }
}
