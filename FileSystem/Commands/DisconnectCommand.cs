using FileSystem.Abstractions;
using FileSystem.Context;

namespace FileSystem.Commands;

public class DisconnectCommand : ICommand
{
    public void Execute(ICommandContext context)
    {
        ArgumentNullException.ThrowIfNull(context);
        context.VisitDisconnect();
    }
}