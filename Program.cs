public class Program
{
    public static void Main(string[] args)
    {
        Answer[] answer = new Answer[]
        {
            new Answer(1, "3"),
            new Answer(2, "4"),
            new Answer(3, "2"),
            new Answer(4, "1"),
        };

        Answer rightans = answer[2];
        MCQ mcq = new MCQ("Math", "1+1=....", 2, answer, rightans);
        mcq.ShowQuestion();
    }
}
