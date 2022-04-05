namespace Composite;

public abstract class FileSystemItem
{
    public string Name { get; set; }
    public abstract long GetSize();

    protected FileSystemItem(string name)
    {
        Name = name;
    }
}

public class File : FileSystemItem
{
    private readonly long _size;

    public File(string name, long size) : base(name)
    {
        _size = size;
    }

    public override long GetSize() => _size;
}

public class Directory : FileSystemItem
{
    private readonly long _size;
    private readonly List<FileSystemItem> _children = new();

    public Directory(string name, long size) : base(name)
    {
        _size = size;
    }

    public void Add(FileSystemItem item)
    {
        _children.Add(item);
    }

    public void Remove(FileSystemItem item)
    {
        _children.Remove(item);
    }

    public override long GetSize()
    {
        long totalSize = _size;
        foreach (var child in _children)
        {
            totalSize += child.GetSize();
        }
        return totalSize;
    }
}
