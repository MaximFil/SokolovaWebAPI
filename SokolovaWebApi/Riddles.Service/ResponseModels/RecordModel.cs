using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riddles.Service.ResponseModels
{
    public class RecordModel
    {
        public string Name { get; set; }

        public int Minutes { get; set; }

        public int Seconds { get; set; }

        public int Points { get; set; }
    }
}
