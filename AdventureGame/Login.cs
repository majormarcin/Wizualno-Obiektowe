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
        public List<User> list= new List<User>();
        public Login()
        {
            
            list.Add(new User("Marcin", "Zelkowski", true));
            list.Add(new User("MZ", "TuJestSkomplikowaneHaslo", true));
            list.Add(new User("user", "user", false));

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            logowanie();
        }
        private void logowanie()
        {
            foreach (User u in list)
            {
                if (u.UserName == textBox_login.Text && u.PassCrypt(textBox_pass.Text) == true)
                {

                    this.Hide();
                    Form1 f = new Form1(u.UserName, u.isAdmin);
                    f.Show();
                    break;

                }
                else if (u.UserName == textBox_login.Text && u.PassCrypt(textBox_pass.Text) == false)
                {
                    MessageBox.Show("Błędne dane logowania");
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

        private void textBox_pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                logowanie();
            }
        }
    }
}
