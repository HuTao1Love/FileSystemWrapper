using FileSystem.Abstractions;

namespace FileSystem.FileSystemElements;

public class File(string path, IFileSystem fileSystem) : IFileSystemElement
{
    public IFileSystem FileSystem { get; } = fileSystem;
    public string Path { get; } = path;
    public string Name => FileSystem.Name(Path);
    public string Content => FileSystem.Content(Path);

    public void Accept(IElementVisitor visitor)
    {
        if (visitor is IElementVisitor<File> v)
            v.Visit(this);
    }
}