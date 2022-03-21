namespace Adapter;

public class CityFromExternalSystem
{
    public string Name { get; private set; }
    public string NickName { get; private set; }
    public int NumberOfInhabitants { get; private set; }

    public CityFromExternalSystem(string name, string nickName, int numberOfInhabitants)
    {
        Name = name;
        NickName = nickName;
        NumberOfInhabitants = numberOfInhabitants;
    }
}

public class ExternalSystem
{
    public CityFromExternalSystem GetCity() => new CityFromExternalSystem("Antwerp", "'t Stad", 500000);
}

public class City
{
    public string FullName { get; }
    public long Inhabitants { get; }

    public City(string fullName, long inhabitants)
    {
        FullName = fullName;
        Inhabitants = inhabitants;
    }
}

public interface ICityAdapter
{
    City GetCity();
}

public class CityAdapter : ICityAdapter
{
    public ExternalSystem ExternalSystem { get; private set; } = new();

    public City GetCity()
    {
        var cityFromExternalSystem = ExternalSystem.GetCity();
        return new City($"{cityFromExternalSystem.Name} - {cityFromExternalSystem.NickName}",
            cityFromExternalSystem.NumberOfInhabitants);
    }
}
