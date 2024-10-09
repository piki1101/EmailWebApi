using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Services.Repositories
{
    public interface IUserRepository
    {
        void Create(EmailAppUser user);
        void Update(EmailAppUser user);
        EmailAppUser GetById(int id);
        EmailAppUser GetByEmail(string email);
    }
}
