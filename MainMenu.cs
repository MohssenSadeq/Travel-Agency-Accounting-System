using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

using System.Data.SqlClient;

namespace HejAndOmra
{
    public partial class MainMenu : Form
    {
        SqlConnection conn = new SqlConnection(connectionstring.con);
        SqlConnection connection = new SqlConnection("Data Source=Mohsen_Altaffi;Initial Catalog = Master; Integrated Security = True");
        SqlCommand addcommand = new SqlCommand();
     
    
        public MainMenu()
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons);
            
            InitializeComponent();

        }

     
        private void employeeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Haj sdf = new Haj();
           
            sdf.Show();

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Calculations h = new Calculations();
            h.Show();
        }

        private void MainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            DialogResult m = MessageBox.Show("Are You Want To Logout !!!", "Logout From This Account", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (m == DialogResult.Yes)
            {
                this.Hide();
                Login k = new Login();
                k.Show();
            }
        }

        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }

        private void notepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Notepad.exe");
        }

        private void mSWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Winword.exe");
        }

        private void taskManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("TaskMgr.exe");
        }

        private void wordpadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Wordpad.exe");
        }

 
        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
         
            menuStrip5.Visible = false; menuStrip4.Visible = false; menuStrip6.Visible = false;
            if (menuStrip3.Visible == false) { menuStrip3.Visible = true; }
            else { menuStrip3.Visible = false; }

        }
        
        private void menuStrip5_MouseLeave(object sender, EventArgs e)
        {
            menuStrip5.Visible = false;
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            menuStrip4.Visible = false;
            users m = new users();
            m.Show();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            menuStrip4.Visible = false;
            Login_and_Logout_Details o = new Login_and_Logout_Details();
            o.Show();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            menuStrip5.Visible = false;
            New_Employee m = new New_Employee();
            m.Show();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            menuStrip5.Visible = false;
            Salary j = new Salary();
            j.Show();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            menuStrip5.Visible = false; menuStrip4.Visible = false;
            if (menuStrip6.Visible == false) { menuStrip6.Visible = true; }
            else { menuStrip6.Visible = false; }
        }

        private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {
            Management m = new Management();
            m.Show();
            menuStrip3.Visible = false;
        }

    

        private void toolStripMenuItem21_Click(object sender, EventArgs e)
        {

        }

    
        private void toolStripMenuItem27_Click(object sender, EventArgs e)
        {
           
        }


        private void toolStripMenuItem29_Click(object sender, EventArgs e)
        {
            Management m = new Management();
            m.Show();
        }


        private void MainMenu_Load(object sender, EventArgs e)
        {
            
            Calculations h = new Calculations();
            button11.Enabled = true;
            h.textBox7.Text = Properties.Settings.Default.text1;
            h.textBox2.Text = Properties.Settings.Default.text2;
            h.textBox3.Text = Properties.Settings.Default.text3;
            h.textBox4.Text = Properties.Settings.Default.text4;
            h.textBox5.Text = Properties.Settings.Default.text5;
            h.textBox6.Text = Properties.Settings.Default.text6;


            Class2.m = h.textBox6.Text;
            Class2.k = h.textBox4.Text;
            Class2.l = h.textBox5.Text;
            Class2.j = h.textBox2.Text;
            Class2.h = h.textBox7.Text;
            Class2.g = h.textBox3.Text;
            if (h.radioButton1.Checked) { h.panel1.Enabled = true; h.panel5.Enabled = false; }
            if (h.radioButton2.Checked) { h.panel1.Enabled = false; h.panel5.Enabled = true; }


            User.Text = Class1.m; 
            Management m = new Management();
            m. chk1.Checked = Properties.Settings.Default.chk1;
            m.chk2.Checked = Properties.Settings.Default.chk2;
            m.chk3.Checked = Properties.Settings.Default.chk3;
            m.chk4.Checked = Properties.Settings.Default.chk4;
            m.chk5.Checked = Properties.Settings.Default.chk5;
            m.chk6.Checked = Properties.Settings.Default.chk6;
            m.chk7.Checked = Properties.Settings.Default.chk7;
            m.chk8.Checked = Properties.Settings.Default.chk8;
            m.chk9.Checked = Properties.Settings.Default.chk9;
            m.chk10.Checked = Properties.Settings.Default.chk10;
            m.chk11.Checked = Properties.Settings.Default.chk11;
            if (Class1.m=="User")
            {
                if (m.chk1.Checked == true) { c2.Enabled = false;c2_2.Enabled = false; }
                if (m.chk2.Checked == true) { c1.Enabled = false;c1_1.Enabled = false; }
                if (m.chk3.Checked == true) { c9.Enabled = false; }
                if (m.chk4.Checked == true) { c10.Enabled = false;}
                if (m.chk5.Checked == true) { c8.Enabled = false; c8_8.Enabled = false; }
                if (m.chk6.Checked == true) { c11.Enabled = false; c11_11.Enabled = false; }
                if (m.chk7.Checked == true) { c3.Enabled = false; c3_3.Enabled = false; }
                if (m.chk8.Checked == true) { c4.Enabled = false; c4_4.Enabled = false; }
                if (m.chk9.Checked == true) { c5.Enabled = false; c5_5.Enabled = false; }
                if (m.chk10.Checked == true) { c7.Enabled = false; c7_7.Enabled = false; }
                if (m.chk11.Checked == true) { c6.Enabled = false; c6_6.Enabled = false; }
            }
           
        }

      

        private void c1_1_Click(object sender, EventArgs e)
        {
            users m = new users();
            m.Show();
        }

        private void c2_2_Click(object sender, EventArgs e)
        {
            Login_and_Logout_Details m = new Login_and_Logout_Details();
            m.Show();
        }

        private void c3_3_Click(object sender, EventArgs e)
        {
            New_Employee m = new New_Employee();
            m.Show();
        }

        private void c4_4_Click(object sender, EventArgs e)
        {
            Salary m = new Salary();
            m.Show();
        }

        private void c5_5_Click(object sender, EventArgs e)
        {
            Trips m = new Trips();
            m.Show();
        }

        private void c6_6_Click(object sender, EventArgs e)
        {
            Drivers m = new Drivers();
            m.Show();
        }

        private void c7_7_Click(object sender, EventArgs e)
        {
            Bus m = new Bus();
            m.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Time.Text = DateTime.Now.ToString();
            timer1.Start();
        }

        private void visualStyler1_VisualStyleChanged(object sender, EventArgs e)
        {
            
        }

   

    

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (panel2.Width >= 184 && panel2.Height <= 564)
            {
                button2.Text = "<";
                panel2.Height = 564;
                panel2.Width = 48;
                panel2.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
                button1.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
                button7.Visible = false;
                button8.Visible = false;
                button9.Visible = false;
                button10.Visible = false;
                button11.Visible = false;
                button12.Visible = false;
                button13.Visible = false;
                button14.Visible = false;
                button15.Visible = false;
                button1.Visible = false;
            }
            else
            {
                button2.Text = ">";
                panel2.Height = 564;
                panel2.Width = 184;
                panel2.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption);
                button1.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
                button5.Visible = true;
                button6.Visible = true;
                button7.Visible = true;
                button8.Visible = true;
                button9.Visible = true;
                button10.Visible = true;
                button11.Visible = true;
                button12.Visible = true;
                button13.Visible = true;
                button14.Visible = true;
                button15.Visible = true;
                button1.Visible = true;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            label2.Text = button14.Text;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            label2.Text = button15.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label2.Text = button3.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label2.Text = button4.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label2.Text = button15.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label2.Text = button6.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label2.Text = button7.Text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            label2.Text = button9.Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label2.Text = button8.Text;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            label2.Text = button10.Text;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            label2.Text = button11.Text;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            label2.Text = button12.Text;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            label2.Text = button13.Text;
        }

        

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string skinName = @"MyApplication.Skins."+label2.Text;
        }
        public void Backup()
        {
            //try
            //{
            //    Cursor = Cursors.WaitCursor;

            //    if ((!System.IO.Directory.Exists("C:\\DBBackup")))
            //    {
            //        System.IO.Directory.CreateDirectory("C:\\DBBackup");
            //    }
            //    string destdir = "C:\\DBBackup\\Hej&Omra " + DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss") + ".bak";

            //    conn.Open();
            //    string cb = "backup database [" + System.Windows.Forms.Application.StartupPath + "\\Hej&Omra.mdf] to disk='" + destdir + "'with init,stats=10";
            //    SqlCommand add = new SqlCommand(cb, conn);


            //    add.ExecuteReader();
            //    conn.Close();
            //    MessageBox.Show("Successfully performed", "Database Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            SaveFileDialog sf = new SaveFileDialog();
            try
            {
                if (sf.ShowDialog() == DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;
                    addcommand = new SqlCommand("Backup Database Hej_Omra To Disk='" + sf.FileName + " " + DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss") + ".bak" + "'", conn);
                     if (conn.State == ConnectionState.Closed)
            { conn.Open(); }
                    addcommand.ExecuteNonQuery();
                  
                    MessageBox.Show("Successfully performed", "Database Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
                sf.FileName = "";
                Cursor = Cursors.Default;
            }
        }
        private void backUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Backup();
        }
        public void restore()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Backup files(*.Bak)|*.bak";
            try
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;

                    addcommand = new SqlCommand("Restore Database Hej_Omra From Disk='" + ofd.FileName + "'", connection);
                   
                    if (connection.State == ConnectionState.Closed)
                    { connection.Open(); }
               
                    addcommand.ExecuteNonQuery();

                    MessageBox.Show("Successfully Restored", "Database Restore", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
                ofd.FileName = "";
                Cursor = Cursors.Default;
            }
        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            restore();
        }


        private void travelsToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem7_Click_1(object sender, EventArgs e)
        {
            menuStrip5.Visible = false; menuStrip6.Visible = false;
            if (menuStrip4.Visible == false) { menuStrip4.Visible = true; }
            else { menuStrip4.Visible = false; }
        }

        private void toolStripMenuItem3_Click_1(object sender, EventArgs e)
        {
            menuStrip4.Visible = false; menuStrip6.Visible = false;

            if (menuStrip5.Visible == false) { menuStrip5.Visible = true; }
            else { menuStrip5.Visible = false; }
        }

        private void trips_Click(object sender, EventArgs e)
        {
            menuStrip5.Visible = false; menuStrip4.Visible = false;
            if (menuStrip6.Visible == false) { menuStrip6.Visible = true; }
            else { menuStrip6.Visible = false; }
        }

        private void c8_Click(object sender, EventArgs e)
        {
            Management m = new Management();
            m.Show();
           
            menuStrip3.Visible = false;
        }

        private void backUpToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            Backup();
        }

        private void restoreToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            restore();
        }

        private void c1_Click(object sender, EventArgs e)
        {
            users m = new users();
            m.Show();
        }

        private void c2_Click(object sender, EventArgs e)
        {
            menuStrip4.Visible = false;
            Login_and_Logout_Details o = new Login_and_Logout_Details();
            o.Show();
        }

        private void c5_Click_1(object sender, EventArgs e)
        {
            Trips m = new Trips();
            m.Show();
        }

        private void c6_Click_1(object sender, EventArgs e)
        {
            Drivers m = new Drivers();
            m.Show();
        }

        private void c7_Click_1(object sender, EventArgs e)
        {
            Bus m = new Bus();
            m.Show();
        }

        private void c4_Click(object sender, EventArgs e)
        {
            menuStrip5.Visible = false;
            Salary j = new Salary();
            j.Show();
        }

        private void c3_Click(object sender, EventArgs e)
        {
            menuStrip5.Visible = false;
            New_Employee m = new New_Employee();
            m.Show();
        }

        private void menuStrip6_MouseLeave_1(object sender, EventArgs e)
        {
            menuStrip6.Visible = false;
        }

        private void menuStrip5_MouseLeave_1(object sender, EventArgs e)
        {
            menuStrip5.Visible = false;
        }

        private void menuStrip4_MouseLeave(object sender, EventArgs e)
        {
            menuStrip4.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            menuStrip5.Visible = false; menuStrip4.Visible = false; menuStrip6.Visible = false;
            if (menuStrip3.Visible == true) { menuStrip3.Visible = false; }
           
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About m = new About();
            m.Show();
        }

        private void exitProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainMenu_MouseClick(object sender, MouseEventArgs e)
        {

            menuStrip5.Visible = false; menuStrip4.Visible = false; menuStrip6.Visible = false;
            if (menuStrip3.Visible == false) { menuStrip3.Visible = true; }
            else { menuStrip3.Visible = false; }

        }
    }
}

