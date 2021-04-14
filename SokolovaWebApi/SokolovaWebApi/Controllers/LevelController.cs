using Microsoft.AspNetCore.Mvc;
using Riddles.Service.ResponseModels;
using Riddles.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SokolovaWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LevelController : Controller
    {
        private readonly LevelService levelService;

        public LevelController()
        {
            this.levelService = new LevelService();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("getlevels")]
        public ApiResponse GetLevels()
        {
            ApiResponse apiResponse;
            try
            {
                apiResponse = levelService.GetLevels();
            }
            catch(Exception ex)
            {
                apiResponse = null;
            }

            return apiResponse;
        }
    }
}
