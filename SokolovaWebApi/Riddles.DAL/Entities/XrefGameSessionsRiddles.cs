using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riddles.DAL.Entities
{
    public class XrefGameSessionsRiddles
    {
        public int? GameSessionId { get; set; }
        public GameSession GameSession { get; set; }

        public int? RiddleId { get; set; }
        public Riddle Riddle { get; set; }
    }
}
