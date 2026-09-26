public class UI
{
    // ANSI code for colors after searching for better way than Console.ForegroundColor
    public const string cyan = "\u001b[96m";
    public const string gray = "\u001b[90m";
    public const string red = "\u001b[31m";
    public const string yellow = "\u001b[33m";
    public const string reset = "\u001b[0m";// important so styling is not applied for the rest of the console
    public static void SeperatorWtext(string text)
    {
        int firstpartwidth = 5;
        int secondpartwidth = 45;
        string seperator = "┌" + new string('─', firstpartwidth) + text + new string('─', secondpartwidth) + "┐";
        Console.WriteLine($"{cyan}{seperator}{reset}");
    }

    public static void DisplayPanel(string text)
    {
        int width = 50;
        // creating borders style with special characters
        string topLine = "╔" + new string('═', width) + "╗";
        string bottomLine = "╚" + new string('═', width) + "╝";
        Console.WriteLine($"{cyan}{topLine}");
        Console.WriteLine($"║\t\t{text}\t\t   ║");
        Console.WriteLine($"{bottomLine}{reset}");
    }
}