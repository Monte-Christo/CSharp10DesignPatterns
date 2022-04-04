namespace Decorator;

public interface IMailService
{
    bool SendMail(string message);
}

public class CloudMailService : IMailService
{
    public bool SendMail(string message)
    {
        Console.WriteLine($"Sending message '{message}' via {nameof(CloudMailService)}.");
        return true;
    }
}

public class OnPremMailService : IMailService
{
    public bool SendMail(string message)
    {
        Console.WriteLine($"Sending message '{message}' via {nameof(OnPremMailService)}.");
        return true;
    }
}

public class MailServiceDecoratorBase : IMailService
{
    private readonly IMailService _mailService;

    public MailServiceDecoratorBase(IMailService mailService)
    {
        _mailService = mailService;
    }
    public virtual bool SendMail(string message) => _mailService.SendMail(message);
}

public class StatisticsDecorator : MailServiceDecoratorBase
{
    private int _sentMessages;

    public StatisticsDecorator(IMailService mailService) : base(mailService)
    {
    }

    public override bool SendMail(string message)
    {
        _sentMessages++;
        return base.SendMail(message);
    }

    public int GetSentMessages()
    {
        return _sentMessages;
    }
}

public class MessageDatabaseDecorator : MailServiceDecoratorBase
{
    public List<string> Messages { get; private set; } = new List<string>();

    public MessageDatabaseDecorator(IMailService mailService) : base(mailService)
    {
    }

    public override bool SendMail(string message)
    {
        if (!base.SendMail(message))
        {
            return false;
        }

        Messages.Add(message);
        return true;
    }
}
