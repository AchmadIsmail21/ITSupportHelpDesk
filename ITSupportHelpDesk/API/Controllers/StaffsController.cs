using API.Base;
using API.Model;
using API.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffsController : BaseController<Staff, StaffRepository, int>
    {
        private readonly StaffRepository staffRepository;

        public StaffsController(StaffRepository staffRepository) : base(staffRepository)
        {
            this.staffRepository = staffRepository;
        }
    }
}
