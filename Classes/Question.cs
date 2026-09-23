public abstract class Question : ICloneable
{
    protected string Header = "";
    protected string Body = "";
    protected int Mark;
    public List<Answer> Answers{get;set;}
    public Answer? RightAnswer{get;set;}

    public Question(string header, string body, int mark)
    {
        Header = header;
        Body = body;
        if(mark > 0) Mark = mark;
    }
    public void ShowQuestion()
    {
        Console.WriteLine(ToString());
    }

    public void AddAnswer(Answer answer, bool rightanswer = false)
    {
        if(answer == null) return;
        Answers.Add(answer);
        if(rightanswer) RightAnswer = answer;
    }

    public override string ToString()
    {
        string answertxt = "";
        if(Answers != null)
        {
            foreach(var ans in Answers)
            {
                answertxt += $"{ans._AnswerId}- {ans._AnswerText}\n";
            }
        }

        return   "========================================\n"+
                $"{Header} \t ({Mark} Marks)\n"+
                $"========================================\n"+
                $"{Body}\n"+
                $"----------------------------------------\n"+
                $"{answertxt}";
    }
    public object Clone()
    {
        throw new NotImplementedException();
    }
}