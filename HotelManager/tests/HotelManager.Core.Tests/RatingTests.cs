using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace HotelManager.Core.Tests
{
    public class RatingTests
    {
        [Theory]
        [MemberData(nameof(ValidRatings))]
        public void ShouldCreateRating(Rating rating, int expected)
        {
            rating.Value.Should().Be(expected);
        }

        [Fact]
        public void ShouldBeRatingOne()
        {
            var ratingOne = Rating.One;
            var anotherRating = Rating.AnotherOne;

            ratingOne.Should().Be(anotherRating);
        }

        [Fact]
        public void ShouldBeDiferentWhenDiferentRating()
        {
            var ratingOne = Rating.One;

            ratingOne.Should().NotBe(Rating.Two);
        }


        [Fact]
        public void ShouldBeTheSmeWhenSameRating()
        {
            var ratingOne = Rating.One;

            ratingOne.Should().Be(Rating.One);
        }

        public static IEnumerable<object[]> ValidRatings => new List<object[]>
        {
            new object[] { Rating.One, 1 },
            new object[] { Rating.Two, 2 },
            new object[] { Rating.Three, 3 },
            new object[] { Rating.Four, 4 },
            new object[] { Rating.Five, 5 },
        };
    }
}
