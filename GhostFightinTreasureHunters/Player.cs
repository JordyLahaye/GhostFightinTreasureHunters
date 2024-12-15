using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostFightinTreasureHunters
{
    public class Player : Pawn
    {
        
        public string Name { get; set; }
        public string ColorHunter { get; set; }
        public bool HasJewel { get; set; }

        private List<string> cardDeck = new List<string>() {"a","b", "c", "d", "e", "f", "g", "h"}; // Bekijk kaartregels dit is een begin
        public Player(string name, string colorHunter) : base("player") //CreatePlayer
        {
            Name = name;
            ColorHunter = colorHunter;

        }

        public void Move(Tile tile)
        {
            //Logic
        }

        public void Attack()
        {
            //Logic
        }

        public string DrawCard()
        {
            Random random = new Random();
            int lenghtList = cardDeck.Count;
            int randint = random.Next(0, lenghtList+1); //Deck van de kaarten
            string drawResult = cardDeck[randint];


            return drawResult;
        }

        public void PickUpJewel()
        {
            //Logic
        }

        public void DropJewel()
        {
            //Logic
        }

        





        public string ThrowDie(string action)
        {
            string rollResult = "";

            if (action == "attack")
            {
                Random random = new Random();
                int randint = random.Next(0, 2); //0 - 1
                if (randint == 0)
                {
                    rollResult = "Ghost";
                }
                else
                {
                    rollResult = "Haunting Marker";
                }


            }
            else
            {
                Random random = new Random();
                int randint = random.Next(1, 7); // 1 - 6
                switch (randint)
                {
                    case 1:
                        rollResult = "1";
                        break;
                    case 2:
                        rollResult = "2";
                        break;
                    case 3:
                        rollResult = "3";
                        break;
                    case 4:
                        rollResult = "4";
                        break;
                    case 5:
                        rollResult = "5";
                        break;
                    case 6:
                        rollResult = "6";
                        break;
                }


            }
            Console.WriteLine($"You roll the {action} die and it lands on: {rollResult}!");
            return rollResult;

        }
    }
}
