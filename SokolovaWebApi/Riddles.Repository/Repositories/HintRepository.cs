using Riddles.DAL;
using Riddles.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riddles.Repository.Repositories
{
    public class HintRepository
    {
        private readonly ApplicationContext context;

        public HintRepository()
        {
            this.context = new ApplicationContext(ConnectionStringHelper.GetConnectionStringByName(ConnectionType.RiddlesDB));
        }

        public IQueryable<Hint> GetHints()
        {
            return context.Hints;
        }
    }
}
