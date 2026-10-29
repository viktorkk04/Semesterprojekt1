class Dilemma
{
    private List<string> dilemma = new List<string>();
    private Score score;
    bool isAccepted = false;
    
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

    public void AcceptDilemma(){
        isAccepted = true;
    }

    public bool GetIsAccepted() {
        return isAccepted;
    }
}