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

        public List<User> list= new List<User> {};
        //public List<User> list = new List<User> { new User("M", "Z", true) };
        //List<User> list = new List<User> { new User("Marcin", "Zelkowski", true)};
        public Login()
        {

            // list.Add(new User("Marcin", "Zelkowski", true));
            //list.Add(new User("MZ", "TuJestSkomplikowaneHaslo", true));
            //list.Add(new User("user", "user", false));
            //list = User.LoadUsers().ToList(List<User>);
            LoadUsers();
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
        public void LoadUsers()
        {
            //List<User> list = new List<User> { new User("Marcin", "Zelkowski", true) };

            const string sPath = "MZ8442.bin";

            List<string> lines = new List<string>();
            try
            {
                // Use using-keyword for disposing.
                using (StreamReader reader = new StreamReader("MZ8442.bin"))
                {
                    // Use while not null pattern in while loop.
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Insert logic here.
                        // ... The "line" variable is a line in the file.
                        // ... Add it to our List.
                        lines.Add(line);
                    }
                }
                
                // Print out all the lines in the list.
                foreach (string value in lines)
                {
                    Console.WriteLine(value);
                    string[] parm = value.Split(' ');
                    //splitowanie po spacji na tablise stringów
                    list.Add(new User(Guid.Parse(parm[0]), parm[1], parm[2], bool.Parse(parm[3])));
                }
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("Brak bazy użytkowników. Tylko predefiniowany dostęp");
                //Console.WriteLine(ex.Message);
                list.Add(new User("M", "Z", true));

            }

        }
    }
}
