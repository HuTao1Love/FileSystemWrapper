namespace FileSystem.Abstractions;

public interface IFileSystem
{
    public string WorkingPath { get; }
    void Navigate(string path);
    void Move(string sourcePath, string destinationPath);
    void Copy(string sourcePath, string destinationPath);
    void Delete(string path);
    void Rename(string oldName, string newName);
    IEnumerable<string> Directories(string? path = null);
    IEnumerable<string> Files(string? path = null);
    string Content(string path);
    string Name(string path);
}