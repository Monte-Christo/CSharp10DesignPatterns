using Xunit;

namespace Prototype.UnitTests;

public class PrototypeTests
{
    [Fact]
    public void ManagerClone_Succeeds()
    {
        Manager manager = new Manager("Cindy");
        Manager mgrClone = manager.Clone();
        Assert.Equal(mgrClone.Name, manager.Name);
    }

    [Fact]
    public void EmployeeClone_Shallow_Succeeds()
    {
        const string OLD_NAME = "Cindy";
        const string NEW_NAME = "foo";

        Manager manager = new Manager(OLD_NAME);
        Employee employee = new Employee("EK", manager);
        Employee empClone = employee.Clone();

        Assert.Equal(OLD_NAME, employee.Manager.Name);
        Assert.Equal(OLD_NAME, empClone.Manager.Name);
        Assert.Equal(empClone.Name, employee.Name);
        Assert.Equal(empClone.Manager, employee.Manager);

        manager.Name = NEW_NAME;

        Assert.Equal(NEW_NAME, employee.Manager.Name);
        Assert.Equal(NEW_NAME, empClone.Manager.Name);
    }

    [Fact]
    public void EmployeeClone_Deep_Succeeds()
    {
        const string OLD_NAME = "Cindy";
        const string NEW_NAME = "foo";

        Manager manager = new Manager(OLD_NAME);
        Employee employee = new Employee("EK", manager);
        Employee empClone = employee.Clone(deep: true);

        Assert.Equal(OLD_NAME, employee.Manager.Name);
        Assert.Equal(OLD_NAME, empClone.Manager.Name);
        Assert.Equal(empClone.Name, employee.Name);
        Assert.NotEqual(empClone.Manager, employee.Manager);

        manager.Name = NEW_NAME;

        Assert.Equal(NEW_NAME, employee.Manager.Name);
        Assert.Equal(OLD_NAME, empClone.Manager.Name);
    }

}