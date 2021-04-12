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
    public partial class New_Haj : MetroFramework.Forms.MetroForm
    {
       
       int i;
      
        public New_Haj()
        {
            InitializeComponent();
           
        }
        private void New_Haj_Load(object sender, EventArgs e)
        {
        
            button3.Enabled = true;
            if (radioButton2.Checked == false) { panel4.Enabled = false; label16.Enabled = false; }
            else { panel4.Enabled = true; label16.Enabled = true; }
        }

     

        private void button3_Click(object sender, EventArgs e)
        {

            Haj.Me.travelcombobox();
            button3.Enabled = false;
            Haj.Me.EmployeeDataGridView.Enabled = true;
            if (radioButton2.Checked == true)
            {
                
                Haj.Me.radioButton8.Checked = true;

                Haj.Me.DgvF();
                Haj.Me.button4.Enabled = true;
                Class2.ll = radioButton2.Text;
                Haj.Me.relationshipComboBox.Enabled = true;
                if (radioButton3.Checked == true)
                {
                    Class2.o = radioButton3.Text;
                }
                if (radioButton4.Checked == true)
                {
                    Class2.o = radioButton4.Text;
                }
                if (radioButton5.Checked == true)
                {
                    Class2.o = radioButton5.Text;
                }
                if (radioButton6.Checked == true)
                {
                    Class2.o = radioButton6.Text;
                }
                if (radioButton7.Checked == true)
                {
                    Class2.o = radioButton7.Text;
                }
                Haj.Me.button7.Text = "Next";
            }
            else
            {
                
                Haj.Me.radioButton7.Checked = true;
                Haj.Me.Dgv();
                Haj.Me.button4.Enabled = true;
                Class2.ll = radioButton1.Text;
                Haj.Me.relationshipComboBox.Enabled = false;
                Class2.o = "0";
                Haj.Me.button7.Text = "Finish";
                
            }

            Haj .Me.op =999;  
            Haj.Me.panel1.Visible = false; Haj.Me.panel5.Visible = false;
            Haj.Me.panel1.Visible = true;
            Haj.Me.button7.Enabled = false;
            this.Hide();
            Haj.Me.panel2.Enabled = true;

        }

      
        private void New_Haj_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }
        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton2.Checked == false) { panel4.Enabled = false; label17.Enabled = true; label16.Enabled = false; }
            else { panel4.Enabled = true; label17.Enabled = false; label16.Enabled = true; }
        }

      

        private void radioButton4_Click_1(object sender, EventArgs e)
        {
            if (i != 4 && button3.Enabled == false) { button3.Enabled = true; }

            i = 4;
        }

        private void radioButton7_Click_1(object sender, EventArgs e)
        {
            if (i != 3 && button3.Enabled == false) { button3.Enabled = true; }

            i = 3;
        }

        private void radioButton3_Click_1(object sender, EventArgs e)
        {

            if (i != 5 && button3.Enabled == false) { button3.Enabled = true; }

            i = 5;
        }

        private void radioButton6_Click_1(object sender, EventArgs e)
        {
            if (i != 6 && button3.Enabled == false) { button3.Enabled = true; }

            i = 6;
        }

        private void radioButton5_Click(object sender, EventArgs e)
        {
            if (i != 7 && button3.Enabled == false) { button3.Enabled = true; }

            i = 7;
        }

        private void radioButton2_Click_1(object sender, EventArgs e)
        {
            if (i == 1 && button3.Enabled == false) { button3.Enabled = true; }

            i = 2;
        }

        private void radioButton1_Click_1(object sender, EventArgs e)
        {

            if (i == 2 && button3.Enabled == false) { button3.Enabled = true; }

            i = 1;
        }

        private void New_Haj_FormClosing(object sender, FormClosingEventArgs e)
        {

      
        }
    }
    }
