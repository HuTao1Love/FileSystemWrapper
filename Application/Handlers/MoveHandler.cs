using FileSystem.Commands;

namespace Parser.Handlers;

// file move [SourcePath] [DestinationPath]
public class MoveHandler : IHandler
{
    private const string CommandStart = "file move";

    public IHandler? Successor { get; set; }

    public ICommand? Handle(string command)
    {
        ArgumentNullException.ThrowIfNull(command);
        if (!command.StartsWith(CommandStart, StringComparison.InvariantCulture))
        {
            return Successor?.Handle(command);
        }

        var args = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
        if (args.Count != 4)
        {
            throw new ArgumentException("Invalid command format");
        }

        return new MoveCommand(args[2], args[3]);
    }
}