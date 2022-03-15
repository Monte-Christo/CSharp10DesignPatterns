using Xunit;

namespace AbstractFactory.Tests
{
    public class AbstractFactoryTests
    {
        [Fact]
        public void BelgiumShoppingSpree()
        {
            var belgiumShoppingCartPurchaseFactory = new BelgiumShoppingCartPurchaseFactory();
            var belgianShoppingCart = new ShoppingCart(belgiumShoppingCartPurchaseFactory);

            Assert.Equal(180, belgianShoppingCart.CalculateTotalCost());
        }

        [Fact]
        public void FranceShoppingSpree()
        {
            var franceShoppingCartPurchaseFactory = new FranceShoppingCartPurchaseFactory();
            var frenchShoppingCart = new ShoppingCart(franceShoppingCartPurchaseFactory);

            Assert.Equal(205.5m, frenchShoppingCart.CalculateTotalCost());
        }
    }
}