using FileSystem.Commands;
using FileSystem.Context;
using Parser;
using Parser.Handlers;

var io = new LocalConsole();
var context = new CommandContext();
var visitor = new ElementVisitor(io);
IHandler handlerChain = new DefaultHandlersBuilderDirector(io, visitor).Build();

do
{
    string? commandText = io.ReadLine();
    if (commandText is null) break;
    ICommand? command = handlerChain.Handle(commandText);
    if (command is null) break;
    command.Execute(context);
}
while (true);