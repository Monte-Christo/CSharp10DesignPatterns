using System.Diagnostics.Tracing;
using Xunit;

namespace Prototype.UnitTests;

public class PrototypeTests
{
    [Fact]
    public void ManagerClone_Succeeds()
    {
        Manager manager = new Manager("Cindy");
        Manager mgrClone = (Manager)manager.Clone();
        Assert.Equal(mgrClone.Name, manager.Name);
    }

    [Fact]
    public void ManagerClone2_Succeeds()
    {
        Manager manager = new Manager("Cindy");
        Manager mgrClone = manager.Clone();
        Assert.Equal(mgrClone.Name, manager.Name);
    }

    [Fact]
    public void EmployeeClone_Succeeds()
    {
        Manager manager = new Manager("Cindy");
        Employee employee = new Employee("EK", manager);
        Employee empClone = employee.Clone();
        Assert.Equal(empClone.Name, employee.Name);
        Assert.Equal(empClone.Manager, employee.Manager);
    }
}