using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostFightinTreasureHunters
{
    public class Board
    {
        public string TileIndexBoard { get; set; }
        public List<Tile> Tiles { get; set; } = new List<Tile>(); //////////////////////////////////////////////// DB EN ALLE DIAGRAMMEN !!!!!!!!!!!!!!!!!!!!! 
        public int CountHauntingMarker { get; set; }


        public void AddTileToTiles(Tile tile)
        {
            Tiles.Add(tile);
        }

        public List <Tile> GetTiles() { return Tiles; } //Getter

    }
}
