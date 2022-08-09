using System;

namespace HotelFinder.Core.Rates
{
    public record WeekendRegularRate : HotelRate
    {
        public WeekendRegularRate(Money rate) : base(rate, RateType.Regular) { }

        public override bool Statisfy(DateTime date, RateType rateType)
        {
            var isWeekend = date.IsWeekend();
            return isWeekend && this.RateType == rateType;
        }
    }
}
