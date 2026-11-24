public class Player {
    public string Name { get; private set; }
    public Score Score { get; private set; }

    public Player (string name, Score score) {
        this.Name = name;
        this.Score = score;
    }

    public string GetName() { return this.Name; }

    public Score GetScore() { return this.Score; }

    public void SetScore(Score score){ this.Score = score; }

    public void CalculateScore(Score score) {
        this.Score.AddPower(score.power);
        this.Score.AddCorruption(score.corruption);
        this.Score.AddPopularity(score.popularity);
    }

    public override string ToString() {
        return $"Player: {Name}, Score: {Score}";
    }
}