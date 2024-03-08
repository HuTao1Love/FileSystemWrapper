using FileSystem.Abstractions;
using FileSystem.Context;

namespace FileSystem.Commands;

public class DeleteCommand(string path) : ICommand
{
    public string Path { get; } = path;

    public void Execute(ICommandContext context)
    {
        ArgumentNullException.ThrowIfNull(context);
        context.VisitDelete(Path);
    }
}