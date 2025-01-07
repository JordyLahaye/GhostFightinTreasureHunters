using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostFightinTreasureHunters
{
    public class CardDeck
    {

        public List<string> ListOfCards { get; set; } = new List<string>() {"A","B","C","D","E"};
        public List<string> RemainingCards { get; set; } = new List<string>();
        private int gameId { get; set; }

        public void Shuffle()
        {
            Random random = new Random();
            RemainingCards = ListOfCards.OrderBy(x => random.Next()).ToList();
            //Shuffle listofcards
        }

        public string GrabCard()
        {

            return RemainingCards.Last();
        }
    }
}
