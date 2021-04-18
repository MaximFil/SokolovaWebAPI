using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Riddles.DAL;
using Riddles.DAL.Entities;

namespace Riddles.Repository.Repositories
{
    public class AnswerHistoryRepository
    {
        private readonly ApplicationContext context;

        public AnswerHistoryRepository()
        {
            this.context = new ApplicationContext(ConnectionStringHelper.GetConnectionStringByName(ConnectionType.TestDB));
        }

        public void CreateAnswerHistory(GameSessionAnswerHistory answerHistory)
        {
            try
            {
                context.GameSessionAnswerHistories.Add(answerHistory);
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
