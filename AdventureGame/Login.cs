using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace AdventureGame
{
    public partial class Login : Form
    {
        List<User> list;
        public Login()
        {
            //konstruktory klas
            // u= new User("admin","abc123!",true);
            list = new List<User>();
            list.Add(new User("admin", "abc123", true));
            list.Add(new User("MZ", "TuJestSkomplikowaneHaslo", true));
            list.Add(new User("user", "user", false));

            

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //odpowiednik form1load
            //User[] us = new User[4];
            // us[0] = new User("admin", "abc123!", true);
            foreach (User u in list)
            {
                if (u.UserName == textBox_login.Text && u.PassCrypt(textBox_pass.Text)==true)
                {
                    
                    this.Hide();
                    Form1 f = new Form1(this,u.UserName,u.isAdmin);
                    //f.Closed += (s, args) => this.Close();
                    f.Show();
                    break;

                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
