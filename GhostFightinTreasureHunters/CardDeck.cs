using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostFightinTreasureHunters
{
    public class Carddeck
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

        public string GrabCard() //Pak de 'bovenste' kaart
        {
            string card = RemainingCards.Last(); // Pak de "bovenste" van de stapel
            RemainingCards.Remove(card);
            return card;
        }

        public List<string> GetListOfCards() //Getter
        {
            return ListOfCards;
        }
        public List<string> GetRemainingCards() //Getter
        {
            return RemainingCards;
        }
    }
}
