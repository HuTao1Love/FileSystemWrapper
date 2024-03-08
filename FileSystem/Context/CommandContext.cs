using FileSystem.Abstractions;
using FileSystem.FileSystemElements;
using Directory = FileSystem.FileSystemElements.Directory;
using File = FileSystem.FileSystemElements.File;

namespace FileSystem.Context;

public class CommandContext : ICommandContext
{
    private IFileSystem? _fileSystem;

    public void VisitConnect(IFileSystem fileSystem)
    {
        ArgumentNullException.ThrowIfNull(fileSystem);
        _fileSystem = fileSystem;
    }

    public void VisitDisconnect()
    {
        _fileSystem = null;
    }

    public void VisitGoto(string path)
    {
        ArgumentNullException.ThrowIfNull(_fileSystem);
        _fileSystem.Navigate(path);
    }

    public void VisitList(IOutput output, IElementVisitor visitor, string indent, int depth = 1)
    {
        ArgumentNullException.ThrowIfNull(_fileSystem);
        ArgumentNullException.ThrowIfNull(output);
        ArgumentNullException.ThrowIfNull(visitor);

        var directory = new Directory(_fileSystem.WorkingPath, _fileSystem);
        visitor.Run(directory, depth, indent);
    }

    public void VisitShow(string path, IOutput output)
    {
        ArgumentNullException.ThrowIfNull(_fileSystem);
        ArgumentNullException.ThrowIfNull(output);
        output.WriteLine(new File(path, _fileSystem).Content);
    }

    public File VisitShow(string path)
    {
        ArgumentNullException.ThrowIfNull(_fileSystem);
        return new File(path, _fileSystem);
    }

    public void VisitMove(string sourcePath, string destinationPath)
    {
        ArgumentNullException.ThrowIfNull(_fileSystem);
        _fileSystem.Move(sourcePath, destinationPath);
    }

    public void VisitCopy(string sourcePath, string destinationPath)
    {
        ArgumentNullException.ThrowIfNull(_fileSystem);
        _fileSystem.Copy(sourcePath, destinationPath);
    }

    public void VisitDelete(string path)
    {
        ArgumentNullException.ThrowIfNull(_fileSystem);
        _fileSystem.Delete(path);
    }

    public void VisitRename(string oldName, string newName)
    {
        ArgumentNullException.ThrowIfNull(_fileSystem);
        _fileSystem.Rename(oldName, newName);
    }
}