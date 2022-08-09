using System;
using FluentAssertions;
using Xunit;

namespace HotelManager.Core.Tests
{
    public class WeekendRegularRateTests
    {
        [Fact]
        public void ShouldSatisfyForWeekendRegular()
        {
            var rate = new WeekendRegularRate(100.Dollars());
            var sunday = new DateTime(2020, 03, 15);

            var satisfy = rate.Satisfy(sunday, false);
            satisfy.Should().BeTrue();
        }

        [Fact]
        public void ShouldNotSatisfyForWeekendLoyalty()
        {
            var rate = new WeekendRegularRate(100.Dollars());
            var sunday = new DateTime(2020, 03, 15);

            var satisfy = rate.Satisfy(sunday, true);
            satisfy.Should().BeFalse();
        }
    }
}
