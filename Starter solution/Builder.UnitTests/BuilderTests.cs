using Xunit;

namespace Builder.UnitTests
{
    public class BuilderTests
    {
        [Fact]
        public void MiniBuilderTest()
        {
            var garage = new Garage();
            var miniBuilder = new MiniBuilder();

            garage.Construct(miniBuilder);

            Assert.Equal(
                @"Car of type Mini has these parts:
'not a V8 engine'
'3-door with stripes'", 
                garage.Show());
        }

        [Fact]
        public void BmwBuilderTest1()
        {
            var garage = new Garage();
            var bmwBuilder = new BmwBuilder();

            garage.Construct(bmwBuilder);

            Assert.Equal(
                @"Car of type BMW has these parts:
'V8 turbo engine'
'5-door with metallic finish'",
                garage.Show());
        }

        [Fact]
        public void BogusBuilderTest1()
        {
            var garage = new Garage();

            Assert.Equal("Please build a car first",
                garage.Show());
        }
    }
}