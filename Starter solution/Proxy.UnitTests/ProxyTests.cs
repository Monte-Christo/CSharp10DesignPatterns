using System;
using System.IO;
using Xunit;

namespace Proxy.UnitTests;

public class ProxyTests
{
    private readonly StringWriter _output;

    public ProxyTests()
    {
        _output = new StringWriter();
        Console.SetOut(_output);

    }
    [Fact]
    public void RealDocument_DisplayDocument_WorksCorrectly()
    {
        var myDocument = new Document("MyDocument.pdf");
        myDocument.DisplayDocument();
        var expectedText = $"Title: An expensive document, Content: Lots of text, AuthorId: 1{Environment.NewLine}";
        Assert.Equal(expectedText, _output.ToString());
    }

    [Fact]
    public void DocumentProxy_DisplayDocument_WorksCorrectly()
    {
        var myDocumentProxy = new DocumentProxy("MyDocument.pdf");
        myDocumentProxy.DisplayDocument();
        var expectedText = $"Title: An expensive document, Content: Lots of text, AuthorId: 1{Environment.NewLine}";
        Assert.Equal(expectedText, _output.ToString());
    }

    [Fact]
    public void LazyDocumentProxy_DisplayDocument_WorksCorrectly()
    {
        var myLazyDocumentProxy = new LazyDocumentProxy("MyDocument.pdf");
        myLazyDocumentProxy.DisplayDocument();
        var expectedText = $"Title: An expensive document, Content: Lots of text, AuthorId: 1{Environment.NewLine}";
        Assert.Equal(expectedText, _output.ToString());
    }
}