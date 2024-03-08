using FileSystem.Abstractions;
using FileSystem.Context;

namespace FileSystem.Commands;

public class ShowCommand(string path, IOutput output) : ICommand
{
    public string Path { get; } = path;

    public void Execute(ICommandContext context)
    {
        ArgumentNullException.ThrowIfNull(context);
        context.VisitShow(Path, output);
    }
}