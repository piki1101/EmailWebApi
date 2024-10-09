using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class EmailSearchModel
    {
        public string SubjectSearchTerm { get; set; }
        public bool Sent { get; set; }
    }
}
