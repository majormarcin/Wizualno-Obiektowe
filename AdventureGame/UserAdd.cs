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

        //public List<User> list = new List<User> { new User("Marcin", "Zelkowski", true) };
      //  User u = new User();
        Login l = new Login();
        public List<User> list = new List<User> { };
        public UserAdd()
        {
            list = l.list;

           
        list.Add(new User("MZ", "MZ", true));
        list.Add(new User("user", "user", false));

        InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //listBox1.Items.Add("user" + x);
            //x++;
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
        //List<User> list = new List<User> { new User("test", "test", true), new User("user", "user", true) };
            //source.Add(new User("Marcin", "Zelkowski", true));

            source.DataSource = list;
            //to było ok
            //source.Add(new User("test", "test", false));

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
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView3.Columns.Add(column);

            

            DataGridViewComboBoxColumn combo4 = new DataGridViewComboBoxColumn();
            combo4.DataPropertyName = "isAdmin2";
            combo4.Name = "isAdmin";
            combo4.Items.AddRange(true, false);
            dataGridView3.Columns.Add(combo4);

            column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "uid2";
            column.Name = "uid";
            column.ReadOnly = true;
            column.DefaultCellStyle.NullValue = Guid.NewGuid().ToString();
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView3.Columns.Add(column);

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
            const string sPath = "MZ8442.bin";

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
