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
    public class CasesController : BaseController<Case, CaseRepository, int>
    {
        private readonly CaseRepository caseRepository;

        public CasesController(CaseRepository caseRepository) : base(caseRepository)
        {
            this.caseRepository = caseRepository;
        }
    }
}
