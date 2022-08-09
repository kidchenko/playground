using System;
using FluentAssertions;
using HotelFinder.Core.Rates;
using Xunit;

namespace HotelFinder.Core.Tests
{
    public class WeekendLoyaltyRateTests
    {
        private readonly WeekendLoyaltyRate weekendLoyaltyRate = new(10.Dollars());

        [Fact]
        public void ShouldCreateWeekendLoyaltyRegularRate()
        {
            weekendLoyaltyRate.Fare.Should().Be(10.Dollars());
        }

        [Fact]
        public void ShouldBeLoyalty()
        {
            var weekendLoyaltyRate = new WeekendLoyaltyRate(Money.Any);

            weekendLoyaltyRate.RateType.Should().Be(RateType.Loyalty);
        }

        [Fact]
        public void ShouldNotSatistyWeekDayAndRegular()
        {
            var weekendLoyaltyRate = new WeekendLoyaltyRate(Money.Any);
            var monday = new DateTime(2020, 3, 16);
            var saturday = new DateTime(2020, 3, 21);
            var sunday = new DateTime(2020, 3, 22);

            weekendLoyaltyRate.Statisfy(monday, RateType.Regular).Should().Be(false);
            weekendLoyaltyRate.Statisfy(saturday, RateType.Regular).Should().Be(false);
            weekendLoyaltyRate.Statisfy(sunday, RateType.Regular).Should().Be(false);
        }

        [Fact]
        public void ShouldSatistyLoyaltyWeekendDay()
        {
            var weekendLoyaltyRate = new WeekendLoyaltyRate(Money.Any);
            var saturday = new DateTime(2020, 3, 21);
            var sunday = new DateTime(2020, 3, 22);

            weekendLoyaltyRate.Statisfy(saturday, RateType.Loyalty).Should().Be(true);
            weekendLoyaltyRate.Statisfy(sunday, RateType.Loyalty).Should().Be(true);
        }
    }
}
