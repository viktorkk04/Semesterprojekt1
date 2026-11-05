public class Score {
    private int _corruption;
    private int _popularity;
    private int _power;

    public Score (int corruption, int popularity, int power) {
        this._corruption = corruption;
        this._popularity = popularity;
        this._power = power;
    }

    public int GetCorruption() { return this._corruption; }

    public int GetPopularity() { return this._popularity; }

    public int GetPower() { return this._power; }

    public void AddPower(int power) { 
        this._power += power;
        if (this._power > 100) {
            this._power = 100;
        }
    }

    public void AddPopularity(int popularity) { 
        this._popularity += popularity;
        if (this._popularity > 100 ) {
            this._popularity = 100;
        }

        if (this._popularity < 0) {
            this._popularity = 0;
        }
    }
    
    public void AddCorruption(int corruption) { 
        this._corruption += corruption;
        if (this._corruption > 100) {
            this._corruption = 100;
        }
    }

    public override string ToString() {
        return $"Corruption = {this.GetCorruption()}%, Popularity = {this.GetPopularity()}%, Power = {this.GetPower()}%";
    }
}