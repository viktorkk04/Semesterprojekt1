/* Main class for launching the game
 */
using System.Text.Json;
class Game
{
    static World world;
    static Context context;

  static void Main(string[] args)
  {
    Console.Clear();
    Score score = new Score(0, 30, 0);
    Player player = new Player("", score);
    string name = "";
    int daysLeft = 5;
    
    string jsonSave = File.ReadAllText("jsonfiles/save.json");
    Save saveTest = JsonSerializer.Deserialize<Save>(jsonSave);
    
    Console.WriteLine("Start a new game or use a save?");
    Console.WriteLine("1: Start new game");
    Console.WriteLine("2: Use a save");
    
    bool gameCreation = false;
    while(!gameCreation) {
        char input = Console.ReadKey(intercept: true).KeyChar;
        if (input == '1') {
            gameCreation = true;

            // Welcome message
            Console.Clear();
            Console.WriteLine("Welcome to Svendborg!"); 
            Console.WriteLine("You're a up-and-coming politician, trying to establish himself in the community before the election, which is set to take place in 5 days."); 
            Console.WriteLine("Your goal is to walk around the town, and accept different dilemmas which can impact how your voters see you."); 
            Console.WriteLine("You can accept 1 dilemma each day, while accumulating a score which impacts your results.");
            Console.WriteLine("You need 60% popularity to get elected for office. Be careful that you do not reach 100% corruption.");
            Console.WriteLine();
            
            // Player Creation and world creation
            Console.WriteLine("What is your name?");
            Console.Write("\n> ");
            bool nameCreation = false;

            while (!nameCreation) {
                string inputName = Console.ReadLine();
                if (inputName == "") {
                    Console.Write("> ");
                    continue;
                } else {
                    nameCreation = true;
                    name = inputName;
                }
            }

            player = new Player(name, score);
        } else if (input == '2') {
            gameCreation = true;
            Console.WriteLine(saveTest);
            Console.ReadLine();
            player = saveTest.player;
            daysLeft = saveTest.daysLeft;
            //bool saveChooser = false;
        } else {
            continue;
        }
    }

    world = new World(player);
    context = new Context(world.GetEntry(), daysLeft);
    List<string> acceptedDilemmas = new List<string>();

    Console.Clear();
    Console.WriteLine($"Hello {player.GetName()}. These are your stats: {player.GetScore()}");
    Console.WriteLine("Write help to display a help message");
    Console.Write("\nPress a button to start you campaign >");
    Console.ReadKey();
    context.GetCurrent().Welcome();

    while (context.IsDone() == false)
    { // This is the main gameplay loop
      Console.Write("> ");
      string? line = Console.ReadLine(); // Gets input from console and puts them in the line string
      if (line == null) continue;

      // parse line
      string[] elements = line.Split(" "); //Splits the lane at each Space puts the elements into an array
      string command = elements[0].ToLower(); //Takes the first index from element and puts it into command
      string[] parameters = GetParameters(elements); // The output of the function is stored in the parameters array. Scroll down for function

      switch (command)
      { //Here the command get checked in a switch
        case "exit":
        case "quit":
        case "bye":
            Console.WriteLine("Do you want to save?");
            Console.WriteLine("Press (y/n) for yes or no:");
            bool saved = false;
            while (!saved) {
                char input = Console.ReadKey(intercept: true).KeyChar;
                if (input == 'y') {
                    Save save = new Save("Save1", player, context.GetDaysLeft(), acceptedDilemmas);
                    string jsonString = JsonSerializer.Serialize(save);
                    File.WriteAllText("jsonfiles/save.json", jsonString);
                    Console.WriteLine("You have saved");
                    context.MakeDone();
                    saved = true;
                } else if (input == 'n') {
                    context.MakeDone();
                    saved = true;
                } else {
                    continue;
                }
            } 
            
            context.MakeDone(); //This ends the while loop. See Context.cs
          break;
        case "go":
          if (parameters.Length != 1)
          { // This checks if the length of parameters is anything else but 1. That is one value.
            Console.WriteLine("I don't seem to know where that is");
            continue;
          }
          context.Transition(parameters[0]); // This passes the parameter value into context.Transition.
          break;
        case "help":
          Console.WriteLine(" - exit        Exit the program");
          Console.WriteLine(" - quit        Exit the program");
          Console.WriteLine(" - bye         Exit the program");
          Console.WriteLine(" - go          Follow an exit");
          Console.WriteLine(" - interact    Interact with a room");
          Console.WriteLine(" - map         Diaplay map and current location");
          Console.WriteLine(" - status      To see your status");
          Console.WriteLine(" - help        Display a help message");
          break;
        case "interact":
        try{
            Dilemma CurrentDilemma = context.GetCurrent().GetDilemma();
            if (CurrentDilemma.GetIsAccepted()) {
                Console.WriteLine("This dilemma has already been accepted!");
                break;
            }
            Console.Clear();
            Console.WriteLine("Press any key to continue:");
            Console.WriteLine();
            foreach (String message in CurrentDilemma.GetDilemmaList() ) {
                string formattedMessage = message.Replace("{playerName}", player.GetName());
                Console.WriteLine(formattedMessage);
                Console.ReadKey(intercept: true);
            }
            
            Console.WriteLine("Will you accept this deal. Press (y/n) for yes or no:");
            bool dealDone = false;
            while (!dealDone) {
                char input = Console.ReadKey(intercept: true).KeyChar;
                
                if (input == 'y') {
                    CurrentDilemma.AcceptDilemma();
                    Score newScore = CurrentDilemma.GetScore();
                    player.CalculateScore(newScore);
                    
                    acceptedDilemmas.Add(context.GetCurrent().GetName());
                    
                    context.NewDay(world, player, newScore);
                    dealDone = true;
                } else if (input == 'n') {
                    context.GetCurrent().Welcome();
                    Console.WriteLine("You chose no. Go explore other options in the city");
                    dealDone = true;
                } else {
                    continue;
                }
            }
        } catch (NullReferenceException){
            Console.WriteLine("Nothing to interact with here");
        }
            break;
        case "status" :
            Console.WriteLine(player.GetScore());
            break;
        case "map" :
            Console.Clear();
            Map map = new Map(context.GetCurrent());
            Console.Write("\nPress any key to exit map:");
            Console.ReadKey(intercept: true);
            Console.Clear();
            context.GetCurrent().Welcome();
            
            break;
        default:
          Console.WriteLine("Woopsie, I don't understand '" + command + "'");
          break;
      }
    }
    Console.WriteLine("");
    Console.WriteLine("Game Over!");
  }

  private static string[] GetParameters(string[] input)
  { //This function takes a string array as an input
    string[] output = new string[input.Length - 1]; //A new array is created with one length less than the input array.
    for (int i = 0; i < output.Length; i++)
    { //This for loop takes the index+1 of the input and puts it into the output.
      output[i] = input[i + 1].ToLower();
    }
    return output; //The output is then returned.
  }
} 
