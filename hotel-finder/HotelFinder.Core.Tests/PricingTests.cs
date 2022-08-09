using FluentAssertions;
using HotelFinder.Core.Rates;
using Xunit;

namespace HotelFinder.Core.Tests
{
    public class PricingTests
    {
        private WeekdayRegularRate weekdayRegularRate = new(10.Dollars());
        private WeekdayLoyaltyRate weekdayLoyaltyRate = new(10.Dollars());
        private WeekendRegularRate weekendRegularRate = new(10.Dollars());
        private WeekendLoyaltyRate weekendLoyaltyRate = new(10.Dollars());

        [Fact]
        public void ShouldCreatePricing()
        {
            var pricing = new Pricing(
                weekdayRegularRate,
                weekdayLoyaltyRate,
                weekendRegularRate,
                weekendLoyaltyRate);

            pricing.WeekdayRegularRate.Fare.Should().Be(Money.InDollars(10));
        }

        [Fact]
        public void ShouldCreateDifferentPricing()
        {
            var pricing = new Pricing(
                weekdayRegularRate,
                weekdayLoyaltyRate,
                weekendRegularRate,
                weekendLoyaltyRate);

            pricing.WeekdayRegularRate.Fare.Should().Be(10.Dollars());
            pricing.WeekdayLoyaltyRate.Fare.Should().Be(10.Dollars());
            pricing.WeekendRegularRate.Fare.Should().Be(10.Dollars());
            pricing.WeekendLoyaltyRate.Fare.Should().Be(10.Dollars());
        }
    }
}
