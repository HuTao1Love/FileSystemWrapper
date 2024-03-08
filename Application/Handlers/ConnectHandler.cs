using FileSystem.Commands;
using Parser.Exceptions;

namespace Parser.Handlers;

// connect [Address] -m mode
public class ConnectHandler : IHandler
{
    private const string CommandStart = "connect ";

    public IHandler? Successor { get; set; }

    public ICommand? Handle(string command)
    {
        ArgumentException.ThrowIfNullOrEmpty(command);

        if (!command.StartsWith(CommandStart, StringComparison.InvariantCulture)) return Successor?.Handle(command);

        IList<string> commandArgs = command[CommandStart.Length..].Split(' ');

        if (commandArgs is not [_, "-m", _])
        {
            throw new CommandArgumentException(command);
        }

        return new LocalConnectCommand(commandArgs[0], commandArgs[2]);
    }
}