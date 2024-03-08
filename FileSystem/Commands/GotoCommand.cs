using FileSystem.Abstractions;
using FileSystem.Context;

namespace FileSystem.Commands;

public class GotoCommand(string path) : ICommand
{
    public string Path { get; } = path;

    public void Execute(ICommandContext context)
    {
        ArgumentNullException.ThrowIfNull(context);
        context.VisitGoto(Path);
    }
}