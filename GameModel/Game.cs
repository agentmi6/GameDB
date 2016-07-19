using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameModel
{
    public class Game
    {       
        public string GameName { get; set; }
        public string Platform { get; set; }
        public string Year { get; set; }
        public double Price{ get; set; }        
        public string GameSummary { get; set; }
    }
}
