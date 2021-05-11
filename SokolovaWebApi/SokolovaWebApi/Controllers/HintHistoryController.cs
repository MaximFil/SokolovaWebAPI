using Microsoft.AspNetCore.Mvc;
using Riddles.Service.Services;
using Riddles.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SokolovaWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HintHistoryController : Controller
    {
        private readonly HintHistoryService hintHistoryService;

        public HintHistoryController()
        {
            this.hintHistoryService = new HintHistoryService();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("createhinthistory")]
        public ActionResult CreateHintHistory([FromBody]GameSessionUseHintHistory hintHistory)
        {
            try
            {
                hintHistoryService.CreateHintHistory(hintHistory);
                return new JsonResult("Success");
            }
            catch(Exception ex)
            {
                return new JsonResult("Error");
            }
        }
    }
}
