using System.Diagnostics.CodeAnalysis;
using FileSystem.Abstractions;

namespace FileSystem.Exceptions;

public class FileSystemNotConnectedException : FileSystemException
{
    public FileSystemNotConnectedException(string message)
        : base($"File system not connected: {message}")
    {
    }

    public FileSystemNotConnectedException()
    {
    }

    public FileSystemNotConnectedException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }

    public static void ThrowIfNotConnected([NotNull] IFileSystem? fileSystem)
    {
        if (fileSystem is null)
        {
            throw new FileSystemException();
        }
    }
}