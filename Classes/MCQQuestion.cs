public class MCQ : Question
{
    public MCQ(string header, string body, int mark, Answer[] answerlist, Answer rightanswer) : base(header, body, mark, answerlist, rightanswer)
    {
    }

    public override void ShowQuestion()
    {
        Console.WriteLine($"{UI.yellow}{Header}{UI.reset}  {UI.gray}[MCQ | {Mark} mark(s)]{UI.reset}");
        Console.WriteLine(Body);

        foreach (var ans in Answers)
        {
            Console.WriteLine($"  {UI.cyan}>{UI.reset} {ans._AnswerId}) {ans._AnswerText}");
        }
    }
}