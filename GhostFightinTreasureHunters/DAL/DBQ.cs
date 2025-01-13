using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace GhostFightinTreasureHunters.DAL
{
    public class DBQ
    {

        private string connectionString = "Data Source=.;Initial Catalog=GFTH;Integrated Security=True;Trust Server Certificate=True";
        

        public void CreateGame(List<Player> players, Player playerTurn, int jewels, List<Tile> tiles, List<string> cards)
        {
            int gameId;
            int collectedJewels = jewels;
            DateTime startDate = DateTime.Now;
            string fileName = "Game_" + startDate.ToString("yyyyMMdd_HHmmss");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Start a transaction to ensure all inserts are executed together
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Insert the game into the Game table
                    string insertGameQuery = @"
                        INSERT INTO Game (fileName, playerCount, collectedJewels, startDate, playerTurn)
                        OUTPUT INSERTED.id
                        VALUES (@fileName, @playerCount, @collectedJewels, @startDate, @playerTurn)";

                    using (SqlCommand command = new SqlCommand(insertGameQuery, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@fileName", fileName);
                        command.Parameters.AddWithValue("@playerCount", players.Count);
                        command.Parameters.AddWithValue("@collectedJewels", collectedJewels);
                        command.Parameters.AddWithValue("@startDate", startDate);
                        command.Parameters.AddWithValue("@playerTurn", playerTurn.Id);

                        // Get the new Game ID
                        gameId = (int)command.ExecuteScalar();
                    }

                    // Insert each player into the Pawn table
                    string insertPawnQuery = @"
                        INSERT INTO Pawn (name, type, gameId, colorHunter)
                        VALUES (@name, @type, @gameId, @colorHunter)";

                    foreach (var player in players)
                    {
                        using (SqlCommand command = new SqlCommand(insertPawnQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@name", player.Name);
                            command.Parameters.AddWithValue("@type", "Player");
                            command.Parameters.AddWithValue("@gameId", gameId);
                            command.Parameters.AddWithValue("@colorHunter", player.ColorHunter);

                            command.ExecuteNonQuery();
                        }
                    }

                    // Insert each tile into the Tile table
                    string insertTileQuery = @"
                        INSERT INTO Tile (gameId, position, tileType)
                        VALUES (@gameId, @position, @tileType)";

                    foreach (var tile in tiles)
                    {
                        using (SqlCommand command = new SqlCommand(insertTileQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@gameId", gameId);
                            command.Parameters.AddWithValue("@position", tile.Position);
                            command.Parameters.AddWithValue("@tileType", tile.TileType);

                            command.ExecuteNonQuery();
                        }
                    }

                    // Insert each card into the CardDeck table
                    string insertCardQuery = @"
                        INSERT INTO CardDeck (gameId, cardName, cardType)
                        VALUES (@gameId, @cardName, @cardType)";

                    foreach (var card in cards)
                    {
                        using (SqlCommand command = new SqlCommand(insertCardQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@gameId", gameId);
                            command.Parameters.AddWithValue("@cardName", card.CardName);
                            command.Parameters.AddWithValue("@cardType", card.CardType);

                            command.ExecuteNonQuery();
                        }
                    }

                    // Commit the transaction
                    transaction.Commit();
                    Console.WriteLine("Game, players, tiles, and cards added successfully!");
                }
                catch (Exception ex)
                {
                    // Rollback the transaction in case of an error
                    transaction.Rollback();
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }


    }


}
