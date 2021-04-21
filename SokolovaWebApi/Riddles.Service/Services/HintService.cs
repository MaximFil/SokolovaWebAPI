using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Riddles.Repository.Repositories;

namespace Riddles.Service.Services
{
    public class HintService
    {
        private readonly HintRepository hintRepository;

        public HintService()
        {
            this.hintRepository = new HintRepository();
        }

        public ResponseModels.ApiResponse GetHints()
        {
            try
            {
                var hints = hintRepository.GetHints().ToList();
                return new ResponseModels.ApiResponse(true, "Success", hints);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
