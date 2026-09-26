public class FinalExam : Exam
{
    public FinalExam(int TimeOfExam, Question[] questions) : base(TimeOfExam, questions)
    {
    }

    public override void ShowExam()
    {
        UI.SeperatorWtext($"Final Exam");
        Console.WriteLine($"{UI.gray}{_NumberOfQuestions} question(s) |  {_TimeOfExam}{UI.reset} minutes\n");

        var (grade, totalmark) = StartExam();

        UI.SeperatorWtext("Final Exam Result");
        UI.DisplayPanel($"Score  {grade} / {totalmark}  |  {(double)grade/totalmark * 100:F1}%");
    }
}