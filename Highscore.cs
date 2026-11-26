// Keeps track of the players' scores and sorts them by the best combined score
using System.Text.Json;

static class Highscore {
    static public List<Player> players { get; set; } = new();
    static string fileName = "HighscoreTable.json";
    static JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };

    // Method for filling the 'players' list with the values from the json file
    static void CreateHighscoreList() {
        // Read the file if it exists
        string jsonString = File.Exists(fileName)
            ? File.ReadAllText(fileName)
            : "";
    
        // Deserialize or create an empty list
        if (string.IsNullOrWhiteSpace(jsonString))
        {
            players = new List<Player>();
        }
        else
        {
            players = JsonSerializer.Deserialize<List<Player>>(jsonString)
                ?? new();
        }
    }

    // Method for adding the current player to the json file
    static public void AddPlayer(Player currentPlayer)
    {
        CreateHighscoreList();
        
        // Find a player with the same name
        Player? existingPlayer = players.FirstOrDefault(
            p => p.GetName() == currentPlayer.GetName()
        );
        
        // if the player name already exists in the list
        if (existingPlayer != null)
        {
            // Update the score for that player
            existingPlayer.SetScore(currentPlayer.GetScore());
        }
        else 
        {
            // add the player to the list
            players.Add(currentPlayer);
        }
            
        // Serialize the entire list
        string updatedJsonString = JsonSerializer.Serialize(players, options);
    
        // Save the updated list
        File.WriteAllText(fileName, updatedJsonString);
    }

    // Method for displaying the highscore list
    static public void DisplayHighscores() {
        CreateHighscoreList();

        Console.WriteLine("""
         _   _ ___ ____ _   _ ____   ____ ___  ____  _____
        | | | |_ _/ ___| | | / ___| / ___/ _ \|  _ \| ____|
        | |_| || | |  _| |_| \___ \| |  | | | | |_) |  _|
        |  _  || | |_| |  _  |___) | |__| |_| |  _ <| |___
        |_| |_|___\____|_| |_|____/ \____\___/|_| \_\_____|
        
        """);

        Console.WriteLine(
                $"{"Name",-20}" +
                $"{"Power",10}" +
                $"{"Corruption",15}" +
                $"{"Popularity",15}"
            );
        Console.WriteLine(new string('-', 60));

        foreach (Player player in players) {
            player.DisplayScore();
        }

    }

    
    

}
