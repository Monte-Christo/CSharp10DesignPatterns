using System.Collections.Generic;
using Xunit;

namespace Bridge.UnitTests;

public class BridgeTests
{
    [Theory]
    [MemberData(nameof(GetTestData))]
    public void VegetarianMenuTest(Menu menu, int price)
    {
        Assert.Equal(price, menu.CalculatePrice());
    }

    public static IEnumerable<object[]> GetTestData()
    {
        yield return new object[] { new VegetarianMenu(new NoCoupon()), 20 };
        yield return new object[] { new VegetarianMenu(new OneEuroCoupon()), 19 };
        yield return new object[] { new MeatBasedMenu(new NoCoupon()), 30 };
        yield return new object[] { new MeatBasedMenu(new TwoEuroCoupon()), 28 };
    }
}
