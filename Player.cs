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
}