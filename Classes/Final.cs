public class FinalExam : Exam
{
    public FinalExam(int TimeOfExam, int NumberOfQuestions, Question[] questions) : base(TimeOfExam, NumberOfQuestions, questions)
    {
    }

    public override void ShowExam()
    {
    }

    public int CalculateGrade()
    {
        return 1;
    }
}