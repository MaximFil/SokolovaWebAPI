using Microsoft.EntityFrameworkCore;
using Riddles.DAL;
using Riddles.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riddles.Repository.Repositories
{
    public class RiddlesRepository
    {
        private readonly ApplicationContext context;

        public RiddlesRepository()
        {
            this.context = new ApplicationContext(ConnectionStringHelper.GetConnectionStringByName(ConnectionType.TestDB));
        }

        public IQueryable<Riddle> GetRiddles()
        {
            return context.Riddles;
        }

        public List<Riddle> GetRiddlesByLevel(int levelId)
        {
            return GetRiddles()
                .Where(r => r.LevelId == levelId)
                .ToList();
        }

        public List<Riddle> GetRiddlesByGameSessionId(int gameSessionId)
        {
            var riddleIds = context.XrefGameSessionsRiddles
                .Where(x => x.GameSessionId == gameSessionId)
                .Select(x => x.RiddleId)
                .ToHashSet();
            return GetRiddles()
                .Where(r => riddleIds.Any(i => i == r.Id))
                .ToList();
        }
    }
}
