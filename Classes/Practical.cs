public class PracticalExam : Exam
{
    public PracticalExam(int TimeOfExam, Question[] questions) : base(TimeOfExam, questions)
    {
    }

    public override void ShowExam()
    {
        UI.SeperatorWtext($"Practical Exam");
        Console.WriteLine($"{UI.gray}{_NumberOfQuestions} question(s) |  {_TimeOfExam}{UI.reset} minutes\n");

        var (grade, totalmark) = StartExam();

        UI.SeperatorWtext("Practical Exam Result");
        Console.WriteLine($"  {UI.gray}Right answers{UI.gray}: ");
        foreach( var question in _questions)
        {
            Console.WriteLine($"  {question.Header}: {question.RightAnswer._AnswerId}) {question.RightAnswer._AnswerText}");
        }
        UI.DisplayPanel($"Score  {grade} / {totalmark}  |  {(double)grade / totalmark * 100:F1}%");
    }
}