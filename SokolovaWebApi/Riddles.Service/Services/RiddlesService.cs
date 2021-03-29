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

        public List<Riddle> GetRiddlesByLevel(string level, int number)
        {
            return riddlesRepository.GetRiddlesByLevel(level).OrderBy(r => Guid.NewGuid()).Take(number).ToList();
        }
    }
}
