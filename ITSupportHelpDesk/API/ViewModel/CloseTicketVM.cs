﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModel
{
    public class CloseTicketVM
    {
        public int CaseId { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
    }
}