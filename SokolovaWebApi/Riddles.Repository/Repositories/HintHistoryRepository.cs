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

        public void CreateHintHIstory(GameSessionUseHintHistory hintHistory, string hintName)
        {
            try
            {
                var hintId = context.Hints.FirstOrDefault(h => string.Equals(h.Name, hintName, StringComparison.InvariantCultureIgnoreCase))?.Id;
                if (hintId.HasValue)
                {
                    hintHistory.HintId = hintId;
                    context.GameSessionUseHintHistories.Add(hintHistory);
                    context.SaveChanges();
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
