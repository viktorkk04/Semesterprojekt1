class Dilemma
{
    private List<string> dilemma = new List<string>();
    private Score score;
    
    public Dilemma(List<string> dilemma, Score score)
    {
        this.dilemma = dilemma;
        this.score = score;
    }

    public List<string> GetDilemmaList(){
        return this.dilemma;
    }
    public Score GetScore() {
        return this.score;
    }
}