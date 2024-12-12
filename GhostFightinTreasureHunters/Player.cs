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
    }
}
