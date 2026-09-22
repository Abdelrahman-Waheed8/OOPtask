public abstract class Question : ICloneable
{
    protected string Header = "";
    protected string Body = "";
    protected int Mark;
    public Answer[]? Answers{get;set;}
    public Answer? RightAnswer{get;set;}

    public Question(string header, string body, int mark, Answer[] answers, Answer rightanswer)
    {
        Header = header;
        Body = body;
        Mark = mark;
        Answers = answers;
        RightAnswer = rightanswer;
    }
    public void ShowQuestion()
    {
        Console.WriteLine(ToString());
    }

    public override string ToString()
    {
        string answertxt = "";
        if(Answers != null)
        {
            foreach(var ans in Answers)
            {
                answertxt += $"{ans.AnswerText} \n";
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