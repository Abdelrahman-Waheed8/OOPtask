public abstract class Exam
{
    protected int _TimeOfExam;
    protected int _NumberOfQuestions;
    public List<Question> _questions {get;set;}

    public bool IsFinished = false;

    public Exam(int TimeOfExam, int NumberOfQuestions)
    {
        if(TimeOfExam > 0) _TimeOfExam = TimeOfExam;
        _NumberOfQuestions = NumberOfQuestions;
    }

    public void AddQuestion(Question question)
    {
        if(question == null) throw new ArgumentException("Question cannot be null");
        _questions.Add(question);
    }
    public abstract void ShowExam();
    public override string ToString()
    {
        return $"{_TimeOfExam}: {_NumberOfQuestions}";
    }
}