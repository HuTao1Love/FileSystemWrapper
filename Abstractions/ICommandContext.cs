namespace FileSystem.Abstractions;

public interface ICommandContext
{
    void VisitConnect(IFileSystem fileSystem);
    void VisitDisconnect();
    void VisitGoto(string path);
    void VisitList(IOutput output, IElementVisitor visitor, string indent, int depth = 1);
    void VisitShow(string path, IOutput output);
    void VisitMove(string sourcePath, string destinationPath);
    void VisitCopy(string sourcePath, string destinationPath);
    void VisitDelete(string path);
    void VisitRename(string oldName, string newName);
}