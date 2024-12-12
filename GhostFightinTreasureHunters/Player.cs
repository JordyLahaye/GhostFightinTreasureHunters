using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostFightinTreasureHunters
{
    public class Player : Pawn
    {
        private List<Int32> DieMoveIndex = new List<Int32>() { 1, 2, 3, 4, 5, 6 };
        private List<String> DieAttackIndex = new List<String>() { "ghost", "ghost", "ghost", "hauntingmarker", "hauntingmarker", "hauntingmarker" };
        //Of 3 en 3 is 1 op 1 kans op een of het ander dus : random 0 tot 1, if 1 dan ghost if 0 dan haunting, zelfde voor moveindex, random next(0,6)?
        /*Random random = new Random();
        int randint = random.Next(0, 2);
        Console.WriteLine(randint);*/

        public string Name { get; set; }
        public string ColorHunter { get; set; }
        public Player(string name, string colorHunter) //CreatePlayer
        {
            Name = name;
            ColorHunter = colorHunter;
            Hunter hunter = new Hunter(colorHunter);

        }

        public void Move(Tile tile)
        {
            //Logic
        }

        public void Attack()
        {
            //Logic
        }

        public void DrawCard()
        {
            //Logic
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
