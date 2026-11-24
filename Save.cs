public class Save {
    public string saveName { get; set; }
    public Player player { get; set; } 
    public int daysLeft {get; set; }
    public List<string> acceptedDilemmas {get ; set;}

    public Save (string saveName, Player player, int daysLeft, List<string> acceptedDilemmas) {
        this.saveName = saveName;
        this.player = player;
        this.daysLeft = daysLeft;
        this.acceptedDilemmas = new List<string>(acceptedDilemmas);
    }

    public override string ToString() {
        return $"Save: {saveName}, Player: {player.Name}, Score: {player.Score}, Days Left: {daysLeft}";
    }
}