using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace HotelFinder.Core.Tests
{
    public class RatingTests
    {
        [Fact]
        public void ShouldSaveThePrimitiveValue()
        {
            var rating = Rating.One;
            rating.Value.Should().Be(Rating.One.Value);
        }


        [Fact]
        public void ShouldHaveSameValue()
        {
            var rating = Rating.One;
            rating.Should().Be(Rating.One);
        }

        [Fact]
        public void ShouldHaveErrorMessage()
        {
            var rating = Rating.ErrorMessage;
            rating.Should().NotBeNullOrEmpty();
        }

        [Theory]
        [MemberData(nameof(ValidRatings))]
        public void ShouldCreateValidRatings(Rating ratingA, Rating ratingB)
        {
            ratingA.Should().Be(ratingB);
        }

        public static IEnumerable<object[]> ValidRatings =>
        new List<object[]>
        {
            new object[] { Rating.One, Rating.One },
            new object[] { Rating.Two, Rating.Two },
            new object[] { Rating.Three, Rating.Three },
            new object[] { Rating.Four, Rating.Four },
            new object[] { Rating.Five, Rating.Five },
        };
    }
}
