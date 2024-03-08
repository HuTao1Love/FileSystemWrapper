using FileSystem.Abstractions;
using Parser.Handlers;

namespace Parser;

public class DefaultHandlersBuilderDirector(IOutput output, IElementVisitor visitor, string indent = " ")
{
    private readonly HandlersBuilder _builder = new HandlersBuilder();

    public IHandler Build()
    {
        _builder
            .AddHandler(new ConnectHandler())
            .AddHandler(new CopyHandler())
            .AddHandler(new DeleteHandler())
            .AddHandler(new DisconnectHandler())
            .AddHandler(new GotoHandler())
            .AddHandler(new ListHandler(output, visitor, indent))
            .AddHandler(new MoveHandler())
            .AddHandler(new RenameHandler())
            .AddHandler(new ShowHandler(output));

        return _builder.Build();
    }
}