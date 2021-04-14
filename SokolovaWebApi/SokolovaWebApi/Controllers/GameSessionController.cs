using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Riddles.Service.ResponseModels;
using Riddles.Service.Services;
using Riddles.DAL.Entities;

namespace SokolovaWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameSessionController : Controller
    {
        private readonly GameSessionService gameSessionService;

        public GameSessionController()
        {
            this.gameSessionService = new GameSessionService();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("creategamesession/{firstUserId}/{secondUserId}")]
        public ApiResponse CreateGameSession([FromBody]GameSession gameSession, int firstUserId, int secondUserId)
        {
            ApiResponse apiResponse;
            try
            {
                apiResponse = gameSessionService.CreateGameSession(gameSession, firstUserId, secondUserId);
            }
            catch(Exception ex)
            {
                apiResponse = new ApiResponse(false, ex.Message);
            }

            return apiResponse;
        }
    }
}
