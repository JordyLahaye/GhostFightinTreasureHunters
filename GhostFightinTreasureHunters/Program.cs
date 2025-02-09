﻿using GhostFightinTreasureHunters.DAL;

namespace GhostFightinTreasureHunters
{
    internal class Program
    {
        //private static List<Player> Players = new List<Player>(); //Note: static is alleen aanroepbaar binnen de klasse Program
        private static Board board;
        static void Main(string[] args)
        {
            ShowListOfCreatedGames();
            SetupBoard();
            
            PlayGame();
            
        }

        static void ShowListOfCreatedGames()
        {
            Console.WriteLine("Je lijst van gespeelde spellen:");
            DBQ dBQ = new DBQ();
            Console.WriteLine(dBQ.GetAllGames());
        }
        public static Board GetBoard()
        {
            return board;
        }

        static void SetupBoard()
        {
            Game game = new Game();
            int gameId = game.Id;
            board = new Board();
            List <Tile> temptiles = new List<Tile>();

            Tile tile1 = new Tile("room", "a", gameId, false, 1);
            Tile tile2 = new Tile("room", "b", gameId, false, 0);
            Tile tile3 = new Tile("room", "c", gameId, true, 1);
            Tile tile4 = new Tile("room", "d", gameId, false, 1);
            Tile tile5 = new Tile("room", "e", gameId, false, 1);
            Tile tile6 = new Tile("room", "f", gameId, true, 0);
            Tile tile7 = new Tile("room", "g", gameId, false, 1);
            Tile tile8 = new Tile("room", "h", gameId, false, 0);
            Tile tile9 = new Tile("room", "i", gameId, true, 1);
            Tile tile10 = new Tile("room", "j", gameId, false, 1);
            Tile tile11 = new Tile("room", "k", gameId, false, 0);
            Tile tile12 = new Tile("room", "l", gameId, true, 1);
            for(int i = 13; i < 36; i++)
            {
                Tile tile = new Tile("hallway", null, gameId, false, 0);
                board.AddTileToTiles(tile);
            }
            board.AddTileToTiles(tile1);
            board.AddTileToTiles(tile2);
            board.AddTileToTiles(tile3);
            board.AddTileToTiles(tile4);
            board.AddTileToTiles(tile5);
            board.AddTileToTiles(tile6);
            board.AddTileToTiles(tile7);
            board.AddTileToTiles(tile8);
            board.AddTileToTiles(tile9);
            board.AddTileToTiles(tile10);
            board.AddTileToTiles(tile11);
            board.AddTileToTiles(tile12);
            Carddeck cd = new Carddeck();
            cd.Shuffle();
            
        }

        static void PlayGame()
        {
            Game game = new Game();
            game.Start();
            Console.WriteLine("Het spel is opgezet en jullie kunnen nu spelen!");
            game.PlayRound();

        }

        public string TextToUserInput(string text)
        {
            Console.WriteLine(text);
            string answer = Console.ReadLine();
            return answer;
        }

        public void TextToUser(string text)
        {
            Console.WriteLine(text);
        }

        public string UserInput()
        {
            string answer = Console.ReadLine();
            return answer;
        }




    }
}
