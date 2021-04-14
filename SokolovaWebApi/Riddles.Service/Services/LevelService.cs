using Riddles.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Riddles.Service.ResponseModels;

namespace Riddles.Service.Services
{
    public class LevelService
    {
        private readonly LevelRepository levelRepository;

        public LevelService()
        {
            this.levelRepository = new LevelRepository();
        }

        public ApiResponse GetLevels()
        {
            try
            {
                var levels = levelRepository.GetDictionaryOfLevels();
                return new ApiResponse(true, "Success", levels);
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
