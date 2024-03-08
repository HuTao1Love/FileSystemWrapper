using FileSystem.Abstractions;
using FileSystem.Commands;
using Moq;
using Parser;
using Parser.Handlers;

namespace Tests;

public class ParserTests
{
    private readonly IHandler _handler;

    public ParserTests()
    {
        // ARRANGE
        IOutput output = Mock.Of<IOutput>();
        IElementVisitor visitor = new ElementVisitor(output);

        _handler = new DefaultHandlersBuilderDirector(output, visitor, " ").Build();
    }

    [Fact]
    public void ConnectDisconnectTest()
    {
        // ACT
        ICommand? connect = _handler.Handle("connect C:\\ -m local");
        ICommand? disconnect = _handler.Handle("disconnect");

        // ASSERT
        Assert.IsType<LocalConnectCommand>(connect);
        Assert.IsType<DisconnectCommand>(disconnect);
    }

    [Fact]
    public void GotoTest()
    {
        // ACT
        ICommand? gotoCommand = _handler.Handle("tree goto users");

        // ASSERT
        Assert.IsType<GotoCommand>(gotoCommand);
        Assert.Equal("users", ((GotoCommand)gotoCommand).Path);
    }

    [Fact]
    public void ListTest()
    {
        // ACT
        ICommand? list = _handler.Handle("tree list -d 2");

        // ASSERT
        Assert.IsType<ListCommand>(list);
    }

    [Fact]
    public void ShowTest()
    {
        // ACT
        ICommand? show = _handler.Handle("file show file.txt");

        // ASSERT
        Assert.IsType<ShowCommand>(show);
    }

    [Fact]
    public void MoveTest()
    {
        // ACT
        ICommand? move = _handler.Handle(@"file move C:\Users\user\Desktop\file.txt C:\Users\user\Documents\file.txt");

        // ASSERT
        Assert.IsType<MoveCommand>(move);
        Assert.Equal(@"C:\Users\user\Desktop\file.txt", ((MoveCommand)move).SourcePath);
        Assert.Equal(@"C:\Users\user\Documents\file.txt", ((MoveCommand)move).DestinationPath);
    }

    [Fact]
    public void CopyTest()
    {
        // ACT
        ICommand? copy = _handler.Handle(@"file copy C:\Users\user\Desktop\file.txt C:\Users\user\Documents\file.txt");

        // ASSERT
        Assert.IsType<CopyCommand>(copy);
        Assert.Equal(@"C:\Users\user\Desktop\file.txt", ((CopyCommand)copy).SourcePath);
        Assert.Equal(@"C:\Users\user\Documents\file.txt", ((CopyCommand)copy).DestinationPath);
    }

    [Fact]
    public void DeleteTest()
    {
        // ACT
        ICommand? delete = _handler.Handle(@"file delete C:\Users\user\Desktop\file.txt");

        // ASSERT
        Assert.IsType<DeleteCommand>(delete);
        Assert.Equal(@"C:\Users\user\Desktop\file.txt", ((DeleteCommand)delete).Path);
    }

    [Fact]
    public void RenameTest()
    {
        // ACT
        ICommand? rename = _handler.Handle(@"file rename C:\Users\user\Desktop\file.txt newFile.txt");

        // ASSERT
        Assert.IsType<RenameCommand>(rename);
        Assert.Equal(@"C:\Users\user\Desktop\file.txt", ((RenameCommand)rename).SourcePath);
        Assert.Equal(@"newFile.txt", ((RenameCommand)rename).DestinationPath);
    }
}