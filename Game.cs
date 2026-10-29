/* Main class for launching the game
 */

class Game
{
  static World world = new World();
  static Context context = new Context(world.GetEntry(), 5);

  static void Main(string[] args)
  {
    Console.Clear();
    Console.WriteLine("Welcome to the World of Zuul!");

    // Player Creation
    Console.WriteLine("What is your name?");
    Console.Write("\n> ");
    string? name = Console.ReadLine();

    Score score = new Score(0, 0, 0);
    Player player = new Player(name, score);

    Console.WriteLine($"Hello {player.GetName()}. These are your stats: {player.GetScore()}");
    Console.WriteLine("Write help to display a help message");
    Console.Write("\nPress a button to continue >");
    Console.ReadKey();
    context.GetCurrent().Welcome();

    while (context.IsDone() == false)
    { // This is the main gameplay loop
      Console.Write("> ");
      string? line = Console.ReadLine(); // Gets input from console and puts them in the line string
      if (line == null) continue;

      // parse line
      string[] elements = line.Split(" "); //Splits the lane at each Space puts the elements into an array
      string command = elements[0]; //Takes the first index from element and puts it into command
      string[] parameters = GetParameters(elements); // The output of the function is stored in the parameters array. Scroll down for function

      switch (command)
      { //Here the command get checked in a switch
        case "exit":
        case "quit":
        case "bye":
          context.MakeDone(); //This ends the while loop. See Context.cs
          break;
        case "go":
          if (parameters.Length != 1)
          { // This checks if the length of parameters is anything else but 1. That is one value.
            Console.WriteLine("I don't seem to know where that is 🤔");
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
          Console.WriteLine(" - help        Display a help message");
          break;
        case "interact":
        try{
            Dilemma CurrentDilemma = context.GetCurrent().GetDilemma();
            if (CurrentDilemma.GetIsAccepted()) {
                Console.WriteLine("This dilemma has already been accepted!");
                break;
            }
            
            
            foreach (String message in CurrentDilemma.GetDilemmaList() ) {
                Console.WriteLine(message);
                Console.ReadKey(intercept: true);
            }
            Console.WriteLine("Will you accept this deal. Press (y/n):");
            bool dealDone = false;
            while (!dealDone) {
                char input = Console.ReadKey(intercept: true).KeyChar;
                
                if (input == 'y') {
                    CurrentDilemma.AcceptDilemma();
                    player.CalculateScore(CurrentDilemma.GetScore());
                    context.NewDay(world,player);
                    dealDone = true;
                } else if (input == 'n') {
                    dealDone = true;
                } else {
                    continue;
                }
                
            }
        } catch (NullReferenceException){
            Console.WriteLine("Nothing to interact with here");
        }
            break;
        default:
          Console.WriteLine("Woopsie, I don't understand '" + command + "' 😕");
          break;
      }
    }
    Console.WriteLine("Game Over 😥");
  }

  private static string[] GetParameters(string[] input)
  { //This function takes a string array as an input
    string[] output = new string[input.Length - 1]; //A new array is created with one length less than the input array.
    for (int i = 0; i < output.Length; i++)
    { //This for loop takes the index+1 of the input and puts it into the output.
      output[i] = input[i + 1];
    }
    return output; //The output is then returned.
  }
} //So if we pass in an array that is {go, north} we then create an array with one less length {0} and put in the second value of the input.
  // The output is then {north}
  // 
  //test push