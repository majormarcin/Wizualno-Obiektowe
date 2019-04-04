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
    public partial class UserAdd : Form
    {
        int x = 1;
        public UserAdd()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("user" + x);
            x++;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
                if (MessageBox.Show("Czy chcesz usunąć użytkownika " +
                     listBox1.GetItemText(listBox1.SelectedItem), "Uwaga", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    listBox1.Items.Remove(listBox1.SelectedItem);
                }
        }

        private void UserAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //ogłem to to nie działa
            //List<User> list;
            //list = new List<User>();
            //list.Add(new User("Marcin", "Zelkowski", true));
            //dataGridView2.DataSource = list;

            var source = new BindingSource();
            List<User> list = new List<User> { new User("Marcin", "Zelkowski", true), new User("user", "user", true) };
            source.DataSource = list;
            dataGridView2.AutoGenerateColumns = false;
           // dataGridView2.DataSource = source;
            //ogłem to to nie działa
            dataGridView3.Columns.Add("uid", "uid");
            dataGridView3.Columns.Add("UserName", "UserName");
            dataGridView3.Columns.Add("Password", "Password");
            dataGridView3.Columns.Add("isAdmin", "isAdmin");
dataGridView3.DataSource = list;
            dataGridView3.Columns["uid"].DisplayIndex = 0;
            dataGridView3.Columns["UserName"].DisplayIndex = 1;
            dataGridView3.Columns["Password"].DisplayIndex = 2;
            dataGridView3.Columns["isAdmin"].DisplayIndex = 3;

        }

        //using przy używaniu streamódo pliku 
        //    try{
        //    File.WriteAllText("plik","text",Encoding,Default);
        //        catch (InvalidOperationException err){//blad}

        //}
        //if(FileDialog.exist("plik"))
        //try{
        //    File.AppendAllLine("plik","text",Encoding,Default);
        //        catch (InvalidOperationException err){//blad}

        //}  konwertować do base64(tobase64string) i to do pliku  zamiast od ascii





    }
}
