public class Player {
    public string _name { get; private set; }
    public Score _score { get; private set; }

    public Player (string _name, Score _score) {
        this._name = _name;
        this._score = _score;
    }

    public string GetName() { return this._name; }

    public Score GetScore() { return this._score; }

    public void SetScore(Score score){ this._score = score; }

    public void CalculateScore(Score score) {
        this._score.AddPower(score.power);
        this._score.AddCorruption(score.corruption);
        this._score.AddPopularity(score.popularity);
    }

    // Method for displaying the player's score together with their _name
    public void DisplayScore()
    {
        Console.WriteLine(
            $"{_name,-20}" +
            $"{_score.power,10}" +
            $"{_score.corruption,15}" +
            $"{_score.popularity,15}"
        );
    }
}