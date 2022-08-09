using System;
using FluentAssertions;
using HotelFinder.Core.Rates;
using Xunit;

namespace HotelFinder.Core.Tests
{

    public class HotelTests
    {
        private static readonly Money teenDollars = Money.InDollars(10);
        private static readonly WeekdayRegularRate weekdayRegular = new WeekdayRegularRate(teenDollars);
        private static readonly WeekdayLoyaltyRate weekdayLoyalty = new WeekdayLoyaltyRate(teenDollars);

        private static readonly WeekendRegularRate weekendRegular = new WeekendRegularRate(teenDollars);
        private static readonly WeekendLoyaltyRate weekendLoyalty = new WeekendLoyaltyRate(teenDollars);

        private readonly HotelName name = HotelName.From("M");
        private readonly Rating rating = Rating.Five;
        private readonly Pricing pricing = new(weekdayRegular, weekdayLoyalty,
                                               weekendRegular, weekendLoyalty);

        [Fact]
        public void SouldCreateHotelWithName()
        {
            var hotel = new Hotel(name, rating, pricing);

            hotel.Name.Should().Be(HotelName.From("M"));
        }

        [Fact]
        public void SouldCreateHotelWithRating()
        {
            var hotel = new Hotel(name, rating, pricing);

            hotel.Rating.Should().Be(Rating.Five);
        }


        [Fact]
        public void SouldCreateHotelWithPricing()
        {
            var hotel = new Hotel(name, rating, pricing);

            hotel.Pricing.WeekdayRegularRate.Fare.Should().Be(Money.InDollars(10));
        }

        [Fact]
        public void SouldGetPriceForWeekDayRegular()
        {
            Pricing weekdayPricing = CreatePricing();

            var hotel = new Hotel(name, rating, weekdayPricing);
            var monday = new DateTime(2020, 3, 16);

            var price = hotel.Pricing.RegularPrice(monday);

            price.Should().Be(110.Dollars());
        }

        

        [Fact]
        public void SouldGetPriceForWeekDayLoyalty()
        {
            var weekdayPricing = CreatePricing();

            var hotel = new Hotel(name, rating, weekdayPricing);
            var monday = new DateTime(2020, 3, 16);

            var price = hotel.Pricing.LoyaltyPrice(monday);

            price.Should().Be(80.Dollars());
        }

        [Fact]
        public void SouldGetPriceForWeekendRegular()
        {
            var weekdayPricing = CreatePricing();

            var hotel = new Hotel(name, rating, weekdayPricing);
            var saturday = new DateTime(2020, 3, 21);

            var price = hotel.Pricing.RegularPrice(saturday);

            price.Should().Be(150.Dollars());
        }

        [Fact]
        public void SouldGetPriceForWeekendLoyalty()
        {
            var weekdayPricing = CreatePricing();

            var hotel = new Hotel(name, rating, weekdayPricing);
            var saturday = new DateTime(2020, 3, 21);

            var price = hotel.Pricing.LoyaltyPrice(saturday);

            price.Should().Be(120.Dollars());
        }


        [Fact]
        public void SouldThrowWhenNameIsNull()
        {
            Action hotel = () => new Hotel(null, rating, pricing);

            hotel.Should().Throw<ArgumentNullException>().WithMessage("Value cannot be null. (Parameter 'name')");
        }

        [Fact]
        public void SouldThrowWhenRatingIsNull()
        {
            Action hotel = () => new Hotel(name, null, pricing);

            hotel.Should().Throw<ArgumentNullException>().WithMessage("Value cannot be null. (Parameter 'rating')");
        }

        [Fact]
        public void SouldThrowWhenPricingIsNull()
        {
            Action hotel = () => new Hotel(name, rating, null);

            hotel.Should().Throw<ArgumentNullException>().WithMessage("Value cannot be null. (Parameter 'pricing')");
        }

        private static Pricing CreatePricing(
                       WeekdayRegularRate weekdayRegularRate = null,
                       WeekdayLoyaltyRate weekdayLoyaltyRate = null,
                       WeekendRegularRate weekendRegularRate = null,
                       WeekendLoyaltyRate weekendLoyaltyRate = null)
        {

            weekdayRegularRate ??= new WeekdayRegularRate(110.Dollars());
            weekdayLoyaltyRate ??= new WeekdayLoyaltyRate(80.Dollars());

            weekendRegularRate ??= new WeekendRegularRate(150.Dollars());
            weekendLoyaltyRate ??= new WeekendLoyaltyRate(120.Dollars());


            var pricing = new Pricing(weekdayRegularRate, weekdayLoyaltyRate,
                                      weekendRegularRate, weekendLoyaltyRate);

            return pricing;
        }
    }
}
