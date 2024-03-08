using FileSystem.Abstractions;
using FileSystem.Context;
using FileSystem.FileSystemElements;

namespace FileSystem.Commands;

public class ConnectCommand(LocalFileSystem fileSystem) : ICommand
{
    public IFileSystem FileSystem { get; } = fileSystem;

    public void Execute(ICommandContext context)
    {
        ArgumentNullException.ThrowIfNull(context);
        context.VisitConnect(FileSystem);
    }
}