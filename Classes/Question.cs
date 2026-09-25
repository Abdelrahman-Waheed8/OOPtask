public abstract class Question
{
    public string Header {get; private set;}
    public string Body {get; private set;}
    public int Mark {get; private set;}
    public Answer[] Answers {get; private set;}
    public Answer RightAnswer{get; private set;}

    public Question(string header, string body, int mark, Answer[] answerlist, Answer rightanswer)
    {
        if(mark <= 0) throw new ArgumentException("Mark must be greater than 0");
        if(answerlist.Length < 2) throw new ArgumentException("Answer list needs to be at least of 2 answers");
        if(!answerlist.Contains(rightanswer)) throw new ArgumentException("The right answer needs to be present in the answer list");

        Header = header;
        Body = body;
        Mark = mark;
        Answers = answerlist;
        RightAnswer = rightanswer;
    }
    public abstract void ShowQuestion();
    public override string ToString()
    {
        return $"{Header}: {Body}: {Mark} (marks)";
    }
}