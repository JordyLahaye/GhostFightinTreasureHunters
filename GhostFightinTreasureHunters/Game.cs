using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostFightinTreasureHunters
{
    public class Game
    {
        public int Id { get; set; } //DB bepaalt
        public DateTime StartDate { get; private set; } // Eenmalig aanmaken
        public DateTime LastPlayedDate { get; set; }

        public bool IsCompleted { get; set; }

        public List<Player> Players { get; set; } = new List<Player>(); 

        public Game() // Nieuw spel, nadenken wanneer word een nieuwe game aangemaakt
        {
            StartDate = DateTime.Now;
        }

        public Game(DateTime startDate) // Bestaand spel
        {
            StartDate = startDate;
        }

        public void StartGame()
        {

        }

    }
}
