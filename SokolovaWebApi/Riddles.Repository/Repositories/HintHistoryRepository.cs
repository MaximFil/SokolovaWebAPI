using Riddles.DAL;
using Riddles.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riddles.Repository.Repositories
{
    public class HintHistoryRepository
    {
        private readonly ApplicationContext context;
        
        public HintHistoryRepository()
        {
            this.context = new ApplicationContext(ConnectionStringHelper.GetConnectionStringByName(ConnectionType.RiddlesDB));
        }

        public void CreateHintHIstory(GameSessionUseHintHistory hintHistory)
        {
            try
            {
                if(hintHistory != null)
                {
                    context.GameSessionUseHintHistories.Add(hintHistory);
                    context.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
