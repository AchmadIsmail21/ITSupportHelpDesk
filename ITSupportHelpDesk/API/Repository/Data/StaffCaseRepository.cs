using API.Context;
using API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class StaffCaseRepository : GeneralRepository<MyContext, StaffCase, int>
    {
        public StaffCaseRepository(MyContext myContext) : base(myContext)
        {
        }
    }
}
