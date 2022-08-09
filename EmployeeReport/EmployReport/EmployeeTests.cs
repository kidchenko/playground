using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace EmployReport
{
    public class EmployeeTests
    {
        private readonly Scheduler employeeScheduler;
        private readonly IReadOnlyList<Employee> EMPLOYEES; 

        public EmployeeTests()
        {
            EMPLOYEES = new[] {
                new Employee(Name.Of("Max"), Age.Of(17)),
                new Employee(Name.Of("Sepp"), Age.Of(18)),
                new Employee(Name.Of("Nina"), Age.Of(15)),
                new Employee(Name.Of("Mike"),Age.Of(51)),
            };

            employeeScheduler = new Scheduler(EMPLOYEES);
        }

        [Fact]
        public void Employees_That_Can_Work_On_Sunday()
        {
            var expected = new[]
            {
                EMPLOYEES[1],
                EMPLOYEES[3]
            };

            var canWorkOnSunday = employeeScheduler.GetWorkShift(new SundayWorkers());

            canWorkOnSunday.ToList().Should().Equal(expected);
        }

        [Fact]
        public void Can_Sort_Employees_By_Name_Ascending()
        {
            var expected = new[]
            {
                EMPLOYEES[0],   
                EMPLOYEES[3],
                EMPLOYEES[2],
                EMPLOYEES[1],
            };

            var sortedbyNameAsc = employeeScheduler.GetWorkShift(new OrderByEmployeeName(AscOrDesc.Asc));

            Assert.Equal(expected, sortedbyNameAsc.ToList());

            //sortedbyNameAsc.ToList().Should().Equal(expected);
        }

        [Fact]
        public void Can_Sort_Employees_By_Name_Descending()
        {
            var expected = new[]
            {
                EMPLOYEES[1],
                EMPLOYEES[2],
                EMPLOYEES[3],
                EMPLOYEES[0],
            };

            var employeesByName = employeeScheduler.GetWorkShift(new OrderByEmployeeName(AscOrDesc.Desc));


            Assert.Equal(expected, employeesByName.ToList());
            //employeesByName.ToList().Should().Equal(expected);
        }

        [Fact]
        public void Employees_Have_Name_Capitalized()
        {
            var expected = new[]
            {
                new Employee(Name.Of("MAX"), Age.Of(17)),
                new Employee(Name.Of("SEPP"), Age.Of(18)),
                new Employee(Name.Of("NINA"), Age.Of(15)),
                new Employee(Name.Of("MIKE"),Age.Of(51)),
            };

            var employessCapitalized = employeeScheduler.GetWorkShift(new CapitalizeName());;

            employessCapitalized.ToList().Should().Equal(expected);
        }

        [Fact]
        public void Employees_Have_Name_LowerCase()
        {
            var expected = new[]
            {
                new Employee(Name.Of("max"), Age.Of(17)),
                new Employee(Name.Of("sepp"), Age.Of(18)),
                new Employee(Name.Of("nina"), Age.Of(15)),
                new Employee(Name.Of("mike"),Age.Of(51)),
            };

            var employessCapitalized = employeeScheduler.GetWorkShift(new LowerCaseName());

            employessCapitalized.ToList().Should().Equal(expected);
        }
    }
}
