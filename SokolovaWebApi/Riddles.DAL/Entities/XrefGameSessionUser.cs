using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riddles.DAL.Entities
{
    public class XrefGameSessionUser
    {
        public int GameSessionID { get; set; }
        public GameSession GameSession { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int TotalTime { get; set; }

        public int Points { get; set; }
    }
}
