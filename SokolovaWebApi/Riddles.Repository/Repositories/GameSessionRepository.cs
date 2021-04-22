using Riddles.DAL;
using Riddles.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riddles.Repository.Repositories
{
    public class GameSessionRepository
    {
        private readonly ApplicationContext context;

        public GameSessionRepository()
        {
            this.context = new ApplicationContext(ConnectionStringHelper.GetConnectionStringByName(ConnectionType.RiddlesDB));
        }

        public IQueryable<GameSession> GetGameSessions()
        {
            return context.GameSessions.AsQueryable();
        }

        public GameSession AddGameSession(GameSession gameSession, int firstUserId, int secondUserId, List<int> riddleIds)
        {
            try
            {
                context.GameSessions.Add(gameSession);
                context.SaveChanges();
                gameSession = context.GameSessions.OrderByDescending(g => g.StartedDate).FirstOrDefault(g => !g.IsCompleted);
                if (gameSession != null && gameSession.Id > 0)
                {
                    context.XrefGameSessionUsers.Add(new XrefGameSessionUser() { GameSessionID = gameSession.Id, UserId = firstUserId, TotalTime = string.Empty, Points = 10, Surrendered = false, Result = string.Empty, Finished = false });
                    context.XrefGameSessionUsers.Add(new XrefGameSessionUser() { GameSessionID = gameSession.Id, UserId = secondUserId, TotalTime = string.Empty, Points = 10, Surrendered = false, Result = string.Empty, Finished = false });
                    foreach(var id in riddleIds)
                    {
                        context.XrefGameSessionsRiddles.Add(new XrefGameSessionsRiddles { GameSessionId = gameSession.Id, RiddleId = id });
                    }
                    context.SaveChanges();
                    return gameSession;
                }
                else
                {
                    throw new Exception("Игровая сессия не было создана!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CompleteGameSession(int gameSessionId)
        {
            try
            {
                var gameSession = GetGameSessions().FirstOrDefault(g => g.Id == gameSessionId);
                if(gameSession != null)
                {
                    gameSession.IsCompleted = true;
                    gameSession.FinishedDate = DateTime.Now;
                }
                else
                {
                    throw new NullReferenceException("Игровая сессия не была найдена!");
                }

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void CompleteGameSessionForUser(XrefGameSessionUser gameSessionUser)
        {
            try
            {
                var gameSession = context.XrefGameSessionUsers
                    .FirstOrDefault(g => g.GameSessionID == gameSessionUser.GameSessionID && g.UserId == gameSessionUser.UserId);
                
                if(gameSession == null)
                {
                    throw new NullReferenceException("Missing game session for current User");
                }

                gameSession.TotalTime = gameSessionUser.TotalTime;
                gameSession.Points = gameSessionUser.Points;
                gameSession.Finished = gameSessionUser.Finished;
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public XrefGameSessionUser GetGameSessionUser(int gameSessionId, int userId)
        {
            try
            {
                var gameSessionUser = context.XrefGameSessionUsers
                    .FirstOrDefault(g => g.GameSessionID == gameSessionId && g.UserId == userId);

                if (gameSessionUser == null)
                {
                    throw new NullReferenceException("Missing game session for current User");
                }

                return gameSessionUser;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void SurrenderedGameSessionUser(int gameSessionId, int userId, bool surrendered = true)
        {
            try
            {
                var gameSessionUser = context.XrefGameSessionUsers
                    .FirstOrDefault(g => g.GameSessionID == gameSessionId && g.UserId == userId);

                if (gameSessionUser == null)
                {
                    throw new NullReferenceException("Missing game session for current User");
                }

                gameSessionUser.Surrendered = true;
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
