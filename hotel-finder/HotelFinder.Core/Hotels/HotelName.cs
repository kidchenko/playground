using System;
namespace HotelFinder.Core
{
    public record HotelName
    {
        public const string NullOrEmptyErrorMessage = "Name cannot be empty.";

        private HotelName(string value)
        {
            Value = value;
        }

        public string Value { get; init; }

        public static HotelName From(string value)
        {
            Validate(value);

            var name = new HotelName(value.Trim());
            return name;
        }

        private static void Validate(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(NullOrEmptyErrorMessage);
            }
        }
    }
}
