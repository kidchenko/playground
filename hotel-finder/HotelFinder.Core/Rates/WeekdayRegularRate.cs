using System;

namespace HotelFinder.Core.Rates
{
    public record WeekdayRegularRate : HotelRate
    {
        public WeekdayRegularRate(Money rate) : base(rate, RateType.Regular)
        {
        }

        public override bool Statisfy(DateTime date, RateType rateType)
        {
            var isWeekend = date.IsWeekend();
            return !isWeekend && RateType == rateType;
        }
    }
}
