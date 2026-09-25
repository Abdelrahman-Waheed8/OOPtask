public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // input for subject id
        Console.Write("Enter subject id: ");
        int subjectId;
        while(!int.TryParse(ReadInput(), out subjectId))
        {
            Console.Write("Invalid input: ");
        }

        // input for subject name
        string? subjectName = "";
        while(string.IsNullOrWhiteSpace(subjectName))
        {
            Console.Write("Please enter subject name: ");
            subjectName = ReadInput();
        }
        Subject subject = new Subject(subjectId, subjectName);
        
        // main program
        Console.WriteLine("================== Examination System ==================");
        Console.WriteLine("Choose Exam Type: ");
        Console.WriteLine("1. Final");
        Console.WriteLine("2. Practical");

        int examChoice;
        Console.Write("Enter your exam choice: ");
        while(!int.TryParse(ReadInput(), out examChoice) || examChoice <= 0 || examChoice > 2)
        {
            Console.Write("Invalid choice Please choose from 1 and 2: ");
        }
        Console.WriteLine("========================================================");

        int timeOfExam;
        Console.Write("Enter exam time in minutes: ");
        while(!int.TryParse(ReadInput(), out timeOfExam) || timeOfExam <= 0)
        {
            Console.Write("Invalid time. Enter a positive number of minutes: ");
        }
        int numberofQuestions;
        Console.Write("Enter number of questions of exam: ");
        while(!int.TryParse(ReadInput(), out numberofQuestions) || numberofQuestions <= 0)
        {
            Console.Write("Invalid number. Enter at least one question: ");
        }

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
                while(!int.TryParse(ReadInput(), out questionChoice) || questionChoice <= 0 || questionChoice > 2)
                {
                    Console.Write("Invalid choice Please choose from 1 and 2: ");
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
        Console.WriteLine(subject);
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
            Console.Write("Please enter a valid question header: ");
            header = ReadInput();
        }

        // body input
        string? body = "";
        while(string.IsNullOrWhiteSpace(body))
        {
            Console.Write("Please enter a valid question body: ");
            body = ReadInput();
        }

        // Answers are true or false
        Answer True = new Answer(1, "True");
        Answer False = new Answer(2, "False");
        Answer[] answers = {True, False};

        // right answer input
        Console.WriteLine();
        Console.WriteLine("Enter Right Answer Id: ");
        Console.WriteLine("1. True \n2. False");
        int rightAnsID;
        while(!int.TryParse(ReadInput(), out rightAnsID) || rightAnsID < 1 || rightAnsID > 2)
        {
            Console.Write("Invalid input as right answer id needs to be either 1 or 2: ");
        }

        // Mark input
        Console.WriteLine();
        Console.WriteLine("Enter Mark: ");
        int mark;
        while(!int.TryParse(ReadInput(), out mark) || mark <= 0)
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
            header = ReadInput();
        }

        // body input
        string? body = "";
        while(string.IsNullOrWhiteSpace(body))
        {
            Console.Write("Please enter a valid question body: ");
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
                    Console.Write($"Enter Answer {i+1}: ");
                    answerText = ReadInput();
                }   
                answerList[i] = new Answer(i+1, answerText);
                break;
            }
        }

        // right answer input
        Console.WriteLine();
        Console.WriteLine("Enter Right Answer Id: ");
        int rightAnsID;
        while(!int.TryParse(ReadInput(), out rightAnsID) || rightAnsID > 4 || rightAnsID < 1)
        {
            Console.Write("Invalid input as right answer id needs to be within 1 and 4: ");
        }

        // Mark input
        Console.WriteLine();
        Console.WriteLine("Enter Mark: ");
        int mark;
        while(!int.TryParse(ReadInput(), out mark) || mark <= 0)
        {
            Console.Write("Invalid input mark needs to be bigger than 0: ");
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
