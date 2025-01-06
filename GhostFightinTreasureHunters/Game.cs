using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace GhostFightinTreasureHunters
{
    public class Game
    {
        public DateTime StartDate { get; private set; } // Eenmalig aanmaken
        public DateTime LastPlayedDate { get; set; }

        public bool IsCompleted { get; set; }

        public int PlayerCount { get; set; }
        public int CollectedJewels { get; set; }

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
            Program program = new Program();
            string inputPlayerCount = program.TextToUserInput("Met hoeveel spelers zijn jullie? (Dit spel kan worden gespeeld met 2-4 spelers)");
            if (int.TryParse(inputPlayerCount, out int PlayerCount))
            {
                for (int i = 0; i < PlayerCount; i++)
                {
                    string playerName = program.TextToUserInput($"Voer de naam in van speler {i + 1}:");
                    string colorHunter;

                    if (i == 3) // Als er met 4 man gespeelt word, de laatste die kiest (0,1,2,3) die heeft de overgebleven pion
                    {
                        string playerColor = availablePlayerPawns[0];
                        program.TextToUser($"{playerName}, jij krijgt de pion kleur: {playerColor}");
                        availablePlayerPawns.Remove(playerColor);

                        Player player = new Player(playerName, playerColor);
                        Players.Add(player);

                    }
                    else
                    {
                        program.TextToUser($"{playerName}, uit de volgende pion kleuren kun je kiezen");

                        int count = 1;
                        foreach (string color in availablePlayerPawns)
                        {

                            program.TextToUser($"{count} : {color}");
                            count++;
                        }

                        bool notCompleted = true; //Zorg ervoor dat je niet de hele StartGame reset moet doen als je één fout maakt
                        while (notCompleted)
                        {
                            string inputColor = program.UserInput();
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
                                program.TextToUser("Kies een geldig nummer!");
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
                program.TextToUser("Geen geldige invoer, voer een getal in");
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
            while (!IsCompleted)
            {
                //Logic
                NextTurn();
                Move();
                //if conditie klopt dan:
                Attack();
            

            }
            
        }

        public void Move()
        {
            Program program = new Program();
            bool correctAnswer = false;
            program.TextToUser($"{PlayerTurn.Name}, rol de dobbelsteen om te lopen (druk op 'Enter' om te rollen)");
            while (true)
            {
                string answer = program.UserInput();
                if (string.IsNullOrEmpty(answer))
                {
                    string rollResult = PlayerTurn.ThrowDie("move");
                    if (rollResult == "6")
                    {
                        program.TextToUser($"Je hebt '{rollResult}' gerolt!");
                        return;

                    }
                    else
                    {
                        program.TextToUser($"Je hebt '{rollResult}' gerolt! Helaas moet je een kaart rapen");
                        DrawCard();
                        return;
                    }

                }
                else
                {
                    program.TextToUser("Foute invoer, druk op 'Enter' om de dobbelsteen te rollen");
                }
            }
        }

        public void DrawCard()
        {
            Program program = new Program();
            program.TextToUser($"{PlayerTurn.Name}, raap een kaart van de stapel (druk op 'Enter') ");
            while (true)
            {
                string answer = program.UserInput();
                if (string.IsNullOrEmpty(answer))
                {
                    string cardResult = PlayerTurn.DrawCard();
                    if (cardResult == "a" || cardResult == "b" || cardResult == "c" || cardResult == "d" || cardResult == "e" || cardResult == "f" 
                        || cardResult == "g" || cardResult == "h") 
                    {
                        program.TextToUser($"Je trekt een kaart van de stapel en raapt: 'Geestkaart', Oh nee! Er komt een spook in kamer {cardResult}");
                        return;

                    }
                    else
                    {
                        program.TextToUser($"Je trekt een kaart van de stapel en raapt:"); // Maak af!
                        return;
                    }

                }
                else
                {
                    program.TextToUser("Foute invoer, druk op 'Enter' om een kaart te rapen");
                }
            }
        }

        public void Attack()
        {
            Program program = new Program();
            while (true)
            {
                string answer = program.UserInput();

                if (string.IsNullOrEmpty(answer))
                {
                    string rollResult = PlayerTurn.ThrowDie("attack");
                    program.TextToUser($"Je dobbelsteen land op: '{rollResult}'!");
                    return;
                }
                else
                {
                    program.TextToUser("Foute invoer, druk op 'Enter' om de dobbelsteen te rollen");
                }
            }
        }

        public void NextTurn()
        {
            if (PlayerTurn == null) // Eerste beurt
            {
                PlayerTurn = Players[0];
            }
            else
            {
                int currentIndex = Players.IndexOf(PlayerTurn);
                PlayerTurn = Players[(currentIndex + 1) % Players.Count]; // Ga oor de lijst
            }
        }

        public void SaveGame()
        {

        }

    }
}
