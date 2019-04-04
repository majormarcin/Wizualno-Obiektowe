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
            byte[] salt = Encoding.ASCII.GetBytes(uid+"8442"+"Zelkowski");//zmieniona sól
            Rfc2898DeriveBytes crypt = new Rfc2898DeriveBytes(Password, salt);
            byte[] crypted = crypt.GetBytes(25);//bezpiecznehasło
            this.Password = Encoding.ASCII.GetString(crypted);
            this.isAdmin = isAdmin;
        }

        //---------------------------
        // zmienić kodowania tablic bajtów
        //---------------------------        
        public bool PassCrypt(string Pass)
        {
            byte[] salt = Encoding.ASCII.GetBytes(uid + "8442" + "Zelkowski");
            Rfc2898DeriveBytes crypt = new Rfc2898DeriveBytes(Pass, salt);
            byte[] crypted = crypt.GetBytes(25);//bezpiecznehasło
            string InPassword = Encoding.ASCII.GetString(crypted);
            bool isCorrect=false;
            if (InPassword== Password)
            {
                isCorrect = true;
            }
            return isCorrect;
        }



    }
}
