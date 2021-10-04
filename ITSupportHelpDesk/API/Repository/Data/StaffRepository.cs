using API.Context;
using API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class StaffRepository : GeneralRepository<MyContext, Staff, int>
    {
        public StaffRepository(MyContext myContext) : base(myContext)
        {
        }
    }
}
