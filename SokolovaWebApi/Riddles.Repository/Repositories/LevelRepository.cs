using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Riddles.DAL;
using Riddles.DAL.Entities;

namespace Riddles.Repository.Repositories
{
    public class LevelRepository
    {
        private readonly ApplicationContext context;
        public LevelRepository()
        {
            this.context = new ApplicationContext(ConnectionStringHelper.GetConnectionStringByName(ConnectionType.TestDB));
        }

        public IQueryable<Level> GetLevels()
        {
            return context.Levels;
        }

        public Dictionary<string, int> GetDictionaryOfLevels()
        {
            try
            {
                return context.Levels.ToDictionary(l => l.LevelName, l => l.Id);
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
