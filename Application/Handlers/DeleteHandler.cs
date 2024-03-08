using FileSystem.Commands;

namespace Parser.Handlers;

// file delete [Path]
public class DeleteHandler : IHandler
{
    private const string CommandStart = "file delete";
    public IHandler? Successor { get; set; }

    public ICommand? Handle(string command)
    {
        ArgumentException.ThrowIfNullOrEmpty(command);
        return !command.StartsWith(CommandStart, StringComparison.InvariantCulture)
            ? Successor?.Handle(command)
            : new DeleteCommand(command[CommandStart.Length..].Trim());
    }
}