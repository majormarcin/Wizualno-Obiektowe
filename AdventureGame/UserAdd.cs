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
        public BindingSource source = new BindingSource();
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

            
            DataGridView dataGridView1 = new DataGridView();
            BindingSource bindingSource1 = new BindingSource();
        List<User> list = new List<User> { new User("Marcin", "Zelkowski", true), new User("user", "user", true) };
            source.Add(new User("Marcin", "Zelkowski", true));
            source.Add(new User("test", "test", false));

            dataGridView3.AutoGenerateColumns = false;
            bindingSource1.DataSource = list;
            
            dataGridView3.DataSource = source;
            

            DataGridViewColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "UserName2";
            column.Name = "UserName";
            dataGridView3.Columns.Add(column);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "Password2";
            column.Name = "Password";
            dataGridView3.Columns.Add(column);

             DataGridViewComboBoxColumn combo4 = new DataGridViewComboBoxColumn();
            combo4.DataPropertyName = "isAdmin2";
            combo4.Name = "isAdmin";
            combo4.Items.AddRange(true, false);
            dataGridView3.Columns.Add(combo4);


            // dataGridView2.DataSource = source;
            //ogłem to to nie działa
            //dataGridView3.Columns.Add("uid", "uid");
            //dataGridView3.Columns.Add("UserName", "UserName");
            //dataGridView3.Columns.Add("Password", "Password");
            //dataGridView3.Columns.Add("isAdmin", "isAdmin");
            //dataGridView3.DataSource = list;
            //dataGridView3.Columns["uid"].DisplayIndex = 0;
            //dataGridView3.Columns["UserName"].DisplayIndex = 1;
            //dataGridView3.Columns["Password"].DisplayIndex = 2;
            //dataGridView3.Columns["isAdmin"].DisplayIndex = 3;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string UserName=tbxUser.Text;
            string Password = tbxUser.Text;
            bool isAdmin = cbxAdmin.Checked;
            source.Add(new User(UserName, Password, isAdmin));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //const string sPath = "save.txt";

            //System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(sPath);
            //foreach (var item in source.IndexOf())
            //{
            //    SaveFile.WriteLine(item.ToString(), item.ToString());
            //}
            //SaveFile.Close();

            //MessageBox.Show("Programs saved!");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // List<Person> pList = new List<Person>();
            // Person p1 = new Person(nric.Text, name.Text);
            //pList.Add(p1);
            const string sPath = "save.txt";

            //System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(sPath);
            using (System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(sPath))
            {
                foreach (User p in source)
                {
                    SaveFile.WriteLine(p);
                }
                SaveFile.Close();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f = new Login(); 
            f.Show();
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
