using FileSystem.Abstractions;
using FileSystem.Context;

namespace FileSystem.Commands;

public class RenameCommand(string sourcePath, string destinationPath) : ICommand
{
    public string SourcePath { get; } = sourcePath;
    public string DestinationPath { get; } = destinationPath;

    public void Execute(ICommandContext context)
    {
        ArgumentNullException.ThrowIfNull(context);
        context.VisitRename(SourcePath, DestinationPath);
    }
}