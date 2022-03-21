namespace Prototype;

public abstract class Person
{
    public abstract string Name { get; }
    public abstract Person Clone(bool deep = false);
}

public class Manager : Person
{
    public override string Name { get; }

    public Manager(string name)
    {
        Name = name;
    }
    public override Manager Clone(bool deep = false) => (Manager)MemberwiseClone();
}

public class Employee : Person
{
    public override string Name { get; }
    public Manager Manager { get; }

    public Employee(string name, Manager manager)
    {
        Name = name;
        Manager = manager;
    }
    public override Employee Clone(bool deep= false) => (Employee)MemberwiseClone();
}

