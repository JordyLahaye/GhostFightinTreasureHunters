﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostFightinTreasureHunters
{

    public class Tile
    {
        private int Id { get; set; }
        public string Type { get; set; }
        public string RoomId { get; set; }
        private Tile tile {  get; set; } // fix dit voor bord
        public bool HasHauntingMarker { get; set; }

        public bool HasJewel { get; set; }

        public List<Pawn> CountPlayers { get; set; }

        public List<Pawn> CountGhosts { get; set; } // OF INT en dan PLUS 1 per geest op de tile?



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
