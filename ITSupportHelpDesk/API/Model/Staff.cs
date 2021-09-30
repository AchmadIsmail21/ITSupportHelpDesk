using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ITSupport_API.Model
{
    [Table("TB_M_Staffs")]
    public class Staff
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<StaffCase> StaffCase { get; set; }
    }
}
