using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostFightinTreasureHunters
{
    public class Ghost : Pawn
    {

        public int AmountOfGhostInRoom { get; set; }

        public Ghost() : base("ghost")
        {

        }
    }
}
