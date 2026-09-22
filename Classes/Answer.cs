public class Answer : ICloneable , IComparable
{
    private int AnswerId;
    private string AnswerText = "";

    public Answer(int aID,string aTxt)
    {
        AnswerId = aID;
        AnswerText = aTxt;
    }

    public object Clone()
    {
        throw new NotImplementedException();
    }

    public int CompareTo(object? obj)
    {
        throw new NotImplementedException();
    }
}