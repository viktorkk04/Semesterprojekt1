class Dilemma
{
    private string dilemma = "";
    private Score score;
    
    public Dilemma(String dilemma, Score score)
    {
        this.dilemma = dilemma;
        this.score = score;
    }

    public string GetDilemmaString(){
        return this.dilemma;
    }
    public Score GetScore() {
        return this.score;
    }
}