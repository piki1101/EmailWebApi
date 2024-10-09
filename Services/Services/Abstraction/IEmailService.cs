using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Dtos.Email.Create;
using Services.Dtos.Email.Read;
using Services.Dtos.Email.Update;
using Services.Dtos.User.Create;
using Services.Models;

namespace Services.Services.Abstraction
{
    public interface IEmailService
    {
        void Create(CreateNewEmailDto emailCreation);
        void Update(UpdateEmailDto emailUpdate);
        void DeleteById(int emailId);
        List<EmailListDto> GetAllUserEmails(EmailSearchModel emailSearch);
    }
}
