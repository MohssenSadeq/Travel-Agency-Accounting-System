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
    public partial class Bus : Form
    { SqlConnection conn = new SqlConnection(connectionstring.con);
        SqlCommand addcommand = new SqlCommand();
        SqlDataAdapter da; SqlDataAdapter da1;
        DataTable dt = new DataTable(); DataTable dt1 = new DataTable();

        public Bus()
        {
            
            InitializeComponent();
            addcommand = new SqlCommand("Select*from Bus", conn);
            da = new SqlDataAdapter(addcommand);
            da.Fill(dt);
            this.busDataGridView.DataSource = dt;
          
        }
        void Bus1()
        {
            if (conn.State == ConnectionState.Closed)
            { conn.Open(); }
            dt1.Clear();
            SqlCommand m = new SqlCommand("select *from Bus", conn);
            da1 = new SqlDataAdapter(m);
            da1.Fill(dt1);
            comboBox2.DataSource = dt1;
            comboBox2.DisplayMember = "bus_ID";
            comboBox2.ValueMember = "bus_ID";
            SqlDataReader dr = m.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Text = dr["bus_ID"].ToString();
            }
            dr.Close();
        }
        void data_grid()
        {
            
            dt.Clear();
            addcommand = new SqlCommand("Select*from Bus", conn);
            da = new SqlDataAdapter(addcommand);
            da.Fill(dt);
            this.busDataGridView.DataSource = dt;
           
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Bus_Load(object sender, EventArgs e)
        {
            Bus1();

        }
       
    
        //get data
        private void button5_Click(object sender, EventArgs e)
        {
            try { 
            SqlCommand get = new SqlCommand("select *from Bus where bus_ID=" + comboBox2.Text + "", conn);
                if (conn.State != ConnectionState.Open)

                { conn.Open(); }
            SqlDataReader dr = get.ExecuteReader();
            dr.Read();
           
                comboBox1.Text = dr["bus_type"].ToString();
                textBox1.Text = dr["panel_no"].ToString();
                textBox3.Text = dr["bus_seats_no"].ToString();
                user_NameTextBox.Text = dr["bus_model"].ToString();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Table is Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           finally
            {
               
                conn.Close();
            }
        }

   

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "Type A Bus Model To Search") { textBox2.Text = ""; textBox2.ForeColor = Color.Black; }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            textBox2.Text = "Bus Model To Search";
            textBox2.ForeColor = Color.FromKnownColor(KnownColor.ActiveCaption);
            data_grid();
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
            { conn.Open(); }
            dt.Clear();
            addcommand = new SqlCommand("Select*from Bus where bus_model like'%"+textBox2.Text+"%'", conn);
            da = new SqlDataAdapter(addcommand);
            da.Fill(dt);
            this.busDataGridView.DataSource = dt;
            conn.Close();
        }
        //New
        private void button1_Click_1(object sender, EventArgs e)
        {
            Bus1();
            button4.Enabled = true;

            user_NameTextBox.Text = "";
            textBox1.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "VIP";

            if (conn.State == ConnectionState.Open) { conn.Close(); }
        }
        //update
        private void button3_Click_1(object sender, EventArgs e)
        {
            if (user_NameTextBox.Text == "")
            {
                MessageBox.Show("Please enter Bus Model ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                user_NameTextBox.Focus();
                return;
            }
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Please enter Bus Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox1.Focus();
                return;
            }
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter Panel Number:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                return;
            }

            if (textBox3.Text == "")
            {
                MessageBox.Show("Please enter Seats Number:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
                return;
            }

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            try
            {
                addcommand = new SqlCommand("update Bus set bus_model='" + user_NameTextBox.Text + "' ,bus_seats_no='" + textBox3.Text + "',bus_type='" + comboBox1.Text + "',panel_no='" + textBox1.Text + "' where bus_ID=" + comboBox2.Text + "", conn);
                addcommand.Connection = conn;
                addcommand.ExecuteNonQuery();
                Bus1();
                data_grid();
                MessageBox.Show("Updated Successful", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                data_grid();
                conn.Close();
            }
        }
        //SAVE
        private void button4_Click_1(object sender, EventArgs e)
        {

            if (user_NameTextBox.Text == "")
            {
                MessageBox.Show("Please enter Bus Model ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                user_NameTextBox.Focus();
                return;
            }
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Please enter Bus Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox1.Focus();
                return;
            }
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter Panel Number:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                return;
            }

            if (textBox3.Text == "")
            {
                MessageBox.Show("Please enter Seats Number:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
                return;

            }

            try
            {
                conn.Open();
                addcommand.CommandText = "insert into Bus(bus_model,bus_seats_no,bus_type,panel_no) values('" + user_NameTextBox.Text + "','" + textBox3.Text + "','" + comboBox1.Text + "','" + textBox1.Text + "')";
                addcommand.Connection = conn;
                addcommand.ExecuteNonQuery();
                MessageBox.Show("Add Successful");
                Bus1();
                data_grid();
                user_NameTextBox.Text = "";
                textBox1.Text = "";
                textBox3.Text = "";
                comboBox1.Text = "VIP";
            }
            catch (Exception ex)
            {
                button4.Enabled = false;
                MessageBox.Show(ex.Message, "Table is Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Bus1();
                data_grid();
                button4.Enabled = false;
                conn.Close();
            }

        }

        private void busDataGridView_Click_1(object sender, EventArgs e)
        {
            if (busDataGridView.CurrentRow != null)
                comboBox2.Text = busDataGridView.CurrentRow.Cells["bus_ID"].Value.ToString();
            comboBox1.Text = busDataGridView.CurrentRow.Cells["bus_type"].Value.ToString();
            textBox1.Text = busDataGridView.CurrentRow.Cells["panel_no"].Value.ToString();
            textBox3.Text = busDataGridView.CurrentRow.Cells["bus_seats_no"].Value.ToString();
            user_NameTextBox.Text = busDataGridView.CurrentRow.Cells["bus_model"].Value.ToString();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DialogResult Answer = MessageBox.Show("are you sure you want to delete row number " + comboBox2.Text + " ?", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (Answer == DialogResult.OK)
            {
                try
                {
                    conn.Open();
                    SqlCommand deletecommand = new SqlCommand("delete from Bus where bus_ID=" + comboBox2.Text + "", conn);
                    deletecommand.ExecuteNonQuery();
                    MessageBox.Show("OK");
                    Bus1();
                    data_grid();

                    user_NameTextBox.Text = "";
                    textBox1.Text = "";
                    textBox3.Text = "";
                    comboBox1.Text = "VIP";
                }
                catch
                {
                    MessageBox.Show("Table is emptyNo Found Row To Delte", "Table is empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    Bus1();
                    data_grid();
                    //refresh of comboBox2 >> bus_ID
                    conn.Close();
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
            { conn.Open(); }
            dt.Clear();
            addcommand = new SqlCommand("Select*from Bus where bus_model like'%" + textBox2.Text + "%'", conn);
            da = new SqlDataAdapter(addcommand);
            da.Fill(dt);
            this.busDataGridView.DataSource = dt;
            conn.Close();
        }
    }
}
