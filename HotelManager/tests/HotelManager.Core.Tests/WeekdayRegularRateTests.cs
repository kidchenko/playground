using System;
using FluentAssertions;
using Xunit;

namespace HotelManager.Core.Tests
{
    public class WeekdayRegularRateTests
    {
        [Fact]
        public void ShouldSatisfyForWeekdayRegular()
        {
            var rate = new WeekdayRegularyRate(100.Dollars());
            var monday = new DateTime(2020, 03, 16);

            var satisfy = rate.Satisfy(monday, false);
            satisfy.Should().BeTrue();
        }

        [Fact]
        public void ShouldNotSatisfyForWeekdayLoyalty()
        {
            var rate = new WeekdayRegularyRate(100.Dollars());
            var monday = new DateTime(2020, 03, 16);

            var satisfy = rate.Satisfy(monday, true);
            satisfy.Should().BeFalse();
        }

        [Fact]
        public void ShouldNotSatisfyForWeekendLoyalty()
        {
            var rate = new WeekdayRegularyRate(100.Dollars());
            var sunday = new DateTime(2020, 03, 15);

            var satisfy = rate.Satisfy(sunday, true);
            satisfy.Should().BeFalse();
        }

        [Fact]
        public void ShouldNotSatisfyForWeekendRegular()
        {
            var rate = new WeekdayRegularyRate(100.Dollars());
            var sunday = new DateTime(2020, 03, 15);

            var satisfy = rate.Satisfy(sunday, false);
            satisfy.Should().BeFalse();
        }
    }
}
