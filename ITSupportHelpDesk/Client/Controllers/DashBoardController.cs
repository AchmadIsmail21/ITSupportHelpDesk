using Client.Base;
using API.Model;
using Client.Repository;
using Client.Repository.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
