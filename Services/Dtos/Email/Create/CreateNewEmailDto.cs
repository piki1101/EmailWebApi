using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;

namespace Services.Dtos.Email.Create
{
    public class CreateNewEmailDto
    {
        public virtual EmailAppUser User { get; set; }
        [Required]
        [EmailAddress]
        public string SendTo { get; set; }
        public List<string> CCList { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public EmailPriority Priority { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime? SentDate { get; set; }
        public bool Seen { get; set; } = false;
    }
}
