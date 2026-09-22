public abstract class Question : ICloneable
{
    protected string Header = "";
    protected string Body = "";
    protected int Mark;

    public void ShowQuestion()
    {
        
    }

    public override string ToString()
    {
        return $"{Header}\n{Body}\n{Mark}\n";
    }
    public object Clone()
    {
        throw new NotImplementedException();
    }
}