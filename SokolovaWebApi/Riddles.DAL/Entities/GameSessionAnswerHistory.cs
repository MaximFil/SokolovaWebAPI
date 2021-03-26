using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riddles.DAL.Entities
{
    public class GameSessionAnswerHistory
    {
        public int Id { get; set; }

        public int GameSessionId { get; set; }
        public GameSession GameSession { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }

        public int? RiddleId { get; set; }
        public Riddle Riddle { get; set; }

        public string Answer { get; set; }

        public bool Correct { get; set; }

        public DateTime AnswerDate { get; set; }
    }
}
