using System.Security.Cryptography.X509Certificates;

public class Subject
{
    public int SubjectId {get; private set;}
    public string SubjectName {get; private set;}
    public Exam? SubjectExam {get; private set;}

    public Subject(int sID,string sName)
    {
        SubjectId = sID;
        SubjectName = sName;
    }

    public void CreateExam(Exam exam)
    {
        if(exam == null) throw new ArgumentNullException("Exam cannot be null");
        if(SubjectExam != null) throw new ArgumentException("Subject already has an exam");

        SubjectExam = exam;
    }

    public override string ToString()
    {
        return $"{SubjectId}: {SubjectName}";
    }

}