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

        [HttpGet("ViewHistoryTicketsByUserId/{userId}")]
        public ActionResult ViewHistoryTicketsByUserId(int userId)
        {
            var getHistory = caseRepository.ViewHistoryTicketsByUserId(userId);
            if (getHistory != null)
            {
                return Ok(getHistory);
            }
            else
            {
                return BadRequest("Data tidak ditemukan");
            }
        }

        [HttpGet("ViewTicketsByStaffId/{staffId}")]
        public ActionResult ViewTicketsByStaffId(int staffId)
        {
            var get = caseRepository.ViewTicketsByStaffId(staffId);
            if (get != null)
            {
                return Ok(get);
            }
            else
            {
                return BadRequest("Data ticket dengan staff id tersebut tidak ditemukan");
            }
        }

        [HttpGet("ViewHistoryTicketByStaffId/{staffId}")]
        public ActionResult ViewHistoryTicketByStaffId(int staffId)
        {
            var getHistory = caseRepository.ViewHistoryTicketsByStaffId(staffId);
            if (getHistory != null)
            {
                return Ok(getHistory);
            }
            else
            {
                return BadRequest("Data tiket dengan staff id tersebut tidak ditemukan");
            }
        }

        [HttpGet("ViewTicketByLevel/{level}")]
        public ActionResult ViewTicketByLevel(int level)
        {
            var get = caseRepository.ViewTicketByLevel(level);
            if (get != null)
            {
                return Ok(get);
            }
            else
            {
                return BadRequest("Tiket Gagal Ditutup");
            }
        }

        [HttpPost("NextLevel")]
        public ActionResult NextLevel(CloseTicketVM closeTicketVM)
        {
            var ask = caseRepository.NextLevel(closeTicketVM.CaseId);
            if (ask > 0)
            {
                return Ok("Berhasil meminta bantuan");
            }
            else
            {
                return BadRequest("Gagal meminta bantuan");
            }
        }
    }
}
