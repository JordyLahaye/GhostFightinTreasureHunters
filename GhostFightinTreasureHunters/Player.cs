using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostFightinTreasureHunters
{
    public class Player : Pawn
    {
        public int Id { get; set; } //////////////////////////////////////////////////////////////////// ALLE DIAGRAMMEN
        public string Name { get; set; }
        public string ColorHunter { get; set; }
        public bool HasJewel { get; set; }
        private Tile tile { get; set; } // tile of position (zelfde in DB houden)

        public Player(string name, string colorHunter) : base("player") //CreatePlayer
        {
            Name = name;
            ColorHunter = colorHunter;

        }

        public void Move(Tile tile)
        {
            string rollResult = "";
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

        public void Attack()
        {
            string rollResult = "";
            Random random = new Random();
            int randint = random.Next(0, 2); //0 - 1 Omdat er 3 ghost kanten zijn en 3 haunting marker kanten op een dobbelsteen
            if (randint == 0)
            {
                rollResult = "Ghost";
            }
            else
            {
                rollResult = "Haunting Marker";
            }
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
            //Console.WriteLine($"You roll the {action} die and it lands on: {rollResult}!");
            return rollResult;

        }
    }
}
