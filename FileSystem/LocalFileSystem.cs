using FileSystem.Abstractions;
using FileSystem.Exceptions;

namespace FileSystem;

public class LocalFileSystem(string path) : IFileSystem
{
    public string AbsolutePath { get; } = path;
    public string WorkingPath { get; private set; } = path;

    public void Navigate(string path)
    {
        ArgumentNullException.ThrowIfNull(path);
        path = GetAbsolutePath(path);

        if (!Directory.Exists(path))
        {
            throw new DirectoryNotExistsException(path);
        }

        WorkingPath = path;
    }

    public void Move(string sourcePath, string destinationPath)
    {
        ArgumentNullException.ThrowIfNull(sourcePath);
        ArgumentNullException.ThrowIfNull(destinationPath);

        sourcePath = GetAbsolutePath(sourcePath);
        destinationPath = GetAbsolutePath(destinationPath);

        if (!Directory.Exists(destinationPath))
        {
            throw new DirectoryNotExistsException(destinationPath);
        }

        if (!File.Exists(sourcePath))
            throw new DirectoryNotExistsException(sourcePath);

        File.Move(sourcePath, destinationPath);
    }

    public void Copy(string sourcePath, string destinationPath)
    {
        ArgumentNullException.ThrowIfNull(sourcePath);
        ArgumentNullException.ThrowIfNull(destinationPath);

        sourcePath = GetAbsolutePath(sourcePath);
        destinationPath = GetAbsolutePath(destinationPath);

        if (!Directory.Exists(destinationPath))
        {
            throw new DirectoryNotExistsException(destinationPath);
        }

        if (!File.Exists(sourcePath))
            throw new DirectoryNotExistsException(sourcePath);

        File.Move(sourcePath, destinationPath);
    }

    public void Delete(string path)
    {
        ArgumentNullException.ThrowIfNull(path);
        path = GetAbsolutePath(path);

        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }

    public void Rename(string oldName, string newName)
    {
        ArgumentNullException.ThrowIfNull(oldName);
        oldName = GetAbsolutePath(oldName);

        if (!File.Exists(oldName))
        {
            throw new DirectoryNotExistsException(oldName);
        }

        File.Move(oldName, newName);
    }

    public IEnumerable<string> Directories(string? path = null) => Directory.GetDirectories(path ?? WorkingPath);

    public IEnumerable<string> Files(string? path = null) => Directory.GetFiles(path ?? WorkingPath);

    public string Content(string path) => File.ReadAllText(path);

    public string Name(string path) => Path.GetFileName(path);

    private string GetAbsolutePath(string path)
    {
        return path.StartsWith(AbsolutePath, StringComparison.InvariantCulture) ? path : Path.Combine(AbsolutePath, path);
    }
}