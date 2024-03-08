namespace FileSystem.Exceptions;

public class DirectoryNotExistsException : FileSystemException
{
    public DirectoryNotExistsException(string message)
        : base($"Directory {message} does not exist")
    {
    }

    public DirectoryNotExistsException()
    {
    }

    public DirectoryNotExistsException(string message, System.Exception innerException)
        : base($"Directory {message} does not exist", innerException)
    {
    }
}