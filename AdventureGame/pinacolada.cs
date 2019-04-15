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
        public delegate List<User> Aut(string x, string y, List<User> a, Form f);
        public Aut Autoryzacja;

        public delegate List<User> Dodaj(string x, string y, bool a);
        public Dodaj UDodaj;

        public delegate BindingSource SavePlik(BindingSource source);
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

            // Print out all the lines in the list.
            //foreach (string value in lines)
            //{
            //    Console.WriteLine(value);
            //    string[] parm = value.Split(' ');
            //    //splitowanie po spacji na tablise stringów
            //    list.Add(new User(Guid.Parse(parm[0]), parm[1], parm[2], bool.Parse(parm[3])));
            //}
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
        private List<User> Dodawanie(string x, string y, bool a)
        {

            list.Add(new User(x, y, a));
            return list;
        }

        private BindingSource ZapiszPlik(BindingSource source)
        {
            List<User> list = new List<User> { };
            List<string> wiersze = new List<string>();

            using (System.IO.StreamWriter SaveFile = new System.IO.StreamWriter("MZ8442.bin"))
            {
                foreach (User p in source)
                {
                    SaveFile.WriteLine(p);
                }
                SaveFile.Close();
            }
            return source;
        }



        private List<User> Autoryzuj(string x, string y, List<User> Autoryzacja, Form f0)
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
            return Autoryzacja;

        }
    }
    

}
