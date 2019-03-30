using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdventureGame
{
    public partial class Form1 : Form
    {

        public Form1(string UserName, bool isAdmin)
        {

            InitializeComponent();
            label1.Text = UserName;
            checkBox1.Checked = isAdmin;

        }



        public void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Form f = new Login();
            
            f.Show();
        }
    }
}
