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
                current.Goodbye();
                current = next;
                current.Welcome();
                Console.WriteLine("This room has a dilemma. Write \"interact\" to interact with the dilemma.");
            }
        } catch (NullReferenceException) {
          current.Goodbye();
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
          current = world.GetEntry();
          current.Welcome();
          current.NewDay(this.GetDaysLeft());
          Console.WriteLine($"Corruption = {player.GetScore().GetCorruption()} ({score.GetCorruption()}), Popularity = {player.GetScore().GetPopularity()} ({score.GetPopularity()}), Power = {player.GetScore().GetPopularity()} ({score.GetPopularity()})");
      }
  }
}
