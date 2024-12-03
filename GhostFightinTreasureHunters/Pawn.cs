using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostFightinTreasureHunters
{
    public abstract class Pawn
    {
        private string Name { get; set; }
        private Dictionary<int,int> Position { get; set; }

        public Pawn(string name)
        {
            Name = name;
            //Position = new Dictionary<int,int>();
        }
    }
}
