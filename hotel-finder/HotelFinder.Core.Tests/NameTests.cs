using System;
using FluentAssertions;
using Xunit;

namespace HotelFinder.Core.Tests
{
    public class NameTests
    {
        private readonly HotelName testName = HotelName.From("Hotel Name");

        [Fact]
        public void ShouldCreateName()
        {
            testName.Value.Should().Be("Hotel Name");
        }

        [Fact]
        public void ShouldTrimName()
        {
            var name = HotelName.From("   Hotel Name     ");
            name.Should().Be(testName);
        }

        [Fact]
        public void ShouldThrowWhenNameIsNull()
        {
            Action name = () => HotelName.From(null);
            name.Should().Throw<ArgumentException>().WithMessage(HotelName.NullOrEmptyErrorMessage);
        }

        [Fact]
        public void ShouldThrowWhenNameIsEmpty()
        {
            Action name = () => HotelName.From("");
            name.Should().Throw<ArgumentException>().WithMessage(HotelName.NullOrEmptyErrorMessage);
        }

        [Fact]
        public void ShouldThrowWhenNameIsWhiteSpace()
        {
            Action name = () => HotelName.From(" ");
            name.Should().Throw<ArgumentException>().WithMessage(HotelName.NullOrEmptyErrorMessage);
        }
    }
}
