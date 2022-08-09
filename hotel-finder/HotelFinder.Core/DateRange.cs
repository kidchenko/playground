using System;
using System.Collections.Generic;

namespace HotelFinder.Core
{
    public record DateRange
    {
        public DateRange(DateTime checkin, DateTime checkout)
        {
            Checkin = checkin;
            Checkout = checkout;
        }

        public DateRange()
        {
        }

        public DateTime Checkin { get; init; }
        public DateTime Checkout { get; init; }


        public void ForEachDay(Action<DateTime> action)
        {
            var date = Checkin;
            while (date <= Checkout)
            {
                action(date);
                date = date.AddDays(1);
            }
        }
    }
}
