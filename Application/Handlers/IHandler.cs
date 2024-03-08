using FileSystem.Commands;

namespace Parser.Handlers;

public interface IHandler
{
    IHandler? Successor { get; set; }
    ICommand? Handle(string command);
}