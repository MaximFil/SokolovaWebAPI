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
    public class HintController : Controller
    {
        private readonly HintService hintService;

        public HintController()
        {
            this.hintService = new HintService();
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("gethints")]
        public ApiResponse GetHints()
        {
            ApiResponse apiResponse;
            try
            {
                apiResponse = hintService.GetHints();
            }
            catch (Exception ex)
            {
                apiResponse = new ApiResponse(false, ex.Message);
            }

            return apiResponse;
        }
    }
}
