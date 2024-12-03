using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostFightinTreasureHunters
{
    public class Hunter : Pawn
    {
        public static List<string> availableHunters = new List<string>() {"green","yellow","cyan","red"}; //Note: nu kan ik het accesen via de klasse ipv Hunter hunter = new Hunter(); hunter.availableHunters;
        private string Name { get; set; }
        private string ColorHunter { get; set; }
        private Boolean HasJewel { get; set; }

        public Hunter(string colorHunter) : base("Hunter")
        {
            ColorHunter = colorHunter;
            HasJewel = false;
        }

        public void Move(Tile tile)
        {
            Die die = new Die();
            die.ThrowDie("move");
        }

        public void Attack()
        {
            Die die = new Die();
            die.ThrowDie("attack");
        }

        public void PickUpJewel()
        {

        }

        public void DropJewel()
        {

        }
    }
}
