﻿using Riddles.DAL;
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
            this.context = new ApplicationContext(ConnectionStringHelper.GetConnectionStringByName(ConnectionType.TestDB));
        }

        public GameSession AddGameSession(GameSession gameSession, int firstUserId, int secondUserId)
        {
            try
            {
                context.GameSessions.Add(gameSession);
                context.SaveChanges();
                gameSession = context.GameSessions.OrderByDescending(g => g.StartedDate).FirstOrDefault(g => !g.IsCompleted);
                if (gameSession != null && gameSession.Id > 0)
                {
                    context.XrefGameSessionUsers.Add(new XrefGameSessionUser() { GameSessionID = gameSession.Id, UserId = firstUserId, TotalTime = 0, Points = 10 });
                    context.XrefGameSessionUsers.Add(new XrefGameSessionUser() { GameSessionID = gameSession.Id, UserId = secondUserId, TotalTime = 0, Points = 10 });
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
    }
}
