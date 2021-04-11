using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riddles.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }

        [DefaultValue(typeof(bool), "false")]
        public bool IsActive { get; set; }

        [DefaultValue(typeof(bool), "false")]
        public bool IsPlaying { get; set; }

        public string ConnectionId { get; set; }

        public List<XrefGameSessionUser> XrefGameSessionUsers { get; set; }

        public List<GameSessionUseHintHistory> GameSessionUseHintHistories { get; set; }

        public List<GameSessionAnswerHistory> GameSessionAnswerHistories { get; set; }

        public User()
        {
            XrefGameSessionUsers = new List<XrefGameSessionUser>();
            GameSessionAnswerHistories = new List<GameSessionAnswerHistory>();
            GameSessionUseHintHistories = new List<GameSessionUseHintHistory>();
        }
    }
}
