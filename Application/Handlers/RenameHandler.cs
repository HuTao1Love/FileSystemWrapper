using FileSystem.Commands;

namespace Parser.Handlers;

// file rename <path> <new name>
public class RenameHandler : IHandler
{
    private const string CommandStart = "file rename";

    public IHandler? Successor { get; set; }
    public ICommand? Handle(string command)
    {
        ArgumentException.ThrowIfNullOrEmpty(command);
        if (!command.StartsWith(CommandStart, StringComparison.InvariantCulture))
        {
            return Successor?.Handle(command);
        }

        var arguments = command.Split(' ').ToList();
        return new RenameCommand(arguments[2], arguments[3]);
    }
}