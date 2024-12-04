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
            Console.WriteLine("Met hoeveel spelers zijn jullie? (Dit spel kan worden gespeeld met 2-4 spelers)");
            string inputPlayerCount = Console.ReadLine();
            if (int.TryParse(inputPlayerCount, out int playerCount))
            {
                for (int i = 0; i < playerCount; i++)
                {
                    Console.WriteLine($"Voer de naam in van speler {i+1}:");
                    string playerName = Console.ReadLine();
                    string colorHunter;

                    if (i == 3) // Als er met 4 man gespeelt word, de laatste die kiest (0,1,2,3) die heeft de overgebleven pion
                    {
                        string playerColor = Hunter.availableHunters[0];
                        Console.WriteLine($"{playerName}, jij krijgt de pion kleur: {playerColor}");
                        Hunter.availableHunters.Remove(playerColor);

                        Player player = new Player(playerName, playerColor);
                        PlayerList.Add(player);
                    }
                    else
                    {
                        Console.WriteLine($"{playerName}, uit de volgende pion kleuren kun je kiezen");

                        int count = 1;
                        foreach (string color in Hunter.availableHunters)
                        {

                            Console.WriteLine($"{count} : {color}");
                            count++;
                        }

                        Console.WriteLine("Kies je pion kleur: (voer een nummer in)");
                        bool notCompleted = true; //Zorg ervoor dat je niet de hele StartGame reset moet doen als je één fout maakt
                        while (notCompleted)
                        {
                            string inputColor = Console.ReadLine();
                            string playerColor = "";
                            if (int.TryParse(inputColor, out int colorChoice) && colorChoice > 0 && colorChoice <= Hunter.availableHunters.Count)
                            {

                                switch (colorChoice)
                                {
                                    case 1:
                                        playerColor = Hunter.availableHunters[0];
                                        break;
                                    case 2:
                                        playerColor = Hunter.availableHunters[1];
                                        break;
                                    case 3:
                                        playerColor = Hunter.availableHunters[2];
                                        break;
                                    case 4:
                                        playerColor = Hunter.availableHunters[3];
                                        break;
                                }

                                Hunter.availableHunters.Remove(playerColor);

                                Player player = new Player(playerName, playerColor);
                                PlayerList.Add(player);
                                notCompleted = false;

                            }
                            else
                            {
                                Console.WriteLine("Kies een geldig nummer!");
                            }

                        }
                    }
                    


                }

                /*
                foreach (Player player in PlayerList)
                {
                    Console.WriteLine($"{player.Name} : {player.ColorHunter}");
                }
                */
            }
            else
            {
                Console.WriteLine("Geen geldige invoer, voer een getal in");
                SetupGame(); // Opnieuw
            }


        }



        //Die die = new Die();
        //die.ThrowDie("attack");
        //die.ThrowDie("move");
    }
}
