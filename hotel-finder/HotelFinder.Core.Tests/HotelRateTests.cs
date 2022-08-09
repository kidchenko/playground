using System;
using FluentAssertions;
using HotelFinder.Core.Rates;
using Xunit;

namespace HotelFinder.Core.Tests
{
    public class HotelRateTests
    {
        [Fact]
        public void ShouldCreateWeekendRegularRate()
        {
            var weekendRegularRate = new WeekendRegularRate(Money.InDollars(10));

            weekendRegularRate.Fare.Should().Be(Money.InDollars(10));
        }

        [Fact]
        public void ShouldCreateWeekendLoyaltyRate()
        {
            var weekendLoyalty = new WeekendLoyaltyRate(Money.InDollars(10));

            weekendLoyalty.Fare.Should().Be(Money.InDollars(10));
        }

        [Fact]
        public void ShouldCreateWeekdayRegularRate()
        {
            var weekDayRegular = new WeekdayRegularRate(Money.InDollars(10));

            weekDayRegular.Fare.Should().Be(Money.InDollars(10));
        }

        [Fact]
        public void ShouldCreateWeekdayLoyaltyRate()
        {
            var weekendLoyalty = new WeekdayLoyaltyRate(Money.InDollars(10));

            weekendLoyalty.Fare.Should().Be(Money.InDollars(10));
        }
    }
}
