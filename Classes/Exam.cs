public abstract class Exam
{
    protected int _TimeOfExam;
    protected int _NumberOfQuestions;
    public Question[] _questions {get;set;}
    public Exam(int TimeOfExam, Question[] questions)
    {
        if(TimeOfExam <= 0) throw new ArgumentOutOfRangeException("Time of exam cannot be less than or equal to 0");
        if(questions.Length == 0) throw new ArgumentException("Exam must have at least 1 question");

        _TimeOfExam = TimeOfExam;
        _questions = questions;
        _NumberOfQuestions = questions.Length;
    }

    public (int, int) StartExam()
    {
        int totalmark = 0;
        int grade = 0;

        foreach(var question in _questions)
        {
            question.ShowQuestion();
            totalmark += question.Mark;

            int minimum = 1;
            int max;
            if(question is TrueOrFalse)
            {
                max = 2;
            }else 
            {
                max = 4;
            }

            int choice;
            while(true)
            {
                Console.Write("Enter your answer id: ");
                string? answerInput = Console.ReadLine();
                if(answerInput is null)
                {
                    throw new InvalidOperationException("Input ended before the exam was completed.");
                }

                if(int.TryParse(answerInput, out choice) && choice >= minimum && choice <= max)
                {
                    break;
                }

                Console.WriteLine($"Cannot choose an answer with id less than {minimum} and greater than {max}");
            }

            Answer selectedAns = question.Answers[choice - 1];
            if(selectedAns._AnswerId == question.RightAnswer._AnswerId)
            {
                grade += question.Mark;
            }
        }
        return (grade, totalmark);
    }
    public abstract void ShowExam();
    public override string ToString()
    {
        return $"{_TimeOfExam}: {_NumberOfQuestions}";
    }
}