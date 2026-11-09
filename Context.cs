/* Context class to hold all context relevant to a session.
 */

class Context {
  Space current;
  bool done = false;
  int daysLeft;
  
  public Context (Space node, int days) {
    current = node;
    this.daysLeft = days;
  }

  public int GetDaysLeft() { return this.daysLeft; }
  
  public Space GetCurrent() { return current; }
  
  public void Transition (string direction) { // This is the transition function
    try {
        Space next = current.FollowEdge(direction);

        if (next==null) {
          Console.WriteLine("You are confused, and walk in a circle looking for '"+direction+"'. In the end you give up 😩");
        } try {
            if (next.GetDilemma().GetDilemmaList().Count() > 0) {
                current = next;
                current.Welcome();
                Console.WriteLine("\nThis room has a dilemma. Write \"interact\" to interact with the dilemma.");
            }
        } catch (NullReferenceException) {
          current = next;
          current.Welcome();
        }
    } catch (KeyNotFoundException) {
        Console.WriteLine("That direction does not exist");
    }
  }
  
  public void MakeDone () { 
      done = true; 
  }
  
  public bool IsDone () { return done; }

  public void NewDay (World world, Player player, Score score) {
      daysLeft--;
      if (player.GetScore().GetCorruption() == 100) {
          Console.Clear();
          world.PrisonGameOver();
          MakeDone();
      } else if (daysLeft == 0) {
          Console.Clear();
          world.GameOver();
          MakeDone();
      } else {
          Console.Clear();
          current = world.GetEntry();
          current.NewDayMessage(this.GetDaysLeft());
          Console.WriteLine("This is your updated status based upon the nature of the deal:");
          Console.WriteLine($"Corruption = {player.GetScore().GetCorruption()} ({score.GetCorruption()}), Popularity = {player.GetScore().GetPopularity()} ({score.GetPopularity()}), Power = {player.GetScore().GetPower()} ({score.GetPower()})");
          Console.Write("\nPress any key to continue:");
          Console.ReadKey(intercept: true);
          Console.Clear();
          current.Welcome();
      }
  }
}