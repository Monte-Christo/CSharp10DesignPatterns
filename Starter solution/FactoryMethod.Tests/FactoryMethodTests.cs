using System;
using Xunit;

namespace FactoryMethod.Tests;

public class FactoryMethodTests
{
    [Fact]
    public void DiscountService_ReturnsCorrectDiscountPercentage()
    {
        var factory1 = new CodeDiscountFactory(Guid.NewGuid());
        var factory2 = new CountryDiscountFactory("BE");
        var service1 = factory1.CreateDiscountService();
        var service2 = factory2.CreateDiscountService();

        Assert.Equal(15, service1.DiscountPercentage);
        Assert.Equal(20, service2.DiscountPercentage);
    }
}
