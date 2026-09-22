public class Answer : ICloneable , IComparable
{
    private int AnswerId;
    private string AnswerText = "";

    public object Clone()
    {
        throw new NotImplementedException();
    }

    public int CompareTo(object? obj)
    {
        throw new NotImplementedException();
    }
}