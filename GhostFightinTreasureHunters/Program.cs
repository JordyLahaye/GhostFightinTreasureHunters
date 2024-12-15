namespace GhostFightinTreasureHunters
{
    internal class Program // Game
    {
        private static List<Player> Players = new List<Player>(); //Note: static is alleen aanroepbaar binnen de klasse Program
        static void Main(string[] args)
        {

            SetupGame();
            
        }

        static void SetupGame()
        {
            Game game = new Game();
            game.Start();

        }


    }
}
