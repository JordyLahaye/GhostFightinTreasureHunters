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
        private Dictionary<int, int> Position { get; set; }
        public HauntingMarker() : base("haunting marker") //Create HauntingMarker
        {

        }

        
    }
}
