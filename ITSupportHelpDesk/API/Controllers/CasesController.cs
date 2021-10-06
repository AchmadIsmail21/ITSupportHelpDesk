using API.Base;
using API.Model;
using API.Repository.Data;
using API.ViewModel;
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

        [HttpPost("CreateTicket")]
        public ActionResult CreateTicket(TicketVM ticketVM) {
            var create = caseRepository.CreateTicket(ticketVM);
            if (create > 0)
            {
                return Ok("Tiket Berhasil Ditambahkan");
            }
            else {
                return BadRequest("Tiket gagal ditambahkan");
            }
        }

        [HttpGet("GetCases")]
        public ActionResult GetCases() {
            var getCase = caseRepository.GetCases();
            if (getCase != null)
            {
                return Ok(getCase);
            }
            else {
                return BadRequest("Data Tidak Ditemukan");
            }
        }

        [HttpGet("ViewTicketsByUserId/{userId}")]
        public ActionResult ViewTicketByUserId(int userId) {
            var getViewTicket = caseRepository.ViewTicketByUserId(userId);
            if (getViewTicket != null)
            {
                return Ok(getViewTicket);
            }
            else {
                return BadRequest("Data dengan Id tersebut tidak ditemukan");
            }
        }
    }
}
