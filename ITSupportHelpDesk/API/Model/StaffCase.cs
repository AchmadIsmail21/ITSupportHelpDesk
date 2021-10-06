using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model
{
    [Table("TB_TR_StaffCases")]
    public class StaffCase
    {
        [Key]
        public int Id { get; set; }
        public int? CaseId { get; set; }
        public virtual Case Case { get; set; }
        public int? StaffId { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual ICollection<StaffCase> StaffCases { get; set; }
    }
}
