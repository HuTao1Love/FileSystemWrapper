using FileSystem.Abstractions;
using FileSystem.Context;

namespace FileSystem.Commands;

public interface ICommand
{
    void Execute(ICommandContext context);
}