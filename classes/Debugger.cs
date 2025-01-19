


public class Debugger
{
    public static string currentLine = "No line specified";

    public static void Log(Exception e)
    {
        Console.WriteLine("An error occurred while parsing the beatmap, at line:\n" + currentLine);
        Console.WriteLine("Exception: " + e.Message);
        Console.WriteLine("Stack trace: " + e.StackTrace);
    }
}