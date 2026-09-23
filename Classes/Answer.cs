public class Answer : ICloneable , IComparable<Answer>
{
    public int _AnswerId {get;}
    public string _AnswerText {get; set;}

    public Answer(int AnswerId,string AnswerText)
    {
        _AnswerId = AnswerId;
        _AnswerText = AnswerText;
    }

    public override string ToString()
    {
        return $"{_AnswerId}. {_AnswerText}";
    }

    public object Clone()
    {
        return new Answer(_AnswerId, _AnswerText);
    }

    public int CompareTo(Answer? obj)
    {
        if(obj == null) return 1;
        return _AnswerId.CompareTo(obj._AnswerId);
    }
}