namespace FileSystem.Abstractions;

public interface IElementVisitor
{
    public IOutput Output { get; }

    public string DirectoryIcon { get; }
    public string FileIcon { get; }

    void Run(IFileSystemElement element, int maxDepth, string indent = " ");
}

public interface IElementVisitor<in TElement> : IElementVisitor
    where TElement : IFileSystemElement
{
    void Visit(TElement element);
}