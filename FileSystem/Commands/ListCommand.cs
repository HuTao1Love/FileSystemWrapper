using FileSystem.Abstractions;
using FileSystem.Context;

namespace FileSystem.Commands;

public class ListCommand(IOutput output, IElementVisitor visitor, string indent, int depth)
    : ICommand
{
    public void Execute(ICommandContext context)
    {
        ArgumentNullException.ThrowIfNull(context);
        context.VisitList(output, visitor, indent, depth);
    }
}