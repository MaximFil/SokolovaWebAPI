using Microsoft.EntityFrameworkCore;
using Riddles.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Riddles.DAL.Entities;
using System.Text;
using System.Threading.Tasks;

namespace Riddles.Service.Services
{
    public class RecordService
    {

        private readonly GameSessionRepository gameSessionRepository;

        public RecordService()
        {
            this.gameSessionRepository = new GameSessionRepository();
        }

        public List<ResponseModels.RecordModel> GetRecordsByLevel(string levelName)
        {
            try
            {
                return gameSessionRepository.GetGameSessionForUser()
                    .Include(g => g.GameSession.Level)
                    .Include(g => g.User)
                    .Where(g => string.Equals(g.GameSession.Level.LevelName.ToLower(), levelName.ToLower()) && g.Finished)
                    .ToList()
                    .Select(g => new ResponseModels.RecordModel
                    {
                        Name = g.User.Name,
                        Minutes = Convert.ToInt32(g.TotalTime.Split(':')?.FirstOrDefault()),
                        Seconds = Convert.ToInt32(g.TotalTime.Split(':')?.Skip(1)?.FirstOrDefault()),
                        Points = g.Points
                    }).OrderByDescending(g => g.Points).ThenBy(g => g.Minutes).ThenBy(g => g.Seconds).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
