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
        private readonly RiddlesService riddlesService;
        private readonly GameSessionRepository gameSessionRepository;

        public GameSessionService()
        {
            userService = new UserService();
            levelService = new LevelService();
            riddlesService = new RiddlesService();
            gameSessionRepository = new GameSessionRepository();
        }

        public ApiResponse CreateGameSession(GameSession gameSession, int firstUserId, int secondUserId, int riddlesCount = 5)
        {
            try
            {
                var riddleIds = riddlesService.GetRiddlesByLevel(gameSession.LevelId, riddlesCount).Select(r => r.Id).ToList();
                var currentGameSession = gameSessionRepository.AddGameSession(gameSession, firstUserId, secondUserId, riddleIds);
                return new ApiResponse(true, "Success", currentGameSession);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public void CompleteGameSession(int gameSessionId)
        {
            try
            {
                gameSessionRepository.CompleteGameSession(gameSessionId);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public GameSession GetGameSessionById(int gameSessionId)
        {
            return gameSessionRepository
                .GetGameSessions()
                .FirstOrDefault(g => g.Id == gameSessionId);
        }

        public void CompleteGameSessionForUser(XrefGameSessionUser gameSessionUser)
        {
            try
            {
                gameSessionRepository.CompleteGameSessionForUser(gameSessionUser);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public XrefGameSessionUser GetCompleteGameSessionUser(int gameSessionId, string userName)
        {
            try
            {
                var userId = userService.GetUserIdByName(userName);

                return gameSessionRepository.GetGameSessionUser(gameSessionId, userId);

            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public void SurrenderGameSessionUser(int gameSessionId, string userName, bool surrendered = true)
        {
            try
            {
                var userId = userService.GetUserIdByName(userName);

                gameSessionRepository.SurrenderedGameSessionUser(gameSessionId, userId, surrendered);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public void AddResultToGameSessionUser(int gameSessionId, int userId, string result)
        {
            try
            {
                gameSessionRepository.AddResultToGameSessionUser(gameSessionId, userId, result);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public void ExitGameSessionUser(int gameSessionId, int userId)
        {
            try
            {
                gameSessionRepository.ExitGameSessionUser(gameSessionId, userId);
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
