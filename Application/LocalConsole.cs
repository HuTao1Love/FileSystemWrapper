using FileSystem.Abstractions;

namespace Parser;

public class LocalConsole : IInput, IOutput
{
    public string? ReadLine()
    {
        return Console.ReadLine();
    }

    public void WriteLine(string content)
    {
        Console.WriteLine(content);
    }
}