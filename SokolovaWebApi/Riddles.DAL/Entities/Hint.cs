using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riddles.DAL.Entities
{
    public class Hint
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Cost { get; set; }

        public List<GameSessionUseHintHistory> GameSessionUseHintHistories { get; set; }

        public Hint()
        {
            GameSessionUseHintHistories = new List<GameSessionUseHintHistory>();
        }
    }
}
