using FileSystem.Commands;

namespace Parser.Handlers;

// disconnect
public class DisconnectHandler : IHandler
{
    private const string CommandStart = "disconnect";

    public IHandler? Successor { get; set; }

    public ICommand? Handle(string command)
    {
        ArgumentException.ThrowIfNullOrEmpty(command);

        return !command.StartsWith(CommandStart, StringComparison.InvariantCulture)
            ? Successor?.Handle(command)
            : new DisconnectCommand();
    }
}