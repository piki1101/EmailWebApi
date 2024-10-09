using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dtos.User.Read
{
    public class ReadAllUsersListDto
    {
        public ReadAllUsersListDto(int id, string name, string surname)
        {
            Id = id;
            Name = name;
            Surname = surname;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
