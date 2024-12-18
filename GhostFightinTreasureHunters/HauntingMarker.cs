using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostFightinTreasureHunters
{
    public class HauntingMarker : Pawn
    {
        private int Id { get; set; }
        private Tile tile { get; set; } // tile of position (zelfde in DB houden)
        public HauntingMarker() : base("haunting marker") //Create HauntingMarker
        {

        }

        
    }
}
