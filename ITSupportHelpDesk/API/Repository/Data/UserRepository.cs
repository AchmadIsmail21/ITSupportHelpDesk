using API.Context;
using API.Model;
using API.ViewModel;
using Microsoft.EntityFrameworkCore;
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
        private readonly DbSet<RegisterVM> entities;

        public UserRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
            entities = myContext.Set<RegisterVM>();
        }

        public int Register(RegisterVM registerVM) {
            var result = 0;
            var checkEmail = myContext.Users.FirstOrDefault(u => u.Email == registerVM.Email);
            var checkPhone = myContext.Users.FirstOrDefault(u => u.Phone == registerVM.Phone);
            if (checkEmail == null && checkPhone == null)
            {
                User user = new User
                {
                    Name = registerVM.Name,
                    Email = registerVM.Email,
                    Password = registerVM.Password,
                    BirthDate = registerVM.BirthDate,
                    gender = (User.Gender)registerVM.gender,
                    RoleId = 1,
                    Phone = registerVM.Phone,
                    Address = registerVM.Address,
                    Department = registerVM.Department,
                    Company = registerVM.Company
                };
                myContext.Add(user);
                result = myContext.SaveChanges();

                return result;
            }
            else if (checkEmail != null)
            {
                return 100;
            }
            else if (checkPhone != null) {
                return 200;
            }
            return result;
        }
    }
}
