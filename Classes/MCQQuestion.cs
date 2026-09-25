public class MCQ : Question
{
    public MCQ(string header, string body, int mark, Answer[] answerlist, Answer rightanswer) : base(header, body, mark, answerlist, rightanswer)
    {
    }

    public override void ShowQuestion()
    {
        Console.WriteLine("------------------------------------------");
        Console.WriteLine($"               MCQ Question       {Mark} mark(s)  ");
        Console.WriteLine("------------------------------------------");
        Console.WriteLine($"{Header}\n{Body}");

        foreach(var ans in Answers)
        {
            Console.WriteLine($"{ans._AnswerId}. {ans._AnswerText}");
        }
    }
}