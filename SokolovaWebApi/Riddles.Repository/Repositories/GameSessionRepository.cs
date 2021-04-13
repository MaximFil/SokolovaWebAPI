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
            this.context = new ApplicationContext(ConnectionStringHelper.GetConnectionStringByName(ConnectionType.TestDB));
        }

        //public GameSession AddGameSession(int firstUserId, int secondUserId, int levelId)
        //{
        //    try
        //    {
        //        context.GameSessions.Add(new GameSession() { LevelId = levelId, StartedDate = DateTime.Now, IsCompleted = false });
        //        context.SaveChanges();
        //        var gameSession = context.GameSessions.OrderByDescending(g => g.StartedDate).FirstOrDefault(g => !g.IsCompleted);
        //        if(gameSession != null && gameSession.Id > 0)
        //        {

        //        }
        //    }
        //}
    }
}
