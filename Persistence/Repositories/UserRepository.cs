using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Services.Exceptions;
using Services.Repositories;

namespace Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppContext _appContext;

        public UserRepository(AppContext context)
        {
            _appContext = context;            
        }
        public void Create(EmailAppUser user)
        {
            _appContext.Add(user);
            _appContext.SaveChanges();
        }

        public void Update(EmailAppUser user)
        {
            EmailAppUser existingUser = GetById(user.Id);

            if (string.IsNullOrEmpty(user.Password))
            {
                user.Password = existingUser.Password;
            }

            _appContext.Entry(existingUser).CurrentValues.SetValues(user);
            _appContext.SaveChanges();
        }

        public EmailAppUser GetById(int id)
        {
            EmailAppUser user = _appContext.Users.Find(id);

            if (user == null)
            {
                throw new UserNotFoundException($"This user does not exist or is not active.");
            }

            return user;
        }

        public EmailAppUser GetByEmail(string email)
        {
            EmailAppUser user = _appContext.Users.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefault();

            if (user == null)
            {
                throw new UserNotFoundException($"Invalid credentials");
            }

            return user;
        }
    }
}
