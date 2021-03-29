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

        public List<Riddle> GetRiddlesByLevel(string level)
        {
            return GetRiddles().Include(r => r.Level)
                .AsEnumerable()
                .Where(r => string.Equals(level, r.Level.LevelName, StringComparison.InvariantCultureIgnoreCase))
                .ToList();
        }
    }
}
