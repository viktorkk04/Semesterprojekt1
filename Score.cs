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

    public void AddPower(int power) {
        this._power += power;
    }

    public void AddPopularity(int popularity) {
        this._popularity += popularity;
    }
    
    public void AddCorruption(int corruption) {
        this._corruption += corruption;
    }
    public override string ToString() {
        return $"Power = {this.GetPower()}, Corruption = {this.GetCorruption()}, Popularity = {this.GetPopularity()}";
    }
}