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
        public int CreateTicket(TicketVM ticketVM) {
            var result = 0;
            var message = "You Succes Create Ticket";
            var user = myContext.Users.Find(ticketVM.UserId);
            if (user == null) {
                return 400;
            }
            serviceEmail.SendEmail(message,user.Email);
            {
                Case cases = new Case()
                {
                    Description = ticketVM.Description,
                    StartDateTime = ticketVM.StartDateTime,
                    EndDateTime = ticketVM.EndDateTime,
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
                    Description = "Create Ticket",
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
    }
}
