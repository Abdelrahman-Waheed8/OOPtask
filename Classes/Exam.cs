public abstract class Exam
{
    protected int _TimeOfExam;
    protected int _NumberOfQuestions;
    public List<Question> _questions {get;set;}

    public Exam(int TimeOfExam, int NumberOfQuestions)
    {
        _TimeOfExam = TimeOfExam;
        _NumberOfQuestions = NumberOfQuestions;
    }

    public abstract void ShowExam();
    public override string ToString()
    {
        return $"{_TimeOfExam}: {_NumberOfQuestions}";
    }
}