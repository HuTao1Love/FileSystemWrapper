namespace Parser.Exceptions;

public class CommandArgumentException : ArgumentException
{
    public CommandArgumentException(string message)
        : base($"Invalid command argument: {message}")
    {
    }

    public CommandArgumentException()
    {
    }

    public CommandArgumentException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}