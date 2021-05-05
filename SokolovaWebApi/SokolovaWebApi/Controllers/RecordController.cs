using Microsoft.AspNetCore.Mvc;
using Riddles.Service.Services;
using Riddles.Service.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SokolovaWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecordController : Controller
    {
        private readonly RecordService recordService;

        public RecordController()
        {
            this.recordService = new RecordService();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("GetRecordsByLevel/{levelName}")]
        public List<RecordModel> GetRecordsByLevel(string levelName)
        {
            try
            {
                return recordService.GetRecordsByLevel(levelName);
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
