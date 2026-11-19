public class Score {
    public int corruption { get; private set; }
    public int popularity { get; private set; }
    public int power { get; private set; }

    public Score (int corruption, int popularity, int power) {
        this.corruption = corruption;
        this.popularity = popularity;
        this.power = power;
    }

    public void AddPower(int power) { 
        this.power += power;
        if (this.power > 100) {
            this.power = 100;
        }
    }

    public void AddPopularity(int popularity) { 
        this.popularity += popularity;
        if (this.popularity > 100 ) {
            this.popularity = 100;
        }

        if (this.popularity < 0) {
            this.popularity = 0;
        }
    }
    
    public void AddCorruption(int corruption) { 
        this.corruption += corruption;
        if (this.corruption > 100) {
            this.corruption = 100;
        }
    }

    public override string ToString() {
        return $"Corruption = {this.corruption}%, Popularity = {this.popularity}%, Power = {this.power}%";
    }
}