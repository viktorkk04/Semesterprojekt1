public class Score {
    private int _corruption;
    private int _popularity;
    private int _power;

    public Score (int corruption, int popularity, int power) {
        this._corruption = corruption;
        this._popularity = popularity;
        this._power = power;
    }

    public int GetCorruption() {
        return this._corruption;
    }

    public int GetPopularity() {
        return this._popularity;
    }

    public int GetPower() {
        return this._power;
    }

    public void CalculateScore(int power, int corruption, int popularity) {
        this._corruption += corruption;
        this._popularity += popularity;
        this._power += power;
    }

    public override string ToString() {
        return $"Power = {this.GetPower()}, Corruption = {this.GetCorruption()}, Popularity = {this.GetPopularity()}";
    }
}