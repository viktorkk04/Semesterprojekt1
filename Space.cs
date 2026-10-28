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

  public Space(String name) : base(name)
  {
  }

  public void Welcome()
  {
    Console.Clear();
    Console.WriteLine("You are now at " + name);
    Console.WriteLine(message);
    HashSet<string> exits = edges.Keys.ToHashSet();
    Console.WriteLine("Current exits are:");
    foreach (String exit in exits)
    {
      Console.WriteLine(" - " + exit);
    }
  }

  public void Goodbye()
  {
  }

  public Dilemma GetDilemma()
  {
    return this.dilemma;
  }

  public override Space FollowEdge(string direction)
  {
    return (Space)(base.FollowEdge(direction));
  }
}
