using System;
using System.Collections.Generic;

namespace HotelFinder.Core
{
    public record Rating
    {
        public int Value { get; init; }
        public const string ErrorMessage = "Invalid Rating.";

        public static readonly Rating One = new(1);
        public static readonly Rating Two = new(2);
        public static readonly Rating Three = new(3);
        public static readonly Rating Four = new(4);
        public static readonly Rating Five = new(5);


        private Rating(int value)
        {
            Value = value;
        }

        public static Rating From(int value)
        {
            var ratings = new Dictionary<int, Rating>
            {
                { 1, One },
                { 2, Two },
                { 3, Three },
                { 4, Four },
                { 5, Five }
            };

            var isRating = ratings.TryGetValue(value, out var rating);

            return isRating ? rating : throw new InvalidOperationException(ErrorMessage);
        }
    }
}
