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
    public partial class Trips : Form
    {
        SqlConnection conn = new SqlConnection(connectionstring.con);
        SqlCommand addcommand = new SqlCommand();
        SqlDataAdapter  da1, da2;
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        public Trips()
        {
            InitializeComponent();
        }

        void Driver_ID()
        {
            if (conn.State == ConnectionState.Closed)
            { conn.Open(); }
            dt1.Clear();
            SqlCommand add2 = new SqlCommand("select *from Driver ", conn);
            da1 = new SqlDataAdapter(add2);
            da1.Fill(dt1);
            comboBox1.DataSource = dt1;
            comboBox1.DisplayMember = "driver_ID";
            comboBox1.ValueMember = "driver_ID";
            SqlDataReader dr = add2.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Text = dr["driver_ID"].ToString();
            }
            dr.Close();
           
             conn.Close(); 
        }
        void data_grid()
        {
            if (conn.State == ConnectionState.Closed)
            { conn.Open(); }
            dt.Clear();
            SqlCommand addcommand2 = new SqlCommand("Select * From Travels", conn);
            SqlDataAdapter da = new SqlDataAdapter(addcommand2);
            da.Fill(dt);
            TRIPDataGridView.DataSource = dt;
            conn.Close();
        }
        void Bus_ID()
        {
            if (conn.State == ConnectionState.Closed)
            { conn.Open(); }
            dt2.Clear();
          SqlCommand  add1 = new SqlCommand("select *from Bus ", conn);
            da2 = new SqlDataAdapter(add1);
            da2.Fill(dt2);
            comboBox2.DataSource = dt2;
            comboBox2.DisplayMember = "bus_ID";
            comboBox2.ValueMember = "bus_ID";
            SqlDataReader dr = add1.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Text = dr["bus_ID"].ToString();
            }
            dr.Close();
           
            conn.Close(); 
        }
        void travels()
        {
            if (conn.State == ConnectionState.Closed)
            { conn.Open(); }
            dt.Clear();
          SqlCommand  add = new SqlCommand("select *from HTravel ", conn);

            SqlDataReader dr = add.ExecuteReader();
            while (dr.Read())
            {
                textBox1.Text = dr["HTravel"].ToString();
            }
            dr.Close();
           
             conn.Close(); 
        }

        void New()
            {
            button4.Enabled = true;
            start_dateDateTimePicker.Value = DateTime.Now.ToLocalTime();
            end_dateDateTimePicker.Value = DateTime.Now.ToLocalTime();
            locationTextBox.Text = "Aden";
            distinationTextBox.Text = "Mekka";
            notesTextBox.Text = "";
           
        }
     


        private void TRIPDataGridView_Click(object sender, EventArgs e)
        {
            if (TRIPDataGridView.CurrentRow != null)
            {
                button3.Enabled = true;
                button4.Enabled = false;
                textBox1.Text = TRIPDataGridView.CurrentRow.Cells["HTravel"].Value.ToString();
                comboBox1.Text = TRIPDataGridView.CurrentRow.Cells["driver_ID"].Value.ToString();
                comboBox2.Text = TRIPDataGridView.CurrentRow.Cells["bus_ID"].Value.ToString();
                start_dateDateTimePicker.Text = TRIPDataGridView.CurrentRow.Cells["start_date"].Value.ToString();
                end_dateDateTimePicker.Text = TRIPDataGridView.CurrentRow.Cells["end_date"].Value.ToString();
                locationTextBox.Text = TRIPDataGridView.CurrentRow.Cells["location"].Value.ToString();
                distinationTextBox.Text = TRIPDataGridView.CurrentRow.Cells["distination"].Value.ToString();
                
            }
         
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "Type A Travel Number To Search") { textBox2.Text = ""; textBox2.ForeColor = Color.Black; }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox2.Text = "Type A Travel Number To Search";
            textBox2.ForeColor = Color.FromKnownColor(KnownColor.ActiveCaption);
            data_grid();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
            { conn.Open(); }
            dt.Clear();
            SqlCommand addcommand2 = new SqlCommand("Select * From Travels where travel_number like'%"+textBox2.Text+"%'", conn);
            SqlDataAdapter da = new SqlDataAdapter(addcommand2);
            da.Fill(dt);
            TRIPDataGridView.DataSource = dt;
            conn.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            New();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (locationTextBox.Text == "")
            {
                MessageBox.Show("Please enter First Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                locationTextBox.Focus(); button4.Enabled = true;
                return;
            }
            if (distinationTextBox.Text == "")
            {
                MessageBox.Show("Please enter Second Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                distinationTextBox.Focus(); button4.Enabled = true;
                return;
            }
            if (notesTextBox.Text == "")
            {
                MessageBox.Show("Please  enter Last Name:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                notesTextBox.Focus(); button4.Enabled = true;
                return;
            }
            try
            {

                conn.Open();
                SqlCommand m = new SqlCommand("insert into HTravel(note)values( '" + notesTextBox.Text + "')", conn);
                m.ExecuteNonQuery();
                travels();
                conn.Open();
                string ss = "insert into Travels(start_date,end_date,location,distination,driver_ID,bus_ID,HTravel) values('" + start_dateDateTimePicker.Value + "','" + end_dateDateTimePicker.Value + "', '" + locationTextBox.Text + "','" + distinationTextBox.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "',"+textBox1.Text+")";
                 m = new SqlCommand(ss, conn);
                
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
                travels();
                data_grid();
                button4.Enabled = false;
                button3.Enabled = false;
                conn.Close();

            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            if (locationTextBox.Text == "")
            {
                MessageBox.Show("Please enter First Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                locationTextBox.Focus(); button4.Enabled = true;
                return;
            }
            if (distinationTextBox.Text == "")
            {
                MessageBox.Show("Please enter Second Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                distinationTextBox.Focus(); button4.Enabled = true;
                return;
            }
            if (notesTextBox.Text == "")
            {
                MessageBox.Show("Please  enter Notes Name:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                notesTextBox.Focus(); button4.Enabled = true;
                return;
            }
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            try
            {
                string dd = "Update Travels set start_date='" + start_dateDateTimePicker.Value + "',end_date='" + end_dateDateTimePicker.Value + "',location= '" + locationTextBox.Text + "',driver_ID='" + comboBox1.Text + "',bus_ID=  '" + comboBox2.Text + "',distination='" + distinationTextBox.Text + "'where HTravel ='"+textBox1.Text+"'";
                addcommand = new SqlCommand(dd, conn);
                addcommand.ExecuteNonQuery();
                string dd1 = "Update HTravel set note='" + notesTextBox.Text + "'where HTravel ='" + textBox1.Text + "'";
                addcommand = new SqlCommand(dd1, conn);
                addcommand.ExecuteNonQuery();
                travels();
                data_grid();
                MessageBox.Show("Updated Successful", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                button3.Enabled = false;
                data_grid();
                conn.Close();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            DialogResult Answer = MessageBox.Show("are you sure you want to delete row number (" + textBox1.Text + ") ?", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (Answer == DialogResult.OK)
            {
                try
                {
                    conn.Open();
                    SqlCommand deletecommand = new SqlCommand("delete from Travels where HTravel=" + textBox1.Text + "", conn);
                    deletecommand.ExecuteNonQuery();

                    MessageBox.Show("OK");
                    travels();
                    data_grid();
                    New();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Table is empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {   //refresh of comboBox2 >> Driver_ID + DatagridView
                    travels();
                    data_grid();
                    conn.Close();
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
            { conn.Open(); }
            dt.Clear();
            SqlCommand addcommand2 = new SqlCommand("Select * From Travels where travel_number like'%" + textBox2.Text + "%'", conn);
            SqlDataAdapter da = new SqlDataAdapter(addcommand2);
            da.Fill(dt);
            TRIPDataGridView.DataSource = dt;
            conn.Close();
        }

        private void Trips_Load(object sender, EventArgs e)
        {
            Bus_ID();
            travels();
            Driver_ID();
            data_grid();
            button3.Enabled = false;
        }
    }
}
