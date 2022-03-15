namespace FactoryMethod;

public abstract class DiscountService
{
    public abstract int DiscountPercentage { get; }
    public override string ToString() => GetType().Name;
}

public class CountryDiscountService : DiscountService
{
    private readonly string _countryId;

    public CountryDiscountService(string countryId)
    {
        _countryId = countryId;
    }

    public override int DiscountPercentage => _countryId == "BE" ? 20 : 10;
}

public class CodeDiscountService : DiscountService
{
    private readonly Guid _code;

    public CodeDiscountService(Guid code)
    {
        _code = code;
    }

    public override int DiscountPercentage => 15;
}

public abstract class DiscountFactory
{
    public abstract DiscountService CreateDiscountService();
}

public class CountryDiscountFactory : DiscountFactory
{
    private readonly string _countryId;

    public CountryDiscountFactory(string countryId)
    {
        _countryId = countryId;
    }

    public override DiscountService CreateDiscountService() => new CountryDiscountService(_countryId);
}

public class CodeDiscountFactory : DiscountFactory
{
    private readonly Guid _code;

    public CodeDiscountFactory(Guid code)
    {
        _code = code;
    }

    public override DiscountService CreateDiscountService() => new CodeDiscountService(_code);
}

