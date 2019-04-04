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
            //wyświetlanie informacji o zalogowanym użytkowniku
            label1.Text = "Login: "+UserName;
            //wyświetlanie informacji czy zalogowany użytkownik jest administratorem
            checkBox1.Checked = isAdmin;
            
            //wyświetlanie przycisku do zarządzania tylko administratorom (domyślnie jest on ukryrty)
            if (isAdmin)
                buttonAdmin.Visible = true;
        }



        public void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //wracanie do logowania przy zamknięciu okienka użytkownika
            this.Hide();
            Form f = new Login(); 
            f.Show();
        }

        private void buttonAdmin_Click(object sender, EventArgs e)
        {
            this.Hide();
            //przejście do formularza zarządzania użytkownikami
            Form userspanel = new UserAdd();
            userspanel.Show();
        }
    }
}
