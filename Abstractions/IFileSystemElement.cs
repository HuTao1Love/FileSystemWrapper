namespace FileSystem.Abstractions;

public interface IFileSystemElement
{
    public IFileSystem FileSystem { get; }
    public string Path { get; }
    public string Name { get; }

    void Accept(IElementVisitor visitor);
}