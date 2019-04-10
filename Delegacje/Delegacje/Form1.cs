using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Delegacje
{
    public partial class Form1 : Form
    {
        delegate int SetMe(int a, int b);
        delegate int Set2(string u, string p);
        //int auth(string login, string password);
        delegate int Set3();
        //int loaduser();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private int Dodaj(int x,int y)
        {
            return x + y;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetMe s = new SetMe(Dodaj);
            int wynik = s.Invoke(2, 3);
            MessageBox.Show("Wynik " + wynik);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Calculations i = new Calculations();
            int a=i.o.Invoke(4, 8);
            MessageBox.Show("wynik " + a);
        }
    }
}
