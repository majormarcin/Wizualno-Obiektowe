using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AdventureGame
{

    class pinacolada
    {
        public delegate List<User> Load();
        public Load load;
        //public delegate List<User> Dodaj(string login,string password,bool isAdmin);
        public delegate void Aut(string x, string y, List<User> a, Form f);
        public Aut Autoryzacja;

        public delegate List<User> Dodaj(string x, string y, bool a, List<User> lista);
        public Dodaj UDodaj;

        public delegate void SavePlik(List<User> list);
        public SavePlik Zapis;

        public pinacolada()
        {
            load += Logading;
            Autoryzacja += Autoryzuj;
            Zapis += ZapiszPlik;
            UDodaj += Dodawanie;
        }

        private List<User> Logading()
        {
            List<User> list = new List<User> { };
            List<string> wiersze = new List<string>();
            try
            {
            //using bo tak kazano :D 
            using (StreamReader reader = new StreamReader("MZ8442.bin"))
            {
                // coś na jedną linijkę tekstu
                string line;
                bool uszkodzony = false;
                //czytanie pliku aż się linijki nie skończą 
                while ((line = reader.ReadLine()) != null)
                {
                    //fajny myk na czyszczenie pustych lini w pliku
                    //if (line == null)
                    //{
                    //    return;
                    //}
                    //if (line == String.Empty)
                    //{
                    //    continue;
                    //}
                    //koniec
                    //wrzucenie linijki do tablicy linijek :D
                    string[] parm = line.Split(' ');
                    //splitowanie po spacji na tablise stringów
                    if (parm.Length == 4)
                        list.Add(new User(Guid.Parse(parm[0]), parm[1], parm[2], bool.Parse(parm[3])));
                    else
                    {
                        uszkodzony = true;
                    }
                }
                if (uszkodzony)
                    MessageBox.Show("Plik uszkodzony");

            }
             }
            catch (FileNotFoundException e)
            {
            MessageBox.Show("Brak bazy użytkowników. Tylko predefiniowany dostęp");
            //Console.WriteLine(e.Message);
            list.Add(new User("Marcin", "Zelkowski", true));

            }
            return list;
        }
        List<User> list = new List<User> { };
        private List<User> Dodawanie(string x, string y, bool a, List<User> lista)
        {

            lista.Add(new User(x, y, a));
            return lista;
        }

        private void ZapiszPlik(List<User> list)
        {
            List<string> wiersze = new List<string>();

            using (System.IO.StreamWriter SaveFile = new System.IO.StreamWriter("MZ8442.bin"))
            {
                foreach (User p in list)
                {
                    SaveFile.WriteLine(p);
                }
                SaveFile.Close();
            }

        }



        private void Autoryzuj(string x, string y, List<User> Autoryzacja, Form f0)
        {
            foreach (User u in Autoryzacja)
            {
                if (u.UserName == x && u.PassCrypt(y) == true)
                {
                    
                    f0.Hide();
                    Form1 f = new Form1(u.UserName, u.isAdmin);

                    f.Show();
                    break;
                }
                else if (u.UserName == x && (u.PassCrypt(y) == false))
                {
                    MessageBox.Show("Błędne Hasło", "Błąd logowania", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
    

}
