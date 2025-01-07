namespace GhostFightinTreasureHunters
{
    internal class Program
    {
        private static List<Player> Players = new List<Player>(); //Note: static is alleen aanroepbaar binnen de klasse Program
        static void Main(string[] args)
        {
            CardDeck cd = new CardDeck();
            cd.Shuffle();
            PlayGame();
            
        }

        static void PlayGame()
        {
            Game game = new Game();
            game.Start();
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
