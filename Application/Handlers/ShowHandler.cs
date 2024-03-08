using FileSystem.Abstractions;
using FileSystem.Commands;
using Parser.Exceptions;

namespace Parser.Handlers;

// file show [Path] {-m Mode}
public class ShowHandler(IOutput output) : IHandler
{
    private const string CommandStart = "file show";

    public IHandler? Successor { get; set; }

    public ICommand? Handle(string command)
    {
        ArgumentException.ThrowIfNullOrEmpty(command);

        if (!command.StartsWith(CommandStart, StringComparison.InvariantCulture)) return Successor?.Handle(command);

        var arguments = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
        if (arguments.Count < 3) throw new CommandArgumentException(command);

        string path = arguments[2];
        string mode = arguments.Count > 3 ? arguments[4] : "console";

        if (mode != "console")
        {
            throw new CommandArgumentException(command);
        }

        return new ShowCommand(path, output);
    }
}