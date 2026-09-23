public class MCQ : Question
{
    public MCQ(string header, string body, int mark, List<Answer> answers, int rightAnswerId) : base(header, body, mark)
    {
        if(answers.Count()<2) throw new ArgumentException("MCQ must be more than 2");
        foreach(var ans in answers)
        {
            AddAnswer(ans, ans._AnswerId == rightAnswerId);
        }
        foreach(var answer in Answers)
        {
            if(answer._AnswerId == rightAnswerId) RightAnswer = answer;
            if(RightAnswer == null) throw new ArgumentException("Answer must be within the answer list");
        }
    }
}