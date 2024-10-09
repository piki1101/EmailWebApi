using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Entities
{
    public class Email
    {
        public int Id { get; set; }
        public virtual EmailAppUser User { get; set; }
        public string SendTo { get; set; }
        public List<string>? CCList { get; set; }
        public string Subject { get; set; }
        public EmailPriority Priority { get; set; }
        public string Content { get; set; }
        public DateTime? SentDate { get; set; }
        public bool Seen { get; set; }
    }
}
