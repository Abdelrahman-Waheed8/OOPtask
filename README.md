# OOPtask

A simple console-based examination system written in C#. A subject can hold one exam, which is built from questions, answered by the user, and graded automatically.

## How to run

```bash
dotnet run
```

## How it works

1. Enter a subject id and name.
2. Choose the exam type: **Final** or **Practical**.
3. Enter the exam time (minutes) and number of questions.
4. For each question, enter its header, body, answers, right answer id, and mark.
   - Final exams support **MCQ** and **True/False** questions.
   - Practical exams use **MCQ** questions only.
5. Take the exam by entering the answer id for each question. Your score is shown at the end. Practical exams also show the right answers after finishing.

## Project structure

- `Program.cs` — entry point, handles all console input and exam creation
- `Classes/Exam.cs` — abstract base class and contains the shared exam-taking logic (`StartExam`)
- `Classes/Final.cs` — final exam type
- `Classes/Practical.cs` — practical exam type
- `Classes/Question.cs` — abstract base class for questions
- `Classes/MCQQuestion.cs` — multiple-choice question
- `Classes/TrueOrFalseQuestion.cs` — true/false question
- `Classes/Answer.cs` — an answer (id + text)
- `Classes/Subject.cs` — a subject that owns one exam
