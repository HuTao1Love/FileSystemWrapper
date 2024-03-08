using FileSystem.Abstractions;

namespace FileSystem.FileSystemElements;

public class Directory(string path, IFileSystem fileSystem) : IFileSystemElement
{
    public IFileSystem FileSystem { get; } = fileSystem;
    public string Path { get; } = path;
    public string Name => FileSystem.Name(Path);

    public IEnumerable<IFileSystemElement> Children
    {
        get
        {
            var directories = FileSystem.Directories(Path)
                .Select(i => new Directory(i, FileSystem))
                .ToList();
            var files = FileSystem.Files(Path)
                .Select(i => new File(i, FileSystem))
                .ToList();

            return new List<IFileSystemElement>(directories)
                .Concat(files);
        }
    }

    public void Accept(IElementVisitor visitor)
    {
        if (visitor is IElementVisitor<Directory> v)
            v.Visit(this);
    }
}