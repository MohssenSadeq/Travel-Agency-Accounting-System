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
    public partial class Salary : Form
    {
      
        SqlConnection conn = new SqlConnection(connectionstring.con);
        SqlCommand addcommand = new SqlCommand();
        SqlDataAdapter da;
        DataTable dt6 = new DataTable();
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        public Salary()
        {
            InitializeComponent();
        }
        // get the data when we change the date
        public void smart_get_data()
        {
          
            if (conn.State == ConnectionState.Closed)
            { conn.Open(); }
            SqlCommand ggg = new SqlCommand("select *from Salary where employee_ID='" + cmb1.Text + "'", conn);
          
            SqlDataReader dr3;
           
            dr3 = ggg.ExecuteReader();
       
            while (dr3.Read())
            {
                
                   
                if (mounthComboBox.Text == dr3["mounth"].ToString() && yearComboBox.Text == dr3["year"].ToString())
                {
                    txtBasicSalary.Text = dr3["basic_salary"].ToString();
                    textBox1.Text = dr3["salary_ID"].ToString();
                    mounthComboBox.Text = dr3["mounth"].ToString();
                    yearComboBox.Text = dr3["year"].ToString();
                    paid_dateDateTimePicker.Text = dr3["paid_date"].ToString();
                    comboBox1.Text = dr3["payment_mode"].ToString();
                    txtPaymentModeDetails.Text = dr3["mode_details"].ToString();
                    txtTotalPaid.Text = dr3["total_paid"].ToString();
                    txtDeduction.Text = dr3["remaing"].ToString();
                    label4.Text = dr3["status"].ToString();
                    groupBox1.Enabled = true;
                    button2.Enabled = true;
                    break;

                }
                else
                {
                    label4.Text = "Unavailable";
                    textBox1.Text = "";
                    txtBasicSalary.Text = "";
                    textBox1.Text = "";
                  
                    paid_dateDateTimePicker.Text = "";
                    comboBox1.Text = "";
                    txtPaymentModeDetails.Text = "";
                    txtTotalPaid.Text = "";
                    txtDeduction.Text = "";
                    groupBox1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
              

                }

            }
            dr3.Close();
            conn.Close();
        

        }
        //void salary_No()
        //{
        //    if (conn.State == ConnectionState.Closed)
        //    { conn.Open(); }

        //    SqlCommand add = new SqlCommand("Select *from Salary", conn);
        //    SqlDataReader dr = add.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        textBox1.Text = dr["salary_ID"].ToString();
        //    }
        //    dr.Close();
        //    conn.Close();
        //}
        void Employ_ID()
        {
          
           
            dt.Clear();
            addcommand = new SqlCommand("select distinct employee_ID from Salary ", conn);
            da = new SqlDataAdapter(addcommand);
            da.Fill(dt);
            cmb1.DataSource = dt;
            cmb1.DisplayMember = "employee_ID";
            cmb1.ValueMember = "employee_ID";
            if (conn.State == ConnectionState.Closed)
            { conn.Open(); }
            SqlDataReader dr = addcommand.ExecuteReader();
            while (dr.Read())
            {
                cmb1.Text = dr["employee_ID"].ToString();

            }

            dr.Close();

            conn.Close();
        }
        // get data from salary
        public void data()
        {
            //Employ_ID();
            txtStaffName.Text = " ";

            if (conn.State == ConnectionState.Closed)
            { conn.Open(); }

            string ss = "select *from Salary ";
            SqlCommand add5 = new SqlCommand(ss, conn);
            SqlDataReader dr4 = add5.ExecuteReader();

            while (dr4.Read())
            {
                if (cmb1.Text == dr4["employee_ID"].ToString())
                {
                    txtBasicSalary.Text = dr4["basic_salary"].ToString();
                    textBox1.Text = dr4["salary_ID"].ToString();
                    mounthComboBox.Text = dr4["mounth"].ToString();
                    yearComboBox.Text = dr4["year"].ToString();
                    paid_dateDateTimePicker.Text = dr4["paid_date"].ToString();
                    comboBox1.Text = dr4["payment_mode"].ToString();
                    txtPaymentModeDetails.Text = dr4["mode_details"].ToString();
                    txtTotalPaid.Text = dr4["total_paid"].ToString();
                    txtDeduction.Text = dr4["remaing"].ToString();
                    label4.Text = dr4["status"].ToString();
                    groupBox1.Enabled = true;
                    button2.Enabled = true;

                    break;
                }
                groupBox1.Enabled = false;
                button2.Enabled = false;

            }
            
            
            dr4.Close();
            conn.Close();
            //Employ_ID();
            if (conn.State == ConnectionState.Closed)
            { conn.Open(); }
            SqlCommand mmmm = new SqlCommand("select Full_Name from salary_view where employee_ID= '" + cmb1.Text + "'", conn);
            dr4 = mmmm.ExecuteReader();
            while (dr4.Read())
            {

                txtStaffName.Text = dr4["Full_Name"].ToString();
            }
            
           
            dr4.Close();
            conn.Close();
            if (label4.Text == "Unavailable") { button2.Enabled = false; }

        }

        //data_grid_View
        void DGV()
        {
            if (conn.State == ConnectionState.Closed)
            { conn.Open(); }
            dt2.Clear();
            SqlCommand m = new SqlCommand("Select*from salary_view", conn);
           SqlDataAdapter daa = new SqlDataAdapter(m);
            daa.Fill(dt2);
            SalaryDataGridView.DataSource = dt2;
            conn.Close();
        }

        private void Salary_Load(object sender, EventArgs e)
        {
            Employ_ID();
            DGV();
            data();
          
            //button2.Enabled = true;
            button3.Enabled = false;
            button4.Enabled = false;
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void cmb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void txtDeduction_TextChanged(object sender, EventArgs e)
        {
            //if (txtDeduction.Text != "")
            //{
            //    txtTotalPaid.Text = Convert.ToString(Convert.ToInt32(txtBasicSalary.Text) - Convert.ToInt32(txtDeduction.Text));
            //}
            //else
            //{
            //    txtTotalPaid.Text = txtBasicSalary.Text;
            //    txtDeduction.Text = "0";

            //}
            if (txtDeduction.Text.Length !=0)
            {
                txtTotalPaid.Text = Convert.ToString(Convert.ToInt32(txtBasicSalary.Text) - (Convert.ToInt32(txtDeduction.Text)));
            }



        }

        private void label4_TextChanged(object sender, EventArgs e)
        {
            if (label4.Text == "Availabel") { label4.ForeColor = Color.LightGreen; }
            else { label4.ForeColor = Color.LightGreen; }
            if (label4.Text == "Paied") { label4.ForeColor = Color.DeepSkyBlue; }
        }

        private void mounthComboBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void yearComboBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void mounthComboBox_DropDownClosed(object sender, EventArgs e)
        {
            smart_get_data();
        }

        private void yearComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
          
        }

        private void txtDeduction_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46)||(txtDeduction.Text.Length==9 && e.KeyChar != 8))
            {
                e.Handled = true;
              

                return;
            }
        }

        private void mounthComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void yearComboBox_DropDownClosed(object sender, EventArgs e)
        {
            smart_get_data();
        }

        private void button77_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "Type A Employee Name To Search") { textBox2.Text = ""; textBox2.ForeColor = Color.Black; }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox2.Text = "Type A Employee Name To Search";
            textBox2.ForeColor = Color.FromKnownColor(KnownColor.ActiveCaption);
            DGV();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
            { conn.Open(); }
            dt6.Clear();

            SqlCommand addcommand2 = new SqlCommand("Select * From salary_view where Full_Name like '%" + textBox1.Text + "%'", conn);

            SqlDataAdapter da2 = new SqlDataAdapter(addcommand2);
            da2.Fill(dt6);
            SalaryDataGridView.DataSource = dt6;


            conn.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (label4.Text != "Unavailable" || label4.Text != "") { button3.Enabled = true; button4.Enabled = true; }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                MessageBox.Show("No Found informations to Update:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


                return;
            }
            if (cmb1.Text == "")
            {
                MessageBox.Show("Please enter Employee_ID:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmb1.Focus();
                return;
            }

            if (mounthComboBox.Text == "")
            {
                MessageBox.Show("Please enter a Mounth:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mounthComboBox.Focus();
                return;
            }
            if (yearComboBox.Text == "")
            {
                MessageBox.Show("Please enter a Year:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                yearComboBox.Focus();
                return;
            }
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Please enter Payment Mode:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox1.Focus();
                return;
            }
            if (txtDeduction.Text == "")
            {
                txtDeduction.Text = "0";
            }



            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            try
            {
                addcommand = new SqlCommand("update salary set mounth='" + mounthComboBox.Text + "' ,year='" + yearComboBox.Text + "', basic_salary='" + txtBasicSalary.Text + "',status=@1,paid_date='" + paid_dateDateTimePicker.Value + "',payment_mode='" + comboBox1.Text + "',mode_details='" + txtPaymentModeDetails.Text + "',remaing=" + txtDeduction.Text + ",total_paid='" + txtTotalPaid.Text + "'  where salary_ID='" + textBox1.Text + "'", conn);
                addcommand.Parameters.AddWithValue("@1", "Paied");
                addcommand.ExecuteNonQuery();

                MessageBox.Show("Updated Successful", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {

                DGV();

                smart_get_data();
                data();
                conn.Close();
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("No Found informations to Update:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


                return;
            }
            if (cmb1.Text == "")
            {
                MessageBox.Show("Please enter Employee_ID:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmb1.Focus();
                return;
            }

            if (mounthComboBox.Text == "")
            {
                MessageBox.Show("Please enter a Mounth:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mounthComboBox.Focus();
                return;
            }
            if (yearComboBox.Text == "")
            {
                MessageBox.Show("Please enter a Year:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                yearComboBox.Focus();
                return;
            }
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Please enter Payment Mode:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox1.Focus();
                return;
            }
            if (txtDeduction.Text == "")
            {
                txtDeduction.Text = "0";
            }



            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            try
            {
                addcommand = new SqlCommand("update salary set mounth='" + mounthComboBox.Text + "' ,year='" + yearComboBox.Text + "', basic_salary='" + txtBasicSalary.Text + "',status=@1,paid_date='" + paid_dateDateTimePicker.Value + "',payment_mode='" + comboBox1.Text + "',mode_details='" + txtPaymentModeDetails.Text + "',remaing=" + txtDeduction.Text + ",total_paid='" + txtTotalPaid.Text + "'  where salary_ID='" + textBox1.Text + "'", conn);
                addcommand.Parameters.AddWithValue("@1", "Unpaied");
                addcommand.ExecuteNonQuery();

                MessageBox.Show("Updated Successful", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                DGV();
                smart_get_data();

                data();
                conn.Close();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
                if (conn.State == ConnectionState.Closed)
                { conn.Open(); }
                dt6.Clear();

                SqlCommand addcommand2 = new SqlCommand("Select * From salary_view where Full_Name like '%" + textBox2.Text + "%'", conn);

                SqlDataAdapter da2 = new SqlDataAdapter(addcommand2);
                da2.Fill(dt6);
                SalaryDataGridView.DataSource = dt6;


                conn.Close();
            

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            
        }

        private void cmb1_DropDownClosed(object sender, EventArgs e)
        {
            data();
        }
    }
    }

