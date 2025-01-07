using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostFightinTreasureHunters
{
    public class CardDeck
    {

        public List<string> ListOfCards { get; set; } = new List<string>();
        public List<string> RemainingCards { get; set; } = new List<string>();
        private int gameId { get; set; }

        public void Shuffle()
        {

        }

    }
}
