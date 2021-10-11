using Client.Base;
using API.Model;
using Client.Repository;
using Client.Repository.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Client.Controllers
{
    public class DashBoardController : BaseController<User, UserRepository, int>
    {
        private readonly UserRepository userRepository;
        private readonly CaseRepository caseRepository;
        private readonly ConvertationRepository convertationRepository;
        private readonly CategoryRepository categoryRepository;
        private readonly HistoryRepository historyRepository;
        private readonly PriorityRepository priorityRepository;
        private readonly RoleRepository roleRepository;
        private readonly StaffCaseRepository staffCaseRepository;
        private readonly StaffRepository staffRepository;
        private readonly StatusCodeRepository statusCodeRepository;

        public DashBoardController(UserRepository userRepository,
         CaseRepository caseRepository,
         ConvertationRepository convertationRepository,
         CategoryRepository categoryRepository,
         HistoryRepository historyRepository,
         PriorityRepository priorityRepository,
         RoleRepository roleRepository,
         StaffCaseRepository staffCaseRepository,
         StaffRepository staffRepository,
         StatusCodeRepository statusCodeRepository) : base(userRepository)
        {
            this.userRepository = userRepository;
            this.caseRepository = caseRepository;
            this.convertationRepository = convertationRepository;
            this.categoryRepository = categoryRepository;
            this.historyRepository = historyRepository;
            this.priorityRepository = priorityRepository;
            this.roleRepository = roleRepository;
            this.staffCaseRepository = staffCaseRepository;
            this.staffRepository = staffRepository;
            this.statusCodeRepository = statusCodeRepository;
        }

        public void GetSession() {
            ViewBag.UserId = HttpContext.Session.GetString("UserId");
            ViewBag.Email = HttpContext.Session.GetString("Email");
            ViewBag.Role = HttpContext.Session.GetString("Role");
            ViewBag.RoleId = HttpContext.Session.GetString("RoleId");
            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.StaffId = HttpContext.Session.GetString("StaffId");

            ViewBag.CurrentPage = "";
           
            if (ViewBag.Role == "IT Support")
            {
                ViewBag.Level = 2;
            }
            else if (ViewBag.Role == "Admin Support")
            {
                ViewBag.Level = 1;
            }
            else
            {
                ViewBag.Level = 0;
            }
        }

        //Case Repository
        public async Task<JsonResult> GetCase() {
            GetSession();
            var cases = await caseRepository.GetCase();
            return Json(cases);
        }

        public async Task<JsonResult> GetHandleTickets() {
            GetSession();
            if (ViewBag.StaffId != null)
            {
                var result = await caseRepository.GetTicketsByStaffId(Int32.Parse(ViewBag.StaffId));
                return Json(result);
            }
            else {
                return Json(null);
            }
        }

        public async Task<JsonResult> GetTicketsUser() {
            GetSession();
            if (ViewBag.UserId != null)
            {
                var result = await caseRepository.GetTicketsByUserId(Int32.Parse(ViewBag.UserId));
                return Json(result);
            }
            else {
                return Json(null);
            }
        }

        //Dashboard 
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Logout() {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}
