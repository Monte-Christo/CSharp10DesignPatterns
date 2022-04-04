using System;
using System.IO;
using Xunit;

namespace Decorator.UnitTests;

public class DecoratorTests
{
    private readonly StringWriter _output;

    public DecoratorTests()
    {
        _output = new StringWriter();
        Console.SetOut(_output);
    }

    [Fact]
    public void CloudMailService_WorksCorrectly()
    {
        var cloudMailService = new CloudMailService();
        cloudMailService.SendMail("Test");

        var expected = $"Sending message 'Test' via CloudMailService.{Environment.NewLine}";
        Assert.Equal(expected, _output.ToString());
    }

    [Fact]
    public void OnPremMailService_WorksCorrectly()
    {
        var onPremMailService = new OnPremMailService();
        onPremMailService.SendMail("Test");

        var expected = $"Sending message 'Test' via OnPremMailService.{Environment.NewLine}";
        Assert.Equal(expected, _output.ToString());
    }

    [Theory]
    [InlineData("Test", "Another one", "How about this one?")]
    public void StatisticsDecoratedCloudMailService_WorksCorrectly(params string[] messages)
    {
        var cloudMailService = new CloudMailService();
        var statisticsCloudMailService = new StatisticsDecorator(cloudMailService);

        string expected = string.Empty;
        foreach (var message in messages)
        {
            statisticsCloudMailService.SendMail(message);
            expected += $"Sending message '{message}' via CloudMailService.{Environment.NewLine}";
        }

        Assert.Equal(expected, _output.ToString());
        Assert.Equal(messages.Length, statisticsCloudMailService.GetSentMessages());
    }

    [Theory]
    [InlineData("Test", "Another one", "And a third")]
    public void DatabaseDecoratedCloudMailService_WorksCorrectly(params string[] messages)
    {
        var cloudMailService = new CloudMailService();
        var databaseCloudMailService = new MessageDatabaseDecorator(cloudMailService);

        string expected = string.Empty;
        foreach (var message in messages)
        {
            databaseCloudMailService.SendMail(message);
            expected += $"Sending message '{message}' via CloudMailService.{Environment.NewLine}";
        }

        Assert.Equal(expected, _output.ToString());
        foreach (var message in messages)
        {
            Assert.Contains(message, databaseCloudMailService.Messages);
        }
    }


}
