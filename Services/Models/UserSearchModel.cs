﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class UserSearchModel
    {
        public int? Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
