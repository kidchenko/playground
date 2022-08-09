using System;

namespace EmployReport
{
    public class Age
    {
        public int Value { get; }

        public static Age Of(int age) => new Age(age);

        public override bool Equals(object obj)
        {
            return obj is Age age &&
                   Value == age.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }

        private Age(int age)
        {
            Value = age;
        }

        public override string ToString() => Value.ToString();
    }
}
