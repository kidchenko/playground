using System;
using FluentAssertions;
using Xunit;

namespace HotelManager.Core.Tests
{
    public class HotelTests
    {
        private Hotel hotel;

        public HotelTests()
        {
            hotel = new Hotel(HotelName.From(""), Rating.Two,
                110.Dollars(),
                80.Dollars(),
                90.Dollars(),
                80.Dollars()
            );
        }

        [Fact]
        public void ShouldCreateHotel()
        {
            hotel.Should().NotBeNull();
        }

        [Fact]
        public void ShouldCreateHotelWithRating()
        {
            hotel.Rating.Should().Be(Rating.Two);
        }

        [Fact]
        public void ShouldCreateHotelWithWeekDayPricing()
        {
            hotel.WeekDayRateRegular.Should().Be(Money.InDollars(110));

            hotel.WeekDayRateLoyalty.Should().Be(Money.InDollars(80));
        }

        [Fact]
        public void ShouldGetPriceForWeekdayRegular()
        {
            var today = new DateTime(2021, 03, 09);
            Money price = hotel.GetRegularPrice(today);

            price.Should().Be(Money.InDollars(110));
        }

        [Fact]
        public void ShouldGetPriceForWeekdayLoyalty() 
        {
            var today = new DateTime(2021, 03, 09);
            Money price = hotel.GetLoyaltyPrice(today);

            price.Should().Be(80M.Dollars());
        }

        [Fact]
        public void ShouldGetPriceForWeekendRegular()
        {
            var saturday = new DateTime(2021, 03, 13); ;
            Money price = hotel.GetRegularPrice(saturday);

            price.Should().Be(90.Dollars());
        }

        [Fact]
        public void ShouldGetPriceForWeekendLoyalty()
        {
            var saturday = new DateTime(2021, 03, 13); ;
            Money price = hotel.GetLoyaltyPrice(saturday);

            price.Should().Be(80M.Dollars());
        }

        [Fact]
        public void ShouldGetPriceForRangeOfDatesRegular()
        {
            var tuesday = new DateTime(2021, 03, 09);
            var friday = new DateTime(2021, 03, 12);
            var range = new DateRange(tuesday, friday);

            Money price = hotel.GetRegularPrice(range);



            price.Should().Be(440M.Dollars());
        }
    }
}
