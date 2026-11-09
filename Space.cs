/* Space class for modeling spaces (rooms, caves, ...)
 */

class Space : Node
{
  private String message = "";
  private Dilemma dilemma;
  
  public Space(String name, String message, Dilemma dilemma) : base(name)
  {
    this.message = message;
    this.dilemma = dilemma;
  }

  public Space(String name, String message) : base(name)
  {
    this.message = message;
  }

  public void Welcome()
  {
    Console.Clear();
    Console.WriteLine("You are now at " + name);
    Console.WriteLine(message);
    Console.WriteLine();
    HashSet<string> exits = edges.Keys.ToHashSet();
    Console.WriteLine("Current exits are:");
    foreach (String exit in exits)
    {
      Console.WriteLine(" - " + exit);
    }
    Console.WriteLine("Write go before an exit to follow its path");
  }

  public void NewDayMessage(int daysLeft) {
      Console.WriteLine();
      Console.WriteLine($"It is now a new day. There are {daysLeft} days left until the election");
      Console.WriteLine("Go explore the city again!");
      Console.WriteLine();
  }

  public Dilemma GetDilemma() { return this.dilemma; }

  public override Space FollowEdge(string direction)
  {
    return (Space)(base.FollowEdge(direction));
  }
}
