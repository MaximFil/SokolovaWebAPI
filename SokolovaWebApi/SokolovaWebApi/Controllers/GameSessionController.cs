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
        [Route("creategamesession/{firstUserId}/{secondUserId}/{riddlesCount}")]
        public ApiResponse CreateGameSession([FromBody]GameSession gameSession, int firstUserId, int secondUserId, int riddlesCount)
        {
            ApiResponse apiResponse;
            try
            {
                apiResponse = gameSessionService.CreateGameSession(gameSession, firstUserId, secondUserId, riddlesCount);
            }
            catch(Exception ex)
            {
                apiResponse = new ApiResponse(false, ex.Message);
            }

            return apiResponse;
        }

        [HttpPut]
        [Route("completegamesession")]
        public void CompleteGameSession([FromBody]int gameSessionId)
        {
            try
            {
                gameSessionService.CompleteGameSession(gameSessionId);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        [HttpPut]
        [Route("surrendergamesessionuser/{gameSessionId}/{userName}")]
        public void SurrenderGameSessionUser([FromBody]bool surrendered, int gameSessionId, string userName)
        {
            try
            {
                gameSessionService.SurrenderGameSessionUser(gameSessionId, userName, surrendered);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("getgamesessionbyid/{gameSessionId}")]
        public GameSession GetGameSessionById(int gameSessionId)
        {
            try
            {
                return gameSessionService.GetGameSessionById(gameSessionId);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        [HttpPut]
        [Route("completegamesessionforuser")]
        public void CompleteGameSessionForUser([FromBody]XrefGameSessionUser gameSessionUser)
        {
            try
            {
                gameSessionService.CompleteGameSessionForUser(gameSessionUser);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("getcompletegamesessionuser/{gameSessionId}/{userName}")]
        public XrefGameSessionUser GetCompleteGameSessionUser(int gameSessionId, string userName)
        {
            try
            {
                return gameSessionService.GetCompleteGameSessionUser(gameSessionId, userName);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
