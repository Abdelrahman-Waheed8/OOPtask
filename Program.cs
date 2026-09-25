public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("================== Examination System ==================");
        Console.WriteLine("Choose Exam Type: ");
        Console.WriteLine("1. Final");
        Console.WriteLine("2. Practical");
        Console.Write("Enter your exam choice: ");
        while(!int.TryParse(Console.ReadLine(), out int examChoice) || examChoice <= 0 || examChoice > 2)
        {
            Console.Write("Invalid choice Please choose from 1 and 2: ");
        }
        Console.WriteLine("========================================================");

        Console.Write("Enter exam time in minutes: ");
        int.TryParse(Console.ReadLine(), out int timeOfExam);
        Console.Write("Enter number of questions of exam");
        int.TryParse(Console.ReadLine(), out int numberofQuestions);

        while(true)
        {
            
        }
    }
}
