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
