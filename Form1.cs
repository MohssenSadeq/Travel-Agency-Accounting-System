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
    public partial class Calculations : Form
    {
        SqlConnection conn = new SqlConnection(connectionstring.con);
        SqlCommand addcommand = new SqlCommand();
        SqlDataAdapter da1;
        public static Calculations Me;
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        DataTable dt4 = new DataTable();
        SqlDataReader dr5;
     

     

        public Calculations()
        {
            InitializeComponent();
            Me = this;

        }

        void Emp_ID()
        {
            try {
                if (conn.State == ConnectionState.Closed)
                { conn.Open(); }
                dt1.Clear();
                SqlCommand add2 = new SqlCommand("select *from Employee ", conn);
                da1 = new SqlDataAdapter(add2);
                da1.Fill(dt1);
                cmb1.DataSource = dt1;
                cmb1.DisplayMember = "employee_ID";
                cmb1.ValueMember = "employee_ID";
                 }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                conn.Close();
            }
        }
  
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        { if(button11.Visible ==false&&button9.Visible == false)
            {
                button11.Visible = true;
                button9.Visible = true;
            }
            else
            {
                button11.Visible = false;
                button9.Visible = false;
            }
        }

     
        private void button9_Click(object sender, EventArgs e)
        {
            Hide();
        }

     
        private void button11_Click(object sender, EventArgs e)
        {


            Properties.Settings.Default.text1 = textBox7.Text;
            Properties.Settings.Default.text2 = textBox2.Text;
            Properties.Settings.Default.text3 = textBox3.Text;
            Properties.Settings.Default.text4 = textBox4.Text;
            Properties.Settings.Default.text5 = textBox5.Text;
            Properties.Settings.Default.text6 = textBox6.Text;
            Properties.Settings.Default.Save();
            MessageBox.Show("All settings have saved", "Settings Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            button11.Enabled = false;
        }

     

        private void Calculations_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = "1";
            Emp_ID();
            button11.Visible= false;
            button9.Visible= false;
            button11.Enabled = true;
            textBox7.Text = Properties.Settings.Default.text1;
            textBox2.Text = Properties.Settings.Default.text2;
            textBox3.Text = Properties.Settings.Default.text3;
            textBox4.Text = Properties.Settings.Default.text4;
            textBox5.Text = Properties.Settings.Default.text5;
            textBox6.Text = Properties.Settings.Default.text6;
            
           Class2.m = textBox6.Text;
            Class2.k = textBox4.Text;
            Class2.l = textBox5.Text;
            Class2.j = textBox2.Text;
            Class2.h = textBox7.Text;
            Class2.g = textBox3.Text;
            if (radioButton1.Checked) { panel1.Enabled = true;panel5.Enabled = false; }
            if (radioButton2.Checked) { panel1.Enabled = false; panel5.Enabled = true; }
            data();

        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true; panel5.Enabled = false;
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            panel1.Enabled = false; panel5.Enabled = true;
        }

        private void cmb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }
        public void Addnew()
        {
            salary_ID.Text = "";
          
            txtBasicSalary.Text = "";
         
            button4.Enabled = true;
            button3.Enabled = false;
            Emp_ID();
        }


        // get data from salary
        public void data()
        {
       
         
                if (conn.State == ConnectionState.Closed)
                { conn.Open(); }
                
                string ss = "select *from Salary ";
                SqlCommand add5 = new SqlCommand(ss, conn);
            SqlDataReader  dr4 = add5.ExecuteReader();
              
                while (dr4.Read())
                {
                    if (cmb1.Text == dr4["employee_ID"].ToString())
                    {
                        txtBasicSalary.Text = dr4["basic_salary"].ToString();
                        salary_ID.Text = dr4["salary_ID"].ToString();
                        comboBox1.Text = dr4["mounth"].ToString();
                        comboBox2.Text = dr4["year"].ToString();
                    }


                }

                dr4.Close();
            conn.Close();
            SqlCommand nn ;
            SqlDataReader mno;
            nn = new SqlCommand("select *from employee_view where employee_ID='" + cmb1.Text + "'", conn);
            if (conn.State == ConnectionState.Closed)
            { conn.Open(); }
            mno = nn.ExecuteReader();
            while (mno.Read())
            {
                textBox1.Text = mno["Full Name"].ToString();
            }

            mno.Close();
            conn.Close();
           

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DialogResult Answer = MessageBox.Show("are you sure you want to delete Salary (" + salary_ID.Text + ") ?", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (Answer == DialogResult.OK)
            {
                try
                {
                    conn.Open();
                    SqlCommand deletecommand = new SqlCommand("delete *from Salary where salary_ID=" + salary_ID.Text + "", conn);
                    deletecommand.ExecuteNonQuery();

                    MessageBox.Show("OK");
                    //Emp_ID();

                    Addnew();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message+ "No Found informations for Delete", "Table is empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {   //refresh of textBox35 >> Employee_Id + DatagridView
                    //Emp_ID();

                    conn.Close();
                }
            }
        }

        private void txtBasicSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows 0-9, backspace, and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

      

     
       // get the data when we change the date
        public void smart_get_data()
        {

            if (conn.State == ConnectionState.Closed)
            { conn.Open(); }
              SqlCommand ggg = new SqlCommand("select *from Salary where employee_ID='"+cmb1.Text+"'", conn);
           SqlDataReader     dr3 = ggg.ExecuteReader();
                while (dr3.Read())
                {
                    if (comboBox1.Text == dr3["mounth"].ToString() && comboBox2.Text == dr3["year"].ToString())
                    {
                        txtBasicSalary.Text = dr3["basic_salary"].ToString();
                        salary_ID.Text = dr3["salary_ID"].ToString();
                    break;
               
                    }
                else
                {
                    txtBasicSalary.Text = "";
                    salary_ID.Text = "";
                
                }

                }
                dr3.Close();
                conn.Close();
            
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            smart_get_data();
        }

        private void cmb1_DropDownClosed(object sender, EventArgs e)
        {
            data();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            smart_get_data();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            button1.Enabled = true;


            button3.Enabled = false;
            Addnew();
            smart_get_data();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (cmb1.Text == "")
            {
                MessageBox.Show("Please enter Employee_ID:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmb1.Focus();
                return;
            }

            if (comboBox1.Text == "")
            {
                MessageBox.Show("Please enter a Mounth:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox1.Focus();
                return;
            }
            if (comboBox2.Text == "")
            {
                MessageBox.Show("Please enter a Year:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox2.Focus();
                return;
            }
            if (txtBasicSalary.Text == "")
            {
                MessageBox.Show("Please enter Basic Salary:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBasicSalary.Focus();
                return;
            }
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            try
            {
                SqlCommand adf = new SqlCommand("select *from Salary where employee_ID=" + cmb1.Text + " ", conn);
                dr5 = adf.ExecuteReader();
                dr5.Read();
                while (dr5.Read())
                {
                    if (comboBox1.Text == dr5["mounth"].ToString() && comboBox2.Text == dr5["year"].ToString())
                    {
                        MessageBox.Show("The salary for this mounth of this Employee is already Added", "Added is not Available", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dr5.Close();
                        return;
                    }


                }
                dr5.Close();
                conn.Close();



                string ss = "insert into Salary(employee_ID,mounth,year,basic_salary,status) values('" + cmb1.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + txtBasicSalary.Text + "',@1)";
                conn.Open();

                SqlCommand m = new SqlCommand(ss, conn);
                m.Parameters.AddWithValue("@1", "Available");
                m.ExecuteNonQuery();
                MessageBox.Show("Add Successful");

            }
            //catch (Exception ex)
            //{
            //    button4.Enabled = false;
            //    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            finally
            {
                Emp_ID();

                button4.Enabled = false;
                button3.Enabled = true;
                button2.Enabled = true;
                conn.Close();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (salary_ID.Text == "")
            {
                MessageBox.Show("No Found informations to Delete:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                button1.Focus();
                button3.Enabled = false;
                return;
            }
            if (cmb1.Text == "")
            {
                MessageBox.Show("Please enter Employee_ID:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmb1.Focus();
                return;
            }

            if (comboBox1.Text == "")
            {
                MessageBox.Show("Please enter a Mounth:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox1.Focus();
                return;
            }
            if (comboBox2.Text == "")
            {
                MessageBox.Show("Please enter a Year:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox2.Focus();
                return;
            }
            if (txtBasicSalary.Text == "")
            {
                MessageBox.Show("Please enter Basic Salary:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBasicSalary.Focus();
                return;
            }
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            try
            {
                addcommand = new SqlCommand("update salary set mounth='" + comboBox1.Text + "' ,year='" + comboBox2.Text + "', basic_salary='" + txtBasicSalary.Text + "',status=@1  where salary_ID='" + salary_ID.Text + "'", conn);
                addcommand.Parameters.AddWithValue("@1", "Available");
                addcommand.ExecuteNonQuery();
                Emp_ID();

                MessageBox.Show("Updated Successful", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                button4.Enabled = false;
                button3.Enabled = true;

                Emp_ID();

                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void salary_ID_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }

