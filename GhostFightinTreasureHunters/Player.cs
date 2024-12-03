using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostFightinTreasureHunters
{
    public class Player
    {
        public string Name { get; set; }
        Hunter hunter { get; set; }
        //private string ColorHunter { get; set; }
        public string ColorHunter { get; set; }
        public Player(string name, string colorHunter)
        {
            Name = name;
            ColorHunter = colorHunter;
            Hunter hunter = new Hunter(colorHunter);

        }
    }
}
