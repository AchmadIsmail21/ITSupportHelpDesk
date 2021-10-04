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
    public class ConvertationsController : BaseController<Convertation, ConvertationRepository, int>
    {
        private readonly ConvertationRepository convertationRepository;

        public ConvertationsController(ConvertationRepository convertationRepository) : base(convertationRepository)
        {
            this.convertationRepository = convertationRepository;
        }
    }
}
