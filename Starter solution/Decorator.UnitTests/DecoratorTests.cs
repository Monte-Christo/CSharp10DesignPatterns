using System;
using System.IO;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

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

    [Fact]
    public void StatisticsDecoratedCloudMailService_WorksCorrectly()
    {
        var cloudMailService = new CloudMailService();
        var statisticsCloudMailService = new StatisticsDecorator(cloudMailService);
        statisticsCloudMailService.SendMail("Test");

        var expected = $"Sending message 'Test' via CloudMailService.{Environment.NewLine}";
        Assert.Equal(expected, _output.ToString());
        Assert.Equal(1, statisticsCloudMailService.GetSentMessages());
    }

    [Fact]
    public void DatabaseDecoratedCloudMailService_WorksCorrectly()
    {
        var cloudMailService = new CloudMailService();
        var databaseCloudMailService = new MessageDatabaseDecorator(cloudMailService);
        var message = "Test";
        databaseCloudMailService.SendMail(message);

        var expected = $"Sending message '{message}' via CloudMailService.{Environment.NewLine}";
        Assert.Equal(expected, _output.ToString());
        Assert.Equal(message, databaseCloudMailService.Messages.FirstOrDefault());
    }


}
