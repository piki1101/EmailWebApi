using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Services.Dtos.Email.Read;
using Services.Dtos.Email.Update;
using Services.Exceptions;
using Services.Models;
using Services.Repositories;

namespace Persistence.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        private readonly AppContext _appContext;
        public EmailRepository(AppContext context)
        {
            _appContext = context;
        }
        public void CreateNewEmail(Email email)
        {
            _appContext.Add(email);
            _appContext.SaveChanges();
        }

        public void DeleteEmail(int id)
        {
            Email email = GetEmailById(id);
            _appContext.Emails.Remove(email);
            _appContext.SaveChanges();
        }

        public IQueryable<Email> GetAllEmails(EmailSearchModel emailSearch)
        {
            IQueryable<Email> results = _appContext.Emails.Where(email => email.SentDate.HasValue == emailSearch.Sent);

            if(!string.IsNullOrEmpty(emailSearch?.SubjectSearchTerm))
            {
                results = results.Where(email => email.Subject.Contains(emailSearch.SubjectSearchTerm));
            }

            return results;
        }

        public Email GetEmailById(int id)
        {
            Email email = _appContext.Emails.Find(id);

            if (email == null)
            {
                throw new UserNotFoundException($"This user does not exist or is not active.");
            }

            return email;
        }

            public void UpdateEmail(UpdateEmailDto email)
            {
                Email existingEmail = GetEmailById(email.Id);

                _appContext.Entry(existingEmail).CurrentValues.SetValues(email);
                _appContext.SaveChanges();
            }
    }
}
