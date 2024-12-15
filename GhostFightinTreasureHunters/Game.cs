using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace GhostFightinTreasureHunters
{
    public class Game
    {
        public int Id { get; set; } //DB bepaalt
        public DateTime StartDate { get; private set; } // Eenmalig aanmaken
        public DateTime LastPlayedDate { get; set; }

        public bool IsCompleted { get; set; }

        public List<Player> Players { get; set; } = new List<Player>();

        public List<string> availablePlayerPawns = new List<string>(){"yellow", "green", "cyan", "red"};

        public Player PlayerTurn { get; set; }

        public Game() // Nieuw spel, nadenken wanneer word een nieuwe game aangemaakt
        {
            StartDate = DateTime.Now;
        }

        public Game(DateTime startDate) // Bestaand spel
        {
            StartDate = startDate;
        }

        public void Start()
        {
            Console.WriteLine("Met hoeveel spelers zijn jullie? (Dit spel kan worden gespeeld met 2-4 spelers)");
            string inputPlayerCount = Console.ReadLine();
            if (int.TryParse(inputPlayerCount, out int playerCount))
            {
                for (int i = 0; i < playerCount; i++)
                {
                    Console.WriteLine($"Voer de naam in van speler {i + 1}:");
                    string playerName = Console.ReadLine();
                    string colorHunter;

                    if (i == 3) // Als er met 4 man gespeelt word, de laatste die kiest (0,1,2,3) die heeft de overgebleven pion
                    {
                        string playerColor = availablePlayerPawns[0];
                        Console.WriteLine($"{playerName}, jij krijgt de pion kleur: {playerColor}");
                        availablePlayerPawns.Remove(playerColor);

                        Player player = new Player(playerName, playerColor);
                        Players.Add(player);

                    }
                    else
                    {
                        Console.WriteLine($"{playerName}, uit de volgende pion kleuren kun je kiezen");

                        int count = 1;
                        foreach (string color in availablePlayerPawns)
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
                            if (int.TryParse(inputColor, out int colorChoice) && colorChoice > 0 && colorChoice <= availablePlayerPawns.Count)
                            {

                                switch (colorChoice)
                                {
                                    case 1:
                                        playerColor = availablePlayerPawns[0];
                                        break;
                                    case 2:
                                        playerColor = availablePlayerPawns[1];
                                        break;
                                    case 3:
                                        playerColor = availablePlayerPawns[2];
                                        break;
                                    case 4:
                                        playerColor = availablePlayerPawns[3];
                                        break;
                                }

                                availablePlayerPawns.Remove(playerColor);

                                Player player = new Player(playerName, playerColor);
                                Players.Add(player);
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
                Start(); // Opnieuw
            }


        
        }
        //Create player in zelf

        public void CheckVictory()
        {
            // als alle juwelen uit het huis zijn dan gewonnen!
        }

        public void CheckDefeat()
        {
            // als er 8 haunting markers staan op het bord dan verloren!
        }

        public void PlayRound()
        {
            //Logic
            NextTurn();
            bool correctAnswer = false;
            Console.WriteLine($"{PlayerTurn.Name}, rol de dobbelsteen om te lopen (druk op 'Enter' om te rollen)");
            string answer = Console.ReadLine();
            while (correctAnswer = false)
            {
                if (answer == "")
                {
                    string rollResult = PlayerTurn.ThrowDie("move");
                    if (rollResult == "6")
                    {
                        Console.WriteLine($"Je hebt '{rollResult}' gerolt!");

                    }
                    else
                    {
                        Console.WriteLine($"Je hebt '{rollResult}' gerolt! Helaas moet je een kaart rapen");
                        string cardResult = PlayerTurn.DrawCard()
                    }

                    correctAnswer = true;
                }
                else
                {
                    Console.WriteLine("Foute invoer, druk op 'Enter' om de dobbelsteen te rollen");
                }
            }
            correctAnswer = false; // Voor het volgende blok
            
            while (correctAnswer = false)
            {
                if (answer == "")
                {
                    PlayerTurn.ThrowDie("attack");
                    correctAnswer = true;
                }
                else
                {
                    Console.WriteLine("Foute invoer, druk op 'Enter' om de dobbelsteen te rollen");
                }
            }
        }

        public void NextTurn()
        {
            if(PlayerTurn == null) // Begint beurt, pak de eerste speler
            {
                PlayerTurn = Players[0];
            }
            else
            {
                
                if (PlayerTurn == Players[0])
                {
                    PlayerTurn = Players[1];
                }
                else if (PlayerTurn == Players[1])
                {
                    PlayerTurn = Players[2];
                }
                else if (PlayerTurn == Players[2])
                {
                    PlayerTurn = Players[3];
                }
                else
                {
                    PlayerTurn = Players[0];
                }
            }
        }

        public void SaveGame()
        {

        }

    }
}
