using API.Context;
using API.Helper;
using API.Model;
using API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class CaseRepository : GeneralRepository<MyContext, Case, int>
    {
        private readonly MyContext myContext;

        public CaseRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
        MailHandler serviceEmail = new MailHandler();
        public int CreateTicket(TicketVM ticketVM)
        {
            var result = 0;
            var message = "You Succes Create Ticket";
            var user = myContext.Users.Find(ticketVM.UserId);
            if (user == null)
            {
                return 400;
            }
            serviceEmail.SendEmail(message, user.Email);
            {
                Case cases = new Case()
                {
                    Description = ticketVM.Description,
                    StartDateTime = DateTime.Now,
                    Review = 0,
                    PriorityId = 1,
                    Level = 1,
                    UserId = ticketVM.UserId,
                    CategoryId = ticketVM.CategoryId
                };
                myContext.Add(cases);
                result = myContext.SaveChanges();

                StaffCase staffCase = new StaffCase()
                {
                    CaseId = cases.Id,
                    StaffId = 1
                };
                myContext.Add(staffCase);
                result = myContext.SaveChanges();

                History history = new History()
                {
                    CaseId = cases.Id,
                    Description = "(System) Create Ticket and Ask Admin Support",
                    DateTime = DateTime.Now,
                    Level = 1,
                    UserId = ticketVM.UserId,
                    StatusCodeId = 1
                };
                myContext.Add(history);
                result = myContext.SaveChanges();
            }
            return result;
        }
        public IEnumerable<CaseVM> GetCases() {
            var all = (
                    from c in myContext.Cases
                    join u in myContext.Users on c.UserId equals u.Id
                    join p in myContext.Priorities on c.PriorityId equals p.Id
                    join ct in myContext.Categories on c.CategoryId equals ct.Id
                    join scs in myContext.StaffCases on c.Id equals scs.CaseId
                    join s in myContext.Staffs on scs.StaffId equals s.Id
                    select new CaseVM
                    {
                        Id = c.Id,
                        Description = c.Description,
                        StartDateTime = c.StartDateTime,
                        EndDateTime = c.EndDateTime,
                        Review = c.Review,
                        Level = c.Level,
                        UserId = u.Id,
                        UserName = u.Name,
                        PriorityName = p.Name,
                        CategoryName = ct.Name,
                        StaffId = s.Id
                    }
                ).ToList();
            return all;
        }

        public IEnumerable<CaseVM> ViewTicketByUserId(int userId) {
            var all = (
                    from c in myContext.Cases
                    join u in myContext.Users on c.UserId equals u.Id
                    join p in myContext.Priorities on c.PriorityId equals p.Id
                    join ct in myContext.Categories on c.CategoryId equals ct.Id
                    join scs in myContext.StaffCases on c.Id equals scs.CaseId
                    join s in myContext.Staffs on scs.StaffId equals s.Id
                    select new CaseVM
                    {
                        Id = c.Id,
                        Description = c.Description,
                        StartDateTime = c.StartDateTime,
                        EndDateTime = c.EndDateTime,
                        Review = c.Review,
                        Level = c.Level,
                        UserId = u.Id,
                        UserName = u.Name,
                        PriorityName = p.Name,
                        CategoryName = ct.Name,
                        StaffId = s.Id
                    }
                ).ToList();
            return all.Where(x => x.UserId == userId && (x.Review == null || x.Review <= 0));
        }

        public IEnumerable<CaseVM> ViewTicketByStaffId(int staffId)
        {
            var all = (
                    from c in myContext.Cases
                    join u in myContext.Users on c.UserId equals u.Id
                    join p in myContext.Priorities on c.PriorityId equals p.Id
                    join ct in myContext.Categories on c.CategoryId equals ct.Id
                    join scs in myContext.StaffCases on c.Id equals scs.CaseId
                    join s in myContext.Staffs on scs.StaffId equals s.Id
                    select new CaseVM
                    {
                        Id = c.Id,
                        Description = c.Description,
                        StartDateTime = c.StartDateTime,
                        EndDateTime = c.EndDateTime,
                        Review = c.Review,
                        Level = c.Level,
                        UserId = u.Id,
                        UserName = u.Name,
                        PriorityName = p.Name,
                        CategoryName = ct.Name,
                        StaffId = s.Id
                    }
                ).ToList();
            return all.Where(x => x.StaffId == staffId && (x.Review == null || x.Review <= 0));
        }

        public IEnumerable<CaseVM> ViewHistoryTicketsByStaffId(int staffId)
        {
            var all = (
                    from c in myContext.Cases
                    join u in myContext.Users on c.UserId equals u.Id
                    join p in myContext.Priorities on c.PriorityId equals p.Id
                    join ct in myContext.Categories on c.CategoryId equals ct.Id
                    join scs in myContext.StaffCases on c.Id equals scs.CaseId
                    join s in myContext.Staffs on scs.StaffId equals s.Id
                    select new CaseVM
                    {
                        Id = c.Id,
                        Description = c.Description,
                        StartDateTime = c.StartDateTime,
                        EndDateTime = c.EndDateTime,
                        Review = c.Review,
                        Level = c.Level,
                        UserId = u.Id,
                        UserName = u.Name,
                        PriorityName = p.Name,
                        CategoryName = ct.Name,
                        StaffId = s.Id
                    }
                ).ToList();
            return all.Where(x => x.StaffId == staffId && (x.Review == null || x.Review <= 0));
        }

        public IEnumerable<CaseVM> ViewTicketByLevel(int staffId)
        {
            var all = (
                    from c in myContext.Cases
                    join u in myContext.Users on c.UserId equals u.Id
                    join p in myContext.Priorities on c.PriorityId equals p.Id
                    join ct in myContext.Categories on c.CategoryId equals ct.Id
                    join scs in myContext.StaffCases on c.Id equals scs.CaseId
                    join s in myContext.Staffs on scs.StaffId equals s.Id
                    select new CaseVM
                    {
                        Id = c.Id,
                        Description = c.Description,
                        StartDateTime = c.StartDateTime,
                        EndDateTime = c.EndDateTime,
                        Review = c.Review,
                        Level = c.Level,
                        UserId = u.Id,
                        UserName = u.Name,
                        PriorityName = p.Name,
                        CategoryName = ct.Name,
                        StaffId = s.Id
                    }
                ).ToList();
            return all.Where(x => x.StaffId == staffId && (x.Review == null || x.Review <= 0));
        }

    }
}
