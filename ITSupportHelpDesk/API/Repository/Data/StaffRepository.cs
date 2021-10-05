using API.Context;
using API.Model;
using API.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class StaffRepository : GeneralRepository<MyContext, Staff, int>
    {
        private readonly MyContext myContext;
        private readonly DbSet<RegisterVM> entities;
        public StaffRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
            entities = myContext.Set<RegisterVM>();
        }

        public IEnumerable<ProfileVM> GetStaffs()
        {
            //User user = new User();
            var all = (
                    from u in myContext.Users
                    join r in myContext.Roles
                    on u.RoleId equals r.Id
                    select new ProfileVM
                    {
                        Id = u.Id,
                        Name = u.Name,
                        Email = u.Email,
                        BirthDate = u.BirthDate,
                        gender = (ProfileVM.Gender)u.gender,
                        RoleName = r.Name,
                        Phone = u.Phone,
                        Address = u.Address,
                        Department = u.Department,
                        Company = u.Company
                    }
                ).ToList();
            return all.Where(rn => rn.RoleName != "Client");
        }
        //get data client by Id
        public ProfileVM GetStaffById(int id)
        {
            var all = (
                    from u in myContext.Users
                    join r in myContext.Roles
                    on u.RoleId equals r.Id
                    select new ProfileVM
                    {
                        Id = u.Id,
                        Name = u.Name,
                        Email = u.Email,
                        BirthDate = u.BirthDate,
                        gender = (ProfileVM.Gender)u.gender,
                        RoleName = r.Name,
                        Phone = u.Phone,
                        Address = u.Address,
                        Department = u.Department,
                        Company = u.Company
                    }
                ).ToList();
            return all.Where(u => u.RoleName != "Client").FirstOrDefault(u => u.Id == id);
        }
    }
}
