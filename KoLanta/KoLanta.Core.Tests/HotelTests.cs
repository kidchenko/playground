using System;
using FluentAssertions;
using Xunit;

namespace KoLanta.Core.Tests
{
    public class HotelTests
    {
        [Fact]
        public void ShouldCreateHotel()
        {
            var hotel = GetHotel();
            hotel.Should().NotBeNull();
       }

        [Fact]
        public void ShouldHaveName()
        {
            var hotel = GetHotel(name: "Juca");
            hotel.Name.Should().Be("Juca");
        }

        [Fact]
        public void ShouldHaveRating()
        {
            var hotel = GetHotel(rating: Rating.Three);
            hotel.Rating.Should().Be(Rating.Three);
        }

        [Fact]
        public void ShouldHaveWeekDayPrice()
        {
            var hotel = GetHotel(rating: Rating.Three);
            var today = DateTime.Now;
            hotel.GetPrice(today, false);
        }


        public static Hotel GetHotel(string name = "Juca", Rating rating = null)
        {
            return new Hotel(name, rating ?? Rating.One);
        }
    }
}
