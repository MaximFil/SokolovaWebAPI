using Microsoft.AspNetCore.Mvc;
using Riddles.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Riddles.DAL.Entities;

namespace SokolovaWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RiddlesController : ControllerBase
    {
        private readonly RiddlesService riddlesService;

        public RiddlesController()
        {
            this.riddlesService = new RiddlesService();
        }

        [HttpGet]
        [Route("getriddlesbylevel/{level}/{number}")]
        public List<Riddle> GetRiddlesByLevel(string level, int number)
        {
            return riddlesService.GetRiddlesByLevel(level, number);
        }
    }
}
