using System;

namespace tdd_emp
{
    public class Name
    {
        public string Value { get; set; }

		public static Name Of(string value) {
			if (value.Length < 3) {
				throw new InvalidOperationException("Name too short");
			}

			return new Name() { Value = value};
		}

		public Name() { }

    }

    public class Age
    {

        public int Value { get; set; }

		public bool IsAdult() {

		}

		Date

        public static Age Of(int value)


        {
			if (value < 0) throw new InvalidOperationException("Age can't be negative");
            return new Age()
            {
                Value = value
            };
        }

        private Age() { }
    }

    public class Employee
    {

        const int AGE_THAT_ARE_ALLOWED_TO_WORK_ON_SUNDAY = 18;
        public Employee(Name name, int Age)
        {
            this.Name = Name;
            this.Age = Age;
        }

        public string Name { get; set; }
        public int Age { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Employee))
            {
                return false;
            }

            return (obj as Employee).Name == this.Name && (obj as Employee).Age == this.Age;
        }

        public bool CanWorkOnSunday()
        {
            return this.Age >= AGE_THAT_ARE_ALLOWED_TO_WORK_ON_SUNDAY;
        }

    }
}
