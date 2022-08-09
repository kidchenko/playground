using System;
namespace HotelManager.Core
{
    public record Rating
    {
        public const string ErrorMessage = "Invalid Rate.";

        public static readonly Rating One = From(1);
        public static readonly Rating Two = From(2);
        public static readonly Rating Three = From(3);
        public static readonly Rating Four = From(4);
        public static readonly Rating Five = From(5);

        public static readonly Rating AnotherOne = From(1);

        public int Value { get; init; }

        private static Rating From(int value)
        {
            return new Rating(value);
        }

        private Rating(int value)
        {
            Value = value;
        }
    }
}
