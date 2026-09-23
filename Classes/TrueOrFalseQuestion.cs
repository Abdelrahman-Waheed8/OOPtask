public class TrueOrFalse : Question
{
    public TrueOrFalse(string header, string body, int mark, bool rightanswer) : base(header, body, mark)
    {
        AddAnswer(new Answer(1, "True"), rightanswer);
        AddAnswer(new Answer(2, "False"), !rightanswer);
    }
}