using FileSystem.Commands;

namespace Parser.Handlers;

// file copy [SourcePath] [DestinationPath]
public class CopyHandler : IHandler
{
    private const string CommandStart = "file copy";

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

        return new CopyCommand(args[2], args[3]);
    }
}