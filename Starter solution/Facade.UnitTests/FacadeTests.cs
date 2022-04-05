using System;
using Xunit;

namespace Facade.UnitTests;

public class FacadeTests
{
    [Theory]
    [InlineData(1, 0)]
    [InlineData(6, 24)]
    [InlineData(10, 12)]
    [InlineData(20, 12)]
    public void DiscountFacade_CalculatesProperDiscount_OnWeekdays(int customerId, double expectedDiscount)
    {
        var facade = new DiscountFacade(new FakeDayOfWeekProvider(new FakeWeekdayTimeProvider()));
        Assert.Equal(expectedDiscount, facade.CalculateDiscount(customerId));
    }

    [Theory]
    [InlineData(1, 0)]
    [InlineData(6, 16)]
    [InlineData(10, 8)]
    [InlineData(20, 8)]
    public void DiscountFacade_CalculatesProperDiscount_OnWeekends(int customerId, double expectedDiscount)
    {
        var facade = new DiscountFacade(new FakeDayOfWeekProvider(new FakeWeekendTimeProvider()));
        Assert.Equal(expectedDiscount, facade.CalculateDiscount(customerId));
    }
}

public class FakeWeekdayTimeProvider : ITimeService
{
    public DayOfWeek GetDayOfWeek() => DayOfWeek.Monday;
}

public class FakeWeekendTimeProvider : ITimeService
{
    public DayOfWeek GetDayOfWeek() => DayOfWeek.Saturday;
}

public class FakeDayOfWeekProvider : DayOfWeekFactor
{
    public FakeDayOfWeekProvider(ITimeService timeService) : base(timeService)
    {
    }
}
