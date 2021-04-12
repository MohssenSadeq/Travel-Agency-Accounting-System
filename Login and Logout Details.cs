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
    public partial class Login_and_Logout_Details : Form
    {
        public Login_and_Logout_Details()
        {
            InitializeComponent();
        }

        private void Login_and_Logout_Details_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_Hej_OmraDataSet.Sign_in_Details' table. You can move, or remove it, as needed.
      

        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "Type A User Name To Search") { textBox2.Text = ""; textBox2.ForeColor = Color.Black; }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox2.Text = "Type A User Name To Search";
            textBox2.ForeColor = Color.FromKnownColor(KnownColor.ActiveCaption);
        }
    }
}
