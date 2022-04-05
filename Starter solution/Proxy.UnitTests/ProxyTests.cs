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
        var expectedText = 
            $"Loading document {fileName}{Environment.NewLine}" + 
            $"FileName: MyDocument.pdf, Title: An expensive document, Content: Lots of text, AuthorId: 1{Environment.NewLine}";
        Assert.Equal(expectedText, _output.ToString());
    }

    [Fact]
    public void DocumentProxy_DisplayDocument_WorksCorrectly()
    {
        var fileName = "MyDocument.pdf";
        var myDocumentProxy = new DocumentProxy(fileName);
        myDocumentProxy.DisplayDocument();
        var expectedText = 
            $"Loading document {fileName}{Environment.NewLine}" + 
            $"FileName: {fileName}, Title: An expensive document, Content: Lots of text, AuthorId: 1{Environment.NewLine}";
        Assert.Equal(expectedText, _output.ToString());
    }

    [Fact]
    public void LazyDocumentProxy_DisplayDocument_WorksCorrectly()
    {
        var fileName = "MyDocument.pdf";
        var myLazyDocumentProxy = new LazyDocumentProxy(fileName);
        myLazyDocumentProxy.DisplayDocument();
        var expectedText = 
            $"Loading document {fileName}{Environment.NewLine}" +
            $"FileName: MyDocument.pdf, Title: An expensive document, Content: Lots of text, AuthorId: 1{Environment.NewLine}";
        Assert.Equal(expectedText, _output.ToString());
    }

    [Fact]
    public void ProtectedDocumentProxy_DisplayDocumentByViewer_WorksCorrectly()
    {
        var fileName = "MyDocument.pdf";
        var myProtectedDocumentProxy = new ProtectedDocumentProxy(fileName, "Viewer");
        myProtectedDocumentProxy.DisplayDocument();
        var expectedText =
            $"Entering DisplayDocument in ProtectedDocumentProxy{Environment.NewLine}" +
            $"Loading document {fileName}{Environment.NewLine}" +
            $"FileName: MyDocument.pdf, Title: An expensive document, Content: Lots of text, AuthorId: 1{Environment.NewLine}" +
            $"Exiting DisplayDocument in ProtectedDocumentProxy{Environment.NewLine}";
        Assert.Equal(expectedText, _output.ToString());
    }

    [Fact]
    public void ProtectedDocumentProxy_DisplayDocumentByOther_Throws()
    {
        var myProtectedDocumentProxy = new ProtectedDocumentProxy("MyDocument.pdf", "Other");
        var exception = Assert.Throws<UnauthorizedAccessException>(() => myProtectedDocumentProxy.DisplayDocument());
        Assert.Equal("Role 'Other' is not authorized to view this document", exception.Message);
    }

}