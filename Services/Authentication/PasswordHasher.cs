using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Services.Authentication
{
    public class PasswordHasher: IPasswordHasher
    {
        public const string SALT = "(*_*)EmailProject_(*o*)_";
        public string HashPassword(string plainPassword)
        {
            string saltedPassword = SALT + plainPassword;
            byte[] hashedBytes = new SHA1CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
            string hashedPassword = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            return hashedPassword;
        }
    }
}
