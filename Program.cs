using static UI;

public class Program
{
    public static void Main(string[] args)
    {
        DisplayPanel(" EXAMINATION SYSTEM ");
        Console.WriteLine($"{gray}Create an exam, Let a student have it in same console{reset}\n");
        try
        {
            // input for subject id
        Console.Write($"  {cyan}> Enter subject id{reset}: ");
        int subjectId;
        while(!int.TryParse(ReadInput(), out subjectId))
        {
            Console.Write($"  {red}> Invalid input{reset}: ");
        }

        // input for subject name
        string? subjectName = "";
        while(string.IsNullOrWhiteSpace(subjectName))
        {
            Console.Write($"  {cyan}> Please enter subject name{reset}: ");
            subjectName = ReadInput();
        }
        Subject subject = new Subject(subjectId, subjectName);
        
        // main program
        SeperatorWtext("Choose Exam Type");
        Console.WriteLine($"   1. Final\t (MCQ, True or False)");
        Console.WriteLine($"   2. Practical\t (MCQ only)\n");

        int examChoice;
        Console.Write($"  {cyan}> Enter your exam choice{reset}: ");
        while(!int.TryParse(ReadInput(), out examChoice) || examChoice <= 0 || examChoice > 2)
        {
            Console.Write($"  {red}> Invalid choice Please choose from 1 and 2{reset}: ");
        }

        int timeOfExam;
        Console.Write($"  {cyan}> Enter exam time in minutes{reset}: ");
        while(!int.TryParse(ReadInput(), out timeOfExam) || timeOfExam <= 0)
        {
            Console.Write($"  {red}> Invalid time. Enter a positive number of minutes{reset}: ");
        }
        int numberofQuestions;
        Console.Write($"  {cyan}> Enter number of questions of exam{reset}: ");
        while(!int.TryParse(ReadInput(), out numberofQuestions) || numberofQuestions <= 0)
        {
            Console.Write($"  {red}> Invalid number. Enter at least one question{reset}: ");
        }

        Question[] questions = new Question[numberofQuestions];

        for(int i = 0 ; i < numberofQuestions; i++)
        {
            SeperatorWtext($"Create question {i+1} of {numberofQuestions}");
            if(examChoice == 1)
            {
                Console.WriteLine("  1. MCQ");
                Console.WriteLine("  2. True or False\n");
                Console.Write($"  {cyan}> Enter your choice{reset}: ");
                int questionChoice;
                while(!int.TryParse(ReadInput(), out questionChoice) || questionChoice <= 0 || questionChoice > 2)
                {
                    Console.Write($"  {red}> Invalid choice Please choose from 1 and 2{reset}: ");
                }
                if(questionChoice == 1)
                {
                    questions[i] = createMCQquestion();
                }
                else if(questionChoice == 2)
                {
                    questions[i] = createTrueOrFalsequestion();
                }
            }
            else
            {
                questions[i] = createMCQquestion();
            }
        }

        Exam exam = createExam(examChoice,timeOfExam,questions);

        Console.Clear();

        subject.CreateExam(exam);
        exam.ShowExam();
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    
    private static TrueOrFalse createTrueOrFalsequestion()
    {
        // header input
        string? header = "";
        while(string.IsNullOrWhiteSpace(header))
        {
            Console.Write($"  {cyan}> Please enter a valid question header{reset}: ");
            header = ReadInput();
        }

        // body input
        string? body = "";
        while(string.IsNullOrWhiteSpace(body))
        {
            Console.Write($"  {cyan}> Please enter a valid question body{reset}: ");
            body = ReadInput();
        }

        // Answers are true or false
        Answer True = new Answer(1, "True");
        Answer False = new Answer(2, "False");
        Answer[] answers = {True, False};

        // right answer input
        Console.WriteLine("  1. True \n  2. False");
        Console.Write($"  {cyan}> Enter Right Answer Id{reset}: ");
        int rightAnsID;
        while(!int.TryParse(ReadInput(), out rightAnsID) || rightAnsID < 1 || rightAnsID > 2)
        {
            Console.Write($"  {red}> Invalid input as right answer id needs to be either 1 or 2{reset}: ");
        }

        // Mark input
        Console.Write($"  {cyan}> Enter Mark{reset}: ");
        int mark;
        while(!int.TryParse(ReadInput(), out mark) || mark <= 0)
        {
            Console.Write($"  {red}> Invalid input mark needs to be bigger than 0{reset}: ");
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
            Console.Write($"  {cyan}> Please enter a valid question header{reset}: ");
            header = ReadInput();
        }

        // body input
        string? body = "";
        while(string.IsNullOrWhiteSpace(body))
        {
            Console.Write($"  {cyan}> Please enter a valid question body{reset}: ");
            body = ReadInput();
        }

        // Answers input
        Answer[] answerList = new Answer[4]; // mcq in this program is of 4 choices
        for(int i = 0 ; i < 4 ; i++)
        {
            while(true)
            {
                string? answerText = "";
                while(string.IsNullOrWhiteSpace(answerText))
                {
                    Console.Write($"  {cyan}> Enter Answer {i+1}{reset}: ");
                    answerText = ReadInput();
                }   
                answerList[i] = new Answer(i+1, answerText);
                break;
            }
        }

        // right answer input
        Console.Write($"  {cyan}> Enter Right Answer Id{reset}: ");
        int rightAnsID;
        while(!int.TryParse(ReadInput(), out rightAnsID) || rightAnsID > 4 || rightAnsID < 1)
        {
            Console.Write($"  {red}> Invalid input as right answer id needs to be within 1 and 4{reset}: ");
        }

        // Mark input
        Console.Write($"  {cyan}> Enter Mark{reset}: ");
        int mark;
        while(!int.TryParse(ReadInput(), out mark) || mark <= 0)
        {
            Console.Write($"  {red}> Invalid input mark needs to be a whole number ranged from 1 and 100{reset}: ");
        }

        MCQ mcq = new MCQ(header,body,mark, answerList, answerList[rightAnsID - 1]);
        return mcq;
    }

    private static string ReadInput()
    {
        string? input = Console.ReadLine();
        if(input == null)
        {
            throw new InvalidOperationException("Input ended before the exam was completed.");
        }
        return input;
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
