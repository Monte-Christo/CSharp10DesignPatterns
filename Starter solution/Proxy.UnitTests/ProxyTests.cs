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
        var fileName = "MyDocument.pdf";
        var myDocument = new Document(fileName);
        myDocument.DisplayDocument();
         var expectedText = $"Loading document {fileName}{Environment.NewLine}" + $"FileName: MyDocument.pdf, Title: An expensive document, Content: Lots of text, AuthorId: 1{Environment.NewLine}";
        Assert.Equal(expectedText, _output.ToString());
    }

    [Fact]
    public void DocumentProxy_DisplayDocument_WorksCorrectly()
    {
        var fileName = "MyDocument.pdf";
        var myDocumentProxy = new DocumentProxy("MyDocument.pdf");
        myDocumentProxy.DisplayDocument();
        var expectedText = $"Loading document {fileName}{Environment.NewLine}" + $"FileName: MyDocument.pdf, Title: An expensive document, Content: Lots of text, AuthorId: 1{Environment.NewLine}";
        Assert.Equal(expectedText, _output.ToString());
    }

    [Fact]
    public void LazyDocumentProxy_DisplayDocument_WorksCorrectly()
    {
        var fileName = "MyDocument.pdf";
        var myLazyDocumentProxy = new LazyDocumentProxy("MyDocument.pdf");
        myLazyDocumentProxy.DisplayDocument();
        var expectedText = $"Loading document {fileName}{Environment.NewLine}" + $"FileName: MyDocument.pdf, Title: An expensive document, Content: Lots of text, AuthorId: 1{Environment.NewLine}";
        Assert.Equal(expectedText, _output.ToString());
    }
}