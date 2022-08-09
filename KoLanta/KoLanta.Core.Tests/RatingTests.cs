using System;
using FluentAssertions;
using Xunit;

namespace KoLanta.Core.Tests
{
    public class RatingTests
    {
        [Fact]
        public void ShouldCreateRating()
        {
            var rating = Rating.One;
            rating.Should().NotBeNull();;
       }

        [Fact]
        public void ShoulbBeOne()
        {
            var rating = Rating.One;
            rating.Should().Be(Rating.One);
        }


        [Fact]
        public void ShoulbBeEqual()
        {
            var rating = Rating.One;
            var another = Rating.One;
            rating.Should().Be(another);
        }
    }
}
