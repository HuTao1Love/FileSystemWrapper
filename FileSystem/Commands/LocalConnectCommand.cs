using FileSystem.Exceptions;
using FileSystem.FileSystemElements;

namespace FileSystem.Commands;

public class LocalConnectCommand : ConnectCommand
{
    public LocalConnectCommand(string address, string mode)
        : base(new LocalFileSystem(address))
    {
        if (mode != "local")
        {
            throw new FileSystemNotConnectedException($"Invalid File System mode: {mode}");
        }
    }
}