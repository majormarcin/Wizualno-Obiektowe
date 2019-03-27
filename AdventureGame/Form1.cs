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
        public Form1(Form f,string UserName, bool isAdmin)
        {
            InitializeComponent();
            label1.Text = UserName;

        }
        Form1 f;

        private void button1_Click(object sender, EventArgs e)
        {
            Form loginForm = new Login();
            loginForm.Show();
        }

        private void Form1_ForeColorChanged(object sender, EventArgs e)
        {
            f.Show();
        }
    }
}
