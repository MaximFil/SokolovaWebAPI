using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riddles.DAL.Entities
{
    public class Level
    {
        public int Id { get; set; }

        [Required]
        public string LevelName { get; set; }

        public string RussianName { get; set; }

        public int LevelTime { get; set; }

        public List<Riddle> Riddles { get; set; }

        public Level()
        {
            Riddles = new List<Riddle>();
        }
    }
}
