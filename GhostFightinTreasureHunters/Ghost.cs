using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostFightinTreasureHunters
{
    public class Ghost : Pawn
    {
        private int Id { get; set; }
        public int AmountOfGhostInRoom { get; set; }
        private Dictionary<int, int> Position { get; set; }

        public Ghost() : base("ghost")
        {

        }
    }
}
