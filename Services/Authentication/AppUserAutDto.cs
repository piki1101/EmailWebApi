using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Authentication
{
    public class AppUserAutDto
    {
        public AppUserAutDto(int id, string email, string password)
        {
            Id = id;
            Email = email;
            Password = password;
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
