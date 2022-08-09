using System;

namespace EmployReport
{
    public class Name
    {
        public string Value { get; }

        public static Name Of(string name) => new Name(name);

        public override bool Equals(object obj)
        {
            return obj is Name name &&
                   Value == name.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }

        private Name(string name)
        {
            Value = name;
        }

        public override string ToString() => Value.ToString();

    }
}
