using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace tdd_emp
{
	public class Schedule
	{
		private Employee[] employees = new[] {


		 public IReadOnlyList<Employee> GetWorkersShift(IScheduleOptions options)
        {
			var age = Age.Of(-1);
			var name = Name.Of("Jose");

			var criteria = employees.ToList();

			if (options.WorkOnSunday) {
				criteria = criteria.Where(emp => emp.CanWorkOnSunday()).ToList();
			}

			if (options.CapitalizeResult) {
				criteria = criteria.Select(emp => new Employee(emp.Name.ToUpper(), emp.Age)).ToList();
			}

			return criteria.ToList();
        }
	}

    public class UnitTest1
    {





        public IReadOnlyList<Employee> OrderByName(bool orderAsc = true)
        {
            return orderAsc ?
                employees.OrderBy(e => e.Name).ToList() :
                employees.OrderByDescending(e => e.Name).ToList();
        }



        [Fact]
        public void Employee_Equals()
        {
            var emp1 = new Employee("Juca", 18);
            var emp2 = new Employee("Juca", 18);
            Assert.Equal(emp1, emp2);
        }

        [Fact]
        public void Employee_Not_Equan_When_The_Age_Is_Not_The_Same()
        {
            var emp1 = new Employee("Juca", 18);
            var emp2 = new Employee("Juca", 10);
            Assert.NotEqual(emp1, emp2);
        }

        [Fact]
        public void Employees_That_Can_Work_On_Sunday()
        {
            var expected = new[] {
                new Employee("Sepp",18),
                new Employee("Mike",51),
            };

            var canWorkOnSunday = Filter(ScheduleOptions.CanWorkOnSunday);

            Assert.Equal(expected, canWorkOnSunday);
        }

        [Fact]
        public void Sort_Employees_By_Name()
        {
            var expected = new[] {
                new Employee("Max" ,17),
                new Employee("Mike",51),
                new Employee("Nina",15),
                new Employee("Sepp",18),
            };
            var sorted = OrderByName();
            Assert.Equal(expected, sorted);
        }

        [Fact]
        public void Capitalize_Employees_By_Name()
        {
            var expected = new[] {
                new Employee("MAX" ,17),
                new Employee("SEPP",18),
                new Employee("NINA",15),
                new Employee("MIKE",51),
            };

            var capitalized = Filter(ScheduleOptions.CapitalizeSearch);

            Assert.Equal(expected, capitalized);
        }

        [Fact]
        public void Should_Support_New_Constructor()
        {
            var anEmployee = new Employee("name", 12);
        }

        [Fact]
        public void Should_Be_Able_To_Order_By_Descending_Name()
        {
            var expected = new[] {
                new Employee("Sepp",18),
                new Employee("Nina",15),
                new Employee("Mike",51),
                new Employee("Max" ,17),
            };

            var sortedByDescending = OrderByName(orderAsc: false);

            Assert.Equal(expected, sortedByDescending);
        }

    }
}
