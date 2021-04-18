using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Riddles.DAL.Entities;
using Riddles.Repository.Repositories;

namespace Riddles.Service.Services
{
    public class AnswerHistoryService
    {
        private readonly AnswerHistoryRepository answerHistoryRepository;

        public AnswerHistoryService()
        {
            this.answerHistoryRepository = new AnswerHistoryRepository();
        }

        public void CreateHistory(GameSessionAnswerHistory answerHistory)
        {
            try
            {
                answerHistoryRepository.CreateAnswerHistory(answerHistory);
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
