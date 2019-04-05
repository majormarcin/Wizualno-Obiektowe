using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

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
        public User(string UserName, string Password, bool isAdmin)
        {

            this.uid = Guid.NewGuid();//generowanie guidu dla użytkownika 
            Console.WriteLine("Guid: {0}", uid);//debug guidu

            this.UserName = UserName;
            // Sól (id_użytkownika+numer albumu+nazwisko).
            byte[] salt = Encoding.UTF8.GetBytes(uid+"8442"+"Zelkowski");//zmieniona sól
            Rfc2898DeriveBytes crypt = new Rfc2898DeriveBytes(Password, salt);
            byte[] crypted = crypt.GetBytes(25);//bezpiecznehasło
            this.Password = Convert.ToBase64String(crypted);
            this.isAdmin = isAdmin;
        }
        //dodany override dla zapisu do pliku z użyciem tostring
        public override string ToString()
        {
            return $"{uid} {UserName} {Password} {isAdmin}";
        }
        //-------------------
        //wypierdala pozostałe tabele w datagrid ? do naprawy
        //-------------------
        //public Guid uid2
        //{
        //    get
        //    {
        //        return uid;
        //    }

        //    set
        //    {
        //        this.uid = value;
        //    }
        //}


        //username dla datagrida
        public string UserName2
        {
            get
            {
                return UserName;
            }

            set
            {
                this.UserName = value;
            }
        }
        //pass dla datagrida
        public string Password2
        {
            get
            {
                return Password;
            }

            set
            {
                this.Password = NewPass(value);
            }
        }
        //isAdmin dla datagrida
        public bool isAdmin2
        {
            get
            {
                return isAdmin;
            }

            set
            {
                this.isAdmin = value;
            }
        }

        //generowanie nowego hasła przy edycji użytkownika w datagrid 
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



    }
}
