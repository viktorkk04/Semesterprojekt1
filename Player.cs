public class Player {
    private string _name;
    private Score _score;

    public Player (string name, Score score) {
        this._name = name;
        this._score = score;
    }

    public string GetName() {
        return this._name;
    }

    public Score GetScore() {
        return this._score;
    }
    public void SetScore(Score score){
        this._score = score;
    }

    public void CalculateScore(Score score) {
        this._score.AddPower(score.GetPower());
        this._score.AddCorruption(score.GetCorruption());
        this._score.AddPopularity(score.GetPopularity());
    }

}