namespace ClassAdapter
{
    public class CityFromExternalSystem
    {
        public string Name { get; }
        public string NickName { get; }
        public int NumberOfInhabitants { get; }

        public CityFromExternalSystem(string name, string nickName, int numberOfInhabitants)
        {
            Name = name;
            NickName = nickName;
            NumberOfInhabitants = numberOfInhabitants;
        }
    }

    public class ExternalSystem
    {
        public CityFromExternalSystem GetCity() => new("Antwerp", "'t Stad", 500000);
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

    public class CityAdapter : ExternalSystem, ICityAdapter
    {
        public new City GetCity()
        {
            var cityFromExternalSystem = base.GetCity();
            return new City($"{cityFromExternalSystem.Name} - {cityFromExternalSystem.NickName}",
                cityFromExternalSystem.NumberOfInhabitants);
        }
    }
}
