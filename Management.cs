using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HejAndOmra
{
    public partial class Management : Form
    {
       

     

        public Management()
        {
            InitializeComponent();
        }


        private void Management_Load(object sender, EventArgs e)
        {
            chk1.Checked =Properties.Settings.Default.chk1 ;
            chk2.Checked =Properties.Settings.Default.chk2 ;
            chk3.Checked = Properties.Settings.Default.chk3;
            chk4.Checked =Properties.Settings.Default.chk4 ;
            chk5.Checked =Properties.Settings.Default.chk5 ;
            chk6.Checked= Properties.Settings.Default.chk6 ;
            chk7.Checked =Properties.Settings.Default.chk7 ;
            chk8.Checked= Properties.Settings.Default.chk8 ;
            chk9.Checked= Properties.Settings.Default.chk9 ;
            chk10.Checked =Properties.Settings.Default.chk10 ;
            chk11.Checked =Properties.Settings.Default.chk11 ;
        }

        private void Management_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.chk1 = chk1.Checked;
            Properties.Settings.Default.chk2 = chk2.Checked;
            Properties.Settings.Default.chk3 = chk3.Checked;
            Properties.Settings.Default.chk4 = chk4.Checked;
            Properties.Settings.Default.chk5 = chk5.Checked;
            Properties.Settings.Default.chk6 = chk6.Checked;
            Properties.Settings.Default.chk7 = chk7.Checked;
            Properties.Settings.Default.chk8 = chk8.Checked;
            Properties.Settings.Default.chk9 = chk9.Checked;
            Properties.Settings.Default.chk10 = chk10.Checked;
            Properties.Settings.Default.chk11 = chk11.Checked;
            Properties.Settings.Default.Save();
            MessageBox.Show("All settings have saved", "Settings Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
           Hide();
        }
    }
}
