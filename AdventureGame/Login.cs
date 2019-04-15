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
using System.IO;



namespace AdventureGame
{
    public partial class Login : Form
    {
        pinacolada escape = new pinacolada();
        public List<User> list= new List<User> {};
        public Login()
        {
            LoadUsers();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            logowanie();
        }
        private void logowanie()
        {
            escape.Autoryzacja.Invoke(textBox_login.Text, textBox_pass.Text,list,this);
            //foreach (User u in list)
            //{
            //    if (u.UserName == textBox_login.Text && u.PassCrypt(textBox_pass.Text) == true)
            //    {

            //        this.Hide();
            //        Form1 f = new Form1(u.UserName, u.isAdmin);
            //        f.Show();
            //        break;

            //    }
            //    else if (u.UserName == textBox_login.Text && u.PassCrypt(textBox_pass.Text) == false)
            //    {
            //        MessageBox.Show("Błędne dane logowania");
            //    }
            //}
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
        //wczytanie użytkowników z pliku
        public void LoadUsers()
        {
            
            list = escape.load.Invoke();
        }
    }
}
