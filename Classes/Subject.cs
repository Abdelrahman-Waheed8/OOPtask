using System.Security.Cryptography.X509Certificates;

public class Subject
{
    private int SubjectId;
    private string SubjectName = "";
    public Exam? SubjectExam;

    public Subject(int sID,string sName,Exam sExam)
    {
        SubjectId = sID;
        SubjectName = sName;
        SubjectExam = sExam;
    }

    public void CreateExam()
    {
        
    }

    public override string ToString()
    {
        return $"{SubjectId}: {SubjectName}";
    }

}