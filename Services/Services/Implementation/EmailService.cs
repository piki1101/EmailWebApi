using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using Services.Dtos.Email.Create;
using Services.Dtos.Email.Read;
using Services.Dtos.Email.Update;
using Services.Models;
using Services.Repositories;
using Services.Services.Abstraction;

namespace Services.Services.Implementation
{
    public class EmailService : IEmailService
    {
        private readonly IEmailRepository _emailRepository;
        private readonly IMapper _mapper;
        public EmailService(IEmailRepository emailRepository, IMapper mapper)
        {
            _emailRepository = emailRepository;
            _mapper = mapper;
        }

        public void Create(CreateNewEmailDto emailCreation)
        {
            Email newEmail = _mapper.Map<CreateNewEmailDto, Email>(emailCreation);
            newEmail.SentDate = DateTime.Now; 

            _emailRepository.CreateNewEmail(newEmail);
        }

        public void DeleteById(int emailId)
        {
            this._emailRepository.DeleteEmail(emailId);
        }

        public void Update(UpdateEmailDto emailUpdate)
        {
            //Email desieredEmail = _mapper.Map<UpdateEmailDto, Email>(emailUpdate);

            _emailRepository.UpdateEmail(emailUpdate);
        }

        List<EmailListDto> IEmailService.GetAllUserEmails(EmailSearchModel emailSearch)
        {
            return _emailRepository.GetAllEmails(emailSearch).Select(email => 
            new EmailListDto(email.Id, email.Subject, email.Priority, email.SentDate, email.Seen)).ToList();
        }
    }
}
