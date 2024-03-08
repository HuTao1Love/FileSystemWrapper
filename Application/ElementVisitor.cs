using FileSystem.Abstractions;
using FileSystem.FileSystemElements;
using Directory = FileSystem.FileSystemElements.Directory;
using File = FileSystem.FileSystemElements.File;

namespace Parser;

public class ElementVisitor(IOutput output, string directoryIcon = "📁", string fileIcon = "📄")
    : IElementVisitor<File>, IElementVisitor<Directory>
{
    private int _currentDepth;
    private int _maxDepth;
    private string? _indent;

    public IOutput Output { get; } = output;
    public string DirectoryIcon { get; } = directoryIcon;
    public string FileIcon { get; } = fileIcon;

    private string CurrentIndent => string.Concat(Enumerable.Repeat(_indent, _currentDepth));

    public void Visit(File element)
    {
        ArgumentNullException.ThrowIfNull(element);
        Output.WriteLine($"{CurrentIndent}{FileIcon}{element.Name}");
    }

    public void Visit(Directory element)
    {
        ArgumentNullException.ThrowIfNull(element);
        Output.WriteLine($"{CurrentIndent}{DirectoryIcon}{element.Name}");

        if (_currentDepth >= _maxDepth) return;

        _currentDepth++;

        foreach (IFileSystemElement child in element.Children)
        {
            child.Accept(this);
        }

        _currentDepth--;
    }

    public void Run(IFileSystemElement element, int maxDepth, string indent)
    {
        ArgumentNullException.ThrowIfNull(element);
        _indent = indent;
        _maxDepth = maxDepth;
        element.Accept(this);
    }
}
