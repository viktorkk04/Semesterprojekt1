/* World class for modeling the entire in-game world
 */
using System.Text.Json;
class World
{
  Space square;
  Player player;
  
  public World(Player player)
  {
    this.player = player; 

    string jsonAllDilemma = File.ReadAllText("jsonfiles/dilemma.json");
    Dictionary<string, Dilemma> allDilemma = JsonSerializer.Deserialize<Dictionary<string, Dilemma>>(jsonAllDilemma);
    
    Space square = new Space("Town Square", "You are now in the middle of the city.\nGo explore!");
    Space community = new Space("Community Neighborhood", "You look around.\nTo the north you see a local association.\nTo the east you see a homeless shelter.\nTo the south you see a local festival.\nThe west leads back to the town square.");
    Space industrial = new Space("Industrial Area", "You look around.\nTo the north you see a huge farm.\nTo the west you see a big company.\nTo the east you see a construction site.\nThe south leads back to the town square.");
    Space finance = new Space("Finance Square", "You look around.\nTo the north you see a bank.\nTo the west you see the mansion of a billionaire.\nTo the south you see a lawyer firm.\nThe east leads back to the town square.");
    Space service = new Space("Public service", "You look around.\nTo the west you see a hospital.\nTo the south you see a nursing home.\nTo the east you see a public school.\nThe north leads back to the town square.");
    Space festival = new Space("Local Festival","Welcome to the Local Festival", allDilemma["festival"]);
    Space shelter = new Space("Homeless Shelter","Welcome to the Homeless Shelter", allDilemma["shelter"]);
    Space sport = new Space("Local Associations", "Welcome to the Local Associations! We're all very excited to host you!" , allDilemma["sport"]);
    Space company = new Space("Private Company", "Welcome to the Private Company! Do you want to get down to business?", allDilemma["company"]);
    Space farm = new Space("Local Farm", "Welcome to the Local Farm! Fresh produce for sale!", allDilemma["farm"]);
    Space construction = new Space("Construction Site", "Welcome to the Construction Site! Watch out for heavy stuff!", allDilemma["construction"]);
    Space bank = new Space("Bank","Welcome to the bank!", allDilemma["bank"]);
    Space billionaire = new Space("Local Billionaire","The billionaire greets you!", allDilemma["billionaire"]);
    Space lawyer = new Space("Law Firm", "Welcome to the law firm! All inquiries are welcome!", allDilemma["lawyer"]);
    Space hospital = new Space("Hospital", "Welcome to the hospital! Hope you stay healthy!",allDilemma["hospital"]);
    Space nursing = new Space("Nursing Home","Welcome to the nursing home! The elderly enjoys their time here",allDilemma["nursing"]);
    Space school = new Space("School","Welcome to the school! Children greet you at the door!",allDilemma["school"]);

    //edge from square
    square.AddEdge("north", industrial);
    square.AddEdge("east", community);
    square.AddEdge("west", finance);
    square.AddEdge("south", service);

    //egde from industrial to room
    industrial.AddEdge("north", farm);
    industrial.AddEdge("east", construction);
    industrial.AddEdge("west", company);
    industrial.AddEdge("south", square);
    //edge from room to industrial
    company.AddEdge("back", industrial);
    farm.AddEdge("back", industrial);
    construction.AddEdge("back", industrial);

    //edge from community to room
    community.AddEdge("north", sport);
    community.AddEdge("east", shelter);
    community.AddEdge("south", festival);
    community.AddEdge("west", square);
    //edge from room to community
    sport.AddEdge("back", community);
    shelter.AddEdge("back", community);
    festival.AddEdge("back", community);

    //edge from service to room
    service.AddEdge("west", hospital);
    service.AddEdge("south", nursing);
    service.AddEdge("east", school);
    service.AddEdge("north", square);
    //edge from room to service
    school.AddEdge("back", service);
    nursing.AddEdge("back", service);
    hospital.AddEdge("back", service);

    //edge from finance to room
    finance.AddEdge("north", bank);
    finance.AddEdge("west", billionaire);
    finance.AddEdge("south", lawyer);
    finance.AddEdge("east", square);
    //edge from room to finance
    bank.AddEdge("back", finance);
    billionaire.AddEdge("back", finance);
    lawyer.AddEdge("back", finance);


    this.square = square;
  }

  public Space GetEntry()
  {
    return square;
  }
  
  public void SetPlayer(Player player)
  {
     this.player = player;
  }

  public void GameOver() {
      Console.WriteLine("The game is now over");
      Console.WriteLine($"The electionday has come and the people has now voted, and your final score based upon your choices is {player.GetScore()}");
      Console.WriteLine("This score has had an influence in the results of your election");
      Console.WriteLine("See how your election went here");
      Console.Write("\nPress any key to continue:");
      Console.ReadKey(intercept: true);
      Console.Clear();
      Console.WriteLine("The city gathers in the town hall");
      Console.WriteLine("The ligths flicker as the last votes are being counted");
      Console.Write("\nPress any key to continue:");
      Console.ReadKey(intercept: true);
      Console.Clear();
        if (player.GetScore().popularity >= 40) {
            Console.WriteLine("The crowd erupts in applause");
            Console.Write("\nPress any key to continue:");
            Console.ReadKey(intercept: true);
            Console.Clear();
            Console.WriteLine("You have been elected!");
            Console.Write("\nPress any key to continue:");
            Console.ReadKey(intercept: true);
            Console.Clear();
                if (player.GetScore().power < 45){
                    Console.WriteLine("But as the weeks pass, you realise you influence is fragile");
                    Console.WriteLine("Your proposals are ignored");
                    Console.WriteLine("Your voice fades in the council chambers");
                    Console.Write("\nPress any key to continue:");
                    Console.ReadKey(intercept: true);
                    Console.Clear();
                    Console.WriteLine("Then it hits you");
                    Console.Write("\nPress any key to continue:");
                    Console.ReadKey(intercept: true);
                    Console.Clear();
                    Console.WriteLine("You might have been elected");
                    Console.Write("\nPress any key to continue:");
                    Console.ReadKey(intercept: true);
                    Console.Clear();
                    Console.WriteLine("But your power is not great enough to have the influence you want");
                    }
                else if (player.GetScore().power >= 45 && player.GetScore().power <=70){
                    Console.WriteLine("Your first months are a mix of victories and defeats");
                    Console.WriteLine("Some of your ideas pass through the council");
                    Console.Write("\nPress any key to continue:");
                    Console.ReadKey(intercept: true);
                    Console.Clear();
                    Console.WriteLine("Others die quietly in committee rooms");
                    Console.Write("\nPress any key to continue:");
                    Console.ReadKey(intercept: true);
                    Console.Clear();
                    Console.WriteLine("You are respected");
                    Console.WriteLine("You are heard");
                    Console.Write("\nPress any key to continue:");
                    Console.ReadKey(intercept: true);
                    Console.Clear();
                    Console.WriteLine("But you are not unstoppable");
                    Console.WriteLine("Your power can only do so much");
                    }
                else if (player.GetScore().power > 70){
                Console.WriteLine("Your influence spreads through the city like wildfire");
                Console.WriteLine("Council members fall silent when you enter the room");
                Console.WriteLine("Every proposal you make passes without resistance");
                Console.Write("\nPress any key to continue:");
                Console.ReadKey(intercept: true);
                Console.Clear();
                Console.WriteLine("You reshape the city");
                Console.WriteLine("You define its future");
                Console.WriteLine("You are the most powerful leader in its history");
                }
        }
        else {
            Console.WriteLine("As the hall grows quiet, a man is going up to a microphone");
            Console.WriteLine("With a single sentence he calmly annunces the results");
            Console.Write("\nPress any key to continue:");
            Console.ReadKey(intercept: true);
            Console.Clear();
            Console.WriteLine("You were not elected");
            Console.Write("\nPress any key to continue:");
            Console.ReadKey(intercept: true);
            Console.Clear();
            Console.WriteLine("People leave the building slowly");
            Console.WriteLine("Some look at you with sympathy");
            Console.WriteLine("Others avoid your eyes");
            Console.Write("\nPress any key to continue:");
            Console.ReadKey(intercept: true);
            Console.Clear();
            Console.WriteLine("Your journey ends here");
        }
  }

  public void PrisonGameOver() {
      Console.WriteLine("You have reached 100% corruption");
      Console.WriteLine("The police has begun an investigation and you have been put into custody");
      Console.WriteLine("You will face a judge soon where your sentence will be decided");
  }
}