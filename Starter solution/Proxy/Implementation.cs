namespace Proxy;

public interface IDocument
{
    void DisplayDocument();
}

public class Document : IDocument
{
    public string? Title { get; private set; }
    public string? Content { get; private set; }
    public int AuthorId { get; private set; }
    public DateTimeOffset LastAccessed { get; private set; }
    private readonly string _fileName;

    public Document(string fileName)
    {
        _fileName = fileName;
        LoadDocument(fileName);
    }

    private void LoadDocument(string fileName)
    {
        Console.WriteLine($"Loading document {fileName}");
        Thread.Sleep(1000);
        Title = "An expensive document";
        Content = "Lots of text";
        AuthorId = 1;
        LastAccessed = DateTimeOffset.UtcNow;
    }

    public void DisplayDocument() => Console.WriteLine($"FileName: {_fileName}, Title: {Title}, Content: {Content}, AuthorId: {AuthorId}");
}

public class DocumentProxy : IDocument
{
    private Document? _document;
    private readonly string _fileName;

    public DocumentProxy(string fileName)
    {
        _fileName = fileName;
    }

    public void DisplayDocument()
    {
        _document ??= new Document(_fileName);
        _document.DisplayDocument();
    }
}

public class LazyDocumentProxy : IDocument
{
    private readonly Lazy<Document> _document;

    public LazyDocumentProxy(string fileName)
    {
        _document = new Lazy<Document>(() => new Document(fileName));
    }

    public void DisplayDocument()
    {
        _document.Value.DisplayDocument();
    }
}

public class ProtectedDocumentProxy : IDocument
{
    private readonly string _userRole;
    private readonly DocumentProxy _documentProxy;

    public ProtectedDocumentProxy(string fileName, string userRole)
    {
        _userRole = userRole;
        _documentProxy = new DocumentProxy(fileName);
    }

    public void DisplayDocument()
    {
        Console.WriteLine($"Entering DisplayDocument in {nameof(ProtectedDocumentProxy)}");
        if (_userRole != "Viewer")
        {
            throw new UnauthorizedAccessException($"Role '{_userRole}' is not authorized to view this document");
        }
        _documentProxy.DisplayDocument();
        Console.WriteLine($"Exiting DisplayDocument in {nameof(ProtectedDocumentProxy)}");
    }
}

