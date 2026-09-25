public class FinalExam : Exam
{
    public FinalExam(int TimeOfExam, Question[] questions) : base(TimeOfExam, questions)
    {
    }

    public override void ShowExam()
    {
        Console.WriteLine("======================================================");
        Console.WriteLine("                    Final Exam                        ");
        Console.WriteLine($"{_NumberOfQuestions} question(s)         {_TimeOfExam} minutes");
        Console.WriteLine("======================================================");

        var (grade, totalmark) = StartExam();

        Console.WriteLine("=================== End of exam ===================");
        Console.WriteLine($"You scored {grade} / {totalmark}");
    }
}