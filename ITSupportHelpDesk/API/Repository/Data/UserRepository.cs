using API.Context;
using API.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class UserRepository : GeneralRepository<MyContext, User, int>
    {
        private readonly MyContext myContext;

        public UserRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
    }
}
