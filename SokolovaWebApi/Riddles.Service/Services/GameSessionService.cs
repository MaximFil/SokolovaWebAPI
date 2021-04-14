using Riddles.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Riddles.Service.ResponseModels;
using Riddles.DAL.Entities;

namespace Riddles.Service.Services
{
    public class GameSessionService
    {
        private readonly LevelService levelService;
        private readonly UserService userService;
        private readonly GameSessionRepository gameSessionRepository;

        public GameSessionService()
        {
            userService = new UserService();
            levelService = new LevelService();
            gameSessionRepository = new GameSessionRepository();
        }

        public ApiResponse CreateGameSession(GameSession gameSession, int firstUserId, int secondUserId)
        {
            try
            {
                var currentGameSession = gameSessionRepository.AddGameSession(gameSession, firstUserId, secondUserId);
                return new ApiResponse(true, "Success", currentGameSession);
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
