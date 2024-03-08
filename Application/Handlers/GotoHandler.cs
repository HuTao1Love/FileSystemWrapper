using FileSystem.Commands;

namespace Parser.Handlers;

// tree goto Path
public class GotoHandler : IHandler
{
    private const string CommandStart = "tree goto ";

    public IHandler? Successor { get; set; }
    public ICommand? Handle(string command)
    {
        ArgumentException.ThrowIfNullOrEmpty(command);

        return !command.StartsWith(CommandStart, StringComparison.InvariantCulture)
            ? Successor?.Handle(command)
            : new GotoCommand(command.Split(CommandStart).Last());
    }
}