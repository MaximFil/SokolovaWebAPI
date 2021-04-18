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
    public class AnswerHistoryController : Controller
    {
        private readonly AnswerHistoryService answerHistoryService;

        public AnswerHistoryController()
        {
            this.answerHistoryService = new AnswerHistoryService();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("createanswerhistory")]
        public ActionResult CreateAnswerHistory([FromBody]GameSessionAnswerHistory answerHistory)
        {
            try
            {
                answerHistoryService.CreateHistory(answerHistory);
                return new JsonResult("Success");
            }
            catch(Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }
    }
}
