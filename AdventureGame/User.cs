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
        public string UserName;
        private string Password;
        public bool isAdmin;

        public User(string UserName, string Password, bool isAdmin)
        {
            this.UserName = UserName;

            byte[] salt = Encoding.ASCII.GetBytes("MarcinZelkowski");
            Rfc2898DeriveBytes crypt = new Rfc2898DeriveBytes(Password, salt);
            byte[] crypted=crypt.GetBytes(25);//bezpiecznehasło
            this.Password = Encoding.ASCII.GetString(crypted);
            this.isAdmin = isAdmin;
        }
        public bool PassCrypt(string Pass)
        {
            byte[] salt = Encoding.ASCII.GetBytes("MarcinZelkowski");
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
