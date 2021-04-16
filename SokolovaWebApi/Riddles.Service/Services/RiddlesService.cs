using Riddles.Repository.Repositories;
using Riddles.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riddles.Service.Services
{
    public class RiddlesService
    {
        private readonly RiddlesRepository riddlesRepository;

        public RiddlesService()
        {
            riddlesRepository = new RiddlesRepository();
        }

        public List<Riddle> GetRiddlesByLevel(int levelId, int count)
        {
            return riddlesRepository
                .GetRiddlesByLevel(levelId)
                .OrderBy(r => Guid.NewGuid())
                .Take(count)
                .ToList();
        }

        public List<Riddle> GetRiddlesByGameSessionId(int gameSessionId)
        {
            return riddlesRepository.GetRiddlesByGameSessionId(gameSessionId);
        }
    }
}
