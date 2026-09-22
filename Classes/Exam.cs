public abstract class Exam
{
    protected int TimeOfExam;
    protected int NumberOfQuestions;
    public Question[]? questions {get;set;}

    public abstract void ShowExam();
    public override string ToString()
    {
        return $"{TimeOfExam}: {NumberOfQuestions}";
    }
}