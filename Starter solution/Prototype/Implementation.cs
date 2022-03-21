using Newtonsoft.Json;
using System.Text.Json.Serialization;
using JsonConverter = System.Text.Json.Serialization.JsonConverter;

namespace Prototype;

public abstract class Person
{
    public abstract string Name { get; set; }
    public abstract Person Clone(bool deep = false);
}

public class Manager : Person
{
    public override string Name { get; set; }

    public Manager(string name)
    {
        Name = name;
    }
    public override Manager Clone(bool deep = false)
    {
        if (deep)
        {
            var jsonMgr = JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject<Manager>(jsonMgr);
        }
        return (Manager) MemberwiseClone();
    }
}

public class Employee : Person
{
    public override string Name { get; set; }
    public Manager Manager { get; }

    public Employee(string name, Manager manager)
    {
        Name = name;
        Manager = manager;
    }
    public override Employee Clone(bool deep= false)
    {
        if (deep)
        {
            var jsonEmp = JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject<Employee>(jsonEmp);
        }
        return (Employee) MemberwiseClone();
    }
}

