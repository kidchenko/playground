using System;
using System.Collections.Generic;

namespace EmployReport
{
    public class Employee
    {
        public Employee(Name name, Age age)
        {
            Name = name;
            Age = age;
        }

        public bool CanWorkOnSunday() => Age.Value >= 18;

        public override bool Equals(object obj)
        {
            return obj is Employee employee &&
                   EqualityComparer<Name>.Default.Equals(Name, employee.Name) &&
                   EqualityComparer<Age>.Default.Equals(Age, employee.Age);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Age);
        }

        public Employee CapitalizeName()
        {
			return new Employee(Name.Of(Name.Value.ToUpper()), Age.Of(Age.Value));
        }

        public Employee LowerCaseName()
        {
            return new Employee(Name.Of(Name.Value.ToLower()), Age.Of(Age.Value));
        }

        public Name Name { get; }
        public Age Age { get; }
    }
}
