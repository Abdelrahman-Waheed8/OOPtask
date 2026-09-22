public class TrueOrFalse : Question
{
    public TrueOrFalse(string header, string body, int mark, Answer rightanswer) : base(header, body, mark, 
    new[]
    {
        new Answer(1, "True"),
        new Answer(2, "False")
    },
    rightanswer)

    {
    }

}