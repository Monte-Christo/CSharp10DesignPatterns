namespace Builder;

public class Car
{
    private readonly List<string> _parts = new();
    private readonly string _carType;

    public Car(string carType)
    {
        _carType = carType;
    }

    public void AddPart(string part) => _parts.Add(part);

    public override string ToString()
    {
        var parts = string.Join(Environment.NewLine, _parts);
        return $"Car of type {_carType} has these parts:{Environment.NewLine}{parts}";
    }
}

public abstract class CarBuilder
{
    public Car Car { get; }

    protected CarBuilder(string carType)
    {
        Car = new Car(carType);
    }

    public abstract void BuildEngine();
    public abstract void BuildFrame();
}

public class MiniBuilder : CarBuilder
{
    public MiniBuilder() : base("Mini")
    {
    }

    public override void BuildEngine() => Car.AddPart("'not a V8 engine'");

    public override void BuildFrame() => Car.AddPart("'3-door with stripes'");
}

public class BmwBuilder : CarBuilder
{
    public BmwBuilder() : base("BMW")
    {
    }

    public override void BuildEngine() => Car.AddPart("'V8 turbo engine'");

    public override void BuildFrame() => Car.AddPart("'5-door with metallic finish'");
}

public class Garage
{
    private CarBuilder? _builder;

    public void Construct(CarBuilder builder)
    {
        _builder = builder;

        _builder.BuildEngine();
        _builder.BuildFrame();
    }

    public string Show() => _builder?.Car.ToString() ?? "Please build a car first";
}