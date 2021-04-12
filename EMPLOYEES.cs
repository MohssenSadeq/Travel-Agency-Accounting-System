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
    public partial class Drivers : Form
    {
        SqlConnection conn = new SqlConnection(connectionstring.con);
        SqlCommand addcommand1 = new SqlCommand();
        SqlCommand addcommand = new SqlCommand();
        SqlDataAdapter da1; SqlDataAdapter da;
        DataTable dt1 = new DataTable(); DataTable dt = new DataTable(); DataTable dt2 = new DataTable();

        public Drivers()
        {
            InitializeComponent();
            addcommand = new SqlCommand("select *from View_1", conn);
            da = new SqlDataAdapter(addcommand);
            da.Fill(dt);
        }

        void Employ_ID()
        {
            if (conn.State == ConnectionState.Closed)
            { conn.Open(); }
            dt1.Clear();
            addcommand1 = new SqlCommand("select *from Driver ", conn);
            da1 = new SqlDataAdapter(addcommand1);
            da1.Fill(dt1);
            comboBox2.DataSource = dt1;
            comboBox2.DisplayMember = "driver_ID";
            comboBox2.ValueMember = "driver_ID";
            SqlDataReader dr = addcommand1.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Text = dr["driver_ID"].ToString();
            }
            dr.Close();
          
             conn.Close(); 
        }
        void data_grid()
        {
            if (conn.State == ConnectionState.Closed)
            { conn.Open(); }
            dt2.Clear();
            SqlCommand addcommand2 = new SqlCommand("Select * From View_1", conn);
            SqlDataAdapter da2 = new SqlDataAdapter(addcommand2);
            da2.Fill(dt2);
            driverDataGridView.DataSource = dt2;

            
             conn.Close(); 
        }


        private void Drivers_Load(object sender, EventArgs e)
        {

            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            label3.Text = radioButton10.Text;
            data_grid();
            Employ_ID();

        }
        
        public void Addnew()
        {
            tx1.Text = "";
            tx2.Text = "";
            tx3.Text = "";
            tx4.Text = "Yemen";
            tx5.Text = "";
            tx6.Text = "";
            comboBox3.Text = "International Licence";
            date1.Value = DateTime.Now.ToLocalTime();
            date2.Value = DateTime.Now.ToLocalTime();
            date3.Value = DateTime.Now.ToLocalTime();
            radioButton10.Checked = true;
            button4.Enabled = true;
            button3.Enabled = false;
            pic1.Image = Properties.Resources.photo;

            Employ_ID();
        }
       

        //NEW
   
        
        //Delete
        private void button2_Click_1(object sender, EventArgs e)
        {
        }
        //update
        private void button3_Click_1(object sender, EventArgs e)
        {
            
        }
        //save
        private void button4_Click_1(object sender, EventArgs e)
        {
          
        }

        private void button7_Click_1(object sender, EventArgs e)
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

        private void tx5_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            // allows 0-9, backspace, and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }
        }

        private void driverDataGridView_Click_1(object sender, EventArgs e)
        {
            if (driverDataGridView.CurrentRow != null)
            {
                
                    button2.Enabled = true;
                    button3.Enabled = true;
                    button4.Enabled = false;
                    tx1.Text = driverDataGridView.CurrentRow.Cells["first_name"].Value.ToString();
                tx2.Text = driverDataGridView.CurrentRow.Cells["second_name"].Value.ToString();
                tx3.Text = driverDataGridView.CurrentRow.Cells["last_name"].Value.ToString();
                tx4.Text = driverDataGridView.CurrentRow.Cells["nationality"].Value.ToString();
                tx5.Text = driverDataGridView.CurrentRow.Cells["phone_no"].Value.ToString();
                tx6.Text = driverDataGridView.CurrentRow.Cells["address"].Value.ToString();
                comboBox3.Text = driverDataGridView.CurrentRow.Cells["licence_type"].Value.ToString();
                date1.Text = driverDataGridView.CurrentRow.Cells["start_licence"].Value.ToString();
                date2.Text = driverDataGridView.CurrentRow.Cells["birth_day"].Value.ToString();
                date3.Text = driverDataGridView.CurrentRow.Cells["expire_licence"].Value.ToString();
                if (radioButton10.Text == driverDataGridView.CurrentRow.Cells["sex"].Value.ToString()) { radioButton10.Checked = true; } else { radioButton9.Checked = true; }
                comboBox2.Text = driverDataGridView.CurrentRow.Cells["driver_ID"].Value.ToString();
                DataGridViewRow row;
                row = driverDataGridView.CurrentRow;
                Byte[] picture = (Byte[])row.Cells["profile_pic"].Value;
                MemoryStream ms = new MemoryStream(picture);
                pic1.Image = Image.FromStream(ms);

            }

        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            Employ_ID();
        }

        private void radioButton10_Click_1(object sender, EventArgs e)
        {
            label3.Text = radioButton10.Text;
        }

     

        private void radioButton9_Click_1(object sender, EventArgs e)
        {
            label3.Text = radioButton9.Text;

        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void driverDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tx5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_Click(object sender, EventArgs e)
        {

            if (textBox2.Text == "Type A Driver Name To Search") { textBox2.Text = ""; textBox2.ForeColor = Color.Black; }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
            { conn.Open(); }
            dt2.Clear();
            SqlCommand addcommand2 = new SqlCommand("Select * From View_1 where first_name like '%" + textBox2.Text + "%' OR second_name like '%" + textBox2.Text + "%'OR last_name like '%" + textBox2.Text + "%'", conn);
            //+' +second_name+' '+last_name
            SqlDataAdapter da2 = new SqlDataAdapter(addcommand2);
            da2.Fill(dt2);
            driverDataGridView.DataSource = dt2;

            conn.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox2.Text = "Type A Driver Name To Search";
            textBox2.ForeColor = Color.FromKnownColor(KnownColor.ActiveCaption);
           data_grid ();
        }

        private void button10_Click(object sender, EventArgs e)
        {

            if (conn.State == ConnectionState.Closed)
            { conn.Open(); }
            dt2.Clear();
            SqlCommand addcommand2 = new SqlCommand("Select * From View_1 where first_name like '%" + textBox2.Text + "%' OR second_name like '%" + textBox2.Text + "%'OR last_name like '%" + textBox2.Text + "%'", conn);
            //+' +second_name+' '+last_name
            SqlDataAdapter da2 = new SqlDataAdapter(addcommand2);
            da2.Fill(dt2);
            driverDataGridView.DataSource = dt2;

            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;

            button2.Enabled = false;
            button3.Enabled = false;
            Addnew();
        }

        private void button2_Click(object sender, EventArgs e)
        {


        DialogResult Answer = MessageBox.Show("are you sure you want to delete row number (" + comboBox2.Text + ") ?", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        if (Answer == DialogResult.OK)
        {
            try
            {
                conn.Open();
                SqlCommand deletecommand = new SqlCommand("delete from Driver where driver_ID=" + comboBox2.Text + "", conn);
                deletecommand.ExecuteNonQuery();

                MessageBox.Show("OK");
                Employ_ID();
                data_grid();
                Addnew();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Table is empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {   //refresh of comboBox2 >> Driver_ID + DatagridView
                Employ_ID();
                data_grid();
                conn.Close();
            }
        }
    }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tx1.Text == "")
            {
                MessageBox.Show("Please enter First Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tx1.Focus(); button4.Enabled = true;
                return;
            }
            if (tx2.Text == "")
            {
                MessageBox.Show("Please enter Second Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tx2.Focus(); button4.Enabled = true;
                return;
            }
            if (tx3.Text == "")
            {
                MessageBox.Show("Please  enter Last Name:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tx3.Focus(); button4.Enabled = true;
                return;
            }

            if (tx4.Text == "")
            {
                MessageBox.Show("Please enter Nationality:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox3.Focus(); button4.Enabled = true;
                return;
            }
            if (tx5.Text == "")
            {
                MessageBox.Show("Please enter Phone Number:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tx5.Focus(); button4.Enabled = true;
                return;
            }
            if (comboBox3.Text == "")
            {
                MessageBox.Show("Please enter Licence type:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox3.Focus(); button4.Enabled = true;
                return;
            }
            if (date1.Text == "")
            {
                MessageBox.Show("Please enter Start Licence Time:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                date1.Focus(); button4.Enabled = true;
                return;
            }
            if (date2.Text == "")
            {
                MessageBox.Show("Please enter Birth Date:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                date2.Focus(); button4.Enabled = true;
                return;
            }
            if (date3.Text == "")
            {
                MessageBox.Show("Please enter Expire Licence Time:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                date3.Focus(); button4.Enabled = true;
                return;
            }
            if (tx6.Text == "")
            {
                MessageBox.Show("Please enter Address:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tx6.Focus(); button4.Enabled = true;
                return;
            }
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            try
            {
                addcommand = new SqlCommand("update Driver set licence_type='" + comboBox3.Text + "' ,start_licence='" + date1.Value + "',expire_licence='" + date3.Value + "' where driver_ID=" + comboBox2.Text + "", conn);
                addcommand.ExecuteNonQuery();
                addcommand = new SqlCommand("Update informations set first_name='" + tx1.Text + "',second_name ='" + tx2.Text + "',last_name='" + tx3.Text + "',nationality='" + tx4.Text + "',phone_no='" + tx5.Text + "',address= '" + tx6.Text + "',birth_day='" + date2.Value + "',sex='" + label3.Text + "',profile_pic=@23 where driver_ID=" + comboBox2.Text + "", conn);

                MemoryStream pp = new MemoryStream();
                pic1.Image.Save(pp, pic1.Image.RawFormat);
                Byte[] pdata = pp.GetBuffer();
                SqlParameter ppic = new SqlParameter("@23", System.Data.SqlDbType.Image);
                ppic.Value = pdata;
                addcommand.Parameters.Add(ppic);
                addcommand.ExecuteNonQuery();
                Employ_ID();
                data_grid();
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
                data_grid();
                conn.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (tx1.Text == "")
            {
                MessageBox.Show("Please enter First Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tx1.Focus(); button4.Enabled = true;
                return;
            }
            if (tx2.Text == "")
            {
                MessageBox.Show("Please enter Second Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tx2.Focus(); button4.Enabled = true;
                return;
            }
            if (tx3.Text == "")
            {
                MessageBox.Show("Please  enter Last Name:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tx3.Focus(); button4.Enabled = true;
                return;
            }

            if (tx4.Text == "")
            {
                MessageBox.Show("Please enter Nationality:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox3.Focus(); button4.Enabled = true;
                return;
            }
            if (tx5.Text == "")
            {
                MessageBox.Show("Please enter Phone Number:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tx5.Focus(); button4.Enabled = true;
                return;
            }
            if (comboBox3.Text == "")
            {
                MessageBox.Show("Please enter Licence type:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox3.Focus(); button4.Enabled = true;
                return;
            }
            if (date1.Text == "")
            {
                MessageBox.Show("Please enter Start Licence Time:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                date1.Focus(); button4.Enabled = true;
                return;
            }
            if (date2.Text == "")
            {
                MessageBox.Show("Please enter Birth Date:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                date2.Focus(); button4.Enabled = true;
                return;
            }
            if (date3.Text == "")
            {
                MessageBox.Show("Please enter Expire Licence Time:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                date3.Focus(); button4.Enabled = true;
                return;
            }
            if (tx6.Text == "")
            {
                MessageBox.Show("Please enter Address:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                date1.Focus(); button4.Enabled = true;
                return;
            }
            try
            {



                string ss = "insert into Driver(licence_type,start_licence,expire_licence) values('" + comboBox3.Text + "','" + date1.Value + "', '" + date3.Value + "')";
                SqlCommand m = new SqlCommand(ss, conn);
                conn.Open();
                m.ExecuteNonQuery();
                Employ_ID();

                string mm = "insert into informations(driver_ID,first_name,second_name,last_name,nationality,phone_no,address,birth_day,sex,profile_pic) values (" + comboBox2.Text + ", '" + tx1.Text + "', '" + tx2.Text + "', '" + tx3.Text + "', '" + tx4.Text + "', '" + tx5.Text + "', '" + tx6.Text + "','" + date2.Value + "', '" + label3.Text + "',@23)";

                m = new SqlCommand(mm, conn);
                MemoryStream pp = new MemoryStream();
                pic1.Image.Save(pp, pic1.Image.RawFormat);
                Byte[] pdata = pp.GetBuffer();
                SqlParameter ppic = new SqlParameter("@23", System.Data.SqlDbType.Image);
                ppic.Value = pdata;
                conn.Open();
                m.Parameters.Add(ppic);
                m.ExecuteNonQuery();
                MessageBox.Show("Add Successful");
                data_grid();
            }
            catch (Exception ex)
            {
                button4.Enabled = false;
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Employ_ID();
                data_grid();
                button4.Enabled = false;
                button3.Enabled = true;
                button2.Enabled = true;
                conn.Close();

            }
        }
    }
}
