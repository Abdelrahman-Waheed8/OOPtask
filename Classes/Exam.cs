public abstract class Exam
{
    protected int _TimeOfExam;
    protected int _NumberOfQuestions;
    public Question[]? _questions {get;set;}

    public Exam(int TimeOfExam, int NumberOfQuestions, Question[] questions)
    {
        _TimeOfExam = TimeOfExam;
        _NumberOfQuestions = NumberOfQuestions;
        _questions = questions;
    }

    public abstract void ShowExam();
    public override string ToString()
    {
        return $"{_TimeOfExam}: {_NumberOfQuestions}";
    }
}