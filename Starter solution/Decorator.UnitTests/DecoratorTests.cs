using System;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Decorator.UnitTests;

public class DecoratorTests
{
    [Fact]
    public void CloudMailService_WorksCorrectly()
    {
        var output = new StringWriter();
        Console.SetOut(output);

        var cloudMailService = new CloudMailService();
        cloudMailService.SendMail("Test");

        var expected = $"Sending message 'Test' via CloudMailService.{Environment.NewLine}";
        Assert.Equal(expected, output.ToString());
    }

    [Fact]
    public void OnPremMailService_WorksCorrectly()
    {
        var output = new StringWriter();
        Console.SetOut(output);

        var onPremMailService = new OnPremMailService();
        onPremMailService.SendMail("Test");

        var expected = $"Sending message 'Test' via OnPremMailService.{Environment.NewLine}";
        Assert.Equal(expected, output.ToString());
    }
}
