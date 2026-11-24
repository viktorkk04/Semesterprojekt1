class Dilemma
{
    public List<string> dilemma { get; set; } = new List<string>();
    public Score score { get; set; }
    public string accepted { get; private set; }
    bool isAccepted {get; set ;} = false;
    
    public Dilemma(List<string> dilemma, string accepted, Score score)
    {
        this.dilemma = dilemma;
        this.score = score;
        this.accepted = accepted;
    }

    public List<string> GetDilemmaList(){ return this.dilemma; }

    public Score GetScore() { return this.score;}

    public void AcceptDilemma(){ isAccepted = true; }

    public bool GetIsAccepted() { return isAccepted; }
}