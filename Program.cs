
using System.Runtime.InteropServices;

public class Program
{
    public static void Main(string[] args)
    {
        // input for subject id
        Console.Write("Enter subject id: ");
        int subjectId;
        while(!int.TryParse(Console.ReadLine(), out subjectId))
        {
            Console.Write("Invalid input: ");
        }

        // input for subject name
        string? subjectName = "";
        while(string.IsNullOrWhiteSpace(subjectName))
        {
            Console.Write("Please enter subject name: ");
            subjectName = Console.ReadLine();
        }
        Subject subject = new Subject(subjectId, subjectName);
        
        // main program
        Console.WriteLine("================== Examination System ==================");
        Console.WriteLine("Choose Exam Type: ");
        Console.WriteLine("1. Final");
        Console.WriteLine("2. Practical");

        int examChoice;
        Console.Write("Enter your exam choice: ");
        while(!int.TryParse(Console.ReadLine(), out examChoice) || examChoice <= 0 || examChoice > 2)
        {
            Console.Write("Invalid choice Please choose from 1 and 2: ");
        }
        Console.WriteLine("========================================================");

        int timeOfExam;
        Console.Write("Enter exam time in minutes: ");
        int.TryParse(Console.ReadLine(), out timeOfExam);
        int numberofQuestions;
        Console.Write("Enter number of questions of exam: ");
        int.TryParse(Console.ReadLine(), out numberofQuestions);

        Question[] questions = new Question[numberofQuestions];

        for(int i = 0 ; i < numberofQuestions; i++)
        {
            Console.WriteLine($"======== Question {i + 1} ==========");
            if(examChoice == 1)
            {
                Console.WriteLine("Choose question type: ");
                Console.WriteLine("1. MCQ");
                Console.WriteLine("2. True or False");
                Console.WriteLine("Enter your choice: ");
                int questionChoice;
                while(!int.TryParse(Console.ReadLine(), out questionChoice) || questionChoice <= 0 || questionChoice > 2)
                {
                    Console.Write("Invalid choice Please choose from 1 and 2: ");
                }
                if(questionChoice == 1)
                {
                    questions[i] = createMCQquestion();
                }
                else questions[i] = createTrueOrFalsequestion();
            }
            else
            {
                createMCQquestion();
            }
        }

        Exam exam = createExam(examChoice,timeOfExam,questions);

        subject.CreateExam(exam);
        Console.WriteLine(subject);
        exam.ShowExam();
    }

    private static TrueOrFalse createTrueOrFalsequestion()
    {
        // header input
        string? header = "";
        while(string.IsNullOrWhiteSpace(header))
        {
            Console.Write("Please enter a valid question header: ");
            header = Console.ReadLine();
        }

        // body input
        string? body = "";
        while(string.IsNullOrWhiteSpace(body))
        {
            Console.Write("Please enter a valid question body: ");
            body = Console.ReadLine();
        }

        // Answers are true or false
        Answer True = new Answer(1, "True");
        Answer False = new Answer(2, "False");
        Answer[] answers = {True, False};

        // right answer input
        Console.WriteLine();
        Console.WriteLine("Enter Right Answer Id: ");
        int rightAnsID;
        while(!int.TryParse(Console.ReadLine(), out rightAnsID) && rightAnsID != 1 && rightAnsID != 2)
        {
            Console.Write("Invalid input as right answer id needs to be either 1 or 2: ");
        }

        // Mark input
        Console.WriteLine();
        Console.WriteLine("Enter Mark: ");
        int mark;
        while(!int.TryParse(Console.ReadLine(), out mark) || mark < 0)
        {
            Console.Write("Invalid input mark needs to be bigger than 0: ");
        }

        TrueOrFalse ToF = new TrueOrFalse(header,body,mark, answers, answers[rightAnsID - 1]);
        return ToF;
    }

    private static MCQ createMCQquestion()
    {
        // header input
        string? header = "";
        while(string.IsNullOrWhiteSpace(header))
        {
            Console.Write("Please enter a valid question header: ");
            header = Console.ReadLine();
        }

        // body input
        Console.WriteLine("Enter Question body: ");
        string? body = "";
        while(string.IsNullOrWhiteSpace(body))
        {
            Console.Write("Please enter a valid question body: ");
            body = Console.ReadLine();
        }

        // Answers input
        Answer[] answerList = new Answer[4]; // mcq in this program is of 4 choices
        for(int i = 0 ; i < 4 ; i++)
        {
            while(true)
            {
                Console.Write($"Enter Answer {i+1}: ");
                string? answerText = "";
                while(string.IsNullOrWhiteSpace(answerText))
                {
                    Console.Write("Please enter a valid question Answer Text: ");
                    answerText = Console.ReadLine();
                }   
                answerList[i] = new Answer(i+1, answerText);
                break;
            }
        }

        // right answer input
        Console.WriteLine();
        Console.WriteLine("Enter Right Answer Id: ");
        int rightAnsID;
        while(!int.TryParse(Console.ReadLine(), out rightAnsID) || rightAnsID > 4 || rightAnsID < 1)
        {
            Console.Write("Invalid input as right answer id needs to be within 1 and 4: ");
        }

        // Mark input
        Console.WriteLine();
        Console.WriteLine("Enter Mark: ");
        int mark;
        while(!int.TryParse(Console.ReadLine(), out mark) || mark < 0)
        {
            Console.Write("Invalid input mark needs to be bigger than 0: ");
        }

        MCQ mcq = new MCQ(header,body,mark, answerList, answerList[rightAnsID - 1]);
        return mcq;
    }

    private static Exam createExam(int examChoice, int TimeOfExam, Question[] questions)
    {
        if(examChoice == 1)
        {
            return new FinalExam(TimeOfExam, questions);
        }
        return new PracticalExam(TimeOfExam, questions);
    }
}
