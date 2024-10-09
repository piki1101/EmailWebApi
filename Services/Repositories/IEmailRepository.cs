using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Services.Dtos.Email.Read;
using Services.Dtos.Email.Update;
using Services.Models;

namespace Services.Repositories
{
    public interface IEmailRepository
    {
        void CreateNewEmail(Email email);
        void UpdateEmail(UpdateEmailDto email);
        void DeleteEmail(int id);
        IQueryable<Email> GetAllEmails(EmailSearchModel emailSearch);
        Email GetEmailById(int id);
    }
}
