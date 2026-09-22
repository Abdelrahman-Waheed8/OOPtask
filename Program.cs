public class Program
{
    public static void Main(string[] args)
    {
        Answer rightans = new Answer(1, "True");
        TrueOrFalse ToF = new TrueOrFalse("Math", "1+1=....", 2, rightans);
        ToF.ShowQuestion();
    }
}
