using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostFightinTreasureHunters
{
    public class Ghost : Pawn
    {
        private Tile tile { get; set; } // tile of position (zelfde in DB houden)

        public Ghost() : base("ghost")
        {

        }

        public void TransformIntoHaunting()
        {

        }
    }
}
