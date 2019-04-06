using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace AdventureGame
{
    public class User
    {
        public Guid uid;//dodać unikalny identyfikator użytkownika, np zmienną id.
        public string UserName;
        public string Password;//zmodyfikować modyfikator zmiennej password na public
        public bool isAdmin;

        //konstruktor klasy nie pobiera userid(uid) bo podczas wywołania konstruktora dla użytkownika Generowany jest nowy Guid
        //co to guid? i jak działa? https://pl.wikipedia.org/wiki/Globally_Unique_Identifier
        // https://docs.microsoft.com/en-us/dotnet/api/system.guid?view=netframework-4.7.2
        public User()
        {

        }

        public User(string UserName, string Password, bool isAdmin)
        {
            //3. w konstruktorze nie wykorzystywać funkcji skrótu hasła (Rfc2898DeriveBytes)
            this.uid = Guid.NewGuid();//generowanie guidu dla użytkownika 
            Console.WriteLine("Guid: {0}", uid);//debug guidu

            this.UserName = UserName;
            // Sól (id_użytkownika+numer albumu+nazwisko).
            this.Password = NewPass(Password);
            this.isAdmin = isAdmin;
        }
        //konstruktor dla wczytywania z pliku
        public User(Guid uid,string UserName, string Password, bool isAdmin)
        {
            //3. w konstruktorze nie wykorzystywać funkcji skrótu hasła (Rfc2898DeriveBytes)
            this.uid = uid;//generowanie guidu dla użytkownika 
            this.UserName = UserName;
            // Sól (id_użytkownika+numer albumu+nazwisko).
            this.Password = Password;
            this.isAdmin = isAdmin;
        }
        //dodany override dla zapisu do pliku z użyciem tostring
        public override string ToString()
        {
            return $"{uid} {UserName} {Password} {isAdmin}";
        }
        //-------------------
        //datagridy @DataGrid
        //-------------------
        //Guid
        public Guid uid2
        {
            get {   return uid;}
            set {   this.uid = Guid.NewGuid(); }
        }
        //UserName
        public string UserName2
        {
            get {   return UserName; }
            set {   this.UserName = value; }
        }
        //Password
        public string Password2
        {
            get {   return Password;}
            set {   this.Password = NewPass(value);}
        }
        //isAdmin
        public bool isAdmin2
        {
            get {   return isAdmin;}
            set {   this.isAdmin = value;}
        }
        //-------------------
        //datagridy KONIEC
        //-------------------

        //szyfrowanie hasła
        public string NewPass(string Pass)
        {
            byte[] salt = Encoding.UTF8.GetBytes(uid + "8442" + "Zelkowski");
            Rfc2898DeriveBytes crypt = new Rfc2898DeriveBytes(Pass, salt);
            byte[] crypted = crypt.GetBytes(25);//bezpiecznehasło
            //string InPassword = Convert.ToBase64String(crypted);
            //this.Password = Convert.ToBase64String(crypted);
            return Convert.ToBase64String(crypted);
        }

        public bool PassCrypt(string Pass)
        {
            byte[] salt = Encoding.UTF8.GetBytes(uid + "8442" + "Zelkowski");
            Rfc2898DeriveBytes crypt = new Rfc2898DeriveBytes(Pass, salt);
            byte[] crypted = crypt.GetBytes(25);//bezpiecznehasło
            string InPassword = Convert.ToBase64String(crypted);
            bool isCorrect=false;
            if (InPassword== Password)
            {
                isCorrect = true;
            }
            return isCorrect;
        }
       // public List<User> LoadUsers

    }
}
