using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModel
{
    public class HistoryVM
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public int Level { get; set; }
        public int UserId { get; set; }
        public int CaseId { get; set; }
        public int StatusCodeId { get; set; }

    }
}
