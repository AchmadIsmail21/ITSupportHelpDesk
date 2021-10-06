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
    public class HistoriesController : BaseController<History, HistoryRepository, int>
    {
        private readonly HistoryRepository historyRepository;
        public HistoriesController(HistoryRepository historyRepository) : base(historyRepository)
        {
            this.historyRepository = historyRepository;
        }
        [HttpGet("GetHistories")]
        public ActionResult GetHistoriess()
        {
            var getHistories = historyRepository.GetHistories();
            if (getHistories != null)
            {
                return Ok(getHistories);
            }
            else
            {
                return BadRequest("Data History Tidak Ditemukan");
            }
        }

    }
}
