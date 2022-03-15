namespace Singleton;
public class Logger
{
    protected Logger()
    {
    }

    private static readonly Lazy<Logger> _instance = new(() => new Logger());

    public static Logger Instance => _instance.Value;

    public void Log(string message) => Console.WriteLine($"Message to log: {message}");
}
