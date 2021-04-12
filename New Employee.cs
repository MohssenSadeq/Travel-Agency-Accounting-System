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
    public partial class New_Employee : Form
    {
        SqlConnection conn = new SqlConnection(connectionstring.con);
        SqlCommand addcommand = new SqlCommand();
        SqlDataAdapter da;
        DataTable dt3 = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        public New_Employee()
        {
            InitializeComponent();
        }
        //Employee_Id
        void Employee_ID()
        {
            if (conn.State == ConnectionState.Closed)
            { conn.Open(); }

            SqlCommand add = new SqlCommand("Select *from Employee", conn);
            SqlDataReader dr = add.ExecuteReader();
            while (dr.Read())
            {
                textBox35.Text = dr["employee_ID"].ToString();
            }
            dr.Close();
            conn.Close();
        }
        //Grid view
      public  void EmployeesDGV()
        {
            if (conn.State == ConnectionState.Closed)
            { conn.Open(); }
            dt3.Clear();
            addcommand = new SqlCommand("Select *from employee_view", conn);
            da = new SqlDataAdapter(addcommand);
            da.Fill(dt3);
            EmployeeDataGridView.DataSource = dt3;
            conn.Close();
        }
        //Browsing
        private void button12_Click(object sender, EventArgs e)
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

        private void New_Employee_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            label3.Text = radioButton10.Text;
            EmployeesDGV();
            Employee_ID();
        }

        private void textBox31_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows 0-9, backspace, and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        private void radioButton10_Click(object sender, EventArgs e)
        {
            label3.Text = radioButton10.Text;
        }

        private void radioButton9_Click(object sender, EventArgs e)
        {
            label3.Text = radioButton9.Text;
        }
        //new
        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        public void Addnew()
        {
            txtFN.Text = "";
            txtSN.Text = "";
            txtLN.Text = "";
            txtADDRE.Text = "Yafa";
            txtPHO.Text = "";
            cmb2r.Text = "Single";
            comboBox1.Text = "Secretary";
            cmb3n.Text = "Yemen";
            DATEBD.Value = DateTime.Now.ToLocalTime();
            DATEJD.Value = DateTime.Now.ToLocalTime();
            radioButton10.Checked = true;
            button4.Enabled = true;
            button3.Enabled = false;
            pic1.Image = Properties.Resources.photo;
            Employee_ID();
        }
        private void EmployeeDataGridView_Click(object sender, EventArgs e)
        {
            if (EmployeeDataGridView.CurrentRow != null)
            {
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = false;
                txtFN.Text = EmployeeDataGridView.CurrentRow.Cells["first_name"].Value.ToString();
                txtSN.Text = EmployeeDataGridView.CurrentRow.Cells["second_name"].Value.ToString();
                txtLN.Text = EmployeeDataGridView.CurrentRow.Cells["last_name"].Value.ToString();
                cmb3n.Text = EmployeeDataGridView.CurrentRow.Cells["nationality"].Value.ToString();
                txtPHO.Text = EmployeeDataGridView.CurrentRow.Cells["phone_no"].Value.ToString();
                txtADDRE.Text = EmployeeDataGridView.CurrentRow.Cells["address"].Value.ToString();
                comboBox1.Text = EmployeeDataGridView.CurrentRow.Cells["employee_Type"].Value.ToString();
                DATEJD.Text = EmployeeDataGridView.CurrentRow.Cells["Joing_date"].Value.ToString();
                DATEBD.Text = EmployeeDataGridView.CurrentRow.Cells["birth_day"].Value.ToString();
                cmb2r.Text = EmployeeDataGridView.CurrentRow.Cells["social_status"].Value.ToString();
                if (radioButton10.Text == EmployeeDataGridView.CurrentRow.Cells["sex"].Value.ToString()) { radioButton10.Checked = true; } else { radioButton9.Checked = true; }
                textBox35.Text = EmployeeDataGridView.CurrentRow.Cells["employee_ID"].Value.ToString();
                //MemoryStream ms = new MemoryStream((byte[])EmployeeDataGridView.CurrentRow.Cells["profile_pic"].Value);
                //pic1.Image = Image.FromStream(ms);
                //pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                DataGridViewRow row;
                row = EmployeeDataGridView.CurrentRow;
                Byte[] picture = (Byte[])row.Cells["profile_pic"].Value;
                MemoryStream ms = new MemoryStream(picture);
                pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                pic1.Image = Image.FromStream(ms);
              
                
                
            }
        }

        private void txtPHO_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
       
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Type A Employee Name To Search") { textBox1.Text = ""; textBox1.ForeColor = Color.Black; }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Type A Employee Name To Search";
            textBox1.ForeColor = Color.FromKnownColor(KnownColor.ActiveCaption);
            EmployeesDGV();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
            { conn.Open(); }
            dt3.Clear();
            SqlCommand addcommand2 = new SqlCommand("Select * From employee_view where first_name like '%" + textBox1.Text + "%'", conn);

            SqlDataAdapter da2 = new SqlDataAdapter(addcommand2);
            da2.Fill(dt3);
            EmployeeDataGridView.DataSource = dt3;

            if (dt3 == null)
            {
                addcommand2 = new SqlCommand("Select * From employee_view where second_name like '%" + textBox1.Text + "%'", conn);
                
                da2 = new SqlDataAdapter(addcommand2);
                da2.Fill(dt3);
                EmployeeDataGridView.DataSource = dt3;
            }
            if (dt3 == null)
            {
                addcommand2 = new SqlCommand("Select * From employee_view where last_name like '%" + textBox1.Text + "%'", conn);
         
                da2 = new SqlDataAdapter(addcommand2);
                da2.Fill(dt3);
                EmployeeDataGridView.DataSource = dt3;
            }
            if (textBox1.Text == "") { dt3.Clear(); }
            conn.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            button1.Enabled = true;

            button2.Enabled = false;
            button3.Enabled = false;
            Addnew();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DialogResult Answer = MessageBox.Show("are you sure you want to delete row number (" + textBox35.Text + ") ?", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (Answer == DialogResult.OK)
            {
                try
                {
                    conn.Open();
                    SqlCommand deletecommand = new SqlCommand("delete from Employee where employee_ID=" + textBox35.Text + "", conn);
                    deletecommand.ExecuteNonQuery();

                    MessageBox.Show("OK");
                    Employee_ID();
                    EmployeesDGV();
                    Addnew();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Table is empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {   //refresh of textBox35 >> Employee_Id + DatagridView
                    Employee_ID();
                    EmployeesDGV();
                    conn.Close();
                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (txtFN.Text == "")
            {
                MessageBox.Show("Please enter First Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFN.Focus(); button4.Enabled = true;
                return;
            }
            if (txtSN.Text == "")
            {
                MessageBox.Show("Please enter Second Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSN.Focus(); button4.Enabled = true;
                return;
            }
            if (txtLN.Text == "")
            {
                MessageBox.Show("Please  enter Last Name:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLN.Focus(); button4.Enabled = true;
                return;
            }

            if (cmb3n.Text == "")
            {
                MessageBox.Show("Please enter Nationality:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmb3n.Focus(); button4.Enabled = true;
                return;
            }
            if (txtPHO.Text == "")
            {
                MessageBox.Show("Please enter Phone Number:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPHO.Focus(); button4.Enabled = true;
                return;
            }

            if (cmb2r.Text == "")
            {
                MessageBox.Show("Please enter a Relationship:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmb2r.Focus(); button4.Enabled = true;
                return;
            }
            if (txtPHO.Text == "")
            {
                MessageBox.Show("Please enter PHONE NUMBER:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPHO.Focus(); button4.Enabled = true;
                return;
            }
            if (txtADDRE.Text == "")
            {
                MessageBox.Show("Please enter Address:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtADDRE.Focus(); button4.Enabled = true;
                return;
            }
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            try
            {
                addcommand = new SqlCommand("update Employee set employee_Type='" + comboBox1.Text + "' ,joing_date='" + DATEJD.Value + "' where employee_ID=" + textBox35.Text + "", conn);
                addcommand.ExecuteNonQuery();
                addcommand = new SqlCommand("Update informations set first_name='" + txtFN.Text + "',second_name ='" + txtSN.Text + "',last_name='" + txtLN.Text + "',nationality='" + cmb3n.Text + "',phone_no='" + txtPHO.Text + "',address= '" + txtADDRE.Text + "',birth_day='" + DATEBD.Value + "',sex='" + label3.Text + "',social_status='" + cmb2r.Text + "',profile_pic=@23 where employee_ID=" + textBox35.Text + "", conn);

                MemoryStream pp = new MemoryStream();
                pic1.Image.Save(pp, pic1.Image.RawFormat);
                Byte[] pdata = pp.GetBuffer();
                SqlParameter ppic = new SqlParameter("@23", SqlDbType.Image);
                ppic.Value = pdata;
                addcommand.Parameters.Add(ppic);
                addcommand.ExecuteNonQuery();

                EmployeesDGV();
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
                button2.Enabled = false;
                EmployeesDGV();
                conn.Close();
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (txtFN.Text == "")
            {
                MessageBox.Show("Please enter First Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFN.Focus(); button4.Enabled = true;
                return;
            }
            if (txtSN.Text == "")
            {
                MessageBox.Show("Please enter Second Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSN.Focus(); button4.Enabled = true;
                return;
            }
            if (txtLN.Text == "")
            {
                MessageBox.Show("Please  enter Last Name:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLN.Focus(); button4.Enabled = true;
                return;
            }

            if (cmb3n.Text == "")
            {
                MessageBox.Show("Please enter Nationality:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmb3n.Focus(); button4.Enabled = true;
                return;
            }
            if (txtPHO.Text == "")
            {
                MessageBox.Show("Please enter Phone Number:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPHO.Focus(); button4.Enabled = true;
                return;
            }

            if (cmb2r.Text == "")
            {
                MessageBox.Show("Please enter a Relationship:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmb2r.Focus(); button4.Enabled = true;
                return;
            }
            if (txtPHO.Text == "")
            {
                MessageBox.Show("Please enter PHONE NUMBER:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPHO.Focus(); button4.Enabled = true;
                return;
            }
            if (txtADDRE.Text == "")
            {
                MessageBox.Show("Please enter Address:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtADDRE.Focus(); button4.Enabled = true;
                return;
            }
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            try
            {



                string ss = "insert into Employee(employee_Type,Joing_date) values('" + comboBox1.Text + "','" + DATEJD.Value + "')";
                SqlCommand m = new SqlCommand(ss, conn);
                m.ExecuteNonQuery();
                Employee_ID();

                string mm = "insert into informations(employee_ID,first_name,second_name,last_name,nationality,phone_no,address,birth_day,sex,social_status,profile_pic) values (" + textBox35.Text + ", '" + txtFN.Text + "', '" + txtSN.Text + "', '" + txtLN.Text + "', '" + cmb3n.Text + "', '" + txtPHO.Text + "', '" + txtADDRE.Text + "','" + DATEBD.Value + "', '" + label3.Text + "','" + cmb2r.Text + "',@23)";

                m = new SqlCommand(mm, conn);
                MemoryStream pp = new MemoryStream();
                pic1.Image.Save(pp, pic1.Image.RawFormat);
                Byte[] pdata = pp.GetBuffer();
                //pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                SqlParameter ppic = new SqlParameter("@23", System.Data.SqlDbType.Image);
                ppic.Value = pdata;
                conn.Open();
                m.Parameters.Add(ppic);
                m.ExecuteNonQuery();
                MessageBox.Show("Add Successful");
                EmployeesDGV();
            }
            catch (Exception ex)
            {
                button4.Enabled = false;
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Employee_ID();
                EmployeesDGV();
                button4.Enabled = false;
                button3.Enabled = true;
                button2.Enabled = true;
                conn.Close();

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
            { conn.Open(); }
            dt3.Clear();
            SqlCommand addcommand2 = new SqlCommand("Select * From employee_view where first_name like '%" + textBox1.Text + "%'", conn);

            SqlDataAdapter da2 = new SqlDataAdapter(addcommand2);
            da2.Fill(dt3);
            EmployeeDataGridView.DataSource = dt3;

            if (dt3 == null)
            {
                addcommand2 = new SqlCommand("Select * From employee_view where second_name like '%" + textBox1.Text + "%'", conn);

                da2 = new SqlDataAdapter(addcommand2);
                da2.Fill(dt3);
                EmployeeDataGridView.DataSource = dt3;
            }
            if (dt3 == null)
            {
                addcommand2 = new SqlCommand("Select * From employee_view where last_name like '%" + textBox1.Text + "%'", conn);

                da2 = new SqlDataAdapter(addcommand2);
                da2.Fill(dt3);
                EmployeeDataGridView.DataSource = dt3;
            }
            ///*if (textBox1.Text == "") { dt3.Clear(); */}
            conn.Close();
        }

        private void DATEJD_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
