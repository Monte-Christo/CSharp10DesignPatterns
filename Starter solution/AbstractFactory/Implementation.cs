namespace AbstractFactory;

public interface IShoppingCartPurchaseFactory
{
    IDiscountService CreateDiscountService();
    IShippingCostService CreateShippingCostService();
}

public class FranceShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
{
    public IDiscountService CreateDiscountService() => new FranceDiscountService();

    public IShippingCostService CreateShippingCostService() => new FranceShippingCostService();
}

public class BelgiumShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
{
    public IDiscountService CreateDiscountService() => new BelgiumDiscountService();

    public IShippingCostService CreateShippingCostService() => new BelgiumShippingCostService();
}

public interface IShippingCostService
{
    decimal ShippingCost { get; }
}

public class FranceShippingCostService : IShippingCostService
{
    public decimal ShippingCost => 25.5m;
}

public class BelgiumShippingCostService : IShippingCostService
{
    public decimal ShippingCost => 20;
}

public interface IDiscountService
{
    int DiscountPercentage { get; }
}

public class FranceDiscountService : IDiscountService
{
    public int DiscountPercentage => 10;
}

public class BelgiumDiscountService : IDiscountService
{
    public int DiscountPercentage => 20;
}

