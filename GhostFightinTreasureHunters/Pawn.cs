using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostFightinTreasureHunters
{
    public abstract class Pawn
    {
        private string Type { get; set; }
        private Dictionary<int,int> Position { get; set; }

        public Pawn(string type)
        {
            Type = type;
            //Position = new Dictionary<int,int>();
        }
    }
}
