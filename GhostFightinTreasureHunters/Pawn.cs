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
        private Tile tile { get; set; } // tile of position (zelfde in DB houden)

        public Pawn(string type)
        {
            Type = type;
            //Position = new Dictionary<int,int>();
        }
    }
}
