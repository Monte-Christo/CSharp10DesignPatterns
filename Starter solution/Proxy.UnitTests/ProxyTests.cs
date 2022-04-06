using System;
using System.IO;
using Xunit;

namespace Proxy.UnitTests;

public class ProxyTests
{
    private readonly StringWriter _output;
    const string FileName = "MyDocument.pdf";

    public ProxyTests()
    {
        _output = new StringWriter();
        Console.SetOut(_output);

    }
    [Fact]
    public void RealDocument_DisplayDocument_WorksCorrectly()
    {
        var myDocument = new Document(FileName);
        myDocument.DisplayDocument();
        var expectedText = 
            $"Loading document {FileName}{Environment.NewLine}" + 
            $"FileName: {FileName}, Title: An expensive document, Content: Lots of text, AuthorId: 1{Environment.NewLine}";
        Assert.Equal(expectedText, _output.ToString());
    }

    [Fact]
    public void DocumentProxy_DisplayDocument_WorksCorrectly()
    {
        var myDocumentProxy = new DocumentProxy(FileName);
        myDocumentProxy.DisplayDocument();
        var expectedText = 
            $"Loading document {FileName}{Environment.NewLine}" + 
            $"FileName: {FileName}, Title: An expensive document, Content: Lots of text, AuthorId: 1{Environment.NewLine}";
        Assert.Equal(expectedText, _output.ToString());
    }

    [Fact]
    public void LazyDocumentProxy_DisplayDocument_WorksCorrectly()
    {
        var myLazyDocumentProxy = new LazyDocumentProxy(FileName);
        myLazyDocumentProxy.DisplayDocument();
        var expectedText = 
            $"Loading document {FileName}{Environment.NewLine}" +
            $"FileName: {FileName}, Title: An expensive document, Content: Lots of text, AuthorId: 1{Environment.NewLine}";
        Assert.Equal(expectedText, _output.ToString());
    }

    [Fact]
    public void ProtectedDocumentProxy_DisplayDocumentByViewer_WorksCorrectly()
    {
        var myProtectedDocumentProxy = new ProtectedDocumentProxy(FileName, "Viewer");
        myProtectedDocumentProxy.DisplayDocument();
        var expectedText =
            $"Entering DisplayDocument in ProtectedDocumentProxy{Environment.NewLine}" +
            $"Loading document {FileName}{Environment.NewLine}" +
            $"FileName: {FileName}, Title: An expensive document, Content: Lots of text, AuthorId: 1{Environment.NewLine}" +
            $"Exiting DisplayDocument in ProtectedDocumentProxy{Environment.NewLine}";
        Assert.Equal(expectedText, _output.ToString());
    }

    [Fact]
    public void ProtectedDocumentProxy_DisplayDocumentByOther_Throws()
    {
        var myProtectedDocumentProxy = new ProtectedDocumentProxy(FileName, "Other");
        var exception = Assert.Throws<UnauthorizedAccessException>(() => myProtectedDocumentProxy.DisplayDocument());
        Assert.Equal("Role 'Other' is not authorized to view this document", exception.Message);
    }

}