using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;

namespace Services.Dtos.Email.Read
{
    public class EmailListDto
    {
        public EmailListDto(int id, string subject, EmailPriority priority, DateTime? sendDate, bool seen)
        {
            Id = id;
            Subject = subject;
            Priority = priority;
            SentDate = sendDate;
            Seen = seen;
            
        }
        public int Id { get; set; }
        public string Subject { get; set; }
        public EmailPriority Priority { get; set; }
        public DateTime? SentDate { get; set; }
        public bool Seen { get; set; }
    }
}
