public class FinalExam : Exam
{
    public FinalExam(int TimeOfExam, int NumberOfQuestions) : base(TimeOfExam, NumberOfQuestions)
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