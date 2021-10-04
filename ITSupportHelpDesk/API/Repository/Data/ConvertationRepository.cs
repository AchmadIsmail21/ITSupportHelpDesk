using API.Context;
using API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class ConvertationRepository : GeneralRepository<MyContext, Convertation, int>
    {
        private readonly MyContext myContext;
        public ConvertationRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
    }
}
