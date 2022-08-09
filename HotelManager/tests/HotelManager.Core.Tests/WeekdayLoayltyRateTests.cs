using System;
using FluentAssertions;
using Xunit;

namespace HotelManager.Core.Tests
{
    public class WeekdayLoayltyRateTests
    {
        [Fact]
        public void ShouldSatisfyForWeekdayLoyalty()
        {
            var rate = new WeekdayLoyaltyRate(100.Dollars());
            var monday = new DateTime(2020, 03, 16);

            var satisfy = rate.Satisfy(monday, true);
            satisfy.Should().BeTrue();
        }

        [Fact]
        public void ShouldNotSatisfyForWeekendRegular()
        {
            var rate = new WeekdayLoyaltyRate(100.Dollars());
            var sunday = new DateTime(2020, 03, 15);

            var satisfy = rate.Satisfy(sunday, false);
            satisfy.Should().BeFalse();
        }

        [Fact]
        public void ShouldNotSatisfyForWeekdayRegular()
        {
            var rate = new WeekdayLoyaltyRate(100.Dollars());
            var monday = new DateTime(2020, 03, 16);

            var satisfy = rate.Satisfy(monday, false);
            satisfy.Should().BeFalse();
        }

        [Fact]
        public void ShouldNotSatisfyForWeekendLoyalty()
        {
            var rate = new WeekdayLoyaltyRate(100.Dollars());
            var sunday = new DateTime(2020, 03, 15);

            var satisfy = rate.Satisfy(sunday, true);
            satisfy.Should().BeFalse();
        }
    }
}
