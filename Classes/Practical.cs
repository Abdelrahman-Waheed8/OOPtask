public class PracticalExam : Exam
{
    public PracticalExam(int TimeOfExam, Question[] questions) : base(TimeOfExam, questions)
    {
    }

    public override void ShowExam()
    {
        Console.WriteLine("======================================================");
        Console.WriteLine("                    Practical Exam                    ");
        Console.WriteLine($"{_NumberOfQuestions} question(s)         {_TimeOfExam} minutes");
        Console.WriteLine("======================================================");

        var (grade, totalmark) = StartExam();

        Console.WriteLine("=================== End of exam ===================");
        Console.WriteLine("Right answers: ");
        foreach( var question in _questions)
        {
            Console.WriteLine($"{question.Header} : {question.RightAnswer._AnswerId}. {question.RightAnswer._AnswerText}");
        }
        Console.WriteLine($"You scored {grade} / {totalmark}");
    }
}