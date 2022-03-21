using System;
using System.Diagnostics.Tracing;
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
    public void EmployeeClone_Succeeds()
    {
        const string OldName = "Cindy";
        const string NewName = "foo";

        Manager manager = new Manager(OldName);
        Employee employee = new Employee("EK", manager);
        Employee empClone = employee.Clone();

        Assert.Equal(OldName, employee.Manager.Name);
        Assert.Equal(OldName, empClone.Manager.Name);
        Assert.Equal(empClone.Name, employee.Name);
        Assert.Equal(empClone.Manager, employee.Manager);

        manager.Name = NewName;

        Assert.Equal(NewName, employee.Manager.Name);
        Assert.Equal(NewName, empClone.Manager.Name);
    }
}