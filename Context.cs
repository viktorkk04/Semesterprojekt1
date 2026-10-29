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

  public int GetDaysLeft() {
      return this.daysLeft;
  }
  
  public Space GetCurrent() {
    return current;
  }
  
  public void Transition (string direction) { // This is the transition function
    try {
        Space next = current.FollowEdge(direction);

        if (next==null) {
          Console.WriteLine("You are confused, and walk in a circle looking for '"+direction+"'. In the end you give up 😩");
        } else {
          current.Goodbye();
          current = next;
          current.Welcome();
        }
    } catch (KeyNotFoundException e) {
        Console.WriteLine("That direction does not exist");
    }
      

  }
  
  public void MakeDone () {
    done = true;
  }
  
  public bool IsDone () {
    return done;
  }

  public void NewDay (World world) {
      daysLeft--;
      current = world.GetEntry();
      current.Welcome();
      current.NewDay(this.GetDaysLeft());
  }
}
