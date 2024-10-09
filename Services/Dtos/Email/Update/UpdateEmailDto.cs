using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Services.Dtos.Email.Update
{
    public class UpdateEmailDto
    {
        public int Id { get; set; }
        public bool Seen { get; set; }
        public DateTime? SentDate { get; set; }
        public EmailPriority Priority { get; set; }
    }
}
