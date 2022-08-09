using System;
using FluentAssertions;
using Xunit;

namespace HotelFinder.Core.Tests
{
    public class DateRangeTests
    {
        [Fact]
        public void Test()
        {
            var now = DateTime.Now;
            var inTwoDays = now.AddDays(2);
            var range = new DateRange(now, inTwoDays);

            Action<DateTime> action = (DateTime date) => { };
            range.ForEachDay(action);

            //action.Should().
        }
    }
}
