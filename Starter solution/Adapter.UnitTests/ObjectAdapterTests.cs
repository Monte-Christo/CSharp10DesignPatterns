using ObjectAdapter;
using Xunit;

namespace Adapter.UnitTests
{
    public class ObjectAdapterTests
    {
        [Fact]
        public void Test1()
        {
            ICityAdapter adapter = new CityAdapter();
            var city = adapter.GetCity();
            Assert.Equal("Antwerp - 't Stad", city.FullName);
            Assert.Equal(500000, city.Inhabitants);
        }
    }
}