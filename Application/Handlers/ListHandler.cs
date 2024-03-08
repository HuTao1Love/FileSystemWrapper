using System.Globalization;
using FileSystem.Abstractions;
using FileSystem.Commands;

namespace Parser.Handlers;

// tree list {-d depth}
public class ListHandler(IOutput output, IElementVisitor visitor, string indent) : IHandler
{
    private const string CommandStart = "tree list";

    public IHandler? Successor { get; set; }

    public ICommand? Handle(string command)
    {
        ArgumentException.ThrowIfNullOrEmpty(command);

        if (!command.StartsWith(CommandStart, StringComparison.InvariantCulture)) return Successor?.Handle(command);

        int depth = Convert.ToInt32(command.Split(' ').LastOrDefault("1"), NumberFormatInfo.InvariantInfo);
        return new ListCommand(output, visitor, indent, depth);
    }
}