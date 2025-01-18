using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostFightinTreasureHunters
{

    public class Tile
    {
        public string Type { get; set; }
        public string RoomId { get; set; }
        public bool HasHauntingMarker { get; set; } = false;
        private int GameId { get; set; }
        public bool HasJewel { get; set; }

        public int CountPlayers { get; set; } = 0;

        public int CountGhosts { get; set; } // OF INT en dan PLUS 1 per geest op de tile?

        public Tile(string type, string roomId, int gameId, bool hasJewel, int countGhosts)
        {
            Type = type;
            RoomId = roomId;
            GameId = gameId;
            HasJewel = hasJewel;
            CountGhosts = countGhosts;

        }



        public void SpawnGhost()
        {
            //Logic
        }
        public void RemoveGhost()
        {
            //Logic
        }
        public void RemoveHauntingMarker()
        {
            //Logic
        }
        public void RemoveJewel()
        {
            //Logic
        }

    }


}
