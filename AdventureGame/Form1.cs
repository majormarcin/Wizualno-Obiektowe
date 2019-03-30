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
        Login logowanie;
        public Form1(Login logowanie2,string UserName, bool isAdmin)
        {
            //logowanie = logowanie2;
            InitializeComponent();
            label1.Text = UserName;
            checkBox1.Checked = isAdmin;
           //logowanie.Close();
        }



        public void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Form f = new Login();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }
    }
}
