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
        //źródło dla datagrida
        public BindingSource source = new BindingSource();

        Login l = new Login();
        public List<User> list = new List<User> { };
        public UserAdd()
        {
            list = l.list;
        InitializeComponent();
        }

        //usuwanie wiersza grida
        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Czy chcesz usunac uzytkownika ?", "Ostrzeżenie!",MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
            {
            foreach (DataGridViewRow item in this.dataGridView3.SelectedRows)
            {
                dataGridView3.Rows.RemoveAt(item.Index);
            }
            }
        }

        private void UserAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            //odświeżenie danych poprzes zresetowanie ich
            source.DataSource = null;
            //dataGridView3.DataSource = null;
            source.DataSource = list;
            dataGridView3.DataSource = source;
        }
        //dodawanie użytkownika
        private void button1_Click(object sender, EventArgs e)
        {
            string UserName=tbxUser.Text;
            string Password = tbxUser.Text;
            bool isAdmin = cbxAdmin.Checked;
            bool uExist = false;
            foreach (User u in list)
            {
                if (u.UserName == UserName)
                {
                    uExist = true;
                    break;
                }
            }//zprawdzenie czy taki użytkownik już isjnieje
            if (!uExist) list.Add(new User(UserName, Password, isAdmin));
            else MessageBox.Show("Użytkownik już istnieje.");
            source.DataSource = null;
            //dataGridView3.DataSource = null;
            source.DataSource = list;
            using (System.IO.StreamWriter SaveFile = new System.IO.StreamWriter("MZ8442.bin"))
            {
                foreach (User p in source)
                {
                    SaveFile.WriteLine(p);
                }
                SaveFile.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //zapis do pliku
            using (System.IO.StreamWriter SaveFile = new System.IO.StreamWriter("MZ8442.bin"))
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            source.DataSource = null;
            //dataGridView3.DataSource = null;
            source.DataSource = list;
            dataGridView3.DataSource = source;
        }

        private void UserAdd_Load(object sender, EventArgs e)
        {
            //ładowanie kolumn dla datagridview
            dataGridView3.AutoGenerateColumns = false;
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
    }
}
