using System;
using FluentAssertions;
using HotelFinder.Core.Rates;
using Xunit;

namespace HotelFinder.Core.Tests
{
    public class WeekendRegularRateTests
    {
        [Fact]
        public void ShouldCreateWeekendRegularRate()
        {
            var weekendRegularRate = new WeekendRegularRate(Money.InDollars(10));

            weekendRegularRate.Fare.Should().Be(Money.InDollars(10));
        }

        [Fact]
        public void ShouldBeRegular()
        {
            var weekendRegularRate = new WeekendRegularRate(Money.Any);

            weekendRegularRate.RateType.Should().Be(RateType.Regular);
        }

        [Fact]
        public void ShouldNotSatistyWeekDay()
        {
            var weekendRegularRate = new WeekendRegularRate(Money.Any);
            var monday = new DateTime(2020, 3, 16);
            var wednesday = new DateTime(2020, 3, 18);

            weekendRegularRate.Statisfy(monday, RateType.Regular).Should().Be(false);
            weekendRegularRate.Statisfy(wednesday, RateType.Regular).Should().Be(false);
        }

        [Fact]
        public void ShouldSatistyWeekendDay()
        {
            var weekendRegularRate = new WeekendRegularRate(Money.Any);
            var saturday = new DateTime(2020, 3, 21);
            var sunday = new DateTime(2020, 3, 22);

            weekendRegularRate.Statisfy(saturday, RateType.Regular).Should().Be(true);
            weekendRegularRate.Statisfy(sunday, RateType.Regular).Should().Be(true);
        }
    }
}
