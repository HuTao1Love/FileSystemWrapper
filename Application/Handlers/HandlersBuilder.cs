namespace Parser.Handlers;

public class HandlersBuilder
{
    private readonly List<IHandler> _handlers = new List<IHandler>();

    public HandlersBuilder AddHandler(IHandler handler)
    {
        _handlers.Add(handler);
        return this;
    }

    public IHandler Build()
    {
        for (int i = 0; i < _handlers.Count - 1; i++)
        {
            _handlers[i].Successor = _handlers[i + 1];
        }

        return _handlers[0];
    }
}