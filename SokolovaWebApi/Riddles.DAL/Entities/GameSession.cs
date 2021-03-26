﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riddles.DAL.Entities
{
    public class GameSession
    {
        public int Id { get; set; }

        public int LevelId { get; set; }
        public Level Level { get; set; }

        public List<XrefGameSessionUser> XrefGameSessionUsers { get; set; }

        public DateTime StartedDate { get; set; }

        public DateTime FinishedDate { get; set; }

        public bool IsCompleted { get; set; }

        public List<GameSessionUseHintHistory> GameSessionUseHintHistories { get; set; }

        public List<GameSessionAnswerHistory> GameSessionAnswerHistories { get; set; }

        public GameSession()
        {
            GameSessionAnswerHistories = new List<GameSessionAnswerHistory>();
            GameSessionUseHintHistories = new List<GameSessionUseHintHistory>();
            XrefGameSessionUsers = new List<XrefGameSessionUser>();
        }
    }
}